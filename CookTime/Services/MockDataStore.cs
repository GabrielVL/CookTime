using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookTime.Models;
using System.Json;
using System.Net;
using CookTime.Views;
using Newtonsoft.Json.Linq;

namespace CookTime.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        JsonArray pubCont = new JsonArray();
        JsonArray comments = new JsonArray();
        public MockDataStore()
        {

            items = new List<Item>()
            {
                
            };
            Peticion();
            Publicar();
        
        }

        /** Hace la petición al servidor para obtener las recetas y las guarda en un JsonArray
        *  @Params: nothing
        *  @Author:Adrian González
        *  @Returns nothing
        **/
        public async void Peticion()
        {
            WebClient nombre = new WebClient();
            MyIp myIps = new MyIp();


            JsonArray x = (JsonArray)config.getPerfilOficial()["Following"];
            try
            {
                foreach (string i in x)
                {
                    Console.WriteLine("USUARIOOOOOOOOOO"+i);
                    String urlUsuario = "http://" + myIps.returnIP() + "/CookTime_war_exploded/users?ID="+i;
                    JsonObject usuarioActual = (JsonObject)JsonObject.Parse(nombre.DownloadString(urlUsuario));
                    JsonObject currentPerfil = (JsonObject)usuarioActual["perfil"];
                    JsonArray currentMymenu = (JsonArray)currentPerfil["MyMenu"];


                    Console.WriteLine("USUARIOOOOOOOOOO2222222222222222" + i);
                    try
                    {
                        foreach (string idReceta in currentMymenu)
                        {
                            Console.WriteLine("RECETA CON IDDDDDDDD" + idReceta);

                            String url = "http://" + myIps.returnIP() + "/CookTime_war_exploded/recipes?Id=" + idReceta;
                            pubCont.Add((JsonObject)JsonObject.Parse(nombre.DownloadString(url)));
                        }

                    }
                    catch { }
                    Console.WriteLine("USUARIOOOOOOOOOO3333333333333333333333333" + i);
                }
            }
            catch { 
            }
        }


        /** Añade los parámetro de las recetas a los de item
        *  @Params: nothing
        *  @Author:Adrian González
        *  @Returns nothing
        **/
        public void Publicar() {

            

            for (int i = 0; i < pubCont.Count; i++)
            {
                try
                {
                    List<string> receta = new List<string>();
                    comments = (JsonArray)pubCont[i]["comentarios"];

                    foreach (JsonObject x in comments) {
                        try
                        {
                            receta.Add(x["contenido"]);
                        }
                        catch (Exception e){
                            Console.WriteLine(e);
                        }
                    }
                    items.Add(new Item { Text = pubCont[i]["nombre"],
                        dieta = pubCont[i]["dieta"], foto = pubCont[i]["foto"], autor = pubCont[i]["autor"],
                        tiempo = pubCont[i]["tiempo"], instrucciones = pubCont[i]["instrucciones"],
                        precio = pubCont[i]["precio"], dificultad = pubCont[i]["dificultad"],
                        Id = pubCont[i]["id"],
                        likes = pubCont[i]["likes"], dislikes = pubCont[i]["dislikes"], comentarios = receta,
                    });

                }
                catch (Exception e)
                {
                    
                }
            }

        }
        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}