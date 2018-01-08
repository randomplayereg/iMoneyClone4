using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFFinanceManager.Models
{
    public class WalletManager
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }      

        public int Amount { get; set; } // not set up at the beginning
        // will calculate automaticly when some modules request the balance on this wallet (detail on FinanceManagerDatabase)
    }

    //public class WalletManagerForUI
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public int Category { get; set; }

    //    public int Amount { set; get; }

    //    public WalletManagerForUI(WalletManager input)
    //    {
    //        Id = input.Id;
    //        Name = input.Name;
    //        Category = input.Category;
    //    }
    //}
}
