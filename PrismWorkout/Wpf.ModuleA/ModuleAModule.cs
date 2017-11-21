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
            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IContentView, ContentView>();
            _container.RegisterType<IContentViewModel, ContentViewModel>();

            IRegion region = _regionManager.Regions[ConstRegionNames.ToolBarRegion];
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            region.Add(_container.Resolve<ToolbarView>());
            //_regionManager.RegisterViewWithRegion(ConstRegionNames.ToolBarRegion, typeof(ToolbarView));

            //_regionManager.RegisterViewWithRegion(ConstRegionNames.ContentRegion, typeof(IContentView));
            var vm = _container.Resolve<IContentViewModel>();
            vm.Message = "First View";
            _regionManager.Regions[ConstRegionNames.ContentRegion].Add(vm.View);

        }
    }
}
