using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookTime.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Administrar : ContentPage
    {
        public Administrar()
        {
            InitializeComponent();
        }

        /** Abre nueva ventana para el cambio de nombre
        *  @Params: object sender, EventArgs e
        *  @Author:Andrés Quirós
        *  @Returns nothing
        **/
        async void ChangeName(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeName()));
        }
        /** Abre nueva ventana para el cambio de contraseña
*  @Params: object sender, EventArgs e
*  @Author:Andrés Quirós
*  @Returns nothing
**/
        async void ChangePass(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangePass()));
        }

        /** Abre nueva ventana para el cambio de foto de perfil
*  @Params: object sender, EventArgs e
*  @Author:Andrés Quirós
*  @Returns nothing
**/
        async void ChangeImage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ChangeImage()));
        }

        /** Abre nueva ventana para creación de nueva empresa
*  @Params: object sender, EventArgs e
*  @Author:Andrés Quirós
*  @Returns nothing
**/
        async void NewEmpresa(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEmpresa()));
        }
    }
}