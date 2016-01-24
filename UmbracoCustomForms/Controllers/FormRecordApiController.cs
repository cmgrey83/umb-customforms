using CustomForms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace CustomForms.Controllers
{
    [PluginController("CustomForms")]
    public class FormRecordApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<FormRecord> GetAll()
        {


        }

    }