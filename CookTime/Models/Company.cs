using System;
using System.Collections.Generic;
using System.Text;

namespace CookTime.Models
{
    public class Company
    {
        public string nombre { get; set; }
        public string horario { get; set; }
        public string contacto { get; set; }

    }

    public class CompanyList
    {
        public List<Company> Companies { get; set; }

    }


}
