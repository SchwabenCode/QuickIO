# QuickIO.NET ![License](https://img.shields.io/github/license/SchwabenCode/QuickIO.png?style=flat-square)
**by [SchwabenCode.com](http://www.schwabencode.com) - [Benjamin Abt](http://www.benjamin-abt.com)**

| Visual Studio Build  | NuGet Stable | NuGet Pre | GitHub latest | Open Issues
|---|---|---|---|---|
| master: - | ![NuGetStable](https://img.shields.io/nuget/v/QuickIO.NET.png?style=flat-square)  | ![NuGetPre](https://img.shields.io/nuget/vpre/QuickIO.NET.png?style=flat-square) | ![GitHubRelease](https://img.shields.io/github/release/SchwabenCode/QuickIO.png?style=flat-square) | ![GitHubRelease](https://img.shields.io/github/issues/SchwabenCode/QuickIO.png?style=flat-square) |
| develop: ![develop](https://schwabencode.visualstudio.com/DefaultCollection/_apis/public/build/definitions/1838fe47-1e26-4f59-924a-59ea28e64d6a/13/badge) | ![NuGetStable](https://img.shields.io/nuget/dt/QuickIO.NET.png?style=flat-square) | | | | |

## Website
Checkout the official Page [http://quickIO.NET](http://quickIO.NET)

## Current Source State January, 17 2015
- New source base
- All operations will be refactored to use normalized strings for better performance
- Project focus is Windows base. Cross-Plattform Support with QuickIO 4.0 and DNX.
- Drop support for older .NET versions. At least 4.0 required (right now)
- License changed to MIT
- Cancellation support for all async operations
- Code Contracts

Master branch is the current development branch. With the first stable release of QuickIO 3.0 project will be changed to support GIT Workflow.

## Project Description
QuickIO.NET is an extension for the .NET Framework to provide faster file operations.
To offer you a simple use and an easy integration QuickIO.NET methods lean against the ones provided by the .NET Framework.

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
* **Async** Operations (requires .NET 4.0)
* Multiple releases from .NET 2.0 to .NET 4.5

## Give Thanks
It took many hours to create this library in its published form.  
If you like the library and saved you much time, then maybe respect this with a small donation to the [animal shelter of Stuttgart](http://www.tierheim-stuttgart.de/).

If you want to thank me personally, take a look at [my personal Amazon wishlist](http://www.amazon.de/gp/registry/wishlist/H6KLKT7UMI7Z/).

It would be also very nice when you just write me, if you like this implementation and tell me what you've started!

## License
[MIT License](https://github.com/SchwabenCode/QuickIO/blob/master/LICENSE.md)

> Copyright (c) 2016 Benjamin Abt
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## NuGet
```
Install-Package QuickIO.NET
```
or visit [QuickIO.NET on NuGet](https://www.nuget.org/packages/QuickIO.NET/)

## Branches
- [master](https://github.com/SchwabenCode/QuickIO/tree/master): stable
- [develop](https://github.com/SchwabenCode/QuickIO/tree/develop): used during development

## Remarks
This library was created on the basis of my own needs. I am not responsible for integration issues, errors or any damage.
On usage problems, please use public forums. For bugs and features please fork to your own branch, fix it and create a pull request or use the [issue tab](https://github.com/SchwabenCode/QuickIO/issues).

Thank you and good luck with your software.