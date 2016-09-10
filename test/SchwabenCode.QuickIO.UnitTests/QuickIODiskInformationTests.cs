using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIODiskInformationTests
    {
        public void QuickIODiskInformationCtor()
        {
            QuickIODiskInformation di = new QuickIODiskInformation( 1, 2, 3 );

            di.Should().NotBeNull();
            di.FreeBytes.Should().Be( 1 );
            di.TotalBytes.Should().Be( 2 );
            di.TotalFreeBytes.Should().Be( 3 );
        }
    }
}
