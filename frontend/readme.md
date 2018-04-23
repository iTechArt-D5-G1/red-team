# Lab Frontend App Environment

## IDE
VSCode https://go.microsoft.com/fwlink/?Linkid=852157

Plugins: EditorConfig, ESLint, StyleLint, Stylefmt + any you like

## Source control flow

git + github

Branch per user story (e.g. survey-edit or authentication).

Master branch is an integration point and it is a base branch for user story branches.

To merge user story branch into master create a pull request via github UI and add reviewers (mentors).

## Environment

### dev runtime:
node.js (globally installed) https://nodejs.org/dist/v9.4.0/node-v9.4.0-x64.msi

eslint/stylelint, babel, webpack, webpack-dev-server, HMR, react hot reload

### package manager:
yarn (globally installed) https://github.com/yarnpkg/yarn/releases/download/v1.3.2/yarn-1.3.2.msi

### JS:
ES 2015+, React, Redux

### Styles:
Sass

## Targeted browsers:

Latest 2 Firefox versions (desktop/android/ios) / Latest 2 Chrome versions (desktop/android/ios)

## Targeted devices:

Dekstop, Apple iPhone 7, Samsung S8

## How to start

Run the following console from VSCode terminal or console from project root folder:

`yarn start`
