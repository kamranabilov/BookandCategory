using Api_Task_BookandCategory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_Task_BookandCategory.DAL
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Author).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(6,2)").IsRequired();
            builder.Property(c => c.Year).IsRequired();
        }
    }
}