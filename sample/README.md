# Minimal Blog preview

The sample uses published ScissorHands.NET packages and the relative theme link
`themes/minimal-blog -> ../../src`. Install the .NET SDK from `global.json`,
then restore and build from the repository root:

```shell
dotnet restore
dotnet build --configuration Release --no-restore
```

`Directory.Packages.props` floats Theme, Web, Google Analytics, and Open Graph
within the latest 1.x release line, including previews. All four resolved to
`1.0.0-preview.20260928.1` on 2026-09-28; later restores may differ. The plugins
are published independently, so verify runtime compatibility after updates.
`dotnet list package --include-transitive` shows the resolved versions.

From `sample`, run `dotnet run -- --preview` to serve
`http://localhost:5000/` and generate `preview/`, or
`dotnet run -- --build` to generate production `dist/`. Stop preview before
rebuilding after Razor changes. Never deploy `preview/`: it includes drafts
and scheduled content.

## Content layout

`contents/` follows the post and page structure from
[theme-template](https://github.com/getscissorhands/theme-template/tree/main/sample/contents),
without its sample illustrations. The original `images/hello-world.png` is
reused as the `hero_image` in both versions of `posts/hello-scissorhands.md`;
the two scheduled post pairs share a new `images/scheduled-post.svg` hero.
The other old images remain removed.
Posts live in `posts/` and pages in `pages/`.
Primary-language content sits directly in its tree; translations are paired
under `posts/ko-kr/` or `pages/ko-kr/`. The first `Site.Locales` entry owns
unprefixed routes; translated routes start with `/ko-kr/`. A missing translation
uses primary content with a localized fallback notice.

The theme-guide directory demonstrates a directory-index page, numbered source
ordering, and nested navigation without a Recipes index. `reference.md` and
`02-unlisted.md` are published but excluded from navigation. Draft pages and
posts, future posts, inherited status on translations, tag views, and the
custom `404.html` page exercise the corresponding theme views in preview.
Production excludes drafts and future posts.

This theme has no site-wide hero image section. Add your own images to
`contents/images/` when needed; post and page images remain optional
per-document content. The home-page text heading is unaffected.

## Base path and localization

Keep `Site.Theme` set to `minimal-blog`, and configure site settings in
`appsettings.json`. To check a subpath without modifying that file:

```shell
dotnet run --configuration Release --no-build -- --Site:BaseUrl=/minimal-blog/ --preview
dotnet run --configuration Release --no-build -- --Site:BaseUrl=/minimal-blog/ --Site:SiteUrl=https://getscissorhands.app --build
```

Pass overrides before the valueless `--preview` or `--build` switch. Preview
mounts the site at `http://localhost:5000/minimal-blog/`; generated files
still reside directly in `preview/` or `dist/`. Inspect home, posts, pages,
both tag views, `404.html`, navigation, plugin metadata, and asset URLs at
both base paths. Content links and theme URLs should retain the prefix.

`Site.TimeZone` is `UTC` for offset-free publication dates. A scheduled
post requires a new build and deployment at publication time; static files
do not publish themselves. Omit or empty `Site.Locales` only after removing
the locale directories from content, or they will be treated as ordinary
nested content.

The sample enables Google Analytics with a fake `G-EXAMPLE` ID and Open Graph.
The fake ID does not prevent network requests in a browser preview; block
external origins when checking rendered pages locally.
