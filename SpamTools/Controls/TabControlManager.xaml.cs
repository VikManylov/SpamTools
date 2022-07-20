using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpamTools.Controls
{
    /// <summary>
    /// Логика взаимодействия для TabControlManager.xaml
    /// </summary>
    public partial class TabControlManager : UserControl
    {
        public event EventHandler Back;
        public event EventHandler Forward;


        public TabControlManager() => InitializeComponent();

        private void OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }

        private void OnForwardButtonClick(object sender, RoutedEventArgs e)
        {
            Forward?.Invoke(this, EventArgs.Empty);
        }
    }
}
