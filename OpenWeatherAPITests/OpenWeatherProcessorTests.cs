using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherAPITests
{

    public class OpenWeatherProcessorTests : IDisposable
    {

        public void Dispose()
        {

        }



        [Fact]
        public void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {

            var t = OpenWeatherProcessor.Instance;

            t.ApiKey = null;

            Task<OpenWeatherOneCallModel> Ow = t.GetOneCallAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }


        [Fact]
        public void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            var t = OpenWeatherProcessor.Instance;

            t.ApiKey = null;

            Task<OWCurrentWeaterModel> Ow = t.GetCurrentWeatherAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }



        [Fact]
        public void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            var t = OpenWeatherProcessor.Instance;

            ApiHelper.ApiClient = null;
            t.ApiKey = "ApiKey";

            Task<OpenWeatherOneCallModel> Ow = t.GetOneCallAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }




        [Fact]
        public void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            

            var t = OpenWeatherProcessor.Instance;
           
            ApiHelper.ApiClient = null;
            t.ApiKey = "ApiKey";
            
            Task<OWCurrentWeaterModel> Ow = t.GetCurrentWeatherAsync();

            Assert.Throws<AggregateException>(() => Ow.Result);
        }

    }
}

