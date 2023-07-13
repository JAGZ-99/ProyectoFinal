using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contáctanos : ContentPage
    {
        public Contáctanos()
        {
            InitializeComponent();
        }

        private void enviar_Clicked(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                // Campos no válidos, muestra un mensaje de error o realiza alguna acción
                return;
            }

            DisplayAlert("Formulario enviado", "Gracias por contáctarnos, tu formulario ha sido enviado.", "Aceptar");
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(cedulaEntry.Text) || !cedulaEntry.Text.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese una cédula válida (solo números).", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(nombreEntry.Text) || !nombreEntry.Text.Replace(" ", "").All(char.IsLetter))
            {
                DisplayAlert("Error", "Ingrese un nombre válido (solo letras).", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(telefonoEntry.Text) || !telefonoEntry.Text.All(char.IsDigit))
            {
                DisplayAlert("Error", "Ingrese un teléfono válido (solo números).", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(direccionEntry.Text) || !direccionEntry.Text.Replace(" ", "").All(char.IsLetterOrDigit))
            {
                DisplayAlert("Error", "Ingrese una dirección válida (solo letras y números).", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(correoEntry.Text) || !IsValidEmail(correoEntry.Text))
            {
                DisplayAlert("Error", "Ingrese un correo electrónico válido.", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(comentariosEditor.Text) || !comentariosEditor.Text.Replace(" ", "").All(char.IsLetterOrDigit))
            {
                DisplayAlert("Error", "Ingrese comentarios válidos (solo letras y números).", "OK");
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            //lógica para validar el formato del correo electrónico
            return email.EndsWith("@gmail.com") || email.EndsWith("@hotmail.com") || email.EndsWith("@yahoo.com");
        }
    }
}