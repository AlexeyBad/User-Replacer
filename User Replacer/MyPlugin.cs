using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace User_Replacer
{
        [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "User Replacer"),
        ExportMetadata("Description", "Replace Users based on the owner and custom fields"),
        ExportMetadata("Author", "Alexey"),
        ExportMetadata("SmallImageBase64", null),
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]


    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}