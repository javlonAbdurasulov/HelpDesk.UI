using HelpDesk.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext() { }
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{
		}
		public DbSet<User> Users{ get; set; }
		public DbSet<Role> Roles{ get; set; }
		public DbSet<Letter> Letters{ get; set; }
		public DbSet<Forma> Formas{ get; set; }

	}
}
