﻿using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Owasp.SafeNuGet.Unsafe
{
    public class PackageListLoader
    {
        private const String PackageUrl = "https://raw.github.com/OWASP/SafeNuGet/master/feed/unsafepackages.xml";

        public UnsafePackages GetCachedUnsafePackages(string cachePath, int cacheTimeInMinutes, out bool cacheHit)
        {
            DirectoryInfo dir = new DirectoryInfo(cachePath);
            if (!dir.Exists) dir.Create();
            FileInfo file = new FileInfo(Path.Combine(dir.FullName, "unsafepackages.xml"));
            cacheHit = true;
            if (!file.Exists || file.LastWriteTime < DateTime.Now.AddMinutes(-cacheTimeInMinutes))
            {
                cacheHit = false;
                FileInfo newFile = new FileInfo(file.FullName + ".new");
                BuildWebClient().DownloadFile(PackageUrl, newFile.FullName);
                File.Copy(newFile.FullName, file.FullName, true);   
            }
            using (var s = file.OpenRead())
            {
                return LoadPackages(s);
            }
        }

        private static WebClient BuildWebClient()
        {
            var client = new WebClient();

            var proxy = WebRequest.DefaultWebProxy;
            if (proxy == null)
            {
                return client;
            }

            proxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = proxy;

            return client;
        }

        public UnsafePackages GetUnsafePackages()
        {
            var request = WebRequest.Create(PackageUrl);
            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    return LoadPackages(stream);
                }
            }
        
        }
        public UnsafePackages LoadPackages(Stream packages)
        {
            var serializer = new XmlSerializer(typeof(UnsafePackages));
            return (UnsafePackages)serializer.Deserialize(packages);
        }
    }
}
