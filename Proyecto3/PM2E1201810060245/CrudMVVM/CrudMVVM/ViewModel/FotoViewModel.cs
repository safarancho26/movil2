using CrudMVVM.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CrudMVVM.ViewModel
{
    public class FotoViewModel : BaseViewModel
    {
        CamaraService camaraService;



        private ImageSource _photo;



        public ImageSource Photo
        {
            get { return _photo; }
            set { _photo = value; OnPropertyChanged(); }
        }



        public ICommand TakePhotoCommand { get; private set; }
        public ICommand ChoosePhotoCommand { get; private set; }



        public FotoViewModel()
        {
            camaraService = new CamaraService();
            Task.Run(async () => await camaraService.Init());



            TakePhotoCommand = new Command(async () => await TakePhoto());
           
        }



        private async Task TakePhoto()
        {
            var file = await camaraService.TakePhoto();



            if (file != null)
                Photo = ImageSource.FromStream(() => file.GetStream());
        }



      
    }
}