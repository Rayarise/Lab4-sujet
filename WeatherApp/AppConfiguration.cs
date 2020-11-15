using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public  class AppConfiguration
    {

       static private  IConfiguration configuration;



        private void initConfig() {

            var build = new ConfigurationBuilder();
            build.AddJsonFile("appsettings.json", optional: true,reloadOnChange: true);

            var EnvironementVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");

            var isDev = string.IsNullOrEmpty(EnvironementVariable) || EnvironementVariable.ToLower() == "development";

            if (isDev)
            {

                build.AddUserSecrets<MainWindow>();
            }

            configuration = build.Build();



        }


        public string getValue(string s) {

            string val = s;

            if (configuration == null)
            {
                initConfig();

            }

            val = configuration["OWApiKey"];

            return val;


            
        }
    }
}
