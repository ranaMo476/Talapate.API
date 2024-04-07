using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repositary.DataContext
{
    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // this is best method to applay configration auto so when added new file config not need to update the code

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Products> products;
        DbSet<ProductsBrand> productsBrands;    
            DbSet<ProductType> productsType;
    }
}
