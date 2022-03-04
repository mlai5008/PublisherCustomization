using Publisher.Infrastructure.Interfaces.Views;
using System.Windows.Controls;

namespace Publisher.Views.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IMainView
    {
        #region ctor
        public MainView()
        {
            InitializeComponent();
        } 
        #endregion
    }
}
