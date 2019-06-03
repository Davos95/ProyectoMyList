using mylist.Base;
using mylist.Models;
using mylist.Repositories;
using mylist.Tools;
using mylist.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mylist.Viewmodels
{
    public class ProductListsViewModel: ViewModelBase
    {
        StorageSession session;
        RepositoryProductList repo;
        public ProductListsViewModel()
        {

            this.session = new StorageSession();
            this.repo = new RepositoryProductList();
            Task.Run(async () =>
            {
                await this.CargarLista();
            });
        }

        private ObservableCollection<ProductList> _productList;
        public ObservableCollection<ProductList> productList
        {
            get { return this._productList; }
            set { this._productList = value; OnPropertyChanged("productList"); }
        }


        private async Task CargarLista()
        {
            USER usuario = await this.session.GetStorageUser();
            List<ProductList> lista = await this.repo.GetListaUsuario(usuario.Id);
            this.productList = new ObservableCollection<ProductList>(lista);
        }

        public Command GoCrear
        {
            get
            {
                return new Command(async() =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new ProductListView());
                    MessagingCenter.Subscribe<ProductListsViewModel>(this, "UPDATE", async(sender)=> {
                        await this.CargarLista();
                    });
                });
            }
        }

        public Command GetListas
        {
            get
            {
                return new Command(async () =>
                {
                    await this.CargarLista();
                });
            }
        }
    }
}
