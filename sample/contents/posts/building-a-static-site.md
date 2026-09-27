---
title: Building a static site
description: Follow a Markdown article from source to a published ScissorHands.NET page.
author: ScissorHands Team
hero_image: images/scissorhands-net.jpg
published: 2026-09-01
tags:
  - dotnet
  - static-site
---

## From Markdown to HTML

ScissorHands.NET turns Markdown and a Razor theme into files a static host
can serve. The frontmatter above supplies this post's title, publication date,
image, and tags; the body supplies the article. **Content** and *presentation*
can change independently.

![The shared ScissorHands image](images/scissorhands-net.jpg)

The image is a content asset, shared by both languages. The theme also uses it
as this post's hero image without embedding a remote URL.

### Run the sample

From the `sample` directory, choose the mode for the job:

| Mode | Output | Use |
| --- | --- | --- |
| Preview | `preview/` | Review edits |
| Build | `dist/` | Publish files |

```shell
dotnet run -- --preview
dotnet run -- --build
```

Stop the preview before building. Never deploy `preview/`: it also contains
draft and scheduled documents. A publication date alone does not deploy a
new build.

### Explore the page tree

Pages can form a hierarchy without adding routes in application code:

1. [Parent](parent) is a directory `index.md` with an inferred slug.
2. [Child](parent/child) uses a numbered filename and an explicit clean slug.
3. [Visible Grandchild](parent/group/visible-grandchild) appears beneath a
   non-clickable Group label because that group has no page.

The [Hidden Grandchild](parent/group/hidden-grandchild) is still generated
and tagged, even though it opts out of navigation. Hiding a link is not access
control.

For related content, browse the [static-site tag](tags/static-site) or read
the [About page](about/). Both internal links and the shared image work when
the site is mounted at a subpath.
