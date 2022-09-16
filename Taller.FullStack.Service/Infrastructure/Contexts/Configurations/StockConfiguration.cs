﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Taller.FullStack.Service.Infrastructure.Contexts;
using Taller.FullStack.Service.Infrastructure.Entities;

namespace Taller.FullStack.Service.Infrastructure.Contexts.Configurations
{
    public partial class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> entity)
        {
            entity.HasKey(e => new { e.StoreId, e.ProductId })
                .HasName("PK__stocks__E68284D33AF83C00");

            entity.ToTable("stocks", "production");

            entity.Property(e => e.StoreId).HasColumnName("store_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__stocks__product___3F466844");

            entity.HasOne(d => d.Store)
                .WithMany(p => p.Stocks)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__stocks__store_id__3E52440B");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Stock> entity);
    }
}
