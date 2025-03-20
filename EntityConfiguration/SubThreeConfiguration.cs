using AlmutasaweqCatalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlmutasaweqCatalog.EntityConfiguration
{
	public class SubThreeConfiguration : IEntityTypeConfiguration<SubThree>
	{
		public void Configure(EntityTypeBuilder<SubThree> builder)
		{
			// ID
			builder.ToTable("SubThrees");
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

			builder.HasMany<Item>().WithOne().HasForeignKey(x => x.SubThreeId);
		}
	}
}
