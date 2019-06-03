using mylist.Models;
using mylist.Tools;
using mylist.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mylist.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ProductListsView))) {
                Title = "MyList",
                BarBackgroundColor = Color.ForestGreen
            };

            IsPresented = false;
            this.lsvmenu.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.PaginaHija;
            if (item.Titulo == "Cerrar sesión")
            {
                StorageSession session = new StorageSession();
                session.RemoveAllStorage();
                Application.Current.MainPage = new LoginView();
                IsPresented = false;
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page)) {
                    BarBackgroundColor = Color.ForestGreen
                };
                IsPresented = false;
            }
        }
    }
}