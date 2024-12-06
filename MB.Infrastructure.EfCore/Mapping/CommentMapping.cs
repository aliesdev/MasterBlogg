using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping;

public class CommentMapping: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name);
        builder.Property(x => x.Email);
        builder.Property(x => x.Status);
        builder.Property(x => x.CreationDate);
        builder.Property(x => x.Message);

        builder
            .HasOne(x => x.Article)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.ArticleId);
    }
}