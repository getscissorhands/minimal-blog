# Minimal Blog Theme

A minimal, responsive blog theme for [ScissorHands.NET](https://getscissorhands.app/), inspired by [astro-minimal-blog](https://github.com/alexanderhodes/astro-minimal-blog). It uses Razor components, framework-free CSS, and plain JavaScript.

See [the demo](https://getscissorhands.app/minimal-blog/) or read the **[theme documentation](https://getscissorhands.app/docs/themes/)** for setup, configuration, component APIs, navigation, and customization.

## Prerequisites

- [.NET 10+ SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## Theme Layout

```text
src/
├── assets/
│   ├── css/
│   │   └── theme.css
│   ├── images/
│   │   └── icons/
│   │       ├── chevron-down.svg
│   │       ├── github.svg
│   │       ├── globe.svg
│   │       ├── moon.svg
│   │       └── sun.svg
│   └── js/
│       └── theme.js
├── Components/
│   ├── Footer.razor
│   ├── Footer.razor.cs
│   ├── Header.razor
│   ├── Header.razor.cs
│   ├── LanguageSwitcher.razor
│   ├── LocalizationFallbackBanner.razor
│   ├── LocalizationMetadata.razor
│   ├── NavigationItems.razor
│   ├── NavigationItems.razor.cs
│   ├── PostCard.razor
│   ├── PostCard.razor.cs
│   ├── PublicationBadges.razor
│   ├── TagList.razor
│   └── TagList.razor.cs
├── favicon.ico
├── theme.json
├── minimal-blog.csproj
├── _Imports.razor
├── MainLayout.razor
├── IndexView.razor
├── PostView.razor
├── PageView.razor
├── NotFoundView.razor
├── TagListView.razor
└── TagView.razor
```

## Plugins

This theme includes the following plugins:

- [Google Analytics](https://github.com/getscissorhands/plugins/tree/main/src/ScissorHands.Plugin.GoogleAnalytics)
- [Open Graph](https://github.com/getscissorhands/plugins/tree/main/src/ScissorHands.Plugin.OpenGraph)

The default configuration of the plugins above, refer to the [sample README](./sample/README.md#plugin-settings).

## Local Preview

The sample needs the committed symbolic link at `sample/themes/minimal-blog` pointing to `src`, with the relative target `../../src`. Recreate it manually if your checkout did not preserve symlinks.

Here are the commands:

```bash
# zsh/bash
mkdir -p sample/themes
ln -s ../../src sample/themes/minimal-blog
```

```powershell
# PowerShell
New-Item -ItemType Directory -Path ./sample/themes -Force
New-Item -ItemType SymbolicLink -Path ./sample/themes/minimal-blog -Target ../../src
```

Then build and preview from the repository root:

```bash
dotnet restore && dotnet build
cd sample
dotnet run -- --preview
```

Open `http://localhost:5000/`. The sample includes English, Korean, missing translations, and preview-only publication statuses. Stop preview before rebuilding Razor components.
