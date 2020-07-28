using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey("Id");

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Street)
                .IsRequired();

            builder.Property(p => p.PostalCode)
                .HasColumnName("Postal Code")
                .IsRequired();
            
            builder.Property(p => p.City)
                .IsRequired();
        }
    }