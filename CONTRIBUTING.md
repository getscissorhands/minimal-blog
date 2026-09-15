# Contributing to Minimal Blog

This repository is a ScissorHands.NET theme, not the engine. It renders
static HTML with Razor and uses framework-free CSS and plain JavaScript.
See the [theme documentation](https://getscissorhands.app/docs/themes/) for
theme APIs and customization.

## Code of Conduct

This project adheres to the [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md).
By participating, you are expected to uphold this code.

## Getting Started

Fork and clone the repository, then create a focused branch for your change.

Install the .NET SDK selected by [global.json](global.json), then create a
branch using `type/short-kebab-case-description`, such as
`feat/theme-navigation`, `fix/tag-links`, or `docs/preview-setup`.

Before building on Windows, follow the [local preview setup](README.md#local-preview)
to ensure Git checked out the committed theme symlink correctly.
From the repository root, run:

```shell
dotnet restore
dotnet build --configuration Release --no-restore
```

## Making Changes

Follow [.editorconfig](.editorconfig), nearby code conventions, and the theme
contracts in [AGENTS.md](AGENTS.md). Keep changes focused and include directly
related documentation.

Keep package versions in [Directory.Packages.props](Directory.Packages.props)
and project references versionless. Preserve the existing major-version
floating policy. Dependabot checks NuGet and GitHub Actions weekly; floating
NuGet references may not result in version-update pull requests.

Do not introduce a browser runtime, UI framework, or JavaScript build step
without discussing the change first. Do not commit credentials, local settings
containing secrets, or generated `bin`, `obj`, `preview`, `dist`, or package
outputs.

## Checking Changes

There are currently no automated test projects; CI restores packages and builds
the Release solution. Its test step remains disabled until test projects are
added. Do not treat a successful `dotnet test` invocation with no test projects
as test coverage.

For rendering, navigation, or asset changes, run the sample from its directory:

```shell
cd sample
dotnet run -- --preview
```

Inspect the rendered output and exercise affected views, desktop/mobile widths,
light/dark modes, keyboard controls, and navigation without JavaScript. Check a
subpath base URL when changing links or assets. See [AGENTS.md](AGENTS.md) for
the relevant theme contracts and [sample/README.md](sample/README.md) for preview
details.

Stop the preview before rebuilding. To generate static output instead, run
`dotnet run -- --build` from `sample`. Documentation-only changes do not require
a .NET build.

## Releases

The [build and release workflow](.github/workflows/main.yaml) creates a GitHub
release whenever a new `v*` tag is pushed, after the Release solution build
succeeds. Use `v` followed by a [SemVer 2.0.0](https://semver.org/) version, such
as `v1.2.3` or `v1.2.3-preview.1`. The workflow extracts the version from the tag
without enforcing full SemVer syntax or setting GitHub's prerelease flag.
Version suffixes and build metadata such as `v1.2.3+build.42` are preserved.

The release job checks the version from the pushed tag and uses its output to
set the GitHub release tag explicitly. Releases attach the packaged theme
archive, generate the sample site, and deploy the demo to GitHub Pages. The
workflow does not publish NuGet packages.

Branch pushes, updates to existing tags, pull requests, and manual workflow runs
only build the solution and do not create releases.

## Pull Request Process

- Keep each commit a complete logical change that can be reviewed and reverted
  independently.
- Complete every section of the [pull request template](.github/PULL_REQUEST_TEMPLATE.md),
  using `N/A` where appropriate.
- Explain the motivation, approach, breaking changes, and any migration steps.
- Describe how you checked the result and disclose checks that were blocked or
  not performed. Ensure CI passes before requesting a merge.
- Link related issues; use a closing reference only when the pull request
  actually resolves the issue.

## Commit Convention

Use [Conventional Commits](https://www.conventionalcommits.org/) in the form
`type(scope): description`, with an optional scope. For example:
`fix(theme): preserve subpath tag links` or `docs: clarify preview setup`.

Allowed types are `build`, `chore`, `ci`, `docs`, `feat`, `fix`, `perf`,
`refactor`, `revert`, `style`, and `test`. Use the same types as branch prefixes.
Mark breaking changes with `!` or a `BREAKING CHANGE:` footer.

## Reporting Bugs

Use the [bug report template](.github/ISSUE_TEMPLATE/bug_report.yml).
Include steps to reproduce, expected behavior, and your environment details.
Report suspected vulnerabilities privately using [SECURITY.md](SECURITY.md),
not in a public issue. For usage questions, see [SUPPORT.md](SUPPORT.md).

## Requesting Features

Use the [feature request template](.github/ISSUE_TEMPLATE/feature_request.yml).
Describe the problem, your proposed solution, and any alternatives considered.
