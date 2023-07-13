using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Proyecto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            // Mostrar diálogo de entrada de datos
            string nombre = await DisplayPromptAsync("Registro", "Ingrese su Nombre", maxLength: 10);
            string primerApellido = await DisplayPromptAsync("Registro", "Ingrese su Primer Apellido", maxLength: 10);
            string segundoApellido = await DisplayPromptAsync("Registro", "Ingrese su Segundo Apellido", maxLength: 10);
            string usuario = await DisplayPromptAsync("Registro", "Ingrese un Usuario", maxLength: 7);
            string contraseña = await DisplayPromptAsync("Registro", "Ingrese una Contraseña", maxLength: 5);

            // Validación de campos
            if (string.IsNullOrWhiteSpace(nombre) || !IsValidName(nombre))
            {
                await DisplayAlert("Error", "Ingrese un Nombre válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(primerApellido) || !IsValidName(primerApellido))
            {
                await DisplayAlert("Error", "Ingrese un Primer Apellido válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(segundoApellido) || !IsValidName(segundoApellido))
            {
                await DisplayAlert("Error", "Ingrese un Segundo Apellido válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(usuario) || !IsValidUsername(usuario))
            {
                await DisplayAlert("Error", "Ingrese un Usuario válido", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(contraseña) || !IsValidUsername(contraseña))
            {
                await DisplayAlert("Error", "Ingrese una Contraseña válido", "OK");
                return;
            }

            // Lógica para registrar al usuario
            await DisplayAlert("Registro exitoso", "Usuario registrado correctamente", "OK");

            // Lógica adicional después del registro
        }

        // Validación de nombre (solo letras)
        private bool IsValidName(string name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        // Validación de usuario (letras, números y caracteres especiales)
        private bool IsValidUsername(string username)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9!@#$%^&*_]+$");
        }

        private async void OnAppleLoginClicked(object sender, EventArgs e)
        {
            // Redirigir al usuario al enlace de Apple
            await Launcher.OpenAsync(new Uri("https://appleid.apple.com/sign-in"));
        }

        private async void OnYahooLoginClicked(object sender, EventArgs e)
        {
            // Redirigir al usuario al enlace de email
            await Launcher.OpenAsync(new Uri("https://login.yahoo.com/?.src=ym&pspid=159600001&activity=mail-direct&.lang=es-ES&.intl=es&.done=https%3A%2F%2Fmail.yahoo.com%2Fd"));
        }

        private async void OnFacebookLoginClicked(object sender, EventArgs e)
        {
            // Redirigir al usuario al enlace de Facebook
            await Launcher.OpenAsync(new Uri("https://es-la.facebook.com/"));
        }

        private async void OnGoogleLoginClicked(object sender, EventArgs e)
        {
            // Redirigir al usuario al enlace de Google
            await Launcher.OpenAsync(new Uri("https://www.google.com/intl/es/gmail/about/"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new IniciarSesionPage());
        }
    }
}