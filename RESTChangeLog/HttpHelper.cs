using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Schaeflein.Community.RESTChangeLog
{
	class HttpHelper
	{
		private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"] ?? ConfigurationManager.AppSettings["ida:ClientID"];
		private static string clientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"] ?? ConfigurationManager.AppSettings["ida:AppKey"] ?? ConfigurationManager.AppSettings["ida:Password"];

		public static async Task<string> GetTokenAsync(string resourceId, string tenantId, ClientAssertionCertificate cac)
		{
			try
			{
				LoggerCallbackHandler.Callback = new AdalLoggerCallback();
				AuthenticationContext authContext =
						new AuthenticationContext("https://login.microsoftonline.com/" + tenantId);

				AuthenticationResult authResult =
						await authContext.AcquireTokenAsync(resourceId, cac);


				return authResult.AccessToken;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public static async Task<string> GetSecuredHttpResource(string url, string token)
		{
			string responseContent = String.Empty;

			var client = new HttpClient();
			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(url),
				Method = HttpMethod.Get,
			};
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
			HttpResponseMessage response = await client.SendAsync(request);
			responseContent = await response.Content.ReadAsStringAsync();

			return responseContent;
		}

		public static async Task<string> PostSecuredHttpResource(string url, string token, string payload)
		{
			string responseContent = String.Empty;

			var client = new HttpClient();
			var request = new HttpRequestMessage()
			{
				RequestUri = new Uri(url),
				Method = HttpMethod.Post,
			};
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			request.Content = new StringContent(payload,Encoding.UTF8,"application/json");

			HttpResponseMessage response = await client.SendAsync(request);
			responseContent = await response.Content.ReadAsStringAsync();

			return responseContent;

		}
	}
}
