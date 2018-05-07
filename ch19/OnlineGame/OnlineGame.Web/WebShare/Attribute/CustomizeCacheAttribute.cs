
using System.Web.Mvc;
using System.Web.Configuration;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class CustomizeCacheAttribute : OutputCacheAttribute
    {
        public CustomizeCacheAttribute(string cacheProfileName)
        {
            OutputCacheSettingsSection cacheSettings =
                (OutputCacheSettingsSection)WebConfigurationManager
                .GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile cacheProfile = cacheSettings.OutputCacheProfiles[cacheProfileName];
            Duration = cacheProfile.Duration;
            VaryByParam = cacheProfile.VaryByParam;
            VaryByCustom = cacheProfile.VaryByCustom;
        }
    }
}
/*
In Web.config
//<system.web>
//    <caching>
//        <outputCacheSettings>
//        <outputCacheProfiles>
//            <clear/>
//            <add name="outputCacheProfile1" duration="60" varyByParam="none"/>
//        </outputCacheProfiles>
//        </outputCacheSettings>
//    </caching>
//    <customErrors mode="On">
//        <error statusCode="401" redirect="Error/UnauthorizedError" />
//        <error statusCode="404" redirect="Error/NotFound" />
//        <error statusCode="500" redirect="Error/InternalServerError" />
//    </customErrors>
//    <globalization culture="en-au" />
//    <compilation debug="true" targetFramework="4.6.1" />
//    <httpRuntime targetFramework="4.6.1" />
//</system.web>
*/
