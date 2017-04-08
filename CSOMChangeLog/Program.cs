using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CSOMChangeLog
{
	class Program
	{
		static void Main(string[] args)
		{
			const string siteUrl = "[your-site-here]";
			ChangeToken chgToken = default(ChangeToken);

			ClientContext clientContext = new ClientContext(siteUrl);
			clientContext.Credentials = new SharePointOnlineCredentials("[your-login]", ConvertToSecureString("[your-password]"));

			var site = clientContext.Site;

			ChangeQuery siteCQ = new ChangeQuery(true, true);
			var siteChanges = site.GetChanges(siteCQ);
			clientContext.Load(siteChanges);
			clientContext.ExecuteQuery();

			string changeType = String.Empty;
			string itemId = String.Empty;


			foreach (Change change in siteChanges)
			{
				Console.WriteLine($"{change.ChangeType}, {change.TypedObject}, {change.ChangeToken.StringValue}");

				if (change is Microsoft.SharePoint.Client.ChangeItem)
				{
					ChangeItem ci = change as ChangeItem;
					Console.WriteLine($"{ci.ItemId}: {change.Time}");
				}
			}

			var web = clientContext.Web;
			clientContext.Load(web);

			var list = web.Lists.GetByTitle("Documents");
			clientContext.Load(list, l => l.Title, l => l.CurrentChangeToken);
			clientContext.ExecuteQuery();

			Console.WriteLine($"List {list.Title}: {list.CurrentChangeToken.StringValue}");


			chgToken = list.CurrentChangeToken;
			ChangeQuery cq = new ChangeQuery(false, false);
			cq.Item = true;
			cq.Add = true;
			cq.Update = true;
			cq.Restore = true;
			cq.ChangeTokenStart = chgToken;

			var changes = list.GetChanges(cq);
			clientContext.Load(changes);

			clientContext.ExecuteQuery();

			foreach (Change change2 in changes)
			{
				if (change2 is Microsoft.SharePoint.Client.ChangeItem)
				{
					ChangeItem ci = change2 as ChangeItem;
					changeType = ci.ChangeType.ToString();
					itemId = ci.ItemId.ToString();
					Console.WriteLine("{0}: {1}", itemId, changeType);

					if (ci.ChangeType == ChangeType.Add)
					{
						ListItem li = list.GetItemById(ci.ItemId);
						clientContext.Load(li);
						clientContext.ExecuteQuery();

						FieldUserValue author = (FieldUserValue) li["Author"];
						Console.WriteLine("  {0}", author.Email);
					}
				}
			}
		}

		private static SecureString ConvertToSecureString(string value)
		{
			SecureString secString = new SecureString();
			Array.ForEach(value.ToArray(), secString.AppendChar);
			secString.MakeReadOnly();
			return secString;
		}
	}
}
