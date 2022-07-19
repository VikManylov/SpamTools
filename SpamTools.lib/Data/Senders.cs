using SpamTools.lib.Servise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpamTools.lib.Data
{
    public class Senders
    {
        public static List<Sender> List { get; } = new List<Sender>
        {
            new Sender{Name = "Ivanov", Address = "ivanov@mail.ru", Password = PasswordService.Encode("PassWord")},
            new Sender{Name = "Petrov", Address = "petrov@mail.ru", Password = PasswordService.Encode("Pass123")},
            new Sender{Name = "Sidorov", Address = "sidorov@mail.ru", Password = PasswordService.Encode("qwerty123")}
        };
    }
}
