namespace SchwabenCode.QuickIO.UnitTests;

public class RandomTestFileProvider : IDisposable
{
    public IList<string> Files { get; private set; }

    public string GetTestFileDirectory()
    {
        return Path.GetFullPath("TestFiles\\");
    }

    public string GetRandomTestFileName()
    {
        return Path.Combine(GetTestFileDirectory(), Path.GetRandomFileName());
    }

    public string CreateRandomTestFile()
    {
        string testPath = Path.Combine( GetTestFileDirectory( ), Path.GetRandomFileName( ) );
        QuickIOFile.Create(testPath);

        return testPath;
    }

    public RandomTestFileProvider()
    {
        Files = [];
    }

    public void Dispose()
    {
        List<string> tempFiles = Files.ToList( );

        if (Files != null)
        {
            foreach (string? file in tempFiles)
            {
                try
                {
                    File.Delete(file);
                    _ = Files.Remove(file);
                }
                catch (Exception)
                {
                    // I dont care
                }
            }
        }
    }
}
