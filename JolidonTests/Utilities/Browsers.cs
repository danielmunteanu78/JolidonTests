using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace JolidonTests.Utilities
{
    public class Browsers
    {
        public static IWebDriver GetDriver(WebBrowsers browserType)
        {
            switch (browserType)
            {
                case WebBrowsers.Chrome:
                    {
                        var options = new ChromeOptions();
                        if (FrameworkConstants.startMaximized)
                        {
                            options.AddArgument("--start-maximized");
                        }                        

                        if (FrameworkConstants.startHeadless)
                        {
                            options.AddArgument("headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            options.AddArgument("ignore-certificate-errors");
                        }                        
                        var proxy = new Proxy
                        {
                            HttpProxy = FrameworkConstants.browserProxy,
                            IsAutoDetect = false
                        };

                        if (FrameworkConstants.useProxy)
                        {
                            options.Proxy = proxy;
                        }
                        //options.AddExtension("C:\\Users\\alex\\Downloads\\extension_4_42_0_0.crx");
                        return new ChromeDriver(options);
                    }

                case WebBrowsers.Firefox:
                    {
                        var firefoxOptions = new FirefoxOptions();
                        List<string> optionList = new List<string>();
                      
                        if (FrameworkConstants.startHeadless)
                        {
                            optionList.Add("--headless");
                        }
                        if (FrameworkConstants.ignoreCertErr)
                        {
                            optionList.Add("--ignore-certificate-errors");
                        }
                        firefoxOptions.AddArguments(optionList);
                        FirefoxProfile fProfile = new FirefoxProfile();                        
                        
                        if (FrameworkConstants.startWithExtension)
                        {
                            fProfile.AddExtension(FrameworkConstants.GetExtensionName(browserType));
                        }
                        firefoxOptions.Profile = fProfile;
                        return new FirefoxDriver(firefoxOptions);   
                    }

                case WebBrowsers.Edge:
                    {
                        var edgeOptions = new EdgeOptions();
                        //edgeOptions.AddExtension("C:\\Users\\alex\\Downloads\\extension_4_42_0_0.crx");
                        //edgeOptions.AddArguments("args", "['--start-maximized', '--headless']");
                        if (FrameworkConstants.startMaximized)
                        {
                            edgeOptions.AddArgument("--start-maximized");
                        }
                        if (FrameworkConstants.startHeadless)
                        {
                            edgeOptions.AddArgument("--headless");
                        }
                        if (FrameworkConstants.startWithExtension)
                        {
                            edgeOptions.AddExtension(FrameworkConstants.GetExtensionName(browserType));
                        }
                                                
                        return new EdgeDriver(edgeOptions);
                    }
                default:
                    {
                        throw new BrowserTypeException(browserType.ToString());
                    }
            }
        }

    }
    public enum WebBrowsers
    {
        Chrome,
        Firefox,
        Edge
    }
}
