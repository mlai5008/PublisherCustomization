using Publisher.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace Publisher.AppleCustomization.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IMainView
    {
        #region Ctor
        public MainView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
