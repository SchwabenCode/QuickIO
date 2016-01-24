using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class InternalHelpersTests
    {

        [Fact]
        public void AddFileAttrribute()
        {
            FileAttributes attr = FileAttributes.Archive;

            FileAttributes result = InternalHelpers.AddFileAttrribute( attr, FileAttributes.System );

            InternalHelpers.ContainsFileAttribute( result, FileAttributes.Archive ).Should().Be( true );
            InternalHelpers.ContainsFileAttribute( result, FileAttributes.System ).Should().Be( true );
        }

        [Fact]
        public void TryAddFileAttrribute()
        {
            FileAttributes attr = FileAttributes.Archive;

            InternalHelpers.TryAddFileAttrribute( attr, FileAttributes.System, out attr ).Should().BeTrue( "First add failed" );
            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.System ).Should().Be( true, "First test failed" );

            InternalHelpers.TryAddFileAttrribute( attr, FileAttributes.System, out attr ).Should().BeFalse( "Second add failed" );
            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.System ).Should().Be( true, "Second test failed" );
        }

        [Fact]
        public void TryRemoveFileAttrribute()
        {
            FileAttributes attr = FileAttributes.Archive | FileAttributes.System;

            InternalHelpers.TryRemoveFileAttrribute( attr, FileAttributes.System, out attr ).Should().BeTrue( "First remove failed" );
            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.System ).Should().Be( false, "First test failed" );

            InternalHelpers.TryRemoveFileAttrribute( attr, FileAttributes.System, out attr ).Should().BeFalse( "Second remove failed" );
            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.System ).Should().Be( false, "First test failed" );
        }

        [Fact]
        public void RemoveFileAttribute()
        {
            FileAttributes attr = FileAttributes.Archive | FileAttributes.System;

            FileAttributes result = InternalHelpers.RemoveFileAttribute( attr, FileAttributes.Archive );

            InternalHelpers.ContainsFileAttribute( result, FileAttributes.Archive ).Should().Be( false );
            InternalHelpers.ContainsFileAttribute( result, FileAttributes.System ).Should().Be( true );
        }

        [Fact]
        public void ContainsFileAttribute()
        {
            FileAttributes attr = FileAttributes.Archive;

            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.Archive ).Should().Be( true );
            InternalHelpers.ContainsFileAttribute( attr, FileAttributes.System ).Should().Be( false );
        }
    }
}
