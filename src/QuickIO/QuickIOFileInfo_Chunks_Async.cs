using SchwabenCode.QuickIO.Compatibility;

namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{

    /// <summary>
    /// Returns the file chunks by given chunksize
    /// </summary>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Collection of chunks. On enumerator, the file gets read.</returns>
    public Task<IEnumerable<QuickIOFileChunk>> GetFileChunksAsync(int chunkSize = DefaultChunkSize)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetFileChunks(chunkSize));
    }

    /// <summary>
    /// Returns the chunks of current file that are identical with the other file
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Returns the chunks of current file that are identical with the other file</returns>
    public Task<IEnumerable<QuickIOFileChunk>> GetFileChunksEqualAsync(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetFileChunksEqual(file, chunkSize));
    }

    /// <summary>
    /// Returns the chunks of current file that are NOT identical with the other file
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Returns the chunks of current file that are NOT identical with the other file</returns>
    public Task<IEnumerable<QuickIOFileChunk>> GetFileChunksUnequalAsync(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => GetFileChunksUnequal(file, chunkSize));
    }

    /// <summary>
    /// Checks if both file contents are equal.
    /// Opens both files for read and breaks on first unequal chunk.
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>true if contents are equal</returns>
    public Task<bool> IsEqualContentsAsync(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        return NETCompatibility.AsyncExtensions.GetAsyncResult(() => IsEqualContents(file, chunkSize));
    }
}
