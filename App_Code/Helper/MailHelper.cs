using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Configuration;

namespace WebFormIdentity.Helper
{

    public class MailHelper
    {
        public static bool ValidSmtpSetting()
        {
            System.Configuration.Configuration config =
            WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

            try
            {
                //Log.d("SMTP 主機: " + settings.Smtp.Network.Host);
                if (settings != null && UriHostNameType.Unknown == Uri.CheckHostName(settings.Smtp.Network.Host)) return false;
                //Log.d("SMTP 埠號: " + settings.Smtp.Network.Port);
                //Log.d("SMTP 帳號: " + settings.Smtp.Network.UserName);
                if (settings != null && string.IsNullOrWhiteSpace(settings.Smtp.Network.UserName)) return false;
                //Log.d("SMTP 密碼: " + settings.Smtp.Network.Password);
                if (settings != null && string.IsNullOrWhiteSpace(settings.Smtp.Network.Password)) return false;
            }
            catch (ConfigurationErrorsException ex)
            {
                throw ex;
            }
            return true;
        }
    }
}