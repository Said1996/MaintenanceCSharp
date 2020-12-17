using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Core.Models
{
    public class DeviceContext : DbContext
    {
        public DbSet<ClientDevice> ClientDevices { get; set; }

        public DbSet<User> Users { get; set; }
        
    }
}
