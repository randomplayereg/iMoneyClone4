using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntitiesPage
    {
        public EntitiesPage()
        {
            InitializeComponent();

            //entitiesList.ItemSource = new List<string> { "Accounts", "Finance Categories" };
        }

        private async void accountsEditorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountsPage());
        }

        private async void categoriesEditorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryPage());
        }
    }
}