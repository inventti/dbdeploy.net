﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Net.Sf.Dbdeploy.Configuration
{
    using System.IO;
    using System.Text;

    using Database;

    /// <summary>
    /// Default values for DbDeploy configuration.
    /// </summary>
    public static class DbDeployDefaults
    {
        /// <summary>
        /// The DBMS default value.
        /// </summary>
        public const string Dbms = "mssql";

        /// <summary>
        /// The connection string default value.
        /// </summary>
        public const string ConnectionString = null;

        /// <summary>
        /// The change log table name default value.
        /// </summary>
        public const string ChangeLogTableName = "ChangeLog";

        /// <summary>
        /// The auto create change log table default value.
        /// </summary>
        public const bool AutoCreateChangeLogTable = true;

        /// <summary>
        /// The force update default value.
        /// </summary>
        public const bool ForceUpdate = false;

        /// <summary>
        /// The use SQLCMD mode default value.
        /// </summary>
        public const bool UseSqlCmd = false;

        /// <summary>
        /// The last change to apply default value.
        /// </summary>
        public const UniqueChange LastChangeToApply = null;

        /// <summary>
        /// The delimiter default value.
        /// </summary>
        public const string Delimiter = null;

        /// <summary>
        /// The output file default value.
        /// </summary>
        public static readonly FileInfo OutputFile = null;

        /// <summary>
        /// The script directory default value.
        /// </summary>
        public static readonly IEnumerable<DirectoryInfo> ScriptDirectory = new List<DirectoryInfo>();

        /// <summary>
        /// The encoding default value.
        /// </summary>
        public static readonly Encoding Encoding = Encoding.UTF8;

        /// <summary>
        /// The templates directory default value.
        /// </summary>
        public static readonly DirectoryInfo TemplateDirectory = null;

        /// <summary>
        /// The delimiter type default value.
        /// </summary>
        public static readonly IDelimiterType DelimiterType = new NormalDelimiter();

        /// <summary>
        /// The line ending default value.
        /// </summary>
        public static readonly string LineEnding = Database.LineEnding.Platform;

        /// <summary>
        /// Embedded script assembly default value.
        /// </summary>
        public static IEnumerable<Assembly> ScriptAssemblies = new List<Assembly>();

        public static Func<string, bool> AssemblyResourceNameFilter = value => true;
        
         /// <summary>
        /// The personal Oracle Dll path connection
        /// </summary>
        public static readonly string DllPathConnector = null;

        /// <summary>
        /// Default value for the directory where the service runs/executes
        /// </summary>
        public static DirectoryInfo DirectoryServiceRun = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    }
}
