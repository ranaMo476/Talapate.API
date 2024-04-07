using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repositary.DataContext.Configeruations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Products>
    {
        void IEntityTypeConfiguration<Products>.Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductsTypeId);

            builder.HasOne(p => p.ProductsBrand).WithMany().HasForeignKey(p => p.ProductsBrandId);

            // if you want upgrade to deffirent version  to solve Nullable issue

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
        }
    }
}
