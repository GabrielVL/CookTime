using System;
using System.Collections.Generic;
using System.Json;
using System.Text;

namespace CookTime
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ItemBuscado
    {

        public string Id { get; set; }
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

        public string correo { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }
        public string edad { get; set; }

        public string chef { get; set; }
        public string chefLabel { get; set; }

        public string horario { get; set; }
        public string contacto { get; set; }
        public string puntuacion { get; set; }

        public JsonArray MyMenu { get; set; }



        public override string ToString()
        {
            return nombre;
        }

        public string CheckChef() {
            if (chef.Equals("2")) {
                return "Chef";
            }
            else
            {
                return "";
            }
        }
    }
}
