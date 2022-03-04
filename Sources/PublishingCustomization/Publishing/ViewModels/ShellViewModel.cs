using Prism.Mvvm;
using Publisher.Infrastructure.Interfaces.ViewModels;

namespace Publishing.ViewModels
{
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        #region ctor
        public ShellViewModel()
        { }
        #endregion

        #region Properties
        public string Fff { get; set; } = "sfdsf";
        #endregion

        #region Methods
        
        #endregion
    }
}