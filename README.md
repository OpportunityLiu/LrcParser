# LrcParser
[![Build status](https://ci.appveyor.com/api/projects/status/7ne8mex2di844260?svg=true)](https://ci.appveyor.com/project/OpportunityLiu/lrcparser)
[![NuGet](https://img.shields.io/nuget/v/Opportunity.LrcParser.svg)](https://www.nuget.org/packages/Opportunity.LrcParser/)  
An library for lrc files.

## Quick Start

### Parse An `LRC` File

To parse `lrc` files, use `Lyrics.Parse(string)` method, overloads can be used for variants of `lrc` formats.

### Stringify A `Lyrics` Instance

To create `lrc` file with a `Lyrics<TLine>` instance, call its `ToString()` method, you can also use `ToString(LyricsFormat)` overload to specify format settings.
