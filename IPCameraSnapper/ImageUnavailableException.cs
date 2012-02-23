using System;

namespace IPCameraSnapper
{
	/// <summary>Represents an error in image retrieval from the camera</summary>
	public class ImageUnavailableException : Exception
	{
		public ImageUnavailableException()
			: base()
		{
		}
		public ImageUnavailableException(string message) 
			: base(message)
		{
		}
		public ImageUnavailableException(string message, Exception innerException) 
			: base(message, innerException)
		{
		}
	}
}
