using System;
using System.Collections.Generic;
using System.Json;
using System.Text;

namespace CookTime.Models
{
    class receta: System.IComparable
    {

        public receta(JsonObject res) 
        
            { recetaJSON = res; }

        public JsonObject recetaJSON { get; set; }


        public int CompareTo(object obj)
        {

            string resActual = recetaJSON["fecha"];
            string resContra = ((JsonObject)obj)["fecha"];

            return resActual.CompareTo(resContra);
        }
    }
}
