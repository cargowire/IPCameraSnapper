using System;
using System.Drawing;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace IPCameraSnapper
{
	/// <summary>Retrives a screenshot of the current camera feed</summary>
	public class ImageRetriever
	{
		/// <summary>Returns an image instance that represents the current camera feed.  Throws ImageUnavailableException if
		/// a valid image cannot be returned.</summary>
		/// <param name="camera">The camera to retrieve the image from.  If the camera includes credentials these are used
		/// as part of the getting image process</param>
		public Image GetImage(Camera camera)
		{
			// This is probably local so if the camera lies behind an untrusted certifcate just permit it anyway
			ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

			Image cameraImage = null;

			WebRequest imageRequest = WebRequest.Create(camera.Address);
			if (camera.Credentials != null)
			{
				imageRequest.UseDefaultCredentials = false;
				imageRequest.Credentials = camera.Credentials;
			}

			try
			{
				using (var imageResponse = imageRequest.GetResponse())
				{
					using (var imageStream = imageResponse.GetResponseStream())
					{
						cameraImage = Image.FromStream(imageStream);
					}
				}
			}
			catch (Exception ex) // Should be more specific
			{
				throw new ImageUnavailableException("Unable to retrieve image from camera", ex);
			}

			return cameraImage;
		}

		private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
		{
			return true;
		}
	}
}
