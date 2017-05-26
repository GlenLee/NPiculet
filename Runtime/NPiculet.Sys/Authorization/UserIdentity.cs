using System;
using System.Security.Principal;
using NPiculet.Logic;

namespace NPiculet.Authorization
{
	public class UserIdentity<TKey> : IIdentity
	{
		public UserIdentity(User<TKey> user)
		{
			if (user != null) {
				User = user;
				IsAuthenticated = true;
				Name = user.Name;
			}
		}
	
		public string Name { get; private set; }

		public string AuthenticationType { get { return "UserIdentity"; } }

		public bool IsAuthenticated { get; private set; }

		public User<TKey> User { get; private set; }
	}
}