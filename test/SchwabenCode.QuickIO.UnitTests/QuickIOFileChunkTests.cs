using FluentAssertions;
using Xunit;

namespace SchwabenCode.QuickIO.UnitTests
{
    public class QuickIOFileChunkTests
    {
        [Fact]
        public void QuickIOFileChunkEqualTests()
        {
            var position = 1;
            byte[ ] bytes = new byte[ 10 ];

            QuickIOFileChunk chunk = new QuickIOFileChunk( 1, bytes );
            chunk.Position.Should().Be( 1 );
            chunk.Bytes.Should().Equal( bytes );

            QuickIOFileChunk sameChunk = new QuickIOFileChunk( 1, bytes );
            sameChunk.Position.Should().Be( 1 );
            sameChunk.Bytes.Should().Equal( bytes );

            chunk.PositionEquals( sameChunk ).Should().Be( true );
            chunk.BytesEquals( sameChunk ).Should().Be( true );
            chunk.ChunkEquals( sameChunk ).Should().Be( true );
            chunk.Equals( sameChunk ).Should().Be( false );

            byte[ ] otherBytes = new byte[ 5 ];
            QuickIOFileChunk otherChunk = new QuickIOFileChunk( 2, otherBytes );
            otherChunk.Position.Should().Be( 2 );
            otherChunk.Bytes.Should().Equal( otherBytes );

            chunk.PositionEquals( otherChunk ).Should().Be( false );
            chunk.BytesEquals( otherChunk ).Should().Be( false );
            chunk.ChunkEquals( otherChunk ).Should().Be( false );
            chunk.Equals( otherChunk ).Should().Be( false );

        }
    }
}
