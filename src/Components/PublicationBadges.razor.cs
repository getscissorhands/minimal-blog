using ScissorHands.Core.Manifests;
using ScissorHands.Core.Models;
using ScissorHands.Core.Urls;
using ScissorHands.Theme;
using ScissorHands.Theme.Components;

namespace ScissorHands.Theme.MinimalBlog.Components;

public partial class PublicationBadges : PublicationBadgeBase
{
    private ThemeLocalization GetMessages()
    {
        if (Site?.IsLocalizationEnabled != true)
        {
            return ThemeLocalization.English;
        }

        var settings = ThemeSettings ?? throw new InvalidOperationException("Theme settings are required to render publication badges.");
        var locale = ContentUrlHelper.GetLocaleSegment(LocaleContext?.Locale ?? Site.Locales[0]);
        if (settings.Localization.TryGetValue(locale, out var messages) != true || messages is null
            || string.IsNullOrWhiteSpace(messages.Draft) || string.IsNullOrWhiteSpace(messages.ScheduledOn))
        {
            throw new InvalidOperationException($"Theme:Localization:{locale} must supply Draft and ScheduledOn messages before rendering publication badges.");
        }

        return messages;
    }
}
