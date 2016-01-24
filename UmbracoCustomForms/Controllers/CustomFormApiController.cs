using CustomForms.Models.Forms;
using CustomForms.Repositories;
using System.Collections.Generic;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace CustomForms.Controllers
{
    [PluginController("CustomForms")]
    public class CustomFormApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<CustomForm> GetAll(string formName)
        {
            var repo = new CustomFormRepo();

            // [Custom form setup]: Add forms in here
            switch(formName)
            {
                case "OtherForm":
                    return repo.GetAll<OtherForm>();
                case "ContactForm":
                default:
                    return repo.GetAll<ContactForm>();
            }         
        }
    }
}