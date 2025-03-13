using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoParkService.Entity.Common.Model;

public class AppSetting
{
    public static string ConnectionString { get; set; }

    public static string ReCaptchaSiteKey { get; set; }

    public static string ReCaptchaSecretKey { get; set; }

    public static string ReCaptchaUrl { get; set; }

    public SendGridSetting sendGridSettings { get; set; }
    public ReCaptchaSetting ReCaptchaSettings { get; set; }
   // public JwtSettings JwtSettings { get; set; }
    public bool EmailValidationEnabled { get; set; }
    public StripeSettings StripeSettings { get; set; }
}
public class SendGridSetting {
    public static string EmailApiKey { get; set; }

    public static string ValidationApiKey { get; set; }

    public static string FromEmail { get; set; }
}
public class ReCaptchaSetting
{
    public static string SiteKey { get; set; }
    public static string SecretKey { get; set; }
    public static string Url { get; set; }
}
public class StripeSettings
{
    public string SecretKey { get; set; }
    public string PublishableKey { get; set; }
}