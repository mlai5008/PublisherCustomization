using Prism.Regions;

namespace Publisher.Infrastructure.Managers
{
    public static class RegionNavigationManager
    {
        #region Methods
        /// <summary>
        /// Navigate to given view in region.
        /// </summary>
        /// <param name="regionManager">Caller region manager</param>
        /// <param name="regionName">Name of region</param>
        /// <param name="viewName">Name of view</param>
        public static void Navigate(IRegionManager regionManager, string regionName, string viewName)
        {
            regionManager?.RequestNavigate(regionName, viewName);
        }

        /// <summary>
        /// Navigate to given view in region.
        /// </summary>
        /// <param name="regionManager">Caller region manager</param>
        /// <param name="regionName">Name of region</param>
        /// <param name="viewName">Name of view</param>
        /// <param name="navigationParameters">Passing parameters</param>
        public static void Navigate(IRegionManager regionManager, string regionName, string viewName, NavigationParameters navigationParameters)
        {
            regionManager?.RequestNavigate(regionName, viewName, navigationParameters);
        }
        #endregion
    }
}