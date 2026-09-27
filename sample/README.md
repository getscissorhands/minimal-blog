# Minimal Blog preview

This project consumes ScissorHands.NET packages from NuGet.org and the committed
relative symlink `themes/minimal-blog -> ../../src`. No engine checkout or
client-side .NET runtime is required.

## Tested versions

Fresh NuGet.org metadata was checked on 2026-09-27 using .NET SDK `10.0.401`.
The repository retains centralized `1.*-*` package floats:

| Package | Restored version | Result |
| --- | --- | --- |
| ScissorHands.Theme / Web | `1.0.0-preview.20260927.1` | Theme and sample Release builds pass |
| ScissorHands.Core / Plugin | `1.0.0-preview.20260927.1` | Transitive engine baseline in both projects |
| ScissorHands.Plugin.GoogleAnalytics | `1.0.0-preview.20260927.1` | Published plugin; fake-ID markup retained |
| ScissorHands.Plugin.OpenGraph | `1.0.0-preview.20260927.1` | Published plugin; localized generation succeeds |

Both plugin packages were independently verified on NuGet.org, not assumed to
match the engine. The final checks use an isolated NuGet.org-only restore, with
no local plugin feed, plugin project references, or engine checkout.

The previously published Open Graph `1.0.0-preview.20260915.1` compiled but threw
`MissingMethodException: SiteManifest.get_Locale()` in both build and preview.
The published migration from
[getscissorhands/plugins#17](https://github.com/getscissorhands/plugins/issues/17)
and [getscissorhands/plugins#18](https://github.com/getscissorhands/plugins/pull/18)
resolves that blocker. Refresh stale restores before using this theme. Do not
disable plugins or suppress final-HTML validation to hide an incompatible
version. No package publishing or demo deployment is part of this theme change.

## Restore, build, and package

From the repository root:

```shell
dotnet restore --force-evaluate --no-http-cache
dotnet build --configuration Release --no-restore
dotnet list package --include-transitive
```

Record **resolved**, not requested, versions when reproducing a result: floats
can change. For a cache-isolated check, add
`--source https://api.nuget.org/v3/index.json --packages <empty-directory>`
to restore; this avoids unintentionally testing local unpublished packages.
The theme is distributed as a source ZIP, not a NuGet package. To
inspect a local archive using the release workflow's exclusions:

```shell
mkdir -p published
(cd src && zip -qr ../published/minimal-blog-local.zip . -x "bin/*" "obj/*")
unzip -l published/minimal-blog-local.zip
```

Do not commit generated output or publish this local verification archive.

On Windows, enable Developer Mode before cloning and use
`git -c core.symlinks=true clone ...` so the theme link is a symlink, not a text
file. An existing checkout can use a directory junction pointing from
`sample/themes/minimal-blog` to `src` instead; do not commit the junction.

## Running at the root or a subpath

The following generation commands use the compatible packages recorded above.
From `sample`, choose an explicit mode:

```shell
dotnet run --configuration Release --no-build -- --preview
# Stop preview with Ctrl+C before rebuilding.
dotnet run --configuration Release --no-build -- --build
```

Preview serves `http://localhost:5000/` and writes `preview/`. Build writes
`dist/` without starting a server. The launch profile does not choose a mode.
Recompile after Razor/C# changes; preview watches content/assets but does not
compile changed Razor assemblies.

Use command-line configuration overrides to exercise the demo path without
editing committed settings:

```shell
dotnet run --configuration Release --no-build -- --Site:BaseUrl=/minimal-blog/ --preview
# Stop preview, then generate the demo artifact without deploying it.
dotnet run --configuration Release --no-build -- --Site:BaseUrl=/minimal-blog/ --Site:SiteUrl=https://getscissorhands.app --build
```

`/minimal-blog` also normalizes to `/minimal-blog/`. Open
`http://localhost:5000/minimal-blog/` in subpath preview. GET/HEAD `/?q=example`
must redirect (302) to `/minimal-blog/?q=example`; unprefixed document/asset URLs,
`/minimal-blog-other/`, and POST `/` must return 404. `/minimal-blog` and directory
redirects preserve prefix and query. Unknown URLs are not automatically rewritten
to the shared `404.html`; inspect that file's route directly.

Keep the valueless mode switch **last**, after configuration overrides, so
ASP.NET configuration does not consume the next option as its value. If port
5000 is occupied, use `--no-launch-profile` before `--` and
`--urls=http://127.0.0.1:5179` before the final `--preview`.

All files remain directly inside `preview/` or `dist/`, not an extra
`minimal-blog/` directory. Mount `dist/` at the prefix on the production static
host and enable directory indexes. Keep `<base href>` and engine-prepared links;
do not prepend the base path again.

## Migrating localization

Use the engine's
[versioned migration guide](https://github.com/getscissorhands/Scissorhands.NET/blob/v1.0.0-preview.20260927.1/docs/website-documentation.md#upgrading-to-vnext)
and [theme contracts](https://github.com/getscissorhands/Scissorhands.NET/blob/v1.0.0-preview.20260927.1/docs/website-documentation.md#locale-render-context),
not older examples using `Site.Locale`.

Remove `Site.Locale`, `Site.UseLocaleInUrl`, and frontmatter `locale`.
`Site.Locales` is ordered: the first language owns the existing unprefixed URLs.
Additional locale directories contain translations paired with primary files:

```text
contents/posts/hello-world.md          -> /hello-world/
contents/posts/ko-kr/hello-world.md    -> /ko-kr/hello-world/
contents/pages/about.md               -> /about/
                                     -> /ko-kr/about/ (primary-content fallback)
```

Post translation pairs need the same authored calendar date in `published`,
even when their times/offsets differ. Assets stay shared under `contents/images`.
`Site.Theme` remains `"minimal-blog"`; messages belong to the application's
top-level `Theme`, not the packaged theme manifest:

```json
{
  "Site": { "Theme": "minimal-blog", "Locales": ["en-us", "ko-kr"] },
  "Theme": {
    "Localization": {
      "en-us": {
        "TranslationUnavailable": "Translation unavailable. Showing the original content.",
        "Draft": "Draft",
        "ScheduledOn": "Scheduled on {0}"
      },
      "ko-kr": {
        "TranslationUnavailable": "이 페이지는 한국어 번역이 없어 원문을 표시합니다.",
        "Draft": "초안",
        "ScheduledOn": "{0} 공개 예정"
      }
    }
  }
}
```

All three nonblank messages are required for **every** declared locale, including
a sole primary locale. `ScheduledOn` must contain a real `{0}` date argument.
Missing values fail before rendering; there is no implicit English fallback for
declared locales. Text is Razor-encoded, never treated as authored HTML.

Omitting `Site.Locales` (or setting it to `[]`) disables localization: no switcher,
paired-document canonical/alternate links, fallback notices, or HTML language is
inferred; publication labels default to English. Remove the locale directory
fixtures when testing a single-language site: undeclared locale directories are
ordinary nested content, **not** excluded translations.

`LocaleContext` is forwarded to views and plugins. The switcher uses prepared
destinations, including fallback copies; SEO alternates list real translations
only. A fallback keeps the requested route/UI language but declares primary
article language and canonical URL. Generated home/tag pages and the shared 404
do not get paired-document canonical/alternate metadata.

Home, Tags, navigation, tag entries, and switch links follow the active locale.
Authored document links are localized by the engine, preserving query/fragment;
`{data-localize="false"}` deliberately targets primary content. Resources stay
shared. Other theme UI text is not automatically translated.

## Publication timing and preview exposure

`Site.TimeZone` is explicitly `UTC` in this sample. It controls offset-free post
datetimes and date-only values (midnight in that zone); it never defaults to the
build machine's local timezone. Use a system timezone such as `Asia/Seoul` when
appropriate. Explicit `Z`/numeric offsets identify their own instant. Invalid
zones and ambiguous/nonexistent offset-free daylight-saving times fail; supply
an explicit offset to disambiguate.

Future posts and draft posts/pages are excluded from production, including
listings, tags, navigation, and active translations of an ineligible primary.
Dates do not schedule ordinary pages. A publication time never clears `draft`.

**Never deploy `preview/` or expose its server publicly:** it intentionally
contains unpublished content, including inherited/combined status. This is not
access control. Preview badges use requested-locale messages and invariant
`yyyy-MM-dd` authored dates; ordinary post dates use an explicit display culture.
Badges/regions and fallback notices retain engine rendering receipts and
machine-readable attributes through final plugin processing.

Static files do not publish themselves. Schedule a new **build and deployment**
at or after the publication instant. Preview also requires regeneration to take
a new time snapshot. Deploy with deletion of withdrawn files, not copy-only
uploads; retain the engine output ledger for in-place regeneration.

## Focused verification

Keep both plugins configured. `G-EXAMPLE` is a fake ID, **not** a network opt-out:
the analytics plugin deliberately emits its script in preview too. Automated
browser checks must intercept requests **before navigation** and block all
non-local origins (including Google tracking and the external GitHub icon).
Inspect emitted markup with file reads or `curl` to avoid executing scripts.
Do not use production analytics credentials for checks. Preserve plugin options,
component/hook behavior, and theme-owned canonical/alternate metadata.

The committed layout uses the plugin components. For hook-mode regression checks,
use an isolated copy and replace the two component calls with
`<plugin:google-analytics />` and `<plugin:open-graph />` respectively (the
commented alternatives in `MainLayout.razor`), then rebuild. Do not insert both
modes together. Keep both manifests and their options unchanged.

For both `/` and `/minimal-blog/`, generate build and preview and inspect:

| Route (append to base path) | Preview expectation |
| --- | --- |
| `hello-world/`, `ko-kr/hello-world/` | Real translation; self-canonical; reciprocal alternates; shared image |
| `ko-kr/about/` | English article; Korean notice; canonical points to primary; localized authored link and explicit primary opt-out |
| `draft-post/`, `ko-kr/draft-post/` | Draft badges; Korean fallback also has a notice |
| `scheduled-post/` | Scheduled badge with `data-publication-date="2099-01-01"` |
| `ko-kr/scheduled-post/` | Both draft and inherited scheduled badges, no fallback notice |
| `draft-guide/`, `ko-kr/draft-guide/` | Draft page and inherited translation draft; adjacent-page navigation |
| Home, `tags/`, `tags/preview/`, Korean equivalents | Correct per-entry status, locale-aware URLs and generated metadata |
| `404.html` | Shared not-found view; working Home/switch links; no publication or document SEO markers |

Production must contain neither draft/future routes nor badge markers or links
to withheld content. Repeat with localization disabled and locale fixtures
removed. Check for one Open Graph/Twitter value per key, actual-content
`og:locale`, requested-route `og:url`, and no duplicate canonical/alternate tags.
Do not bypass the engine's final-HTML validation.

In the browser, check desktop and 320px mobile widths, light/dark and reduced
motion, keyboard focus and switch links, submenu Escape dismissal, navigation
without JavaScript, and the colour toggle with storage access denied. Directory
navigation ends in a slash: use the **exact destination URL** (including base
path and trailing slash) when waiting for a language switch. A suffix glob such
as `**/scheduled-post/` also matches the source Korean route and can pass before
navigation; `**/scheduled-post` never matches the resulting directory URL.

To exercise nested navigation, use an isolated sample copy with a temporary
`contents/pages/draft-guide/checklist.md` declaring
`slug: draft-guide/checklist`, `draft: true`, and `show_in_navigation: true`.
The child should be reachable without JavaScript; with enhancement, Enter opens
the submenu and Escape closes it and restores focus to its toggle. In another
isolated configuration, include literal `<b>`, `&`, and quotes in localized
messages to check that notices/badges expose encoded text, not markup.

### Verification recorded on 2026-09-27

All final results below use the **published** versions in the table above.
An earlier local-plugin experiment was superseded by the NuGet.org-only run.

| Check | Observed result |
| --- | --- |
| Release restore/build | Both projects build with no warnings/errors; all six ScissorHands libraries resolve to `1.0.0-preview.20260927.1` |
| Root and demo-path production | 17 HTML files each; 286 internal link/asset/metadata targets each; no withheld routes or publication badges |
| Root and demo-path preview | 23 HTML files each; 427 internal targets each; 19 required badges each, including combined/inherited states |
| Subpath HTTP boundary | Root GET/HEAD query-preserving redirects; outside-prefix 404s; directory redirects; all 32 generated public files served successfully |
| Localization disabled | 9 production pages and 12 preview pages; 8 preview badges with English defaults; no localization/social-locale markers |
| Browser appearance | 16 routes at 1280px/320px in light/dark at both base paths: 128 checks without horizontal overflow; new switcher/notice/badge text contrast exceeds 4.5:1 |
| Browser interactions | Exact keyboard language switching, missing-tag switch to locale home, persisted/denied-storage colour preference, reduced motion, no-JavaScript navigation, nested Escape/focus restoration |
| Encoded messages | Literal markup/ampersands/quotes remain text; fallback and combined-status final-HTML receipts pass with both plugins enabled |
| Plugin integration modes | Component mode passes the full matrix; isolated hook mode passes root/subpath builds and subpath preview with identical counts and no duplicate metadata |
| Distribution | Source ZIP excludes `bin`/`obj`; seven view roles and assets verified; a clean tracked-file consumer using the extracted ZIP restores/builds/generates without an engine checkout |

These are focused generated-output and browser checks, not an automated .NET
test suite, analytics-provider acceptance, or proof of a deployed host. All
non-local browser requests were intercepted before navigation; no tracking
requests were sent. The demo was not deployed.
