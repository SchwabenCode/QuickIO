// <copyright file="QuickIOTransferJobType.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOTransferJobType</summary>

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Avoids expensive reflection
    /// </summary>
    internal enum QuickIOTransferJobType : int
    {
        /// <summary>
        /// JobType is unknwon
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// JobType: FileCopy
        /// </summary>
        FileCopy,
        /// <summary>
        /// JobType: FileCreation
        /// </summary>
        FileCreation,
        /// <summary>
        /// JobType: DirectoryCreation
        /// </summary>
        DirectoryCreation,
        /// <summary>
        /// JobType: FileSetAttributesJob
        /// </summary>
        FileSetTimestampsJob,
        /// <summary>
        /// JobType: FileSetAttributesJob
        /// </summary>
        FileSetAttributesJob
    }
}