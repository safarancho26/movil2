using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E1201810060245.Services
{
    public class CamaraService
    {
        Plugin.Permissions.Abstractions.PermissionStatus cameraOK;
        Plugin.Permissions.Abstractions.PermissionStatus storageOK;
        public async Task Init()
        {
            await CrossMedia.Current.Initialize();
            cameraOK = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            storageOK = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (cameraOK != Plugin.Permissions.Abstractions.PermissionStatus.Granted || storageOK != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var status = await CrossPermissions.Current.RequestPermissionsAsync(new[]
                  {
                 Permission.Camera, Permission.Storage });



                cameraOK = status[Permission.Camera];
                storageOK = status[Permission.Storage];
            }
        }
        public async Task<MediaFile> TakePhoto()
        {



            if (cameraOK == Plugin.Permissions.Abstractions.PermissionStatus.Granted && storageOK == Plugin.Permissions.Abstractions.PermissionStatus.Granted && CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                var options = new StoreCameraMediaOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    AllowCropping = true,
                    PhotoSize = PhotoSize.Medium,



                    Directory = "Direcciones",
                    Name = $"{Guid.NewGuid()}.jpg",
                    SaveToAlbum = true
                };
                var file = await CrossMedia.Current.TakePhotoAsync(options);
                return file;
            }



            return null;
        }




        public async Task<MediaFile> ChoosePhoto()
        {



            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                return file;
            }



            return null;



        }




    }
}


