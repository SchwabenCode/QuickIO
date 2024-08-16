namespace SchwabenCode.QuickIO;

public partial class QuickIOFileInfo
{
    /// <summary>
    /// Default ChunkSize
    /// </summary>
    private const int DefaultChunkSize = 1024; // Bytes


    /// <summary>
    /// Returns the file chunks by given chunksize
    /// </summary>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Collection of chunks. On enumerator, the file gets read.</returns>
    public IEnumerable<QuickIOFileChunk> GetFileChunks(int chunkSize = DefaultChunkSize)
    {
        return InternalEnumerateFileChunks(chunkSize);
    }

    /// <summary>
    /// Returns the chunks of current file that are identical with the other file
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Returns the chunks of current file that are identical with the other file</returns>
    public IEnumerable<QuickIOFileChunk> GetFileChunksEqual(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        IEnumerator<QuickIOFileChunk> en1 = GetFileChunksEnumerator( chunkSize );
        IEnumerator<QuickIOFileChunk> en2 = file.GetFileChunksEnumerator( chunkSize );

        while (en1.MoveNext() && en2.MoveNext())
        {
            // check of the chunks are equal
            if (en1.Current.ChunkEquals(en2.Current))
            {
                // equal
                yield return en1.Current;
            }
        }
    }

    /// <summary>
    /// Returns the chunks of current file that are NOT identical with the other file
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Returns the chunks of current file that are NOT identical with the other file</returns>
    public IEnumerable<QuickIOFileChunk> GetFileChunksUnequal(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        IEnumerator<QuickIOFileChunk> en1 = GetFileChunksEnumerator( chunkSize );
        IEnumerator<QuickIOFileChunk> en2 = file.GetFileChunksEnumerator( chunkSize );

        while (en1.MoveNext())
        {
            bool mn2 = en2.MoveNext( );

            // EOF of file2?
            if (!mn2)
            {
                // current chunk must be unequal
                yield return en1.Current;
            }
            else
            {
                // check of the chunks are unequal
                if (!en1.Current.ChunkEquals(en2.Current))
                {
                    // unequal
                    yield return en1.Current;
                }
            }
        }
    }

    /// <summary>
    /// Returns the <see>
    ///         <cref>IEnumerator</cref></see>
    ///   of <see cref="GetFileChunks"/>
    /// </summary>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns></returns>
    public IEnumerator<QuickIOFileChunk> GetFileChunksEnumerator(int chunkSize = DefaultChunkSize)
    {
        return GetFileChunks(chunkSize).GetEnumerator();
    }

    /// <summary>
    /// Checks if both file contents are equal.
    /// Opens both files for read and breaks on first unequal chunk.
    /// </summary>
    /// <param name="file">File to compare</param>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>true if contents are equal</returns>
    public bool IsEqualContents(QuickIOFileInfo file, int chunkSize = DefaultChunkSize)
    {
        IEnumerator<QuickIOFileChunk> en1 = GetFileChunksEnumerator( chunkSize );
        IEnumerator<QuickIOFileChunk> en2 = file.GetFileChunksEnumerator( chunkSize );

        while (true)
        {
            // Go to next element
            bool mn1 = en1.MoveNext( );
            bool mn2 = en2.MoveNext( );

            // check if next element exists
            if (mn1 != mn2)
            {
                // collections count diff
                return false;
            }

            // no more elements in both collections
            if (!mn1)
            {
                return true;
            }

            // check chunks
            QuickIOFileChunk chunk1 = en1.Current;
            QuickIOFileChunk chunk2 = en2.Current;

            if (!chunk1.ChunkEquals(chunk2))
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Reads the file and returns containign chunks
    /// </summary>
    /// <param name="chunkSize">Chunk size (Bytes)</param>
    /// <returns>Collection of chunks</returns>
    private IEnumerable<QuickIOFileChunk> InternalEnumerateFileChunks(int chunkSize = DefaultChunkSize)
    {
        FileStream fs;
        try
        {
            // Open first File
            fs = OpenRead();
        }
        catch (Exception e)
        {
            throw new Exception("Failed to file to read", e);
        }

        using (fs)
        {
            // check buffer for small files; will be faster
            byte[] bytes = new byte[ Math.Min( fs.Length, chunkSize ) ];

            ulong position = 0;
            // transfer chunks
            while ((fs.Read(bytes, 0, bytes.Length)) > 0)
            {
                //var arr = new byte[ bytes.Length ];
                //Buffer.BlockCopy( bytes, 0, arr, 0, bytes.Length );
                yield return new QuickIOFileChunk(position, bytes);
                position += Convert.ToUInt64(bytes.Length);
            }
        }
    }
}
