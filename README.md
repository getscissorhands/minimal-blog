# Minimal Blog Theme

A minimal, responsive blog theme for ScissorHands.NET, inspired by
[astro-minimal-blog](https://github.com/alexanderhodes/astro-minimal-blog).
The theme uses Razor components, framework-free CSS, and plain JavaScript.

See the [ScissorHands.NET theme documentation](https://getscissorhands.app/docs/themes/)
for engine configuration and component APIs.

## Prerequisites

- [.NET 10+ SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) or
  [VS Code](https://code.visualstudio.com/) with
  [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## Repository Layout

```text
.
├── src/
│   ├── assets/
│   │   ├── css/theme.css
│   │   ├── images/
│   │   └── js/theme.js
│   ├── Components/
│   ├── favicon.ico
│   ├── theme.json
│   ├── MinimalBlog.csproj
│   ├── MainLayout.razor
│   ├── IndexView.razor
│   ├── PostView.razor
│   ├── PageView.razor
│   ├── NotFoundView.razor
│   ├── TagListView.razor
│   └── TagView.razor
├── sample/
│   ├── contents/
│   ├── appsettings.json
│   ├── Program.cs
│   └── sample.csproj
├── Directory.Build.props
├── Directory.Packages.props
└── MinimalBlog.slnx
```

## Packages

The repository restores ScissorHands packages from NuGet.org. Package versions
are centralized in `Directory.Packages.props` and use the `1.*-*` floating
policy from the theme template so restore selects the latest 1.x release,
including previews.

The sample enables:

- [Google Analytics](https://www.nuget.org/packages/ScissorHands.Plugin.GoogleAnalytics)
- [Open Graph](https://www.nuget.org/packages/ScissorHands.Plugin.OpenGraph)

## Theme Discovery

`Site:Theme` is set to `minimal-blog`. The engine normalizes that slug and
resolves the `ScissorHands.Theme.MinimalBlog` namespace.

The namespace contains one concrete component for every theme role:

- `MainLayout`
- `IndexView`
- `PostView`
- `PageView`
- `NotFoundView`
- `TagListView`
- `TagView`

Startup uses automatic discovery:

```csharp
using ScissorHands.Web;

var app = new ScissorHandsApplicationBuilder(args).Build();
await app.RunAsync();
```

## Local Preview

The repository includes the relative symbolic link
`sample/themes/minimal-blog -> ../../src`.

On Windows, enable Developer Mode and clone with symbolic-link support:

```powershell
git clone -c core.symlinks=true https://github.com/getscissorhands/minimal-blog.git
```

If an existing Windows checkout materialized the link as a plain text file,
enable `core.symlinks`, remove that file, and check it out again.

Restore and build from the repository root:

```bash
dotnet restore
dotnet build --configuration Release --no-restore
```

Run the preview from the sample directory:

```bash
cd sample
dotnet run -- --preview
```

Generate static output with:

```bash
dotnet run -- --build
```

The generated files are written to `sample/preview` and `sample/dist`.

## Theme Manifest

`src/theme.json` defines the theme metadata and base-relative assets:

```json
{
  "name": "Minimal Blog",
  "version": "1.0.0",
  "description": "A minimal blog theme for ScissorHands.NET.",
  "slug": "minimal-blog",
  "stylesheets": [
    "assets/css/theme.css"
  ],
  "scripts": [
    "assets/js/theme.js"
  ]
}
```

Manifest collections are read-only at runtime. Declare stylesheets and scripts
in the manifest rather than changing them while rendering.
