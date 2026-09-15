# Contributing to Minimal Blog

Minimal Blog is a static Razor theme for ScissorHands.NET, using plain CSS and
JavaScript. Follow the [Code of Conduct](CODE_OF_CONDUCT.md) and
[theme contracts](AGENTS.md); see the
[theme documentation](https://getscissorhands.app/docs/themes/) for engine APIs.

## Getting Started

Fork and clone the repository, install the SDK from [global.json](global.json),
and create a `type/short-kebab-case-description` branch, such as `fix/tag-links`.
On Windows, follow the [symlink setup](README.md#local-preview) before building.
From the repository root:

```shell
dotnet restore
dotnet build --configuration Release --no-restore
```

## Making Changes

- Keep changes focused, follow [.editorconfig](.editorconfig) and existing
  patterns, and update directly related documentation.
- Centralize package versions in [Directory.Packages.props](Directory.Packages.props),
  keep project references versionless, and preserve major-version floating.
- Discuss browser runtimes, UI frameworks, or asset build systems before adding them.
- Never commit secrets or generated `bin`, `obj`, `preview`, `dist`, or package outputs.

## Checking Changes

Restore and build after code or dependency changes. There are no automated test
projects; an empty `dotnet test` run is not coverage. Documentation-only changes
need no build.

For rendering, navigation, or asset changes, run `dotnet run -- --preview` from
`sample` and check affected routes, responsive layouts, light/dark modes, keyboard
access, and navigation without JavaScript. Check subpath base URLs for link or
asset changes. Stop the preview before rebuilding; use `dotnet run -- --build`
for static output. See [sample/README.md](sample/README.md) for details.

## Releases

Push a new `v*` tag to trigger the [release workflow](.github/workflows/main.yaml):
build, attach the theme ZIP, and deploy the sample to GitHub Pages. Other triggers
do not publish releases; NuGet packages are not published.

Use `v1.0.0-preview.<yyyymmdd>.<sequence>` for previews, such as
`v1.0.0-preview.20260915.1`. Use the release date, starting at `1` each day.
Stable tags use `v<major>.<minor>.<patch>`. Never move or reuse a published tag.

The workflow preserves version suffixes but does not validate full
[SemVer](https://semver.org/) syntax or automatically set GitHub's prerelease flag.

## Commits and Pull Requests

Keep commits focused and use [Conventional Commits](https://www.conventionalcommits.org/):
`type(scope): description` (scope optional), such as `fix(theme): preserve tag links`.

Commit types and branch prefixes: `build`, `chore`, `ci`, `docs`, `feat`, `fix`,
`perf`, `refactor`, `revert`, `style`, `test`.
Mark breaking changes with `!` or a `BREAKING CHANGE:` footer.

Complete every section of the [PR template](.github/PULL_REQUEST_TEMPLATE.md),
using `N/A` where appropriate. Explain the change, breaking changes or migration,
and checks performed or skipped. Ensure CI passes and link related issues; use
closing references only for issues the PR resolves.

## Issues and Support

Use the [bug report](.github/ISSUE_TEMPLATE/bug_report.yml) or
[feature request](.github/ISSUE_TEMPLATE/feature_request.yml) template.
Report vulnerabilities privately via [SECURITY.md](SECURITY.md).
For usage questions, see [SUPPORT.md](SUPPORT.md).
