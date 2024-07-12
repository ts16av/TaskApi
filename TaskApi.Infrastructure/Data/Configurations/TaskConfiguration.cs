using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskApi.Domain.Entities;

namespace TaskApi.Infrastructure.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("tasks");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.Status);
    }
}