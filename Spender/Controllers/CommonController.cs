// // -----------------------------------------------------------------------
// // <copyright file="CommonController.cs"  company="One Call Care Management, Inc.">
// // Copyright (c) One Call Care Management, Inc. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Spender.Controllers
{
	#region Using

	using System.IO;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Web;
	using System.Web.Http;

	#endregion

	public class CommonController : ApiController
	{
		[HttpGet]
		[Route("api/common/getImage/{imageId}")]
		public HttpResponseMessage GetImage(string imageId)
		{
			var response = new HttpResponseMessage();
			string root = HttpContext.Current.Server.MapPath("~/App_Data");
			var filePath = root + "/" + imageId;
			if (File.Exists(filePath))
			{
				response.Content = new StreamContent(File.Open(filePath, FileMode.Open));
				response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
			}

			return response;
		}
	}
}