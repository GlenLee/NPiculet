//using System.Collections.Generic;
//using System.Collections.Concurrent;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Web;

//namespace NPiculet.Logic.Sys
//{
//	public class CertificateKit
//	{
//		private ConcurrentDictionary<string, Certificate> _dict = new ConcurrentDictionary<string, Certificate>();

//		public Certificate Current
//		{
//			get {
//				string key = LoginKit.GetUserSessionCode();
//				if (!_dict.ContainsKey(key)) {
//					var user = LoginKit.GetUserInfo(key);
//					if (user != null) {
//						List<Role> roles = new List<Role>();
//						List<Organization> orgs = new List<Organization>();
//						_dict[key] = new Certificate(user.Id, user.Sn, user.Name, user.Account, 0, "", 0, "", new ReadOnlyCollection<Role>(roles), new ReadOnlyCollection<Organization>(orgs));
//					}
//				}
//				return _dict[key];
//			}
//		}

//		public Certificate Get(string key)
//		{
//			return _dict[key];
//		}

//		public bool InRole(string roleName)
//		{
//			return (from a in this.Current.Roles where a.Name == roleName select a).Count() > 0;
//		}

//		public bool InDept(string deptName)
//		{
//			return (from a in this.Current.Organizations where a.Name == deptName select a).Count() > 0;
//		}
//	}
//}