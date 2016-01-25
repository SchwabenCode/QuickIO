using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SchwabenCode.QuickIO.Core;
using Xunit;

namespace SchwabenCode.QuickIO.IntegrationTests
{
    public class QuickIOPathInfoTests : IntegrationTestBase
    {
        [Fact]
        public void QuickIOPathInfoFile()
        {
            string parent = QuickIOPath.Combine( CurrentPath(), "_TestFiles" );
            string fullpath = QuickIOPath.Combine( CurrentPath(), "_TestFiles", "ExistingTestFile.txt" );
            string fullPathUnc = QuickIOPath.ToPathUnc( fullpath );
            string root = QuickIOPath.GetPathRoot( fullpath );

            QuickIOPathInfo pi = new QuickIOPathInfo( fullpath );

            pi.Should().NotBe( null );

            pi.Name.Should().Be( "ExistingTestFile.txt" );
            pi.FullName.Should().Be( fullpath );
            pi.FullNameUnc.Should().Be( fullPathUnc );
            pi.Parent.Should().Be( parent );
            pi.Root.Should().Be( root );
            pi.IsRoot.Should().Be( false );
            pi.FindData.Should().NotBe( null );
            InternalHelpers.ContainsFileAttribute( pi.Attributes, FileAttributes.Directory ).Should().Be( false );
            pi.Exists.Should().Be( true );
            pi.SystemEntryType.Should().Be( QuickIOFileSystemEntryType.File );


        }
    }
}
