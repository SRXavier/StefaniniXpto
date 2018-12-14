using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace XPTOModel
{
    public class XPTOContext : DbContext 
    {
        public XPTOContext() : base("XPTO.DB") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }
    }
}
