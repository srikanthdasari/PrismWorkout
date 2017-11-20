using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Wpf.Infra;
using Wpf.Infra.Constants;

namespace Wpf.ModuleA
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, RegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions[ConstRegionNames.ToolBarRegion];
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            //_regionManager.RegisterViewWithRegion(ConstRegionNames.ToolBarRegion, typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion(ConstRegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
