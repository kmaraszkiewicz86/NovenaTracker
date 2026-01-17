using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovenaTracker.Domain.Entities;

namespace NovenaTracker.Infrastructure.DbConfiguration;

/// <summary>
/// Entity configuration for NovenaDayPrayer entity
/// </summary>
public class NovenaDayPrayerConfiguration : IEntityTypeConfiguration<NovenaDayPrayer>
{
    public void Configure(EntityTypeBuilder<NovenaDayPrayer> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.NovenaId)
            .IsRequired();
            
        builder.Property(e => e.DayNumber)
            .IsRequired();
            
        builder.Property(e => e.PrayerText)
            .IsRequired()
            .HasColumnType("TEXT");
            
        builder.Property(e => e.PrayerTitle)
            .HasMaxLength(200);
        
        // Create index for efficient querying
        builder.HasIndex(e => new { e.NovenaId, e.DayNumber });
        
        // Seed prayers for the Venerable Wenanty Katarzyniec novena
        builder.HasData(
            new NovenaDayPrayer
            {
                Id = 1,
                NovenaId = 1,
                DayNumber = 0,
                PrayerTitle = "Modlitwa początkowa",
                PrayerText = "Boże w Trójcy Jedyny, bądź uwielbiony za wszelkie dobra, którymi napełniłeś sługę Twego Wenantego; on przez życie według rad ewangelicznych i gorliwą posługę kapłańską w Kościele stał się przykładem dla Twoich wiernych. Wynieś, Panie, tego sługę Twego na ołtarze, abyśmy lepiej mogli Tobie służyć, mnie zaś udziel łaski, o którą pokornie proszę za jego wstawiennictwem. Przez Chrystusa Pana naszego. Amen."
            },
            new NovenaDayPrayer
            {
                Id = 2,
                NovenaId = 1,
                DayNumber = 1,
                PrayerTitle = "Dzień 1 – Dobre życie",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 3,
                NovenaId = 1,
                DayNumber = 2,
                PrayerTitle = "Dzień 2 – Łaska",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 4,
                NovenaId = 1,
                DayNumber = 3,
                PrayerTitle = "Dzień 3 – Unikanie grzechów",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 5,
                NovenaId = 1,
                DayNumber = 4,
                PrayerTitle = "Dzień 4 – Cierpienie",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 6,
                NovenaId = 1,
                DayNumber = 5,
                PrayerTitle = "Dzień 5 – Wiara",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 7,
                NovenaId = 1,
                DayNumber = 6,
                PrayerTitle = "Dzień 6 – Nadzieja",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 8,
                NovenaId = 1,
                DayNumber = 7,
                PrayerTitle = "Dzień 7 – Modlitwa",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 9,
                NovenaId = 1,
                DayNumber = 8,
                PrayerTitle = "Dzień 8 – Maryja",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            },
            new NovenaDayPrayer
            {
                Id = 10,
                NovenaId = 1,
                DayNumber = 9,
                PrayerTitle = "Dzień 9 – Niebo",
                PrayerText = "[Treść modlitwy z https://wenanty.pl/nowenna/]"
            }
        );
    }
}
