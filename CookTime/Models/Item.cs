using System;
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

    }

    public class User
    {   
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Edad { get; set; }
        public string Contraseña { get; set; }
        public string Perfil { get; set; }




    }
}