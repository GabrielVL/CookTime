using System;
using System.Collections.Generic;
using System.Text;

namespace CookTime
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ItemBuscado
    {
        public string nombre { get; set; }
        public string Desc { get; set; }
        public string Foto { get; set; }
        public string tipo { get; set; }
        public string tiempo { get; set; }
        public string instrucciones { get; set; }
        public string precio { get; set; }
        public string porciones { get; set; }
        public string dificultad { get; set; }
        public string dieta { get; set; }
        public string likes { get; set; }
        public string dislikes { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
