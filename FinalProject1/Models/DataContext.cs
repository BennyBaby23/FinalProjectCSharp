using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject1.Models;

namespace FinalProject1.Models
{
    public class DataContext : DbContext
    {
        public DbSet<AboutProduct> FinalProject { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<FinalProject1.Models.AboutProduct> AboutProuct { get; set; }
        public DbSet<FinalProject1.Models.ProuctSore> ProuctSore { get; set; }
        public DbSet<FinalProject1.Models.ProuctOverview> ProuctOverview { get; set; }
        public DbSet<FinalProject1.Models.BuyerInfo> BuyerInfo { get; set; }
        public DbSet<FinalProject1.Models.PaymentInfo> PaymentInfo { get; set; }
    }
}
