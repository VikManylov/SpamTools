using SpamTools.lib.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib
{
    public class DataServiceDB : IDataService
    {
        private SpamDatabaseDataContext _DataBaseContext;

        public DataServiceDB(SpamDatabaseDataContext Context) => _DataBaseContext = Context;

        public IEnumerable<EmailRecipient> GetEmailRecipients()
        {
            return new ObservableCollection<EmailRecipient>(_DataBaseContext.EmailRecipient); 
        }
    }
}
