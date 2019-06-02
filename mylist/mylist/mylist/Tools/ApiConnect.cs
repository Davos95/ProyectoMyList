using mylist.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace mylist.Tools
{
    public class ApiConnect
    {
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public ApiConnect()
        {
            this.uriapi = "https://apimylistdvb.azurewebsites.net/";
            this.headerjson = new MediaTypeWithQualityHeaderValue("application/json");
        }


        public async Task<T> CallApi<T>(String peticion, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if(token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }

                HttpResponseMessage response = await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T datos = JsonConvert.DeserializeObject<T>(json);
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }


        public async Task CallApiPost(Object obj, String peticion, String token)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            String jsondoctor = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //DEBEMOS CONVERTIR EL STRING A BYTE[]
            byte[] bufferdoctor = Encoding.UTF8.GetBytes(jsondoctor);
            //PARA PODER ENVIAR OBJETOS A NUESTRO SERVICIO SE UTILIZA UN TONTEN. 
            //EN XAMARIN ES UN ByteArrayContent

            ByteArrayContent content = new ByteArrayContent(bufferdoctor);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Uri uri = new Uri(this.uriapi + peticion);

            HttpResponseMessage response = await client.PostAsync(uri, content);

        }


        public async Task ApiDelete(String peticion, String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);

                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
                }
                HttpResponseMessage responseMessage = await cliente.DeleteAsync(peticion);
            }
        }

        public async Task<String> GetToken(String usuario, String password)
        {
            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);

                USER user = new USER();
                user.Nick = usuario;
                user.Password = password;
                String json = JsonConvert.SerializeObject(user);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                String peticion = "api/Auth/Login";
                HttpResponseMessage response = await client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(contenido);
                    return jObject.GetValue("response").ToString();
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
