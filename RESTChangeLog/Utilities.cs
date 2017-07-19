using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Schaeflein.Community.RESTChangeLog
{
	internal class Utilities
	{
		internal static X509Certificate2 GetAppCertificate(string certPath, string certificatePassword)
		{
			// For details: https://blogs.msdn.microsoft.com/richard_dizeregas_blog/2015/05/03/performing-app-only-operations-on-sharepoint-online-through-azure-ad/
			//NOTE: This is a hack...Azure Key Vault is best approach
			//certPath = certPath.Substring(0, certPath.LastIndexOf('\\')) + "\\O365AppOnly_private.pfx";
			var certfile = System.IO.File.OpenRead(certPath);
			var certificateBytes = new byte[certfile.Length];
			certfile.Read(certificateBytes, 0, (int)certfile.Length);
			var cert = new X509Certificate2(
					certificateBytes,
					certificatePassword,
					X509KeyStorageFlags.Exportable |
					X509KeyStorageFlags.MachineKeySet |
					X509KeyStorageFlags.PersistKeySet); //switchest are important to work in webjob
			return cert;
		}

		internal static string GetSharePointHost(string url)
		{
			Uri theHost = new Uri(url);
			return $"{theHost.Scheme}://{theHost.Host}/";
		}
	}
}
