using Microsoft.Extensions.Configuration;
using System;

namespace SpecflowSelenium.Setup
{
    public class Configuracao
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration != null)
                {
                    return _configuration;
                }
                Configurar();
                return _configuration;
            }
        }

        public static void Configurar()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }
    }
}

