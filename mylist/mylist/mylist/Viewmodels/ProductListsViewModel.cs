using mylist.Base;
using mylist.Models;
using mylist.Repositories;
using mylist.Tools;
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

        public Command GoCesta
        {
            get
            {
                return new Command(async() =>
                {
                    
                });
            }
        }
    }
}
