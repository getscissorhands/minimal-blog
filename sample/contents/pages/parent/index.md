---
title: Parent
description: A directory index with nested navigation examples.
show_in_navigation: true
tags:
  - hierarchy
  - navigation
---

## A page for a directory

This page lives at `pages/parent/index.md`. With no `slug` in its frontmatter,
the engine gives it the `parent` route instead of `parent/index`.

The [Child](parent/child) and [Child 2](parent/child-2) pages use numbered
filenames to choose their reading order, but have clean URLs through explicit
slugs. Between them is a Group with no landing page: its
[Visible Grandchild](parent/group/visible-grandchild) keeps a non-clickable
Group label in the navigation.

Each visible page opts in with `show_in_navigation: true`. The links below
each page follow the source-file reading order, even across directories.
Try the [Hidden Grandchild](parent/group/hidden-grandchild) directly: it is
published and tagged, but absent from navigation and previous/next links.
