using System;
using AlMarket.MVC.Data;

namespace AlMarket.MVC.Services
{
	public interface IMailService
	{
		Task SendEmailAsync(RequestEmail requestEmail);
	}
}

