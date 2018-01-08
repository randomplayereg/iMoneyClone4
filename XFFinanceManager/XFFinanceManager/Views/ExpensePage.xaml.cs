using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFinanceManager.Models;
using static XFFinanceManager.Enums.CategoryEnum;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage
    {
        public ExpensePage()
        {
            InitializeComponent();

            var ExpenseList = Enum.GetValues(typeof(ExpenseCategory));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App)App.Current).ResumeAtFinanceManagerId = -1;
            var sortValue = App.Database.GetSettingValue("Sort");
            var filterValue = App.Database.GetSettingValue("Filter");

            //financeManagerListView.ItemsSource = App.Database.GetSortListFinance(filterValue, sortValue, 2, DateTime.Now, 0);
            walletList = App.Database.GetWalletManagerListForUI();

            if (((App)App.Current).CurrentWalletId == -1)
            {
                ((App)App.Current).CurrentWalletId = walletList[0].Id;
            };

            financeManagerListView.ItemsSource = App.Database.GetSortListFinance_ByWallet(filterValue, sortValue, 2, DateTime.Now, 0, ((App)App.Current).CurrentWalletId);

            walletUIName.Text = walletList.Single(w => w.Id == ((App)App.Current).CurrentWalletId).Name;
        }

        private async void AddNewItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewFinanceManager(2)
            {
                BindingContext = new FinanceManager()
                {
                    Type = 2,
                    WalletId = ((App)App.Current).CurrentWalletId
                }
            });
        }

        private async void financeManagerListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((App)App.Current).ResumeAtFinanceManagerId =
                (e.SelectedItem as FinanceManager).Id;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new DetailFinanceManager(2)
                {
                    BindingContext = e.SelectedItem as FinanceManager
                });
            }
        }

        List<WalletManager> walletList;

        // pop up when user click wallet toolbar item
        private async void WalletChoser(object sender, EventArgs e)
        {
            string[] walletNames = walletList.Select(w => w.Name).ToArray();
            string chosenName = await DisplayActionSheet(
                "Choose wallet",
                "Cancel",
                "Abort",
                walletNames);
            if (chosenName == "Cancel" || chosenName == "Abort") { return; };
            int chosenWalletId = walletList.Single(w => w.Name == chosenName).Id;
            ((App)App.Current).CurrentWalletId = chosenWalletId;

            //UpdateUI_ChangeWallet();
            var sortValue = App.Database.GetSettingValue("Sort");
            var filterValue = App.Database.GetSettingValue("Filter");
            //only expenses that belong to current chosen wallet will be shown
            walletUIName.Text = walletList.Single(w => w.Id == ((App)App.Current).CurrentWalletId).Name;
            financeManagerListView.ItemsSource = App.Database.GetSortListFinance_ByWallet(filterValue, sortValue, 2, DateTime.Now, 0, ((App)App.Current).CurrentWalletId);

        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = searchBar.Text;

            financeManagerListView.ItemsSource = App.Database.GetFinanceManagerSearchByName(keyword).Where(fm => fm.Type == 1).ToList();
            //financeManagerListView.ItemsSource = App.Database.GetFinanceManagerSearchByName_ExpensePage(keyword);
            //this also works xD
        }
    }
}