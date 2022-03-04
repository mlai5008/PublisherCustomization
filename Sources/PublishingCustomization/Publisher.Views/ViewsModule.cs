using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Publisher.Infrastructure.Constants;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Infrastructure.Managers;
using Publisher.Views.Views;

namespace Publisher.Views
{
    public class ViewsModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterViews(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            RegisterViewWithRegionManager.RegisterViewWithRegion(regionManager, RegionNamesConstants.MainRegion, typeof(IMainView));
        }

        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMainView, MainView>();
        }
        #endregion
    }
}