# Minimal Blog Theme

A minimal, responsive blog theme for [ScissorHands.NET](https://getscissorhands.app/), inspired by [astro-minimal-blog](https://github.com/alexanderhodes/astro-minimal-blog). It uses Razor components, framework-free CSS, and plain JavaScript.

[View the demo](https://getscissorhands.app/minimal-blog/) or read the [theme documentation](https://getscissorhands.app/docs/themes/).

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) with the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## Run locally

Restore and build from the repository root:

```shell
dotnet restore
dotnet build --configuration Release --no-restore
```

Run the preview:

```shell
cd sample
dotnet run -- --preview
```

Generate static output with `dotnet run -- --build` from `sample`. Output is written to `sample/preview` or `sample/dist`.

## Customize

- `src/theme.json`: theme metadata and asset declarations.
- `src/*.razor`: layout, content, error, and tag views.
- `src/Components/`: shared UI components.
- `src/assets/`: theme CSS, JavaScript, and images.
- `sample/appsettings.json`: local site and plugin configuration.
- `sample/contents/`: preview posts, pages, and images.

The sample enables the [Google Analytics](https://www.nuget.org/packages/ScissorHands.Plugin.GoogleAnalytics) and [Open Graph](https://www.nuget.org/packages/ScissorHands.Plugin.OpenGraph)
plugins.

ScissorHands packages versions are centralized in `Directory.Packages.props` and float within the latest 1.x release line, including previews.

## Project guidance

- [Contributing](CONTRIBUTING.md)
- [Support](SUPPORT.md)
- [Security policy](SECURITY.md)
- [Changelog](CHANGELOG.md)
