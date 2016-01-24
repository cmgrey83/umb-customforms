using CustomForms.Setup;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace UmbracoSandbox.App_Plugins.CustomForms
{
    public class RegisterEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            UmbracoDatabase db = applicationContext.DatabaseContext.Database;
            CustomFormsSetup.SetupForms(db);
        }
    }
}