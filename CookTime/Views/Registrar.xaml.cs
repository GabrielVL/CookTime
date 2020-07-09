using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CookTime.Models;

namespace CookTime.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Registrar : ContentPage
    {
        public User User { get; set; }

        public Registrar()
        {
            InitializeComponent();
            User = new User
            {
                Nombre = "Nombre del usuario",
                PrimerApellido = "Primer apellido",
                SegundoApellido = "Segundo apellido",
                Correo = "Corrreo Electrónico",
                Edad = "Edad",
                Contraseña = "Contraseña",
                Perfil = "Perfil del usuario",
            };

            BindingContext = this;
        }

        async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }



    }
}