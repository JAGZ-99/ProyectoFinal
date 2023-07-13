using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto
{
    public partial class RegistroPage : ContentPage, INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        private string _primerApellido;
        public string PrimerApellido
        {
            get { return _primerApellido; }
            set
            {
                if (_primerApellido != value)
                {
                    _primerApellido = value;
                    OnPropertyChanged(nameof(PrimerApellido));
                }
            }
        }

        private string _segundoApellido;
        public string SegundoApellido
        {
            get { return _segundoApellido; }
            set
            {
                if (_segundoApellido != value)
                {
                    _segundoApellido = value;
                    OnPropertyChanged(nameof(SegundoApellido));
                }
            }
        }

        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(Usuario));
                }
            }
        }

        private string _contrasena;
        public string Contrasena
        {
            get { return _contrasena; }
            set
            {
                if (_contrasena != value)
                {
                    _contrasena = value;
                    OnPropertyChanged(nameof(Contrasena));
                }
            }
        }

        private Command _registerCommand;
        public Command RegisterCommand => _registerCommand ?? (_registerCommand = new Command(OnRegister));

        public RegistroPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnRegister()
        {
            // Validación de campos
            if (string.IsNullOrWhiteSpace(Nombre) || !IsValidName(Nombre))
            {
                await DisplayAlert("Error", "Ingrese un Nombre válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(PrimerApellido) || !IsValidName(PrimerApellido))
            {
                await DisplayAlert("Error", "Ingrese un primer Apellido válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(SegundoApellido) || !IsValidName(SegundoApellido))
            {
                await DisplayAlert("Error", "Ingrese un segundo Apellido válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Usuario) || !IsValidUsername(Usuario))
            {
                await DisplayAlert("Error", "Ingrese un Usuario válido", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Contrasena) || !IsValidPassword(Contrasena))
            {
                await DisplayAlert("Error", "Ingrese una Contraseña válida", "OK");
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

        // Validación de contraseña (mínimo 8 caracteres, al menos una letra y un número)
        private bool IsValidPassword(string password)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}