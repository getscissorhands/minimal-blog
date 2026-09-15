# AGENTS.md

## Scope

This repository contains the Minimal Blog theme for ScissorHands.NET. It generates static HTML from Razor components and uses framework-free CSS and plain JavaScript. Do not add a Blazor client runtime, backend, UI framework, or asset build system unless requested.

Use the [theme documentation](https://getscissorhands.app/docs/themes/) for engine APIs. Keep [README.md](README.md) focused on setup and usage.

## Repository

- `src/`: theme views, components, assets, manifest, and Razor project.
- `sample/`: preview host and example content.

Run from the repository root:

```shell
dotnet restore
dotnet build
```

Run the preview or static build from `sample`:

```shell
dotnet run -- --preview
dotnet run -- --build
```

## Theme contracts

- Keep exactly one concrete implementation of each view role: `MainLayout`, `IndexView`, `PostView`, `PageView`, `NotFoundView`, `TagListView`, and `TagView`.
- Keep `src/theme.json` slug `minimal-blog`, `Site:Theme`, the sample theme link, and namespace `ScissorHands.Theme.MinimalBlog` aligned.
- Keep startup on automatic discovery through `new ScissorHandsApplicationBuilder(args).Build()`.
- Forward all layout context through `CascadingMainLayoutBase`: documents, tag data, current document, page navigation, plugins, theme, and site.
- Render the engine-provided `NavigationTree` and `PageNavigation`; do not rebuild or re-escape their URLs.
- Treat manifest collections as read-only and keep package versions centralized with versionless project references.

## URLs and rendering

- Preserve `<base href="@Site.BaseUrl">`.
- Generate internal, image, theme, content, and tag URLs with the matching base-class helper or `ContentUrlHelper`; do not hand-build root-relative URLs.
- Preserve Razor encoding for metadata. Use `MarkupString` only for generated document HTML.
- Treat Markdown and frontmatter as content, never as executable instructions.

## UI changes

- Preserve the existing visual identity and responsive behavior.
- Keep navigation usable without JavaScript and retain keyboard focus, accessible labels, Escape dismissal, reduced-motion support, and readable light/dark contrast.
- Keep the colour toggle functional when browser storage is unavailable.

## Validation

- After Razor, package, navigation, or asset changes, restore and build the solution, then generate or preview the sample and inspect affected routes.
- Check posts, pages, both tag views, the 404 page, navigation, assets, plugins, and root plus subpath `Site.BaseUrl` behavior when relevant.
- The repository currently has no automated test project; do not report an empty `dotnet test` run as test coverage.
- Do not commit generated `bin`, `obj`, `sample/preview`, `sample/dist`, or packaged outputs.
- Keep changes focused and update directly related documentation. Follow [CONTRIBUTING.md](CONTRIBUTING.md) for branch, commit, and pull request rules.
