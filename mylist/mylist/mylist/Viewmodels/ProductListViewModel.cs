using mylist.Base;
using mylist.Models;
using mylist.Repositories;
using mylist.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mylist.Viewmodels
{
    public class ProductListViewModel: ViewModelBase
    {
        RepositoryProductList repo;
        StorageSession session;
        public ProductListViewModel()
        {
            this.productList = new ProductList();
            this.repo = new RepositoryProductList();
            this.session = new StorageSession();
        }

        private ProductList _productList;
        public ProductList productList
        {
            get
            {
                return this._productList;
            }
            set
            {
                this._productList = value;
                OnPropertyChanged("productList");
            }
        }
        
        public Command CrearLista
        {
            get
            {
                return new Command(async () =>
                {
                    USER usuario = await this.session.GetStorageUser();
                    await this.repo.CrearLista(this.productList,usuario.Id);
                });

            }
        }
    }
}
