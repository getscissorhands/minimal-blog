# Minimal Blog preview

This project provides an end-to-end preview using the latest ScissorHands.NET packages from NuGet.org and the committed relative symlink `themes/minimal-blog -> ../../src`.

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

The sample enables the Google Analytics and Open Graph plugins. Replace the placeholder Google Analytics measurement ID in `appsettings.json` before using it outside local development.
