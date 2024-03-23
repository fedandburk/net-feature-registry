# Feature Registry
![GitHub](https://img.shields.io/github/license/fedandburk/net-feature-registry.svg)
![Nuget](https://img.shields.io/nuget/v/Fedandburk.FeatureRegistry.svg)
[![CI](https://github.com/fedandburk/net-feature-registry/actions/workflows/ci.yml/badge.svg)](https://github.com/fedandburk/net-feature-registry/actions/workflows/ci.yml)
[![CD](https://github.com/fedandburk/net-feature-registry/actions/workflows/cd.yml/badge.svg)](https://github.com/fedandburk/net-feature-registry/actions/workflows/cd.yml)
[![CodeFactor](https://www.codefactor.io/repository/github/fedandburk/net-feature-registry/badge)](https://www.codefactor.io/repository/github/fedandburk/net-feature-registry)

Provides a singleton to store the information about enabled or disabled application features. Features can be represented by a `string`, `Type` or `Enum`.

## Installation

Use [NuGet](https://www.nuget.org) package manager to install this library.

```bash
Install-Package Fedandburk.FeatureRegistry
```

## Usage
```csharp
using Fedandburk.FeatureRegistry;

FeatureRegistry.Default["Feature"] = true;
var isEnabled = FeatureRegistry.Default["Feature"];

FeatureRegistry.Default[Features.Feature] = true;
var isEnabled = FeatureRegistry.Default[Features.Feature];

FeatureRegistry.Default[typeof(Feature)] = true;
var isEnabled = FeatureRegistry.Default[typeof(Feature)];
```