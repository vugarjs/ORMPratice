using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORMPratice.Entities;

namespace ORMPratice.Config
{
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id); // Set the primary key for the Student entity

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100); // Set the Name property as required with a maximum length of 100 characters

            builder.Property(s => s.Surname).IsRequired().HasMaxLength(100); // Set the Surname property as required with a maximum length of 100 characters

            builder.Property(s => s.Email).IsRequired().HasMaxLength(255);// Set the Email property as required with a maximum length of 255 characters

            builder.Property(s => s.BirthDate).IsRequired(); // Set the BirthDate property as required

            builder.Property(s => s.GroupId).IsRequired(); // Set the GroupId property as required

            builder.HasOne(s => s.Group) // Configure the relationship between Student and Group entities
               .WithMany(g => g.Students)
               .HasForeignKey(s => s.GroupId); // Set the foreign key for the relationship
        }
    }
}
