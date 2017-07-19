using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Claims;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace CSOMChangeLog
{
	class ContextProvider
	{
		//  https://github.com/SharePoint/sp-dev-samples/blob/master/Samples/WebHooks.List.AzureAD/SharePoint.WebHooks.Common/ContextProvider.cs
		public static ClientContext GetAppOnlyClientContext(String siteUrl, string clientId, string tenantId, string certificatePath, string certificatePassword)
		{
			AuthenticationManager authManager = new AuthenticationManager();
			ClientContext context = authManager.GetAzureADAppOnlyAuthenticatedContext(
					siteUrl,
					clientId,
					tenantId,
					certificatePath, certificatePassword);

			return (context);
		}

		private static string GetSharePointHost(string url)
		{
			// https://samlman.wordpress.com/2015/02/27/using-adal-access-tokens-with-o365-rest-apis-and-csom/
			Uri theHost = new Uri(url);
			return $"{theHost.Scheme}://{theHost.Host}/";
		}

	}
}
