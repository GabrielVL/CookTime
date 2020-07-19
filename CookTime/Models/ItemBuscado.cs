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

        public override string ToString()
        {
            return nombre;
        }
    }
}
