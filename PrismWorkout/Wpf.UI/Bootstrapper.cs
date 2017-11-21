using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;
using Wpf.ModuleA;
using Prism.Regions;
using System.Windows.Controls;
using Wpf.Infra;

namespace Wpf.UI
{
    public class Bootstrapper:UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ModuleAModule));
            return catalog;
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //  Loading Modules from file system
        //  return new DirectoryModuleCatalog() { ModulePath=@".\Modules" };
        //}
        //protected override void ConfigureModuleCatalog()
        //{
        //    Type moduleAType = typeof(ModuleAModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleAType.Name,
        //        ModuleType = moduleAType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable
        //    });
        //}
        //protected override IModuleCatalog CreateModuleCatalog()
        //{ 
        // Loading Modules from Resources 
        //  return ModuleCatalog.CreateFromXaml(new Uri("/PrismWorkOut;cmponent/Generic.xaml",UriKind.Relative));
        //}
        //protected override IModuleCatalog CreateModuleCatalog()
        //{ 
        // Loading Modules from app.config 
        //  return new ConfigurationModuleCatalog();
        //}


        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.TryResolve<StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
