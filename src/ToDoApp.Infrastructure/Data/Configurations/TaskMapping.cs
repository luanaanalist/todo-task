
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure.Data.Configurations
{
    public class TaskMapping : IEntityTypeConfiguration<ItemTask>
    {
        public void Configure(EntityTypeBuilder<ItemTask> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.CreatedAt).IsRequired();
        }
    }
}
