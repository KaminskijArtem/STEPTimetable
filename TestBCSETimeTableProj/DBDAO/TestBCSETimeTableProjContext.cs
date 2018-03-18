using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestBCSETimeTableProj.DBDAO
{
    public class TestBCSETimeTableProjContext : DbContext
    {
        public TestBCSETimeTableProjContext() : base("name=BSACEntities")
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Facultys { get; set; }
        public DbSet<Flow> Flows { get; set; }
    }
}