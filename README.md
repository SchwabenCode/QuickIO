# QuickIO.NET
**by [SchwabenCode.com](http://www.schwabencode.com) - [Benjamin Abt](http://www.benjamin-abt.com)**

| Branch | Type | AppVeyor | NuGet Package |
|---|---|---|---|
|master| Stable |  [![AppVeyor Stable](https://img.shields.io/appveyor/ci/BenjaminAbt/QuickIO/master.svg?style=flat-square)](https://ci.appveyor.com/project/BenjaminAbt/QuickIO) | [![NuGet](https://img.shields.io/nuget/v/QuickIO.NET.svg?style=flat-square)](https://www.nuget.org/packages/QuickIO.NET) on [NuGet](https://www.nuget.org/packages/QuickIO.NET)|
|develop| Pre Releases | [![AppVeyor Unstable](https://img.shields.io/appveyor/ci/BenjaminAbt/QuickIO/develop.svg?style=flat-square)](https://ci.appveyor.com/project/BenjaminAbt/QuickIO) | [![MyGet](https://img.shields.io/myget/schwabencode/vpre/QuickIO.NET.svg?style=flat-square)](https://www.myget.org/feed/schwabencode/package/nuget/QuickIO.NET) on [MyGet](https://www.myget.org/feed/schwabencode/package/nuget/QuickIO.NET) |

# Project Description
QuickIO.NET is an extension for the .NET Framework to provide faster file operations.
To offer you a simple use and an easy integration QuickIO.NET methods lean against the ones provided by the .NET Framework.

# Main features
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

It would be also very nice when you just write me, if you like this implementation and tell me what you've started!

## License
	MIT License

	Copyright (c) 2016 Benjamin Abt

	Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

# Releases

## Stable on NuGet
We publish stable releases to NuGet.

    Install-Package QuickIO.NET

See [QuickIO.NET on NuGet](https://www.nuget.org/packages/QuickIO.NET/)

## Pre on MyGet

Use our [SchwabenCode Development feed](https://www.myget.org/gallery/schwabencode) `https://www.myget.org/F/schwabencode/api/v3/index.json` on [MyGet](https://www.myget.org/gallery/schwabencode) for unstable releases.

    Install-Package QuickIO.NET -Pre

See [QuickIO.NET on MyGet](https://www.myget.org/feed/schwabencode/package/nuget/QuickIO.NET)

## Branches
- [master](https://github.com/SchwabenCode/QuickIO/tree/master): stable
- [develop](https://github.com/SchwabenCode/QuickIO/tree/develop): used during development

## Contributors
I want to say thank you to following contributors
- [Avinash Puchalapalli](https://github.com/holycrepe)

## Remarks
This library was created on the basis of my own needs. I am not responsible for integration issues, errors or any damage.
On usage problems, please use public forums. For bugs and features please fork to your own branch, fix it and create a pull request or use the [issue tab](https://github.com/SchwabenCode/QuickIO/issues).

Thank you and good luck with your software.
