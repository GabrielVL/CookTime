    using System;
using System.Collections.Generic;
using System.Json;
using Xamarin.Forms;

namespace CookTime.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string foto { get; set; }
        public string autor { get; set; }
        public string tiempo { get; set; }
        public string instrucciones { get; set; }
        public string precio { get; set; }
        public string porciones { get; set; }
        public string dificultad { get; set; }
        public string dieta { get; set; }
        public string likes { get; set; }
        public string dislikes { get; set; }
        public List<string> comentarios { get; set; }

    }

}