using mylist.Base;
using mylist.Models;
using mylist.Tools;
using mylist.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace mylist.Viewmodels
{
    public class MasterPageItemViewModel : ViewModelBase
    {
        StorageSession session;
        public MasterPageItemViewModel()
        {
            this.session = new StorageSession();
            Task.Run(async() => {
                await this.CargarMenu();
                await this.CargarNombreUsuario();
            });
        }
        private ObservableCollection<MasterPageItem> _MasterPageItems;
        public ObservableCollection<MasterPageItem> MasterPageItems
        {
            get { return this._MasterPageItems; }
            set
            {
                this._MasterPageItems = value;
                OnPropertyChanged("MasterPageItems");
            }
        }

        private String _username;
        public String username
        {
            get { return this._username; }
            set { this._username = value; OnPropertyChanged("username"); }
        }

        public async Task CargarNombreUsuario()
        {
            USER usuario = await this.session.GetStorageUser();
            this.username = usuario.Nick;
        }

        public async Task CargarMenu()
        {
            this.MasterPageItems = new ObservableCollection<MasterPageItem>();
            this.MasterPageItems.Clear();

            var CerrarSesion = new MasterPageItem()
            {
                Titulo = "Cerrar sesión",
                PaginaHija = typeof(LoginView)
            };
            MasterPageItems.Add(CerrarSesion);
        } 

    }
}
