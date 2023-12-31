﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Repository.Configurations
{
    internal class SuplierConfiguration : IEntityTypeConfiguration<Suplier>
    {
        public void Configure(EntityTypeBuilder<Suplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.TaxNumber).IsRequired().HasMaxLength(10);

            builder.ToTable("Supliers");
        }
    }
}
