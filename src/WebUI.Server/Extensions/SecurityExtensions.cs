using DataAccess.Data;
using Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using WebUI.Server.Components.Account;

namespace WebUI.Server.Extensions;

public static class SecurityExtensions
{
    public static void AddSecurity(this IServiceCollection services)
    {
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

        services.AddIdentityCore<DbUser>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;

            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedAccount = true;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<EcommerceContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        services.AddTransient<UserManager<DbUser>>();
        services.AddTransient<SignInManager<DbUser>>();
        services.AddSingleton<IEmailSender<DbUser>, IdentityNoOpEmailSender>();
        services.AddAuthorization();
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();
    }

    public static void UseSecurity(this WebApplication app)
    {
        app.UseReferrerPolicy(options => options.SameOrigin());
        app.UseXfo(options => options.Deny());
        app.UseXXssProtection(options => options.EnabledWithBlockMode());
        app.UseCspReportOnly(options => options
            .BlockAllMixedContent()
            .StyleSources(s => s.Self().UnsafeInline().CustomSources("https://fonts.googleapis.com"))
            .FontSources(s => s.Self().CustomSources("https://fonts.gstatic.com"))
            .FormActions(s => s.Self())
            .FrameAncestors(s => s.Self())
            .ImageSources(s => s.Self().CustomSources("blob:", "https://upload.wikimedia.org", "https://en.wikipedia.org", "data:"))
            .ScriptSources(s => s.Self().CustomSources("https://localhost:55150").UnsafeEval())
        );

        app.Use(async (context, next) =>
        {
            #pragma warning disable ASP0019 // Suggest using IHeaderDictionary.Append or the indexer
            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
            #pragma warning restore ASP0019 // Suggest using IHeaderDictionary.Append or the indexer
            await next.Invoke();
        });

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseAntiforgery();
    }
}
