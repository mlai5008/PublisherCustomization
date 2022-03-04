using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Publisher.AppleCustomization.Views;
using Publisher.Infrastructure.Constants;
using Publisher.Infrastructure.Interfaces.Views;
using Publisher.Infrastructure.Managers;

namespace Publisher.AppleCustomization
{
    public class AppleCustomizationModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterMainViews(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            RegisterViewWithRegionManager.RegisterViewWithRegion(regionManager, RegionNamesConstants.MainRegion, typeof(IMainView));
        }

        private void RegisterMainViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMainView, MainView>();
        }
        #endregion
    }
}