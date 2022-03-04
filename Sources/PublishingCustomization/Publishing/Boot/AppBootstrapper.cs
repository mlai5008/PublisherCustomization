using Prism.Ioc;
using Prism.Modularity;
using Publisher.Infrastructure.Interfaces.ViewModels;
using Publisher.Infrastructure.Interfaces.Views;
using Publishing.ModulesSettingModels;
using Publishing.ViewModels;
using Publishing.Views;
using System.Collections.Generic;
using System.Reflection;

namespace Publishing.Boot
{
    public class AppBootstrapper
    {
        #region Fields
        private IContainerRegistry _containerRegistry;
        private IList<ModulesSettingModel> _modulesSettingModels;
        #endregion

        #region Ctor
        public AppBootstrapper()
        {
        }
        #endregion

        #region Methods
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;

            RegisterViews(containerRegistry);
            RegisterViewModels(containerRegistry);
        }

        public void GenerateModules()
        {
            _modulesSettingModels = new List<ModulesSettingModel>
            {
                new ModulesSettingModel()
                {
                    Name = "ViewsModule",
                    AssemblyFile = "Publisher.Views.dll",
                    ModuleType = "Publisher.Views.ViewsModule, Publisher.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                },
                new ModulesSettingModel()
                {
                    Name = "ViewModelsModule",
                    AssemblyFile = "Publisher.ViewModels.dll",
                    ModuleType = "Publisher.ViewModels.ViewModelsModule, Publisher.ViewModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                },
                new ModulesSettingModel()
                {
                    Name = "AppleCustomizationModule",
                    AssemblyFile = "Publisher.AppleCustomization.dll",
                    ModuleType = "Publisher.AppleCustomization.AppleCustomizationModule, Publisher.AppleCustomization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                }
            };
        }

        public void LoadModules(IModuleCatalog moduleCatalog)
        {
            LoadCoreModules(_modulesSettingModels, moduleCatalog);
        }

        private void LoadCoreModules(IList<ModulesSettingModel> modulesSettingModels, IModuleCatalog moduleCatalog)
        {
            foreach (ModulesSettingModel modulesSettingModel in modulesSettingModels)
            {
                AddModule(moduleCatalog, modulesSettingModel);
            }
        }

        private void AddModule(IModuleCatalog moduleCatalog, ModulesSettingModel modulesSettingModel)
        {
            Assembly.LoadFrom(modulesSettingModel.AssemblyFile);

            moduleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = modulesSettingModel.Name,
                ModuleType = modulesSettingModel.ModuleType,
                Ref = modulesSettingModel.AssemblyFile
            });
        }

        private void RegisterViews(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellView, ShellView>();
        }

        private void RegisterViewModels(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IShellViewModel, ShellViewModel>();
        } 
        #endregion
    }
}