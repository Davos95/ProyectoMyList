using mylist.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace mylist.Tools
{
    public class StorageSession
    {

        public async Task StorageUser(USER usuario, String token)
        {
            String json = JsonConvert.SerializeObject(usuario, Formatting.Indented);
            await SecureStorage.SetAsync("MyList_user_Storage", json);
            await SecureStorage.SetAsync("MyList_token_Storage", token);
        }

        public async Task<USER> GetStorageUser()
        {
            USER usuario = null;
            try
            {
                var authUser = await SecureStorage.GetAsync("MyList_user_Storage");
                usuario = JsonConvert.DeserializeObject<USER>(authUser);
            }catch
            {
                
            }
            
            return usuario;
        }

        public async Task<String> GetStorageToken()
        {
            String token = await SecureStorage.GetAsync("MyList_token_Storage");
            return token;
        }

        public void RemoveAllStorage()
        {
            SecureStorage.RemoveAll();
        }
    }
}
