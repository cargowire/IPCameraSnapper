using System;
using System.Net;

namespace IPCameraSnapper
{
	/// <summary>Represents an IP Camera that exposes a screenshot via the 'Address' Uri</summary>
	public class Camera
	{
		public Uri Address { get; set; }
		
		/// <summary>Optional credentials if the cameras feed address is secured</summary>
		public ICredentials Credentials { get; set; }

		/// <param name="address">The location of a current screenshot from the cameras feed</param>
		public Camera(Uri address)
		{
			this.Address = address;
		}
	}
}
