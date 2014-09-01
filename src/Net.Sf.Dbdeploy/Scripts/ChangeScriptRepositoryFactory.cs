using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Net.Sf.Dbdeploy.Configuration;

namespace Net.Sf.Dbdeploy.Scripts
{
    public class ChangeScriptRepositoryFactory
    {
        private readonly DbDeployConfig dbDeployConfig;
        private readonly TextWriter infoWriter;

        public ChangeScriptRepositoryFactory(DbDeployConfig dbDeployConfig, TextWriter infoWriter)
        {
            this.dbDeployConfig = dbDeployConfig;
            this.infoWriter = infoWriter;
        }

        public IAvailableChangeScriptsProvider Obter()
        {
            var allScriptScanner = new AllScriptScanner(GetScriptScanners().ToArray());
            return new ChangeScriptRepository(allScriptScanner.GetChangeScripts());
        }

        private IEnumerable<IScriptScanner> GetScriptScanners()
        {
            var scanners = new List<IScriptScanner>();

            if (dbDeployConfig.ScriptAssemblies != null)
            {
                foreach (var type in dbDeployConfig.ScriptAssemblies)
                {
                    var pathAssembly = Path.Combine(dbDeployConfig.DirectoryServiceRun.FullName, type.Module.Name);
                    var assemblyScriptEmbedded = Assembly.LoadFile(pathAssembly);
                    scanners.Add(new AssemblyScanner(infoWriter, dbDeployConfig.Encoding, assemblyScriptEmbedded, dbDeployConfig.AssemblyResourceNameFilter));
                }
            }

            //if (dbDeployConfig.AssemblyOnly)
            //    return scanners;
            if (dbDeployConfig.ScriptDirectory != null)
                scanners.Add(new DirectoryScanner(infoWriter, dbDeployConfig.Encoding, dbDeployConfig.ScriptDirectory));

            return scanners;
        }
    }
}