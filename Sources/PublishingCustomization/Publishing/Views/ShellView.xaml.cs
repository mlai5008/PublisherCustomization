using System.Windows;
using Publisher.Infrastructure.Interfaces.Views;

namespace Publishing.Views
{
    /// <summary>
    /// Логика взаимодействия для ShellView.xaml
    /// </summary>
    public partial class ShellView : Window, IShellView
    {
        #region ctor
        public ShellView()
        {
            InitializeComponent();
        }
        #endregion
    }
}
