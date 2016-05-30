OWASP SafeNuGet
===============
OWASP SafeNuGet is an MsBuild task to warn about insecure NuGet libraries:
https://nuget.org/packages/SafeNuGet/

Use of libraries with known vulnerabilities is a big problem. So big in fact it has now made it to the [OWASP Top 10 2013](https://www.owasp.org/index.php/Top_10#OWASP_Top_10_for_2013). It's under [A9 Using Known Vulnerable Components](https://www.owasp.org/index.php/Top_10_2013-A9-Using_Components_with_Known_Vulnerabilities).

Installation
------------
1. Install the NuGet package
2. Build

Configuring
-----------
You can configure OWASP SafeNuGet by editing the packages/SafeNuGet.1.0.9/build/SafeNuGet.targets (replace the version number with the one you have installed).

Settings:

* CacheTimeInMinutes - how long the list of vulnerabilities should be kept before being refreshed from github
* DontBreakBuild - (from 1.0.9) - If set to true, will not break build even though vulnerable package is found


Want to contribute?
-------------------
Great! If you want to contribute to the list of unsafe libraries, please create a pull request, register it as an [issue](https://github.com/OWASP/SafeNuGet/issues) or email me at erlend.oftedal@owasp.org.

Code contributions are also very welcome. Fork and create a pull request.

Experience an issue?
--------------------
Register it here at github: [issues](https://github.com/OWASP/SafeNuGet/issues)

