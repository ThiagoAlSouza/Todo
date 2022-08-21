using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Mappings;

public class TodoMap : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TODO");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("varchar(70)")
            .HasColumnName("TITLE");

        builder.Property(x => x.Date)
            .HasColumnName("DATE");

        builder.Property(x => x.Done)
            .HasColumnType("bit")
            .HasColumnName("DONE");

        builder.Property(x => x.User)
            .IsRequired()
            .HasColumnType("varchar(70)")
            .HasColumnName("USER");

        builder.HasIndex(x => x.User);
    }
}