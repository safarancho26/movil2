using PM2E1201810060245.Data;
using PM2E1201810060245.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201810060245.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        UserDB userData = new UserDB();
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón para validar e ingresar a la pantalla principal de la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void loging_Clicked(object sender, EventArgs e)
        {
            if (await ValidateForm())
            {
                IEnumerable<User> result = userData.whereUser(userNameEntry.Text.Trim(), passwordEntry.Text.Trim());

                if (result.Count() == 0)
                {
                    await DisplayAlert("Alerta", "Email o Password Incorrectos.", "OK");
                }
                else if (result.Count() == 1)
                {
                    userNameEntry.Text = "";
                    passwordEntry.Text = "";
                    await Navigation.PushAsync(new MainPage());
                }
                else if (result.Count() >= 1)
                {
                    await DisplayAlert("Alerta", "Existe más de una cuenta registada, favor de solicitar la correción de la cuenta.", "OK");
                    //await Navigation.PushAsync(new DuplicateAccountSendEmail());
                }
            }
        }

        /// <summary>
        /// Validar las propiedades de la pantalla de envio de email
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ValidateForm()
        {
            //Valida si el valor en el Entry txtTo se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(userNameEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo Email es obligatorio.", "OK");
                return false;
            }
            else
            {
                //Valida que el formato del email sea valido
                bool isEmail = Regex.IsMatch(userNameEntry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    await this.DisplayAlert("Advertencia", "El formato del Email es incorrecto.", "OK");
                    return false;
                }
            }

            //Valida si el valor en el Entry txtSubject se encuentra vacio o es igual a Null
            if (String.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo Password es obligatorio.", "OK");
                return false;
            }

            return true;
        }

        private async void newloging_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new CrearUser());

        }
        private void salida_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}