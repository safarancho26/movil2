﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM2E1201810060245.ViewModels
{
    class Metodos
    {
        public class Meta
        {
            public int code { get; set; }
            public string requestId { get; set; }
        }



        public class Item
        {
            public int unreadCount { get; set; }
        }



        public class Notification
        {
            public string type { get; set; }
            public Item item { get; set; }
        }



        public class Contact
        {
        }



        public class LabeledLatLng
        {
            public string label { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
            public IList<LabeledLatLng> labeledLatLngs { get; set; }
            public int distance { get; set; }
            public string cc { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string contextLine { get; set; }
            public long contextGeoId { get; set; }
            public IList<string> formattedAddress { get; set; }
        }
        public class Icon
        {
            public string prefix { get; set; }
            public string mapPrefix { get; set; }
            public string suffix { get; set; }
        }
        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }



        public class Stats
        {
            public int tipCount { get; set; }
            public int usersCount { get; set; }
            public int checkinsCount { get; set; }
        }



        public class BeenHere
        {
            public int lastCheckinExpiredAt { get; set; }
        }



        public class Specials
        {
            public int count { get; set; }
            public IList<object> items { get; set; }
        }



        public class HereNow
        {
            public int count { get; set; }
            public string summary { get; set; }
            public IList<object> groups { get; set; }
        }



        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public string canonicalUrl { get; set; }
            public string canonicalPath { get; set; }
            public IList<Category> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            public bool venueRatingBlacklisted { get; set; }
            public BeenHere beenHere { get; set; }
            public Specials specials { get; set; }
            public HereNow hereNow { get; set; }
            public string referralId { get; set; }
            public IList<object> venueChains { get; set; }
            public bool hasPerk { get; set; }
        }



        public class Response
        {
            public IList<Venue> venues { get; set; }
            public bool confident { get; set; }
        }



        public class Places
        {
            public Meta meta { get; set; }
            public IList<Notification> notifications { get; set; }
            public Response response { get; set; }
        }



        public async static Task<List<Venue>> getSites(Double platitud, Double plongitud)
        {
            List<Venue> sitiosCercanos = new List<Venue>();
            //var urlfq = Sitios.getUrl(platitud, plongitud);
            //Response lugares = null;



            using (HttpClient cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync(Sitios.getUrl(platitud, plongitud));



                if (respuesta.IsSuccessStatusCode)
                {
                    var json = respuesta.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(json);
                    Debug.WriteLine(json);
                    //await DisplayAlert("respuesta", json, "ok");
                    var lugares = JsonConvert.DeserializeObject<Places>(json);



                    sitiosCercanos = lugares.response.venues as List<Venue>;
                }
            }
            return sitiosCercanos;
        }
    }



}

