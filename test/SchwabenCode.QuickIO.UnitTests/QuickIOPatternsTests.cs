using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOPatternsTests
    {
        [Fact]
        public void PathMatchAllTest(  )
        {
            QuickIOPatterns.PathMatchAll.Should().Be( "*" );
        }
    }
}
