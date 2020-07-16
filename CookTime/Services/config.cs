using System;
using System.Collections.Generic;
using System.Json;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Xsl;

namespace CookTime.Services
{
    class config
    {
        private static String myId;
        private static config conf;
        private static JsonObject perfil;
        private static JsonObject perfilOficial;
        private config()
        {
            
        }


        public static config getConfig()
        {
            if (conf == null)
            {
                conf = new config();
            }
            return conf;
        }

        public static String getMyId()
        {
            return myId;
        }
        public static void setMyId(String id)
        {
            myId = id;
        }

        public static JsonObject getPerfil()
        {
            return perfil;
        }
        public static void setPerfil(JsonObject profile)
        {
            perfil = profile;
            perfilOficial = (JsonObject) perfil["perfil"];
        }

        public static JsonObject getPerfilOficial()
        {
            return perfilOficial;
        }

    } 
}
