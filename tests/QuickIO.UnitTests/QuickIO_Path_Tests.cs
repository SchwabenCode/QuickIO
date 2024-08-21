using Xunit;

namespace SchwabenCode.QuickIO.UnitTests;

public class QuickIO_Path_Tests
{
    [Fact]
    public void Path_GetRootFromSimplePathTest_HaveToSucceed()
    {
        Assert.Equal(@"C:\", QuickIOPath.GetRootFromLocalPath(@"C:\test\path", QuickIOPathLocation.Local));
        Assert.Equal(@"C:\", QuickIOPath.GetRootFromLocalPath(@"C:\test\path\dsadasd", QuickIOPathLocation.Local));
        Assert.Equal(@"C:\", QuickIOPath.GetRootFromLocalPath(@"C:\test\path\sa\dd\s.jpf", QuickIOPathLocation.Local));
        Assert.Equal(@"C:\", QuickIOPath.GetRootFromLocalPath(@"C:\test\path\", QuickIOPathLocation.Local));
        Assert.Equal(@"C:\", QuickIOPath.GetRootFromLocalPath(@"C:\", QuickIOPathLocation.Local));


        Assert.Equal(@"\\server\share", QuickIOPath.GetRootFromLocalPath(@"\\server\share\s\\s\sss\ssss", QuickIOPathLocation.Share));
        Assert.Equal(@"\\server\share", QuickIOPath.GetRootFromLocalPath(@"\\server\share\s\\ssss", QuickIOPathLocation.Share));
        Assert.Equal(@"\\server\share", QuickIOPath.GetRootFromLocalPath(@"\\server\share", QuickIOPathLocation.Share));
        Assert.Equal(@"\\server\share", QuickIOPath.GetRootFromLocalPath(@"\\server\share\", QuickIOPathLocation.Share));
    }

    [Fact]
    public void Path_TestPathPrefixes()
    {
        Assert.Equal("", QuickIOPath.RegularLocalPathPrefix);
        Assert.Equal(@"\\", QuickIOPath.RegularSharePathPrefix);
        Assert.Equal(@"\\?\", QuickIOPath.UncLocalPathPrefix);
        Assert.Equal(@"\\?\UNC\", QuickIOPath.UncSharePathPrefix);
    }

    [Fact]
    public void Path_ToRegularPathTest()
    {
        Assert.Equal(@"C:\", QuickIOPath.ToRegularPath(@"\\?\C:\"));
        Assert.Equal(@"C:\", QuickIOPath.ToRegularPath(@"C:\"));

        Assert.Equal(@"\\server\share\folder", QuickIOPath.ToRegularPath(@"\\server\share\folder"));
        Assert.Equal(@"\\server\share\folder", QuickIOPath.ToRegularPath(@"\\?\UNC\server\share\folder"));
    }

    [Fact]
    public void Path_ToUncPathTest()
    {
        Assert.Equal(@"\\?\C:\", QuickIOPath.ToUncPath(@"\\?\C:\"));
        Assert.Equal(@"\\?\C:\", QuickIOPath.ToUncPath(@"C:\"));

        Assert.Equal(@"\\?\UNC\server\share\folder", QuickIOPath.ToUncPath(@"\\server\share\folder"));
        Assert.Equal(@"\\?\UNC\server\share\folder", QuickIOPath.ToUncPath(@"\\?\UNC\server\share\folder"));
    }

    [Fact]
    public void Path_GetFullPath_Equal_Test()
    {
        Assert.Equal(Path.GetFullPath("Ben"), QuickIOPath.GetFullPath("Ben"));
    }

    [Fact]
    public void GetFullPathInfo_Equal_Test()
    {
        Assert.Equal(Path.GetFullPath("Ben"), QuickIOPath.GetFullPathInfo("Ben").FullName);
    }

    [Fact]
    public void Path_Const_LocalRegularPrefix_Test()
    {
        Assert.Equal(QuickIOPath.RegularLocalPathPrefix, string.Empty);
    }
    [Fact]
    public void Path_Const_LocalUncPrefix_Test()
    {
        Assert.Equal(QuickIOPath.UncLocalPathPrefix, @"\\?\");
    }
    [Fact]
    public void Path_Const_ShareRegularPrefix_Test()
    {
        Assert.Equal(QuickIOPath.RegularSharePathPrefix, @"\\");
    }
    [Fact]
    public void Path_Const_ShareUncPrefix_Test()
    {
        Assert.Equal(QuickIOPath.UncSharePathPrefix, @"\\?\UNC\");
    }

    [Fact]
    public void Path_ToLocalLocalRegular_Folder_Test()
    {
        const string testPath = @"\\?\C:\temp";
        const string shouldBe = @"C:\temp";
        string convertedPath = QuickIOPath.ToLocalRegularPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }
    [Fact]
    public void Path_ToLocalLocalRegular_File_Test()
    {
        const string testPath = @"\\?\C:\temp\file.txt";
        const string shouldBe = @"C:\temp\file.txt";
        string convertedPath = QuickIOPath.ToLocalRegularPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }

    [Fact]
    public void Path_ToShareRegularPath_Folder_Test()
    {
        const string testPath = @"\\?\UNC\server\share";
        const string shouldBe = @"\\server\share";
        string convertedPath = QuickIOPath.ToShareRegularPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }

    [Fact]
    public void Path_ToShareRegularPath_File_Test()
    {
        const string testPath = @"\\?\UNC\server\share\file.txt";
        const string shouldBe = @"\\server\share\file.txt";
        string convertedPath = QuickIOPath.ToShareRegularPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }


    [Fact]
    public void Path_Combination_Test()
    {
        string shouldBe = Path.Combine( @"C:\temp\", @"\test\folder" );
        string reference = QuickIOPath.Combine( @"C:\temp\", @"\test\folder" );
        Assert.Equal(shouldBe, reference);
    }

    [Fact]
    public void Path_ToShareUncPath_Folder_Test()
    {
        const string testPath = @"\\server\share";
        const string shouldBe = @"\\?\UNC\server\share";
        string convertedPath = QuickIOPath.ToShareUncPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }

    [Fact]
    public void Path_ToShareUncPath_File_Test()
    {
        const string testPath = @"\\server\share\file.txt";
        const string shouldBe = @"\\?\UNC\server\share\file.txt";
        string convertedPath = QuickIOPath.ToShareUncPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }


    [Fact]
    public void Path_ToLocalUncPath_Folder_Test()
    {
        const string testPath = @"C:\temp";
        const string shouldBe = @"\\?\C:\temp";
        string convertedPath = QuickIOPath.ToLocalUncPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }

    [Fact]
    public void Path_ToLocalUncPath_File_Test()
    {
        const string testPath = @"C:\temp\file.txt";
        const string shouldBe = @"\\?\C:\temp\file.txt";
        string convertedPath = QuickIOPath.ToLocalUncPath( testPath );
        Assert.Equal(shouldBe, convertedPath);
    }

    [Fact]
    public void Path_GetName_Invalid_Test()
    {
        string r = QuickIOPath.GetName( @"peterpan" );
        Assert.Equal("peterpan", r);
    }

    [Fact]
    public void Path_GetName_SimpleName_Test()
    {
        string r = QuickIOPath.GetName( @"peter\pan" );
        Assert.Equal("pan", r);
    }

    [Fact]
    public void Path_GetParent1_Test()
    {
        string fullname1 = Path.GetFullPath( @"peter\pan" );
        string parent1 = new DirectoryInfo( fullname1 ).Parent!.FullName;
        Assert.Equal(parent1, QuickIOPath.GetParentPath(fullname1));


    }
    [Fact]
    public void Path_GetParent2_Test()
    {
        string expected = @"C:\temp\folder\folder\parent";
        string fullpath = expected + @"\name";

        Assert.Equal(expected, QuickIOPath.GetParentPath(fullpath));
    }

    [Fact]
    public void Path_GetRoot_Test()
    {
        string expected = @"C:\";
        string fullpath = expected + @"temp\folder\folder\parent\name";

        Assert.Equal(expected, QuickIOPath.GetRoot(fullpath));
    }


    [Fact]
    public void Path_IsLocalRegularPath_Test()
    {
        Assert.True(QuickIOPath.IsLocalRegularPath(@"C:\"), "1 failed");
        Assert.True(QuickIOPath.IsLocalRegularPath(@"c:\"), "2 failed");


        Assert.True(QuickIOPath.IsLocalRegularPath(@"C:\dsad"), "5 failed");
        Assert.True(QuickIOPath.IsLocalRegularPath(@"c:\dsad 0s\sadsad\d"), "6 failed");

        Assert.False(QuickIOPath.IsLocalRegularPath(@"4:\"), "3 failed");
        Assert.False(QuickIOPath.IsLocalRegularPath(@"as:\dd"), "4 failed");
    }

    [Fact]
    public void Path_IsLocalUncPath_Test()
    {
        Assert.True(QuickIOPath.IsLocalUncPath(@"\\?\C:\"), "1 failed");
        Assert.True(QuickIOPath.IsLocalUncPath(@"\\?\c:\"), "2 failed");


        Assert.True(QuickIOPath.IsLocalUncPath(@"\\?\C:\dsad"), "5 failed");
        Assert.True(QuickIOPath.IsLocalUncPath(@"\\?\c:\dsad 0s\sadsad\d"), "6 failed");

        Assert.False(QuickIOPath.IsLocalUncPath(@"\\?\4:\"), "3 failed");
        Assert.False(QuickIOPath.IsLocalUncPath(@"\\?\as:\dd"), "4 failed");
    }

    [Fact]
    public void Path_IsShareRegularPath_Test()
    {
        Assert.True(QuickIOPath.IsShareRegularPath(@"\\server\name"), "1 failed");
        Assert.True(QuickIOPath.IsShareRegularPath(@"\\servEr\nAme"), "2 failed");

        Assert.True(QuickIOPath.IsShareRegularPath(@"\\server\name\folder"), "5 failed");
        Assert.True(QuickIOPath.IsShareRegularPath(@"\\server\name\folder\folder\file.txt"), "6 failed");

        Assert.False(QuickIOPath.IsShareRegularPath(@"f\\server\name\folder"), "3 failed");
        Assert.False(QuickIOPath.IsShareRegularPath(@"\server\name\folder"), "4 failed");
        Assert.False(QuickIOPath.IsShareRegularPath(@"server\name\folder"), "5 failed");
        Assert.False(QuickIOPath.IsShareRegularPath(@"\UNC\?\server\name\folder"), "7 failed");
    }

    [Fact]
    public void Path_IsShareUncPath_Test()
    {
        Assert.True(QuickIOPath.IsShareUncPath(@"\\?\UNC\server\name"), "1 failed");
        Assert.True(QuickIOPath.IsShareUncPath(@"\\?\UNC\servEr\nAme"), "2 failed");


        Assert.True(QuickIOPath.IsShareUncPath(@"\\?\UNC\server\name\folder"), "5 failed");
        Assert.True(QuickIOPath.IsShareUncPath(@"\\?\UNC\server\name\folder\folder\file.txt"), "6 failed");

        Assert.False(QuickIOPath.IsShareUncPath(@"f\\?\UNC\server\name\folder"), "3 failed");
        Assert.False(QuickIOPath.IsShareUncPath(@"\\server\name\folder"), "4 failed");
        Assert.False(QuickIOPath.IsShareUncPath(@"server\name\folder"), "5 failed");
    }

    [Fact]
    public void Path_TryParse_Test1()
    {
        bool done = QuickIOPath.TryParsePath( @"C:\", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.True(result.IsRoot);
        Assert.Equal(@"C:\", result.FullName);
        Assert.Equal(@"\\?\C:\", result.FullNameUnc);
        Assert.Null(result.Name);
        Assert.Null(result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Null(result.RootPath);
    }

    [Fact]
    public void Path_ParseLocalRegularPath_Test1()
    {
        bool done = QuickIOPath.TryParseLocalRegularPath( @"C:\", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.True(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"C:\", result.FullName);
        Assert.Equal(@"\\?\C:\", result.FullNameUnc);
        Assert.Null(result.Name);
        Assert.Null(result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Null(result.RootPath);
    }

    [Fact]
    public void Path_TryParse_Test2()
    {
        bool done = QuickIOPath.TryParsePath( @"C:\peter\pan", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot);
        Assert.Equal(@"C:\peter\pan", result.FullName);
        Assert.Equal(@"\\?\C:\peter\pan", result.FullNameUnc);
        Assert.Equal("pan", result.Name);
        Assert.Equal(@"C:\peter", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Equal(@"C:\", result.RootPath);
    }

    [Fact]
    public void Path_ParseLocalRegularPath_Test2()
    {
        bool done = QuickIOPath.TryParseLocalRegularPath( @"C:\peter\pan", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot);
        Assert.Equal(@"C:\peter\pan", result.FullName);
        Assert.Equal(@"\\?\C:\peter\pan", result.FullNameUnc);
        Assert.Equal("pan", result.Name);
        Assert.Equal(@"C:\peter", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Equal(@"C:\", result.RootPath);
    }

    [Fact]
    public void Path_ParseLocalRegularPath_Test3()
    {
        bool done = QuickIOPath.TryParseLocalRegularPath( @"C:\peter\pan\file.txt", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"C:\peter\pan\file.txt", result.FullName);
        Assert.Equal(@"\\?\C:\peter\pan\file.txt", result.FullNameUnc);
        Assert.Equal("file.txt", result.Name);
        Assert.Equal(@"C:\peter\pan", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Equal(@"C:\", result.RootPath);
    }

    [Fact]
    public void Path_ParseLocalUncPath_Test1()
    {
        bool done = QuickIOPath.TryParseLocalUncPath( @"\\?\C:\", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.True(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"C:\", result.FullName);
        Assert.Equal(@"\\?\C:\", result.FullNameUnc);
        Assert.Null(result.Name);
        Assert.Null(result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.UNC, result.PathType);
        Assert.Null(result.RootPath);

    }

    [Fact]
    public void Path_ParseLocalUncPath_Test2()
    {
        bool done = QuickIOPath.TryParseLocalUncPath( @"\\?\C:\peter\pan", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"C:\peter\pan", result.FullName);
        Assert.Equal(@"\\?\C:\peter\pan", result.FullNameUnc);
        Assert.Equal("pan", result.Name);
        Assert.Equal(@"C:\peter", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.UNC, result.PathType);
        Assert.Equal(@"C:\", result.RootPath);
    }

    [Fact]
    public void Path_ParseLocalUncPath_Test3()
    {
        bool done = QuickIOPath.TryParseLocalUncPath( @"\\?\C:\peter\pan\file.txt", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"C:\peter\pan\file.txt", result.FullName);
        Assert.Equal(@"\\?\C:\peter\pan\file.txt", result.FullNameUnc);
        Assert.Equal("file.txt", result.Name);
        Assert.Equal(@"C:\peter\pan", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Local, result.PathLocation);
        Assert.Equal(QuickIOPathType.UNC, result.PathType);
        Assert.Equal(@"C:\", result.RootPath);
    }


    [Fact]
    public void Path_ParseShareRegularPath_Test1()
    {
        bool done = QuickIOPath.TryParseShareRegularPath( @"\\server\share", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.True(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"\\server\share", result.FullName);
        Assert.Equal(@"\\?\UNC\server\share", result.FullNameUnc);
        Assert.Null(result.Name);
        Assert.Null(result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Share, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Null(result.RootPath);
    }

    [Fact]
    public void Path_ParseShareRegularPath_Test2()
    {
        bool done = QuickIOPath.TryParseShareRegularPath( @"\\?\UNC\server\share", out QuickIOParsePathResult? result );

        Assert.False(done);
        Assert.Null(result);
    }

    [Fact]
    public void Path_ParseShareRegularPath_Test3()
    {
        bool done = QuickIOPath.TryParseShareRegularPath( @"\\server\share\folder\parent\file.txt", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"\\server\share\folder\parent\file.txt", result.FullName);
        Assert.Equal(@"\\?\UNC\server\share\folder\parent\file.txt", result.FullNameUnc);
        Assert.Equal("file.txt", result.Name);
        Assert.Equal(@"\\server\share\folder\parent", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Share, result.PathLocation);
        Assert.Equal(QuickIOPathType.Regular, result.PathType);
        Assert.Equal(@"\\server\share", result.RootPath);
    }

    [Fact]
    public void Path_ParseShareUncPath_Test1()
    {
        bool done = QuickIOPath.TryParseShareUncPath( @"\\?\UNC\server\share", out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.True(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"\\server\share", result.FullName);
        Assert.Equal(@"\\?\UNC\server\share", result.FullNameUnc);
        Assert.Null(result.Name);
        Assert.Null(result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Share, result.PathLocation);
        Assert.Equal(QuickIOPathType.UNC, result.PathType);
        Assert.Null(result.RootPath);
    }

    [Fact]
    public void Path_ParseShareUncPath_Test2()
    {
        bool done = QuickIOPath.TryParseShareUncPath( @"\\server\share", out _ );

        Assert.False(done);
    }

    [Fact]
    public void Path_ParseShareUncPath_Test3()
    {
        bool done = QuickIOPath.TryParseShareUncPath( @"\\?\UNC\server\share\folder\parent\file.txt",
            out QuickIOParsePathResult? result );

        Assert.True(done);
        Assert.NotNull(result);

        Assert.False(result.IsRoot, "IsRoot failed");
        Assert.Equal(@"\\server\share\folder\parent\file.txt", result.FullName);
        Assert.Equal(@"\\?\UNC\server\share\folder\parent\file.txt", result.FullNameUnc);
        Assert.Equal("file.txt", result.Name);
        Assert.Equal(@"\\server\share\folder\parent", result.ParentPath);
        Assert.Equal(QuickIOPathLocation.Share, result.PathLocation);
        Assert.Equal(QuickIOPathType.UNC, result.PathType);
        Assert.Equal(@"\\server\share", result.RootPath);
    }
}
