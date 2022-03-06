using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.Utilities
{
    class FrameworkConstants
    {
        
        const string protocol = "https";
        const string hostname = "shop.jolidon.ro";
        const string extensionPath = "Other\\ExtensionFile";

        public const bool startHeadless = false;
        public const bool useProxy = false;
        public const bool startMaximized = true;
        public const bool ignoreCertErr = true;
        public const string browserProxy = "127.0.0.1:8080";
        public const bool startWithExtension = false;
        public const string extensionName = "metamask-10.8.1-an+fx.xpi";

        public static string GetUrl()
        {
            return String.Format("{0}://{1}", protocol, hostname);
        }

        public static string GetExtensionName(WebBrowsers browserType)
        {
            switch (browserType)
            {
                case WebBrowsers.Firefox:
                    {
                        return String.Format("{0}\\metamask-10.8.1-an+fx.xpi",extensionPath);
                    }
                default:
                    {
                        return String.Format("{0}\\extension_4_42_0_0.crx",extensionPath);
                    }
            }
        }
    }
}
