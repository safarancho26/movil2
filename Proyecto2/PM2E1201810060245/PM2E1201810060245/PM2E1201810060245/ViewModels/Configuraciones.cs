using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E1201810060245.ViewModels
{
    class Configuraciones
    {
        public const String IDFoursquare = "4CWDZINIQLPOD1VOT2STL1T5RXSIXBQPHWESXFLL1UJDMW2R";
        public const String SecretFoursquare = "HMCDZGLOQDRDOHO51QBLIPY52XCMG2XCBSLGHLWC1DS35K5A";
        public const String apifoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}&radius=1000&venuePhotos=1";
    }



    public static class Sitios
    {
        public static String getUrl(Double latitud, Double longitud)
        {
            return String.Format(
            Configuraciones.apifoursquare,
            latitud,
            longitud,
            Configuraciones.IDFoursquare,
            Configuraciones.SecretFoursquare,
            DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}