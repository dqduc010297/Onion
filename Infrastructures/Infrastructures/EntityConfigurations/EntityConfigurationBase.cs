using ApplicationDomains.Core;
using AspNetCore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructures.EntityConfigurations
{
    public abstract class EntityConfigurationBase<TEntity, TKeyType> :EntityConfiguration<TEntity>
        where TEntity: EntityBase<TKeyType>
    {
        public new void Configure(ModelBuilder builder)
        {
            EntityTypeBuilder<TEntity> typeBuilder = builder.Entity<TEntity>();

            typeBuilder.HasKey(p => p.Id);
            typeBuilder.Property(p => p.Id).ValueGeneratedOnAdd();

            OnConfigure(typeBuilder);
        }
    }
}
