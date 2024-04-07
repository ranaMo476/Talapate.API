using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repositary.DataContext.Configurations
{
    internal class ProductBrandConfigurations : IEntityTypeConfiguration<ProductsBrand>
    {
        public void Configure(EntityTypeBuilder<ProductsBrand> builder)
        {
            // it is refere to data anotation by fluent api added on attribute
           builder.Property(p =>p.Name).IsRequired();
        }
    }
}
