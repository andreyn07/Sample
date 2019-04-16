using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class DBContext : DbContext
{
    
    public DBContext() : base("name=DefaultConnection")
    {
    }

    public DbSet<JetSpring.Models.Event> Events { get; set; }

    public DbSet<JetSpring.Models.Attendance> Attendances { get; set; }
}
