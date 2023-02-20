using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchBet.Player.Data.Mappings;

public class PlayerMapping
{
    public PlayerMapping(EntityTypeBuilder<Models.Player> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(q => q.Id);
        entityTypeBuilder.ToTable("players");

        entityTypeBuilder.Property(q => q.Id).HasColumnName("id");
        entityTypeBuilder.Property(q => q.UserName).HasColumnName("username");
        entityTypeBuilder.Property(q => q.Email).HasColumnName("email");
        entityTypeBuilder.Property(q => q.Password).HasColumnName("password");
        entityTypeBuilder.Property(q => q.Credit).HasColumnName("credit");
        entityTypeBuilder.Property(q => q.Score).HasColumnName("score");
    }
}