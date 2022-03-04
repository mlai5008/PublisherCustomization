using Prism.Ioc;
using Prism.Modularity;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.ViewModels.ViewModels;

namespace Publisher.ViewModels
{
    public class ViewModelsModule : IModule
    {
        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterViewModels(containerRegistry);
        }

        public void OnInitialized(IContainerProvider containerProvider) { }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMainViewModel, MainViewModel>();
        }
        #endregion
    }
}