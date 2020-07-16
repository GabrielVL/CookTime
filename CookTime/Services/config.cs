using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Xsl;

namespace CookTime.Services
{
    class config
    {
        private static String myId;
        private static config conf;
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
        
    } 
}
