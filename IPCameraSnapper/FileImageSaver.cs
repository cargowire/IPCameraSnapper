using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace IPCameraSnapper
{
	/// <summary>Saves an image to the filesystem</summary>
	public class FileImageSaver : IImageSaver
	{
		private string filePath;
		
		/// <param name="filePath">A valid path to a folder location for the image to be stored</param>
		public FileImageSaver(string filePath)
		{
			this.filePath = filePath;
		}

		/// <summary>Synchronously saves the image to the filesystem</summary>
		/// <param name="image">The image to save</param>
		public void SaveImage(Image image)
		{
			var fileName = System.IO.Path.Combine(filePath, NameImage(image));
			image.Save(fileName, ImageFormat.Jpeg);
		}

		/// <summary>Provides an appropriate name for the image</summary>
		private string NameImage(Image image)
		{
			return string.Concat(DateTime.Now.ToString("yyyyMMdd_HHmmss"), ".jpg");
		}
	}
}
