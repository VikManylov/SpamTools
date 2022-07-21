using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SpamTools.lib;
using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpamTools.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDataService _DataService;

        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        //private readonly ObservableCollection<EmailRecipient> _Recipients = new ObservableCollection<EmailRecipient>();

        public ObservableCollection<EmailRecipient> Recipients { get; } = new ObservableCollection<EmailRecipient>();

        public ICommand UpdateRecipientsCommand { get; }

        private bool CanUpdateRecipientsCommandExecute() => true;

        private void OnUpdateRecipientsCommandExecuted()
        {
            Recipients.Clear();
            var db_recipients = _DataService.GetEmailRecipients();

            foreach(var recipient in db_recipients)
            {
                Recipients.Add(recipient);
            }
        }

        public MainWindowViewModel(IDataService DataService)
        {
            UpdateRecipientsCommand = new RelayCommand(OnUpdateRecipientsCommandExecuted, CanUpdateRecipientsCommandExecute);

            _DataService = DataService;
        }
    }
}
