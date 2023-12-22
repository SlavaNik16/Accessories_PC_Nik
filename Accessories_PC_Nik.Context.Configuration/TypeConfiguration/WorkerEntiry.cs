﻿using Accessories_PC_Nik.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accessories_PC_Nik.Context.Configuration.TypeConfiguration
{
    internal class WorkerEntiry : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("TWorker");
            builder.HasIdAsKey();
            builder.PropertyAuditConfiguration();

            builder.Property(x => x.Number).IsRequired().HasMaxLength(80); ;
            builder.Property(x => x.Series).IsRequired();
            builder.Property(x => x.IssuedAt).IsRequired();
            builder.Property(x => x.IssuedBy).IsRequired();
            builder.Property(x => x.DocumentType).IsRequired();
            builder.Property(x => x.AccessLevel).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();

            builder.HasIndex(x => x.Number)
                .IsUnique()
                .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                .HasDatabaseName($"IX_{nameof(Worker)}_" +
                             $"{nameof(Worker.Number)}");

            builder.HasIndex(x => x.Series)
                 .IsUnique()
                 .HasFilter($"{nameof(Worker.DeletedAt)} is null")
                 .HasDatabaseName($"IX_{nameof(Worker)}_" +
                              $"{nameof(Worker.Series)}");

        }
    }
}
