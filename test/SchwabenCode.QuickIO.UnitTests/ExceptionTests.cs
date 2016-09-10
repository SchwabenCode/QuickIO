using System;
using FluentAssertions;
using SchwabenCode.QuickIO.UnitTests.TestClasses;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class ExceptionTests
    {
        [Fact]
        public void DirectoryAlreadyExistsExceptionCtor()
        {
            DirectoryAlreadyExistsException ex = new DirectoryAlreadyExistsException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void DirectoryNotEmptyExceptionCtor()
        {
            DirectoryNotEmptyException ex = new DirectoryNotEmptyException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void FileAlreadyExistsExceptionCtor1()
        {
            FileAlreadyExistsException ex = new FileAlreadyExistsException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void FileAlreadyExistsExceptionCtor2()
        {
            FileAlreadyExistsException ex = new FileAlreadyExistsException( "path" );
            ex.Message.Should().Be( "Cannot create a file when that file already exists." );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void FileSystemIsBusyExceptionCtor()
        {
            FileSystemIsBusyException ex = new FileSystemIsBusyException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void InvalidPathExceptionCtor1()
        {
            InvalidPathException ex = new InvalidPathException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void InvalidPathExceptionCtor2()
        {
            InvalidPathException ex = new InvalidPathException( "path" );
            ex.Message.Should().Be( "The filename, directory name, or volume label syntax is incorrect." );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void PathAlreadyExistsExceptionCtor1()
        {
            PathAlreadyExistsException ex = new PathAlreadyExistsException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void PathNotFoundExceptionCtor1()
        {
            PathNotFoundException ex = new PathNotFoundException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void PathNotFoundExceptionCtor2()
        {
            PathNotFoundException ex = new PathNotFoundException( "path" );
            ex.Message.Should().Be( "The system cannot find the path specified" );
            ex.Path.Should().Be( "path" );
        }

        [ Fact ]
        public void QuickIOBaseExceptionCtor1()
        {
            QuickIOBaseException ex = new TestExceptionClass( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void QuickIOBaseExceptionCtor2()
        {
            Exception inner = new Exception( "InnerExMessage" );

            QuickIOBaseException ex = new TestExceptionClass( "message", "path", inner );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
            ex.InnerException.Should().Be( inner );
        }

        [Fact]
        public void QuickIOTransferAlreadyRunningExceptionCtor1()
        {
            QuickIOTransferAlreadyRunningException ex = new QuickIOTransferAlreadyRunningException( "message" );
            ex.Message.Should().Be( "message" );
        }

        [Fact]
        public void UnmatchedFileSystemEntryTypeExceptionCtor1()
        {
            UnmatchedFileSystemEntryTypeException ex = new UnmatchedFileSystemEntryTypeException( QuickIOFileSystemEntryType.Directory, QuickIOFileSystemEntryType.Directory, "path" );
            ex.Message.Should().Be( "FileSystemEntryType not matched!" );
            ex.Expected.Should().Be( QuickIOFileSystemEntryType.Directory );
            ex.Found.Should().Be( QuickIOFileSystemEntryType.Directory );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void UnsupportedDriveTypeExceptionCtor1()
        {
            UnsupportedDriveTypeException ex = new UnsupportedDriveTypeException( "path" );
            ex.Message.Should().Be( "Unsupported Drive Type: only logical drives are supported; do not use mapped network drives." );
            ex.Path.Should().Be( "path" );
        }

        [Fact]
        public void UnsupportedShareTypeExceptionCtor1()
        {
            UnsupportedShareTypeException ex = new UnsupportedShareTypeException( "message", "path" );
            ex.Message.Should().Be( "message" );
            ex.Path.Should().Be( "path" );
        }
    }
}