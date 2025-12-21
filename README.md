# Minimal Blog Theme

A minimal blog theme using Tailwind CSS for ScissorHands.NET, inspired by [astro-minimal-blog](https://github.com/alexanderhodes/astro-minimal-blog).

## Theme Structure

This is the overall structure of the theme.

```text
.
└── src/
    ├── assets/
    │   ├── css/
    │   │   └── theme.css
    │   ├── images/
    │   │   ├── logo.png
    │   │   ├── moon-icon.svg
    │   │   └── sun-icon.svg
    │   └── js/
    │       └── theme.js
    │
    ├── favicon.ico
    │
    ├── theme.json
    │
    ├── Components/
    │   ├── Header.razor
    │   ├── Footer.razor
    │   ├── PostCard.razor
    │   └── TagList.razor
    ├── _Imports.razor
    ├── MainLayout.razor
    ├── IndexView.razor
    ├── PostView.razor
    └── PageView.razor
```

## Getting Started

### Theme Manifest &ndash; `theme.json`

- `theme.json` defines the metadata of the theme.

    ```jsonc
    {
      "name": "Minimal Blog",
      "version": "1.0.0",
      "description": "A minimal blog theme using Tailwind CSS for ScissorHands.NET, inspired by [astro-minimal-blog](https://github.com/alexanderhodes/astro-minimal-blog).",
      "slug": "minimal-blog",
      "stylesheets": [
        "/assets/css/theme.css"
      ],
      "scripts": [
        "/assets/js/theme.js"
      ]
    }
    ```

  You can have one or more CSS and JavaScript files. If you choose to do so, make sure to include them all in this `theme.json`.

### Integrated Plugins

- [Google Analytics](https://github.com/getscissorhands/plugins/tree/main/src/ScissorHands.Plugin.GoogleAnalytics)
- [Open Graph](https://github.com/getscissorhands/plugins/tree/main/src/ScissorHands.Plugin.OpenGraph)

### Layout Components

#### `_Imports.razor` Global Component

- It defines the global namespace and using directives.

    ```razor
    @using ScissorHands.Core.Manifests
    @using ScissorHands.Core.Models
    @using ScissorHands.Plugin.GoogleAnalytics
    @using ScissorHands.Plugin.OpenGraph
    @using ScissorHands.Theme.MinimalBlog.Components.Footer
    @using ScissorHands.Theme.MinimalBlog.Components.Header
    @using ScissorHands.Theme.MinimalBlog.Components.PostCard
    @using ScissorHands.Theme.MinimalBlog.Components.TagList
    
    @using Theme = ScissorHands.Core.Manifests.ThemeManifest
    
    @namespace ScissorHands.Theme.MinimalBlog
    ```

#### `MainLayout.razor` Layout Component

- This is the overall HTML layout structure.
- It calls both UI components and plugin components.

#### `IndexView.razor` Page Component

- This is the landing page of your static website.

#### `PostView.razor` Page Component

- This is the blog post page.

#### `PageView.razor` Page Component

- This is the non-blog post page.

### UI Components

- The list of UI components used in this theme are:
  - Header
  - Footer
  - PostCard
  - TagList

## Previewing Theme

1. Set environment variables for GitHub NuGet Package Registry.

    ```bash
    # zsh/bash
    export GH_PACKAGE_USERNAME="<GITHUB_USERNAME>"
    export GH_PACKAGE_TOKEN="<GITHUB_TOKEN>"
    ```

    ```powershell
    # PowerShell
    $env:GH_PACKAGE_USERNAME = "<GITHUB_USERNAME>"
    $env:GH_PACKAGE_TOKEN = "<GITHUB_TOKEN>"
    ```

1. Add a NuGet package for the theme.

    ```bash
    dotnet add package ScissorHands.Theme --prerelease
    ```

1. Create a symbolic link under the `themes` directory.

    ```bash
    # zsh/bash
    REPOSITORY_ROOT=$(git rev-parse --show-toplevel)
    ln -s $REPOSITORY_ROOT/src $REPOSITORY_ROOT/preview/ScissorHands/themes/minimal-blog
    ```

    ```powershell
    # PowerShell
    $REPOSITORY_ROOT = git rev-parse --show-toplevel
    New-Item -ItemType SymbolicLink -Path "$REPOSITORY_ROOT/preview/ScissorHands/themes/minimal-blog" -Target "$REPOSITORY_ROOT/src"
    ```

1. Run the app.

    ```bash
    dotnet run --project ./preview/ScissorHands -- --preview
    ```

1. Verify the generated HTML properly renders your theme.
