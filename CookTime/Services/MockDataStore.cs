using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookTime.Models;
using System.Json;
using System.Net;
using CookTime.Views;

namespace CookTime.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        JsonArray pubCont = new JsonArray();
        public MockDataStore()
        {

            items = new List<Item>()
            {
                
            };
            Peticion();
            Publicar();
        
        }

        public async void Peticion()
        {
            MyIp myIps = new MyIp();
            String url = "http://"+myIps.returnIP()+"/CookTime_war_exploded/recipes";


            WebClient nombre = new WebClient();
            //nombre.QueryString.Add("ID", "1");
            //nombre.QueryString.Add("DATA", "nombre");
            pubCont = (JsonArray)JsonArray.Parse(nombre.DownloadString(url));
        }

        public void Publicar() {

            for (int i = 0; i < pubCont.Count; i++)
            {
                try
                {
                    items.Add(new Item { Id = Guid.NewGuid().ToString(), Text = pubCont[i]["nombre"].ToString(), Description = pubCont[i]["dieta"], foto = pubCont [i]["foto"], autor = pubCont[i]["autor"], tiempo = pubCont[i]["tiempo"], instrucciones = pubCont[i]["instrucciones"], precio = pubCont[i]["precio"], dificultad = pubCont[i]["dificultad"]    });
                    JsonObject actPub = new JsonObject();
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