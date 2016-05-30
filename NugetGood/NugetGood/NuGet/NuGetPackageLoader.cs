using System;
using System.IO;
using System.Xml.Serialization;

namespace Owasp.SafeNuGet.NuGet
{
    public class NuGetPackageLoader
    {
        public NuGetPackages LoadPackages(String path)
        {
            using (var stream = File.OpenRead(path))
            {
                return LoadPackages(stream);
            }
        }
        
        public NuGetPackages LoadPackages(Stream packageConfig)
        {
            var serializer = new XmlSerializer(typeof(NuGetPackages));
            return (NuGetPackages)serializer.Deserialize(packageConfig);
        }
    }
}
