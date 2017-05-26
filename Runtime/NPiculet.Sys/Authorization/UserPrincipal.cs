using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NPiculet.Authorization
{
	public class UserPrincipal<TKey> : IPrincipal
	{
		public UserPrincipal(UserIdentity<TKey> identity)
		{
			Identity = identity;
		}

		public UserPrincipal(User<TKey> user)
			: this(new UserIdentity<TKey>(user))
		{

		}

		public UserIdentity<TKey> Identity { get; private set; }

		IIdentity IPrincipal.Identity
		{
			get { return Identity; }
		}

		public bool IsInRole(string role)
		{
			throw new NotImplementedException();
		}

	}
}
