// <copyright file="IQuickIOTransferWriteJob.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>IQuickIOTransferWriteJob</summary>

using System;

namespace SchwabenCode.QuickIO.Transfer
{
    /// <summary>
    /// Implements <see cref="IQuickIOTransferJob"/> with Overwrite option
    /// </summary>
    public interface IQuickIOTransferWriteJob : IQuickIOTransferJob
    {    
        /// <summary>
        /// Max Buffer Size for Transfer
        /// </summary>
        Int32 MaxBufferSize { get; set; }

        /// <summary>
        /// True to check parent folder existance. False is much faster, but you have to be sure that the parent exists.
        /// </summary>
        bool ParentExistanceCheck { get; }

        /// <summary>
        /// true to overwrite existing element
        /// </summary>
        Boolean Overwrite { get; set; }
    }
}