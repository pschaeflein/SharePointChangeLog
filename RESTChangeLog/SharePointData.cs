using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schaeflein.Community.RESTChangeLog
{
	public class ChangeQuery
	{
		private bool m_activity;

		private bool m_add;

		private bool m_alert;

		private ChangeToken m_changeTokenEnd;

		private ChangeToken m_changeTokenStart;

		private bool m_contentType;

		private bool m_deleteObject;


		private bool m_field;

		private bool m_file;

		private bool m_folder;

		private bool m_group;

		private bool m_groupMembershipAdd;

		private bool m_groupMembershipDelete;

		private bool m_item;

		private bool m_latestFirst;

		private bool m_list;

		private bool m_move;

		private bool m_navigation;

		private bool m_recursiveAll;

		private bool m_rename;

		private bool m_requireSecurityTrim;

		private bool m_restore;

		private bool m_roleAssignmentAdd;

		private bool m_roleAssignmentDelete;

		private bool m_roleDefinitionAdd;

		private bool m_roleDefinitionDelete;

		private bool m_roleDefinitionUpdate;

		private bool m_securityPolicy;

		private bool m_site;

		private bool m_systemUpdate;

		private bool m_update;

		private bool m_user;

		private bool m_view;

		private bool m_web;


		public bool Activity
		{
			get
			{
				return this.m_activity;
			}
			set
			{
				this.m_activity = value;
			}
		}


		public bool Add
		{
			get
			{
				return this.m_add;
			}
			set
			{
				this.m_add = value;
			}
		}


		public bool Alert
		{
			get
			{
				return this.m_alert;
			}
			set
			{
				this.m_alert = value;
			}
		}


		public ChangeToken ChangeTokenEnd
		{
			get
			{
				return this.m_changeTokenEnd;
			}
			set
			{
				this.m_changeTokenEnd = value;
			}
		}


		public ChangeToken ChangeTokenStart
		{
			get
			{
				return this.m_changeTokenStart;
			}
			set
			{
				this.m_changeTokenStart = value;
			}
		}


		public bool ContentType
		{
			get
			{
				return this.m_contentType;
			}
			set
			{
				this.m_contentType = value;
			}
		}


		public bool DeleteObject
		{
			get
			{
				return this.m_deleteObject;
			}
			set
			{
				this.m_deleteObject = value;
			}
		}

		public bool Field
		{
			get
			{
				return this.m_field;
			}
			set
			{
				this.m_field = value;
			}
		}


		public bool File
		{
			get
			{
				return this.m_file;
			}
			set
			{
				this.m_file = value;
			}
		}


		public bool Folder
		{
			get
			{
				return this.m_folder;
			}
			set
			{
				this.m_folder = value;
			}
		}


		public bool Group
		{
			get
			{
				return this.m_group;
			}
			set
			{
				this.m_group = value;
			}
		}


		public bool GroupMembershipAdd
		{
			get
			{
				return this.m_groupMembershipAdd;
			}
			set
			{
				this.m_groupMembershipAdd = value;
			}
		}


		public bool GroupMembershipDelete
		{
			get
			{
				return this.m_groupMembershipDelete;
			}
			set
			{
				this.m_groupMembershipDelete = value;
			}
		}


		public bool Item
		{
			get
			{
				return this.m_item;
			}
			set
			{
				this.m_item = value;
			}
		}


		public bool LatestFirst
		{
			get
			{
				return this.m_latestFirst;
			}
			set
			{
				this.m_latestFirst = value;
			}
		}


		public bool List
		{
			get
			{
				return this.m_list;
			}
			set
			{
				this.m_list = value;
			}
		}


		public bool Move
		{
			get
			{
				return this.m_move;
			}
			set
			{
				this.m_move = value;
			}
		}


		public bool Navigation
		{
			get
			{
				return this.m_navigation;
			}
			set
			{
				this.m_navigation = value;
			}
		}


		public bool RecursiveAll
		{
			get
			{
				return this.m_recursiveAll;
			}
			set
			{
				this.m_recursiveAll = value;
			}
		}


		public bool Rename
		{
			get
			{
				return this.m_rename;
			}
			set
			{
				this.m_rename = value;
			}
		}


		public bool RequireSecurityTrim
		{
			get
			{
				return this.m_requireSecurityTrim;
			}
			set
			{
				this.m_requireSecurityTrim = value;
			}
		}


		public bool Restore
		{
			get
			{
				return this.m_restore;
			}
			set
			{
				this.m_restore = value;
			}
		}


		public bool RoleAssignmentAdd
		{
			get
			{
				return this.m_roleAssignmentAdd;
			}
			set
			{
				this.m_roleAssignmentAdd = value;
			}
		}


		public bool RoleAssignmentDelete
		{
			get
			{
				return this.m_roleAssignmentDelete;
			}
			set
			{
				this.m_roleAssignmentDelete = value;
			}
		}


		public bool RoleDefinitionAdd
		{
			get
			{
				return this.m_roleDefinitionAdd;
			}
			set
			{
				this.m_roleDefinitionAdd = value;
			}
		}


		public bool RoleDefinitionDelete
		{
			get
			{
				return this.m_roleDefinitionDelete;
			}
			set
			{
				this.m_roleDefinitionDelete = value;
			}
		}


		public bool RoleDefinitionUpdate
		{
			get
			{
				return this.m_roleDefinitionUpdate;
			}
			set
			{
				this.m_roleDefinitionUpdate = value;
			}
		}


		public bool SecurityPolicy
		{
			get
			{
				return this.m_securityPolicy;
			}
			set
			{
				this.m_securityPolicy = value;
			}
		}


		public bool Site
		{
			get
			{
				return this.m_site;
			}
			set
			{
				this.m_site = value;
			}
		}


		public bool SystemUpdate
		{
			get
			{
				return this.m_systemUpdate;
			}
			set
			{
				this.m_systemUpdate = value;
			}
		}

		public bool Update
		{
			get
			{
				return this.m_update;
			}
			set
			{
				this.m_update = value;
			}
		}


		public bool User
		{
			get
			{
				return this.m_user;
			}
			set
			{
				this.m_user = value;
			}
		}


		public bool View
		{
			get
			{
				return this.m_view;
			}
			set
			{
				this.m_view = value;
			}
		}


		public bool Web
		{
			get
			{
				return this.m_web;
			}
			set
			{
				this.m_web = value;
			}
		}

		public ChangeQuery()
		{
		}

		public ChangeQuery(bool allChangeObjectTypes, bool allChangeTypes)
		{
			this.InitQuery(allChangeObjectTypes, allChangeTypes);
		}

		private void InitQuery(bool allChangeObjectTypes, bool allChangeTypes)
		{
			if (allChangeObjectTypes)
			{
				this.m_item = true;
				this.m_list = true;
				this.m_web = true;
				this.m_site = true;
				this.m_file = true;
				this.m_folder = true;
				this.m_alert = true;
				this.m_user = true;
				this.m_group = true;
				this.m_contentType = true;
				this.m_field = true;
				this.m_securityPolicy = true;
				this.m_view = true;
			}
			if (allChangeTypes)
			{
				this.m_add = true;
				this.m_update = true;
				this.m_deleteObject = true;
				this.m_rename = true;
				this.m_move = true;
				this.m_restore = true;
				this.m_roleDefinitionAdd = true;
				this.m_roleDefinitionDelete = true;
				this.m_roleDefinitionUpdate = true;
				this.m_roleAssignmentAdd = true;
				this.m_roleAssignmentDelete = true;
				this.m_groupMembershipAdd = true;
				this.m_groupMembershipDelete = true;
				this.m_systemUpdate = true;
				this.m_navigation = true;
			}
		}
	}

	public class ChangeToken
	{
		private string m_stringValue;
		public string StringValue
		{
			get
			{
				return this.m_stringValue;
			}
			set
			{
				this.m_stringValue = value;
			}
		}
	}
}



