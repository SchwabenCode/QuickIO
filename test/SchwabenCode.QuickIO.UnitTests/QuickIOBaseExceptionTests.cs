using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class ExceptionCtorTests
    {
        [Fact]
        public void DirectoryAlreadyExistsExceptionCtor()
        {
            QuickIOBaseException ex = new DirectoryAlreadyExistsException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void DirectoryNotEmptyExceptionCtor()
        {
            QuickIOBaseException ex = new DirectoryNotEmptyException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void FileAlreadyExistsExceptionCtor()
        {
            QuickIOBaseException ex = new FileAlreadyExistsException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void FileSystemIsBusyExceptionCtor()
        {
            QuickIOBaseException ex = new FileSystemIsBusyException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void InvalidPathExceptionCtor()
        {
            QuickIOBaseException ex = new InvalidPathException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void PathAlreadyExistsExceptionCtor()
        {
            QuickIOBaseException ex = new PathAlreadyExistsException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void PathNotFoundExceptionCtor()
        {
            QuickIOBaseException ex = new PathNotFoundException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void UnsupportedDriveTypeExceptionCtor()
        {
            QuickIOBaseException ex = new UnsupportedDriveTypeException("path");
            ex.Message.Should().Be("Unsupported Drive Type: only logical drives are supported; do not use mapped network drives.");
            ex.Path.Should().Be("path");
        }
        [Fact]
        public void UnsupportedShareTypeExceptionCtor()
        {
            QuickIOBaseException ex = new UnsupportedShareTypeException("message", "path");
            ex.Message.Should().Be("message");
            ex.Path.Should().Be("path");
        }
    }
}
