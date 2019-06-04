using Acr.UserDialogs;
using mylist.Base;
using mylist.Models;
using mylist.Repositories;
using mylist.Services;
using mylist.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mylist.Viewmodels
{
    public class LoginViewModel: ViewModelBase
    {
        RepositoryLogin repo;
        public LoginViewModel()
        {
            this.repo = new RepositoryLogin();
            this.usuario = new USER();
        }

        private USER _usuario;
        
        public USER usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; OnPropertyChanged("usuario"); }
        }

        private String _repitePassword;
        public String repitePassword
        {
            get { return this._repitePassword; }
            set { this._repitePassword = value; OnPropertyChanged("repitePassword"); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return this._IsLoading; }
            set { this._IsLoading = value; OnPropertyChanged("IsLoading"); }
        }

        public Command LoginAction
        {
            get {
                return new Command( async()=> {
                    UserDialogs.Instance.ShowLoading("Cargando...",MaskType.Black);
                    if (await this.repo.Login(this.usuario)) {
                        DependencyService.Get<Toast>().Show("Se ha iniciado sesión!");
                        App.Current.MainPage = new NavigationPage(new MasterPage());
                    }
                    UserDialogs.Instance.HideLoading();
                });
            }
        }

        public Command GoRegistrar
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new RegisterView());
                });
            }
        }

        public Command Registrar
        {
            get
            {
                return new Command(async () =>
                {
                    if(this.usuario.Password == this.repitePassword)
                    {
                        this.usuario.Apellido1 = "prueba";
                        this.usuario.Apellido2 = "prueba";
                        this.usuario.Email = "prueba";
                        await this.repo.RegistrarUsuario(this.usuario);
                        DependencyService.Get<Toast>().Show("Usuario creado!");
                        await App.Current.MainPage.Navigation.PopModalAsync();
                    }
                    
                });
            }
        }

    }
}
