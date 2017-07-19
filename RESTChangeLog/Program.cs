using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Schaeflein.Community.RESTChangeLog
{
	class Program
	{
		static void Main(string[] args)
		{
			const string siteUrl = "[your-site-here]";

			string tenantId = ConfigurationManager.AppSettings["TenantId"];
			string clientId = ConfigurationManager.AppSettings["ClientId"];
			string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];

			string certificatePath     = ConfigurationManager.AppSettings["CertificatePath"];
			string certificatePassword = ConfigurationManager.AppSettings["CertificatePassword"];

			string token = default(string);
			var cac = new ClientAssertionCertificate(clientId, Utilities.GetAppCertificate(certificatePath, certificatePassword));
			AsyncContext.Run((Action)(async () =>
			{
				token = await HttpHelper.GetTokenAsync(Utilities.GetSharePointHost(siteUrl), tenantId, cac);
			}));


			/////
			/////  https://msdn.microsoft.com/en-us/library/office/dn600183.aspx#bk_ChangeQuery
			/////
			string changeCollection = default(string);
			AsyncContext.Run((Action)(async () =>
			{
				string query = "{'query': {'Activity':false,'Add':true,'Alert':true,'ChangeTokenEnd':null,'ChangeTokenStart':null,'ContentType':true,'DeleteObject':true,'Field':true,'File':true,'Folder':true,'Group':true,'GroupMembershipAdd':true,'GroupMembershipDelete':true,'Item':true,'LatestFirst':false,'List':true,'Move':true,'Navigation':true,'RecursiveAll':false,'Rename':true,'RequireSecurityTrim':false,'Restore':true,'RoleAssignmentAdd':true,'RoleAssignmentDelete':true,'RoleDefinitionAdd':true,'RoleDefinitionDelete':true,'RoleDefinitionUpdate':true,'SecurityPolicy':true,'Site':true,'SystemUpdate':true,'Update':true,'User':true,'View':true,'Web':true}}";
				changeCollection = await HttpHelper.PostSecuredHttpResource($"{siteUrl}/_api/web/GetChanges", token, query);
			}));

			var x = changeCollection.Length;
		}

		// This code would need to parse the JSON results....

		//private void holdfornow()
		//{
		//	string changeType = String.Empty;
		//	string itemId = String.Empty;


		//	foreach (Change change in siteChanges)
		//	{
		//		Console.WriteLine("{0}, {1}", change.ChangeType, change.TypedObject);

		//		if (change is Microsoft.SharePoint.Client.ChangeItem)
		//		{
		//			ChangeItem ci = change as ChangeItem;
		//			Console.WriteLine("{0}: {1}", ci.ItemId, change.Time);
		//		}
		//	}

		//	var web = clientContext.Web;
		//	clientContext.Load(web);
		//	clientContext.ExecuteQuery();

		//	var list = web.Lists.GetByTitle("Client Documents");
		//	clientContext.Load(list);


		//	//ChangeQuery cq = new ChangeQuery(true, true);
		//	ChangeQuery cq = new ChangeQuery(false, false);
		//	cq.Item = true;
		//	cq.Add = true;
		//	cq.Update = true;
		//	cq.Restore = true;


		//	var changes = list.GetChanges(cq);
		//	clientContext.Load(changes);

		//	clientContext.ExecuteQuery();

		//	foreach (Change change2 in changes)
		//	{
		//		if (change2 is Microsoft.SharePoint.Client.ChangeItem)
		//		{
		//			ChangeItem ci = change2 as ChangeItem;
		//			changeType = ci.ChangeType.ToString();
		//			itemId = ci.ItemId.ToString();
		//			Console.WriteLine("{0}: {1}", itemId, changeType);

		//			if (ci.ChangeType == ChangeType.Add)
		//			{
		//				ListItem li = list.GetItemById(ci.ItemId);
		//				clientContext.Load(li);
		//				clientContext.ExecuteQuery();

		//				FieldUserValue uv = new FieldUserValue();
		//				Console.WriteLine("  {0}", li["LicensedUser"]);
		//			}
		//		}
		//	}
		//}

		private static SecureString ConvertToSecureString(string value)
		{
			SecureString secString = new SecureString();
			Array.ForEach(value.ToArray(), secString.AppendChar);
			secString.MakeReadOnly();
			return secString;
		}
	}
}
