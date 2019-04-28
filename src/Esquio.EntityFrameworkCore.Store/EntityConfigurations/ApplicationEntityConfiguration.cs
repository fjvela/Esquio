﻿using Esquio.EntityFrameworkCore.Store.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esquio.EntityFrameworkCore.Store.EntityConfigurations
{
    internal class ApplicationEntityConfiguration : IEntityTypeConfiguration<Entities.ApplicationEntity>
    {
        private readonly StoreOptions storeOption;

        public ApplicationEntityConfiguration(StoreOptions storeOption)
        {
            this.storeOption = storeOption;
        }

        public void Configure(EntityTypeBuilder<Entities.ApplicationEntity> builder)
        {
            builder.ToTable(storeOption.Features);
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2000).IsRequired();
            builder.HasMany(x => x.Features).WithOne(x => x.Application).HasForeignKey(x => x.ApplicationId);
        }
    }
}