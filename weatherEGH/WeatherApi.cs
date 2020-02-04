using System;
using System.Threading.Tasks;
using Refit;

namespace weatherEGH
{
    [Headers("Content-Type: application/json")]
    public interface WeatherApi
    {
        [Get("/data/2.5/weather?lat={lat}&lon={lot}&APPID=b534b41eadfefd8cd3ae7750d673b92b")]
        Task<Weather> getInfo(String lat,String lot);

    }
}
