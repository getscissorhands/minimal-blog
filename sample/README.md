# Minimal Blog preview

This provides an end-to-end preview with the theme linked at `themes/minimal-blog` to `../../src`.

## Build

Set up the [theme link](../README.md#local-preview) before building. From the repository root:

```bash
dotnet restore && dotnet build
```

## Running the preview

Run from this directory:

```bash
dotnet run -- --preview
```

Generate static files without starting the preview server:

```bash
dotnet run -- --build
```

Generated preview and build outputs are written to `preview/` and `dist/` respectively.
Never deploy `preview/`: it includes draft and scheduled content.

## Theme settings

- Locale:
  - Primary locale: `en-us`
  - Additional locale: `ko-kr`
- Default timezone: `UTC`

## Plugin settings

### Google Analytics

- `MeasurementId`: `G-EXAMPLE` is a placeholder, not a network opt-out. Use a real ID only for deployment; block external requests when testing locally in a browser.

### Open Graph

- `TwitterSiteId`: `@getscissorhands` is used, which needs to be replaced with yours. If you don't have a Twitter account, remove this.
