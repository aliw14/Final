using System;
using Microsoft.AspNetCore.Identity;

namespace AlMarket.MVC.Data
{
	public class LocalizeIdentityError : IdentityErrorDescriber
	{
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Description = "Email tekrarlana bilmez",

				Code = "101"
			};
		}
	}
}

