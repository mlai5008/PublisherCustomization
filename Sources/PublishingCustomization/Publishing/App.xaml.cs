using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Publisher.Infrastructure.Interfaces.Views;
using Publishing.Boot;
using Publishing.Views;
using System;
using System.Reflection;
using System.Windows;

namespace Publishing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        #region Fields
        private AppBootstrapper _bootstrapper;
        #endregion

        #region Methods
        #region Override Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                CreateBootstrapper();
                base.OnStartup(e);
            }
            catch (Exception)
            {

            }
            finally
            {
                
            }
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName?.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName?.Replace(".Views", ".ViewModels");
                var viewModelName = $"{viewName}Model, {viewAssemblyName}".Replace(".Views.", ".ViewModels.");
                return Type.GetType(viewModelName);
            });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _bootstrapper.RegisterTypes(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            _bootstrapper.GenerateModules();
            _bootstrapper.LoadModules(moduleCatalog);

            base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override Window CreateShell()
        {
            return (ShellView)Container.Resolve<IShellView>();
        }
        #endregion

        #region Private Methods
        private void CreateBootstrapper()
        {
            _bootstrapper = new AppBootstrapper();
        }
        #endregion
        #endregion
    }
}