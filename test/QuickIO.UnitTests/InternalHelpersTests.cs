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

            InternalHelpers.ContainsFileAttribute( result, FileAttributes.System ).Should().Be( true );
        }

        [Fact]
        public void RemoveFileAttribute()
        {
            FileAttributes attr = FileAttributes.Archive | FileAttributes.Normal;

            FileAttributes result = InternalHelpers.RemoveFileAttribute( attr, FileAttributes.Archive );

            InternalHelpers.ContainsFileAttribute( result, FileAttributes.Archive ).Should().Be( false );
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
