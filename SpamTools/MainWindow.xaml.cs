using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
using SpamTools.lib;
using SpamTools.lib.Data;
using SpamTools.lib.Servise;

namespace SpamTools
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs e)
        {
            var server = Servers.SelectedItem as MailServer;
            if(server == null)
            {
                MessageBox.Show("Сервер не выбран", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var sender = Users.SelectedItem as Sender;
            if (sender == null)
            {
                MessageBox.Show("Отправител не выбран", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var password = new SecureString();
            foreach(var password_char in PasswordService.Decode(sender.Password))
            {
                password.AppendChar(password_char);
            }

            var send_mail_server = new MailSenderService(server.Address, server.Port, server.UseSSL,
                sender.Address, password);

            send_mail_server.Send("Subject", "EmailBody", "email@server.com");
        }


    }
}
