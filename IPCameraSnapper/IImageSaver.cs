using System.Drawing;

namespace IPCameraSnapper
{
	public interface IImageSaver
	{
		/// <summary>Synchronously saves the image to the filesystem</summary>
		/// <param name="image">The image to save</param>
		void SaveImage(Image image);
	}
}