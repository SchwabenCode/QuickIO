﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOHashTests
    {
        [Theory]
        [InlineData( "Benjamin Abt SchwabenCode", "84c7ab34d2e4dbf1bc9d72f97f356f3defa34ebd" )]
        public void CalculateHashSHA1( string testString, string expectedHash )
        {

            QuickIOHashResult result = QuickIOHash.Calculate( new SHA1Managed(), testString );
            result.Format().Should().Be( expectedHash );
        }
    }
}
