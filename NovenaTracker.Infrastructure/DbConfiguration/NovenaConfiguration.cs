using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for Novena entity
/// </summary>
public class NovenaConfiguration : IEntityTypeConfiguration<Novena>
{
    public void Configure(EntityTypeBuilder<Novena> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(e => e.Description)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(e => e.DaysDuration)
            .IsRequired();
        
        // Configure relationships
        builder.HasMany(e => e.DayPrayers)
            .WithOne(e => e.Novena)
            .HasForeignKey(e => e.NovenaId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasMany(e => e.Completions)
            .WithOne(e => e.Novena)
            .HasForeignKey(e => e.NovenaId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Seed initial data
        builder.HasData(
            new Novena
            {
                Id = 1,
                Title = "Dziewięciodniowa nowenna za wstawiennictwem Sługi Bożego o.Wenantego Katarzyńca",
                Description = "Nowenna do Wenantego Katarzyńca to 9-dniowa modlitwa (nowenna od łac. novem - dziewięć), przez którą wierni proszą o łaski za wstawiennictwem Sługi Bożego o. Wenantego, franciszkanina, często w intencjach związanych z pracą, finansami i trudnymi sprawami, a także za dusze w czyśćcu cierpiące, gdyż sam o. Wenanty był ich gorliwym orędownikiem.",
                DaysDuration = 9
            }
        );
    }
}
