using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey("Id");

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
                .HasColumnName("First Name")
                .IsRequired();

            
            builder.Property(p => p.LastName)
                .HasColumnName("Last Name")
                .IsRequired();

            builder.HasMany(p => p.Adresses).WithOne(p => p.Person)
                    .HasForeignKey(p => p.PersonId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }