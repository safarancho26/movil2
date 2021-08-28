using PM2E1201810060245.Data;
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
    public partial class CrearUser : ContentPage
    {
       
        UserDB userData = new UserDB();
        public CrearUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón para validar e ingresar a la pantalla principal de la app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void crearCuenta(object sender, EventArgs e)
        {
            if (await ValidateForm())
            {
                bool result = userData.InsertUser(EmailEntry.Text.Trim(), passwordEntry.Text.Trim(), userNameEntry.Text.Trim(), PhoneEntry.Text.Trim());

                if (result == true)
                {
                    await Navigation.PushAsync(new Login());
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
                bool isEmail = Regex.IsMatch(EmailEntry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
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

    }
}