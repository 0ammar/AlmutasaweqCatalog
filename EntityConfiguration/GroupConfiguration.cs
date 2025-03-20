﻿using AlmutasaweqCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmutasaweqCatalog.EntityConfiguration
{
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			// ID
			builder.ToTable("Groups");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).IsRequired();

			// IsDeleted
			builder.Property(u => u.IsDeleted).HasDefaultValue(false);

			// CreationDate
			builder.Property(u => u.CreationDate).IsRequired().HasDefaultValueSql("GETDATE()");

			// Names
			builder.Property(x => x.Name).IsRequired(true).IsUnicode(false).HasMaxLength(50);
			builder.HasIndex(x => x.Name).IsUnique(true);
			builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(Name) >= 3"));

			builder.HasMany<SubOne>().WithOne().HasForeignKey(x => x.GroupId);
		}
	}
}
