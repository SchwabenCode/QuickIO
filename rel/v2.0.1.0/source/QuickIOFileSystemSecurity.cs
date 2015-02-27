// <copyright file="QuickIOFileSystemSecurity.cs" company="Benjamin Abt (  http://www.benjamin-abt.com - http://quickIO.NET  )">
// Copyright (c) 2014 All Rights Reserved - DO NOT REMOVE OR EDIT COPYRIGHT
// </copyright>
// <author>Benjamin Abt</author>
// <date>03/29/2014</date>
// <summary>QuickIOFileSystemSecurity</summary>

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using SchwabenCode.QuickIO.Internal;
using SchwabenCode.QuickIO.Win32API;

namespace SchwabenCode.QuickIO
{
    /// <summary>
    /// Provides methods for accessing the security information of files and folders, such as for example the getting and setting of the owner.
    /// </summary>
    public class QuickIOFileSystemSecurity
    {
        /// <summary>
        /// Creates new instance of <see cref="QuickIOFileSystemSecurity"/> for specified path.
        /// Current Windows Identtiy is used.
        /// </summary>
        /// <param name="pathInfo"></param>
        public QuickIOFileSystemSecurity( QuickIOPathInfo pathInfo )
            : this( pathInfo, WindowsIdentity.GetCurrent( ) )
        {

        }

        /// <summary>
        /// Supply the path to the file or directory and a user or group. 
        /// Access checks are done
        /// during instantiation to ensure we always have a valid object
        /// </summary>
        /// <param name="pathInfo"></param>
        /// <param name="principal"></param>
        public QuickIOFileSystemSecurity( QuickIOPathInfo pathInfo, WindowsIdentity principal )
        {
            if ( pathInfo == null )
            {
                throw new ArgumentNullException( "pathInfo" );
            }
            if ( principal == null )
            {
                throw new ArgumentNullException( "principal" );
            }

            this.PathInfo = pathInfo;
            this.WindowsIdentity = principal;

            Refresh( );
        }

        /// <summary>
        /// Refreshes the Information
        /// </summary>
        public void Refresh()
        {
            GetSecurityFromFileSystem( );
            ReadSecurityInformation( );
        }

        /// <summary>
        /// Affected Windows IDentity
        /// </summary>
        public WindowsIdentity WindowsIdentity { get; private set; }

        /// <summary>
        /// Affected path
        /// </summary>
        public QuickIOPathInfo PathInfo { get; private set; }

        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedAppendData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedChangePermissions { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedCreateDirectories { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedCreateFiles { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedDelete { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedDeleteSubdirectoriesAndFiles { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedExecuteFile { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedFullControl { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedListDirectory { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedModify { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedRead { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedReadAndExecute { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedReadAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedReadData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedReadExtendedAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedReadPermissions { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedSynchronize { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedTakeOwnership { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedTraverse { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedWrite { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedWriteAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedWriteData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is denied
        /// </summary>
        public bool IsDeniedWriteExtendedAttributes { get; private set; }

        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedAppendData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedChangePermissions { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedCreateDirectories { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedCreateFiles { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedDelete { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedDeleteSubdirectoriesAndFiles { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedExecuteFile { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedFullControl { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedListDirectory { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedModify { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedRead { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedReadAndExecute { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedReadAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedReadData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedReadExtendedAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedReadPermissions { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedSynchronize { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedTakeOwnership { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedTraverse { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedWrite { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedWriteAttributes { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedWriteData { get; private set; }
        /// <summary>
        /// Returns true if specified right level is explizit allowed
        /// </summary>
        public bool IsAllowedWriteExtendedAttributes { get; private set; }

        /// <summary>
        /// Ermittelt, ob etwas hinzugefügt werden kann (Dateien)
        /// </summary>
        public bool CanAppendData
        {
            get { return !IsDeniedAppendData && IsAllowedAppendData; }
        }

        /// <summary>
        /// Ermittelt, ob die Rechte verändert werden dürfen
        /// </summary>
        public bool CanChangePermissions
        {
            get { return !IsDeniedChangePermissions && IsAllowedChangePermissions; }
        }

        /// <summary>
        /// Ermittelt, ob neue Ordner hinzugefügt werden dürfen (Ordner)
        /// </summary>
        public bool CanCreateDirectories
        {
            get { return !IsDeniedCreateDirectories && IsAllowedCreateDirectories; }
        }

        /// <summary>
        /// Ermittelt, ob neue Dateien hinzugefügt werden dürfen (Ordner)
        /// </summary>
        public bool CanCreateFiles
        {
            get { return !IsDeniedCreateFiles && IsAllowedCreateFiles; }
        }

        /// <summary>
        /// Ermittelt, ob etwas gelöscht werden darf (Ordner)
        /// </summary>
        public bool CanDelete
        {
            get { return !IsDeniedDelete && IsAllowedDelete; }
        }

        /// <summary>
        /// Ermittelt, ob darunterliegende Ordner und Dateien gelöscht werden dürfen (Ordner)
        /// </summary>
        public bool CanDeleteSubdirectoriesAndFiles
        {
            get
            {
                return !IsDeniedDeleteSubdirectoriesAndFiles &&
                       IsAllowedDeleteSubdirectoriesAndFiles;
            }
        }

        /// <summary>
        /// Ermittelt, ob eine Datei ausgeführt werden darf (Dateien)
        /// </summary>
        public bool CanExecuteFile
        {
            get { return !IsDeniedExecuteFile && IsAllowedExecuteFile; }
        }

        /// <summary>
        /// Ermittelt, ob die vollständige Kontrolle gewährt ist
        /// </summary>
        public bool CanFullControl
        {
            get { return !IsDeniedFullControl && IsAllowedFullControl; }
        }

        /// <summary>
        /// Ermittelt, ob die Ordner aufgelistet werden dürfen (Ordner)
        /// </summary>
        public bool CanListDirectory
        {
            get { return !IsDeniedListDirectory && IsAllowedListDirectory; }
        }

        /// <summary>
        /// Ermittelt, ob etwas verändert werden darf
        /// </summary>
        public bool CanModify
        {
            get { return !IsDeniedModify && IsAllowedModify; }
        }

        /// <summary>
        /// Ermittelt, ob etwas gelesen werden darf
        /// </summary>
        public bool CanRead
        {
            get { return !IsDeniedRead && IsAllowedRead; }
        }

        /// <summary>
        /// Ermittelt, ob gelesen und ausgeführt werden darf
        /// </summary>
        public bool CanReadAndExecute
        {
            get { return !IsDeniedReadAndExecute && IsAllowedReadAndExecute; }
        }

        /// <summary>
        /// Ermittelt, ob die Attribute gelesen werden dürfen
        /// </summary>
        public bool CanReadAttributes
        {
            get { return !IsDeniedReadAttributes && IsAllowedReadAttributes; }
        }
        /// <summary>
        /// Ermittelt, ob Daten gelesen werden dürfen
        /// </summary>
        public bool CanReadData
        {
            get { return !IsDeniedReadData && IsAllowedReadData; }
        }

        /// <summary>
        /// Ermittelt, ob die erweiterten Attribute gelesen werden dürfen
        /// </summary>
        public bool CanReadExtendedAttributes
        {
            get
            {
                return !IsDeniedReadExtendedAttributes &&
                       IsAllowedReadExtendedAttributes;
            }
        }
        /// <summary>
        /// Ermittelt, ob die Rechte gelesen werden dürfen
        /// </summary>
        public bool CanReadPermissions
        {
            get { return !IsDeniedReadPermissions && IsAllowedReadPermissions; }
        }

        /// <summary>
        /// Ermittelt, ob synchronisiert werden darf
        /// </summary>
        public bool CanSynchronize
        {
            get { return !IsDeniedSynchronize && IsAllowedSynchronize; }
        }
        /// <summary>
        /// Ermittelt, ob der Besitzerstatus eingenommen werden darf
        /// </summary>
        public bool CanTakeOwnership
        {
            get { return !IsDeniedTakeOwnership && IsAllowedTakeOwnership; }
        }

        /// <summary>
        /// Ermittelt, ob ???????
        /// </summary>
        public bool CanTraverse
        {
            get { return !IsDeniedTraverse && IsAllowedTraverse; }
        }

        /// <summary>
        /// Ermittelt, ob geschrieben werden darf
        /// </summary>
        public bool CanWrite
        {
            get { return !IsDeniedWrite && IsAllowedWrite; }
        }

        /// <summary>
        /// Ermittelt, ob Attribute verändert werden dürfen
        /// </summary>
        public bool CanWriteAttributes
        {
            get { return !IsDeniedWriteAttributes && IsAllowedWriteAttributes; }
        }

        /// <summary>
        /// Ermittelt, ob Daten geschrieben werden dürfen
        /// </summary>
        public bool CanWriteData
        {
            get { return !IsDeniedWriteData && IsAllowedWriteData; }
        }

        /// <summary>
        /// Ermittelt, ob erweiterte Attribute geschrieben werden dürfen
        /// </summary>
        public bool CanWriteExtendedAttributes
        {
            get
            {
                return !IsDeniedWriteExtendedAttributes && IsAllowedWriteExtendedAttributes;
            }
        }

        #region Initial Read
        /// <summary>
        /// Reads the security information of <see cref="FileSystemSecurityInformation"/>
        /// </summary>
        private void ReadSecurityInformation()
        {
            // Receive File System ACL Information
            var acl = FileSystemSecurityInformation.GetAccessRules( true, true, typeof( SecurityIdentifier ) );

            ReceiveUserIdentityRules( acl );
            ReceivGroupIdentityRules( acl );
        }

        /// <summary>
        /// Processes the authentication data of a Windows Group
        /// </summary>
        /// <param name="acl"><see cref="AuthorizationRuleCollection"/></param>
        private void ReceivGroupIdentityRules( AuthorizationRuleCollection acl )
        {
            // Only Handle Groups
            if ( WindowsIdentity.Groups == null )
            {
                return;
            }

            foreach ( var identity in WindowsIdentity.Groups )
            {
                for ( var i = 0 ; i < acl.Count ; i++ )
                {
                    var rule = ( FileSystemAccessRule ) acl[ i ];
                    HandleFileSystemAccessRule( rule, identity );
                }
            }
        }

        /// <summary>
        /// Processes the authentication data of a Windows identity
        /// </summary>
        /// <param name="rule">FileSystemAccessRule</param>
        /// <param name="identity"></param>
        private void HandleFileSystemAccessRule( FileSystemAccessRule rule, IdentityReference identity )
        {
            if ( rule == null )
            {
                return;
            }

            // Ignore all other users
            if ( identity.Equals( rule.IdentityReference ) )
            {
                HandleAccessControlType( rule );
            }
        }

        /// <summary>
        /// Processes the authentication data of a Windows user
        /// </summary>
        /// <param name="acl"><see cref="AuthorizationRuleCollection"/></param>
        private void ReceiveUserIdentityRules( AuthorizationRuleCollection acl )
        {
            if ( WindowsIdentity.User == null )
            {
                return;
            }

            for ( var i = 0 ; i < acl.Count ; i++ )
            {
                var rule = ( FileSystemAccessRule ) acl[ i ];
                HandleFileSystemAccessRule( rule, WindowsIdentity.User );
            }
        }

        /// <summary>
        /// Handles the access rights. Differentiates between allowed and denied rights
        /// </summary>
        private void HandleAccessControlType( FileSystemAccessRule rule )
        {
            switch ( rule.AccessControlType )
            {
                case AccessControlType.Allow:
                    HandleAllowedAccessRule( rule );
                    break;
                case AccessControlType.Deny:
                    HandleDeniedAccessRule( rule );
                    break;
            }
        }

        /// <summary>
        /// Processed the permitted rights
        /// </summary>
        private void HandleAllowedAccessRule( FileSystemAccessRule rule )
        {
            IsAllowedAppendData = Contains( FileSystemRights.AppendData, rule );
            IsAllowedChangePermissions = Contains( FileSystemRights.ChangePermissions, rule );
            IsAllowedCreateDirectories = Contains( FileSystemRights.CreateDirectories, rule );
            IsAllowedCreateFiles = Contains( FileSystemRights.CreateFiles, rule );
            IsAllowedDelete = Contains( FileSystemRights.Delete, rule );
            IsAllowedDeleteSubdirectoriesAndFiles = Contains( FileSystemRights.DeleteSubdirectoriesAndFiles, rule );
            IsAllowedExecuteFile = Contains( FileSystemRights.ExecuteFile, rule );
            IsAllowedFullControl = Contains( FileSystemRights.FullControl, rule );
            IsAllowedListDirectory = Contains( FileSystemRights.ListDirectory, rule );
            IsAllowedModify = Contains( FileSystemRights.Modify, rule );
            IsAllowedRead = Contains( FileSystemRights.Read, rule );
            IsAllowedReadAndExecute = Contains( FileSystemRights.ReadAndExecute, rule );
            IsAllowedReadAttributes = Contains( FileSystemRights.ReadAttributes, rule );
            IsAllowedReadData = Contains( FileSystemRights.ReadData, rule );
            IsAllowedReadExtendedAttributes = Contains( FileSystemRights.ReadExtendedAttributes, rule );
            IsAllowedReadPermissions = Contains( FileSystemRights.ReadPermissions, rule );
            IsAllowedSynchronize = Contains( FileSystemRights.Synchronize, rule );
            IsAllowedTakeOwnership = Contains( FileSystemRights.TakeOwnership, rule );
            IsAllowedTraverse = Contains( FileSystemRights.Traverse, rule );
            IsAllowedWrite = Contains( FileSystemRights.Write, rule );
            IsAllowedWriteAttributes = Contains( FileSystemRights.WriteAttributes, rule );
            IsAllowedWriteData = Contains( FileSystemRights.WriteData, rule );
            IsAllowedWriteExtendedAttributes = Contains( FileSystemRights.WriteExtendedAttributes, rule );
        }

        /// <summary>
        /// Processed the denied rights
        /// </summary>
        private void HandleDeniedAccessRule( FileSystemAccessRule rule )
        {
            IsDeniedAppendData = Contains( FileSystemRights.AppendData, rule );
            IsDeniedChangePermissions = Contains( FileSystemRights.ChangePermissions, rule );
            IsDeniedCreateDirectories = Contains( FileSystemRights.CreateDirectories, rule );
            IsDeniedCreateFiles = Contains( FileSystemRights.CreateFiles, rule );
            IsDeniedDelete = Contains( FileSystemRights.Delete, rule );
            IsDeniedDeleteSubdirectoriesAndFiles = Contains( FileSystemRights.DeleteSubdirectoriesAndFiles, rule );
            IsDeniedExecuteFile = Contains( FileSystemRights.ExecuteFile, rule );
            IsDeniedFullControl = Contains( FileSystemRights.FullControl, rule );
            IsDeniedListDirectory = Contains( FileSystemRights.ListDirectory, rule );
            IsDeniedModify = Contains( FileSystemRights.Modify, rule );
            IsDeniedRead = Contains( FileSystemRights.Read, rule );
            IsDeniedReadAndExecute = Contains( FileSystemRights.ReadAndExecute, rule );
            IsDeniedReadAttributes = Contains( FileSystemRights.ReadAttributes, rule );
            IsDeniedReadData = Contains( FileSystemRights.ReadData, rule );
            IsDeniedReadExtendedAttributes = Contains( FileSystemRights.ReadExtendedAttributes, rule );
            IsDeniedReadPermissions = Contains( FileSystemRights.ReadPermissions, rule );
            IsDeniedSynchronize = Contains( FileSystemRights.Synchronize, rule );
            IsDeniedTakeOwnership = Contains( FileSystemRights.TakeOwnership, rule );
            IsDeniedTraverse = Contains( FileSystemRights.Traverse, rule );
            IsDeniedWrite = Contains( FileSystemRights.Write, rule );
            IsDeniedWriteAttributes = Contains( FileSystemRights.WriteAttributes, rule );
            IsDeniedWriteData = Contains( FileSystemRights.WriteData, rule );
            IsDeniedWriteExtendedAttributes = Contains( FileSystemRights.WriteExtendedAttributes, rule );
        }


        /// <summary>
        /// Returs the if <paramref name="right"/> is in <sparamref name="rule"/>
        /// </summary>
        public Boolean Contains( FileSystemRights right, FileSystemAccessRule rule )
        {
            return ( ( ( Int32 ) right & ( Int32 ) rule.FileSystemRights ) == ( Int32 ) right );
        }

        /// <summary>
        /// Get the File Information and set's the result to <see cref="FileSystemSecurityInformation"/> on success.
        /// Also set's owner and owner's domain
        /// </summary>
        /// <returns>true on success. Use native win32 exception to get further error information</returns>
        private void GetSecurityFromFileSystem()
        {
            var sidHandle = new IntPtr( );
            try
            {
                this.FileSystemSecurityInformation = ReceiveFileSystemSecurityInformation( out sidHandle );
            }
            finally
            {
                Win32SafeNativeMethods.LocalFree( sidHandle );
            }
        }

        /// <summary>
        /// Gets the security information of specified handle from file system
        /// </summary>
        /// <param name="sidHandle">Handle to get file security information</param>
        /// <returns><see cref="CommonObjectSecurity"/>Result</returns>
        private CommonObjectSecurity ReceiveFileSystemSecurityInformation( out IntPtr sidHandle )
        {
            var zeroHandle = new IntPtr( );
            var pSecurityDescriptor = new IntPtr( );

            try
            {
                var namedSecInfoResult = Win32SafeNativeMethods.GetNamedSecurityInfo( PathInfo.FullNameUnc, Win32SecurityObjectType.SeFileObject,
                                            Win32FileSystemEntrySecurityInformation.OwnerSecurityInformation | Win32FileSystemEntrySecurityInformation.DaclSecurityInformation,
                                            out sidHandle, out zeroHandle, out zeroHandle, out zeroHandle, out pSecurityDescriptor );
                var win32Error = Marshal.GetLastWin32Error( );
                // Cancel if call failed

                if ( namedSecInfoResult != 0 )
                {
                    InternalQuickIOCommon.NativeExceptionMapping( PathInfo.FullName, win32Error );
                }

                var securityDescriptorLength = Win32SafeNativeMethods.GetSecurityDescriptorLength( pSecurityDescriptor );
                var securityDescriptorDataArray = new byte[ securityDescriptorLength ];
                Marshal.Copy( pSecurityDescriptor, securityDescriptorDataArray, 0, ( int ) securityDescriptorLength );

                CommonObjectSecurity securityInfo;
                if ( InternalHelpers.ContainsFileAttribute( PathInfo.Attributes, FileAttributes.Directory ) )
                {
                    securityInfo = new DirectorySecurity( );
                    securityInfo.SetSecurityDescriptorBinaryForm( securityDescriptorDataArray );
                }
                else
                {
                    securityInfo = new FileSecurity( );
                    securityInfo.SetSecurityDescriptorBinaryForm( securityDescriptorDataArray );
                }

                return securityInfo;
            }
            finally
            {
                Win32SafeNativeMethods.LocalFree( zeroHandle );
                Win32SafeNativeMethods.LocalFree( pSecurityDescriptor );
            }
        }


        #endregion

        /// <summary>
        /// File System Security Information
        /// </summary>
        public CommonObjectSecurity FileSystemSecurityInformation { get; private set; }
    }

}

