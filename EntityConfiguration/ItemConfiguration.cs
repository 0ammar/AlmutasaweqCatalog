using AlmutasaweqCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmutasaweqCatalog.EntityConfiguration
{
	public class ItemConfiguration : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			// ID
			builder.ToTable("Items");
			builder.HasKey(x => x.ItemNo);
			builder.Property(x => x.ItemNo).IsRequired();

			// IsDeleted
			builder.Property(u => u.IsDeleted).HasDefaultValue(false);

			// CreationDate
			builder.Property(u => u.CreationDate).IsRequired().HasDefaultValueSql("GETDATE()");

			// Names
			builder.Property(x => x.Name).IsRequired(true).IsUnicode(false).HasMaxLength(50);
			builder.HasIndex(x => x.Name).IsUnique(true);
			builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(Name) >= 3"));

			// Price
			builder.Property(p => p.Price).IsRequired().HasDefaultValue(0).HasPrecision(18, 2);
			builder.ToTable(x => x.HasCheckConstraint("CH_Price_Positive", "[Price] >= 0"));

			// Image
			builder.Property(x => x.Image)
			   .HasMaxLength(255)
			   .IsUnicode(false)
			   .IsRequired(false);
		}
	}
}
