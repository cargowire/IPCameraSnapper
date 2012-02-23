using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace IPCameraSnapper
{
	/// <summary>Saves an image to an FTP location</summary>
	public class FTPImageSaver : IImageSaver
	{
		private Uri ftpAddress;
		private string username;
		private string password;

		public FTPImageSaver(Uri ftpAddress)
			:this(ftpAddress, null, null)
		{
		}
		public FTPImageSaver(Uri ftpAddress, string username, string password)
		{
			this.ftpAddress = ftpAddress;
			this.username = username;
			this.password = password;
		}

		/// <summary>Synchronously saves the image to the FTP location</summary>
		/// <param name="image">The image to save</param>
		public void SaveImage(Image image)
		{
			//TODO: Implement FTP saving for easy integration between local and live websites
			throw new NotImplementedException();
		}
	}
}
