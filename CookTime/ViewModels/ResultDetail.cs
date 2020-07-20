using System;

using CookTime.Models;

namespace CookTime.ViewModels
{
    public class ResultDetail : BaseViewModel
    {
        public ItemBuscado Ver { get; set; }
        public ResultDetail(ItemBuscado obj = null)
        {
            Title = obj?.nombre;
            Ver = obj;
        }
    }
}
