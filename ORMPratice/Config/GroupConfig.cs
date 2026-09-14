using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORMPratice.Entities;

namespace ORMPratice.Config;

public class GroupConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id); // Set the primary key for the Group entity

        builder.Property(g => g.Name) // Configure the Name property
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(g => g.Limit) // Configure the Limit property
               .IsRequired();
    }
}
