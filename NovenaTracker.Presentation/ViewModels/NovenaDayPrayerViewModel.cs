using CommunityToolkit.Mvvm.ComponentModel;
using NovenaTracker.Model.Models;

namespace NovenaTracker.Presentation.ViewModels;

public class NovenaDayPrayerViewModel : ObservableObject
{
    public int Id
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public int NovenaId
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public int DayNumber
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public string PrayerText
    {
        get => field;
        set => SetProperty(ref field, value);
    } = string.Empty;

    public string? PrayerTitle
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public bool IsCompleted
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public bool IsFirstPrayer
    {
        get => field;
        set => SetProperty(ref field, value);
    }

    public static NovenaDayPrayerViewModel Convert(NovenaDayPrayerDto novenaDayPrayerDto)
    {
        return new NovenaDayPrayerViewModel
        {
            Id = novenaDayPrayerDto.Id,
            NovenaId = novenaDayPrayerDto.NovenaId,
            DayNumber = novenaDayPrayerDto.DayNumber,
            PrayerText = novenaDayPrayerDto.PrayerText,
            PrayerTitle = novenaDayPrayerDto.PrayerTitle,
            IsCompleted = novenaDayPrayerDto.IsCompleted,
            IsFirstPrayer = novenaDayPrayerDto.IsFirstPrayer
        };
    }
}
