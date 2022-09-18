using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Infrastructure.Configurations
{
    public class ServiceConfiguration
    {

        public static IConfiguration GetConfigurationSection(string sectionName)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../", "Presentation/PhotoProject.Api"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetSection(sectionName);
        }

    }
}
