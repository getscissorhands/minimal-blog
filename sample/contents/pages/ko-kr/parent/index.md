---
title: 상위 페이지
description: 디렉터리 인덱스와 중첩 탐색 예제입니다.
show_in_navigation: true
tags:
  - hierarchy
  - navigation
---

## 디렉터리의 시작 페이지

이 페이지는 영어 `pages/parent/index.md`와 짝을 이루는 실제 번역입니다.
두 파일 모두 `slug`를 생략해 `parent` 경로를 사용합니다.

[하위 페이지](parent/child)는 번역이 없으므로 한국어 경로에서 영어 원문과
번역 안내문을 표시합니다. [영어 원문으로 이동](parent/child){data-localize="false"}하면
기본 언어 경로로 이동합니다.

[보이는 손자 페이지](parent/group/visible-grandchild)는 페이지가 없는
Group 아래에 표시됩니다. [숨겨진 손자 페이지](parent/group/hidden-grandchild)는
메뉴에 나타나지 않지만 직접 방문할 수 있습니다.
