﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Net.Sf.Dbdeploy.Configuration
{
    using System.IO;
    using System.Text;

    using Database;

    /// <summary>
    /// Represents DbDeploy configuration settings.
    /// </summary>
    public class DbDeployConfig
    {
        /// <summary>
        /// Gets or sets the database management system being used (mssql, mysql, or ora).
        /// </summary>
        /// <value>
        /// The DBMS.
        /// </value>
        public string Dbms { get; set; }

        /// <summary>
        /// Gets or sets the connection string to execute on.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the root script directory to read all change scripts from.
        /// </summary>
        /// <value>
        /// The script directory.
        /// </value>
        public IEnumerable<DirectoryInfo> ScriptDirectory { get; set; }
        
        /// <summary>
        /// Gets or sets the assembly to read all change scripts resource files from.
        /// </summary>
        /// <value>
        /// The assembly containing embbeded scripts.
        /// </value>
        /// <remarks>
        /// This is a optional parameter.
        /// </remarks>
        public IEnumerable<Assembly> ScriptAssemblies { get; set; }

        /// <summary>
        /// Gets or sets the filter function to filter the embbeded resources found in a assembly.
        /// This property is used in conjunction ScriptAssemblies property.
        /// </summary>
        /// <value>
        /// The filter function.
        /// </value>
        /// <remarks>
        /// This is a optional parameter.
        /// </remarks>
        public Func<string, bool> AssemblyResourceNameFilter { get; set; }

        /// <summary>
        /// Get or Sets path custom file DLL connector
        /// <remarks>If this is not set, DbDeploy will get config from dbproviders.xml file</remarks>
        /// </summary>
        /// <value>
        /// Path to a specific DLL for custom connector
        /// </value>
        public string DllPathConnector { get; set; }

        /// <summary>
        /// Gets or sets the output file to render the combined change scripts to.
        /// </summary>
        /// <remarks>If this is not set, DbDeploy will run against the database directly.</remarks>
        /// <value>
        /// The output file.
        /// </value>
        public FileInfo OutputFile { get; set; }

        /// <summary>
        /// Gets or sets the file to render the combined undo change scripts to.
        /// </summary>
        /// <value>
        /// The undo output file.
        /// </value>
        public FileInfo UndoOutputFile { get; set; }

        /// <summary>
        /// Gets or sets the name of the change log table to story the applied change script information in.
        /// </summary>
        /// <value>
        /// The name of the change log table.
        /// </value>
        public string ChangeLogTableName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically create the change log table if it does not exist
        /// </summary>
        /// <value>
        /// <c>true</c> if auto create change log table; otherwise, <c>false</c>.
        /// </value>
        public bool AutoCreateChangeLogTable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to re-run previously failed scripts.
        /// </summary>
        /// <remarks>If this is not set, an error will be thrown if there are any scripts in the database with a status of Failure.</remarks>
        /// <value>
        ///   <c>true</c> if force update; otherwise, <c>false</c>.
        /// </value>
        public bool ForceUpdate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to run the scripts in SQLCMD mode.
        /// </summary>
        /// <remarks>This option is only available for Microsoft SQL Server deployments.</remarks>
        /// <value>
        ///   <c>true</c> if use SQLCMD mode; otherwise, <c>false</c>.
        /// </value>
        public bool UseSqlCmd { get; set; }

        /// <summary>
        /// Gets or sets the last change execute up to.
        /// </summary>
        /// <remarks>When this is set, DbDeploy will stop short of applying all scripts at the script specified.</remarks>
        /// <value>
        /// The last change to execute.
        /// </value>
        public UniqueChange LastChangeToApply { get; set; }

        /// <summary>
        /// Gets or sets the SQL file encoding.
        /// </summary>
        /// <value>
        /// The encoding.
        /// </value>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Gets or sets the directory to use templates from for building a combined SQL output file.
        /// </summary>
        /// <value>
        /// The template directory.
        /// </value>
        public DirectoryInfo TemplateDirectory { get; set; }

        /// <summary>
        /// Gets or sets the delimiter to separate sql statements.
        /// </summary>
        /// <value>
        /// The delimiter.
        /// </value>
        public string Delimiter { get; set; }

        /// <summary>
        /// Gets or sets the type of the delimiter (row or normal).
        /// </summary>
        /// <value>
        /// The type of the delimiter.
        /// </value>
        public IDelimiterType DelimiterType { get; set; }

        /// <summary>
        /// Gets or sets the line ending to use when applying scripts direct to db (platform, cr, crlf, lf).
        /// </summary>
        /// <value>
        /// The line ending.
        /// </value>
        public string LineEnding { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbDeployConfig" /> class.
        /// </summary>
        public DbDeployConfig()
        {
            // Set all defaults.
            Dbms = DbDeployDefaults.Dbms;
            ConnectionString = DbDeployDefaults.ConnectionString;
            ScriptDirectory = DbDeployDefaults.ScriptDirectory;
            OutputFile = DbDeployDefaults.OutputFile;
            ChangeLogTableName = DbDeployDefaults.ChangeLogTableName;
            AutoCreateChangeLogTable = DbDeployDefaults.AutoCreateChangeLogTable;
            ForceUpdate = DbDeployDefaults.ForceUpdate;
            UseSqlCmd = DbDeployDefaults.UseSqlCmd;
            LastChangeToApply = DbDeployDefaults.LastChangeToApply;
            Encoding = DbDeployDefaults.Encoding;
            TemplateDirectory = DbDeployDefaults.TemplateDirectory;
            Delimiter = DbDeployDefaults.Delimiter;
            DelimiterType = DbDeployDefaults.DelimiterType;
            LineEnding = DbDeployDefaults.LineEnding;
            DllPathConnector = DbDeployDefaults.DllPathConnector;
            ScriptAssemblies = DbDeployDefaults.ScriptAssemblies;
        }
    }
}