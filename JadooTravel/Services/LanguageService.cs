using System.Reflection;
using Microsoft.Extensions.Localization;

namespace JadooTravel.Services
{
    public class SharedResource
    {

    }
    public class LanguageService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type=typeof(SharedResource);
            var assemblyName=new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _stringLocalizer = factory.Create(nameof(SharedResource),assemblyName.Name);
        }

        public LocalizedString Getkey(string key)
        {
            return _stringLocalizer[key];
        }
    }
}
