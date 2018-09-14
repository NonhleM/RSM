using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RSM.Models;

namespace RSM.Models
{
    public class RSMContext : DbContext
    {
        public RSMContext (DbContextOptions<RSMContext> options)
            : base(options)
        {
        }

        public DbSet<RSM.Models.box> box { get; set; }

        public DbSet<RSM.Models.checklist> checklist { get; set; }

        public DbSet<RSM.Models.order> order { get; set; }

        public DbSet<RSM.Models.repair> repair { get; set; }

        public DbSet<RSM.Models.resource> resource { get; set; }

        public DbSet<RSM.Models.service> service { get; set; }

        public DbSet<RSM.Models.task> task { get; set; }

        public DbSet<RSM.Models.team> team { get; set; }

        public DbSet<RSM.Models.user> user { get; set; }

        public DbSet<RSM.Models.boxResource> boxResource { get; set; }

        public DbSet<RSM.Models.checklistResource> checklistResource { get; set; }

        public DbSet<RSM.Models.orderItems> orderItems { get; set; }

        public DbSet<RSM.Models.teamLeader> teamLeader { get; set; }
    }
}
