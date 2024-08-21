# QuickIO.NET ![GitHub Sponsors](https://img.shields.io/github/sponsors/BenjaminAbt?label=Sponsor%20QuckIO.NET)


**by [Benjamin Abt](http://www.benjamin-abt.com) - [SchwabenCode.com](http://www.schwabencode.com)**

QuickIO is a library that extends and accelerates .NET methods for file operations by not using the .NET abstraction for file operations, but by communicating directly with the Win32 API and avoiding unnecessary early overhead.


## Installation

![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/SchwabenCode/QuickIO/main.yml?branch=main&label=GitHub%20Action)


[![QuickIO.NET](https://img.shields.io/nuget/v/QuickIO.NET.svg?logo=nuget&label=QuickIO.NET%20NuGet)](https://www.nuget.org/packages/QuickIO.NET)


```shell
# CLI
dotnet add package QuickIO.NET --version yourVersion

# Package Reference
<PackageReference Include="QuickIO.NET" Version="yourVersion" />

# Directory.Packages.props
<PackageVersion Include="QuickIO.NET" Version="yourVersion" />

# replace yourVersion with the specific verison
```

See [QuickIO.NET on NuGet.org](https://www.nuget.org/packages/QuickIO.NET)

## Main features

* **Much** faster browsing of folder structures (up to 30x faster)
* Lightning-fast retrieve of **metadata** of folders, files, and directory structures
* File chunk support for reading, comparisons and hashing.
* Data transfer services **monitored file and directory copy/move with progress events**
* Custom service and job support (via extensions and own implementation)
* **Long path support** (UNC paths) up to 32767 characters
* Calculate **checksums of files and file chunks**
* Fully tested source code using UnitTests
* Nearly identical signature of methods. So a simple replacement is possible

## Roadmap

QuickIO was not developed further for many years, partly due to time constraints and partly in the hope that file operations in .NET would become more efficient. Many workarounds from the .NET Framework 4.0 era are currently included, e.g. asynchronous operations.
Starting in July 2024, the migration to a new codebase has begun. Version 3 will be a transition phase that will only support Windows. Version 4 will then be a cross-platform solution.

## Give Thanks ![GitHub Sponsors](https://img.shields.io/github/sponsors/BenjaminAbt?label=Sponsors)

It took many hours to create this library.  
If you like the library and saved you much time, then maybe respect this with a small donation to the [animal shelter of Stuttgart](http://www.tierheim-stuttgart.de/).

It would be also very nice when you just write me, if you like this implementation and tell me what you've started!

## License ![GitHub License](https://img.shields.io/github/license/SchwabenCode/QuickIO)


>    MIT License
>    Copyright (c) 2013-2024 Benjamin Abt
>
>    Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
>
>    The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
>
>    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Remarks
This library was created on the basis of my own needs. I am not responsible for integration issues, errors or any damage.
On usage problems, please use public forums. For bugs and features please fork to your own branch, fix it and create a pull request or use the [issue tab](https://github.com/SchwabenCode/QuickIO/issues).

Thank you and all the best for your software.

## History

QuickIO was initially developed on CodePlex and migrated to GitHub in 2016 after CodePlex was discontinued. During the migration, as it later turned out, not all of the history was transferred; however, since CodePlex no longer exists, the history is lost.