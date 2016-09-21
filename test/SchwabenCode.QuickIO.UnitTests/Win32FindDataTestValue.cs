using System.IO;
using SchwabenCode.QuickIO.Win32;

namespace SchwabenCode.QuickIO.UnitTests
{
    internal class Win32FindDataTestValue : Win32FindData
    {
        public Win32FindDataTestValue()
        {
            this.dwFileAttributes = FileAttributes.Compressed | FileAttributes.Normal |
                                    FileAttributes.ReadOnly;
            this.ftCreationTime_dwLowDateTime = 1;
            this.ftCreationTime_dwHighDateTime = 2;
            this.ftLastAccessTime_dwLowDateTime = 3;
            this.ftLastAccessTime_dwHighDateTime = 4;
            this.ftLastWriteTime_dwLowDateTime = 5;
            this.ftLastWriteTime_dwHighDateTime = 6;
            this.nFileSizeHigh = 7;
            this.nFileSizeLow = 8;
            this.dwReserved0 = 9;
            this.dwReserved1 = 0;


            this.cFileName = "test.txt";
            this.cAlternateFileName = "test.txt";
        }

    }
}