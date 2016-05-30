﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Owasp.SafeNuGet.NuGet
{
    [XmlRoot(Namespace="", ElementName="packages")]
    public class NuGetPackages : List<NuGetPackage>
    {
    }

    [XmlType(TypeName="package")]
    public class NuGetPackage
    {
        [XmlAttribute(AttributeName="id")]
        public String Id { get; set; }
        [XmlAttribute(AttributeName="version")]
        public String Version { get; set; }
    }
}
