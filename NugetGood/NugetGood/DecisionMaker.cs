using Owasp.SafeNuGet.NuGet;
using Owasp.SafeNuGet.Unsafe;
using System.Collections.Generic;
using System.Linq;

namespace Owasp.SafeNuGet
{
    public class DecisionMaker
    {
        public List<KeyValuePair<NuGetPackage, UnsafePackage>> Evaluate(NuGetPackages packages, UnsafePackages unsafePackages) 
        {
            return packages
                .SelectMany(p => 
                    unsafePackages.Where(u => u.Is(p))
                        .Select(u => new KeyValuePair<NuGetPackage, UnsafePackage>(p, u)
                    )
                 ).ToList();
        }
    }
}
