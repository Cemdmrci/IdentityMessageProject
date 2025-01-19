using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
	public class IdentityContext : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-AHMBJB5\\SQLEXPRESS;initial catalog=IdentityMessageDb;integrated security=true;");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}
