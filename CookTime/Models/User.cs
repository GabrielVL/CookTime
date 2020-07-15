using System;
using System.Collections.Generic;
using System.Text;

namespace CookTime
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class User
    {
        public string apellido2 { get; set; }
        public string apellido1 { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
        public string edad { get; set; }
        public string perfil { get; set; }

    }

    public class UserList
    {
        public List<User> User { get; set; }

    }


}
