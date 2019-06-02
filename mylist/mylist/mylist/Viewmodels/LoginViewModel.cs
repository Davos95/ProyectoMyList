using mylist.Base;
using mylist.Models;
using mylist.Repositories;
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

        public Command LoginAction
        {
            get {
                return new Command( async()=> {
                    if (await this.repo.Login(this.usuario)) {
                        await App.Current.MainPage.Navigation.PushAsync(new MasterPage());
                    }
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
                    }
                    
                });
            }
        }

    }
}
