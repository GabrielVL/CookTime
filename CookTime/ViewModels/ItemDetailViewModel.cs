using System;

using CookTime.Models;

namespace CookTime.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        /** Ayuda a visualizar parámetro items
       *  @Params: item Item
       *  @Author:Adrian González
       *  @Returns nothing
       **/
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
