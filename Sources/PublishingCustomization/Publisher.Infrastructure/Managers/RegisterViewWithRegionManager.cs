using Prism.Regions;
using System;

namespace Publisher.Infrastructure.Managers
{
    public static class RegisterViewWithRegionManager
    {
        #region Methods
        public static void RegisterViewWithRegion(IRegionManager regionManager, string regionName, Type viewType)
        {
            ClearRegion(regionManager, regionName);
            regionManager.RegisterViewWithRegion(regionName, viewType);
        }

        /// <summary>
        /// Removes all views from the region.
        /// </summary>
        private static void ClearRegion(IRegionManager regionManager, string regionName)
        {
            regionManager.Regions[regionName].RemoveAll();
        }
        #endregion
    }
}