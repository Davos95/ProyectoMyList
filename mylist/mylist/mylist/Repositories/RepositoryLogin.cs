using mylist.Models;
using mylist.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mylist.Repositories
{
    public class RepositoryLogin
    {

        ApiConnect connet;
        StorageSession session;
        public RepositoryLogin()
        {
            this.connet = new ApiConnect();
            this.session = new StorageSession();
        }

        public async Task<bool> Login(USER usuario)
        {
            var token = await this.connet.GetToken(usuario.Nick, usuario.Password);

            if(token != null)
            {
                USER usu = await this.connet.CallApi<USER>("api/User/GetUsuarioCredenciales/" + usuario.Nick + "/" + usuario.Password, null);
                await session.StorageUser(usu, token);
                return true;
            } else
            {
                return false;
            }
        }

        public async Task RegistrarUsuario(USER usuario)
        {
            await this.connet.CallApiPost(usuario, "api/User/CrearUsuario", null);
        }

    }
}
