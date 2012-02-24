using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

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
			Uri imageUpload = new Uri(this.ftpAddress, NameImage(image));
			FtpWebRequest request = WebRequest.Create(imageUpload) as FtpWebRequest;
			if (request != null)
			{
				request.Method = WebRequestMethods.Ftp.UploadFile;
				if (!string.IsNullOrEmpty(password))
				{
					request.Credentials = new NetworkCredential(this.username, this.password);
				}

				using (var ftpStream = request.GetRequestStream())
				{
					image.Save(ftpStream, ImageFormat.Jpeg);
					ftpStream.Close();
				}
			}
		}

		/// <summary>Provides an appropriate name for the image</summary>
		private string NameImage(Image image)
		{
			return string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".jpg");
		}
	}
}
