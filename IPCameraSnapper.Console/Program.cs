using System;
using System.Configuration;
using System.Net;
using System.Threading;

namespace IPCameraSnapper.Console
{
	/// <summary>Until exited by a keypress will continually retrieve and save snapshots from the specified IP camera at intervals
	/// as specified by the first argument.  If no argument is supplied only one screenshot is taken</summary>
	class Program
	{
		private static Camera camera;
		private static IImageSaver saver;
		private static ImageRetriever retriever;

		static void Main(string[] args)
		{
			// Get my dirty XML config
			string cameraAddress = ConfigurationManager.AppSettings["CameraAddress"];
			string cameraUsername = ConfigurationManager.AppSettings["CameraUsername"];
			string cameraPassword = ConfigurationManager.AppSettings["CameraPassword"];
			string snapshotFolder = ConfigurationManager.AppSettings["SnapshotFolder"];
			// FTP Option
			string ftpAddress = ConfigurationManager.AppSettings["FTPAddress"];
			string ftpUsername = ConfigurationManager.AppSettings["FTPUsername"];
			string ftpPassword = ConfigurationManager.AppSettings["FTPPassword"];

			// Setup
			camera = new Camera(new Uri(cameraAddress));
			if(!string.IsNullOrEmpty(cameraPassword))
				camera.Credentials = new NetworkCredential(cameraUsername, cameraPassword);

			saver = new FileImageSaver(snapshotFolder);
			//saver = new FTPImageSaver(new Uri(ftpAddress), ftpUsername, ftpPassword);
			retriever = new ImageRetriever();

			int seconds;
			if (args.Length > 0 && int.TryParse(args[0], out seconds))
			{
				Timer timer = new Timer(TimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(seconds));
				System.Console.ReadLine(); // Chillout and wait for the timer mo'fo
			}
			else
			{
				TimerTick(null); // Force it once
			}
		}

		static void TimerTick(object state)
		{
			try
			{
				saver.SaveImage(retriever.GetImage(camera));
			}
			catch (ImageUnavailableException ex) // Allow the caller to see that certain image attempts failed
			{
				System.Console.WriteLine(string.Concat("Image unavailable at ", DateTime.Now.ToString("yyyy-MMM-dd HH:mm:ss")));
			}
		}
	}
}
