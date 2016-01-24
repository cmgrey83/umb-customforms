using CustomForms.Models.Forms;
using CustomForms.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace CustomForms.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult SubmitForm(ContactForm form)
        {
            form.DateSubmitted = DateTime.Now;

            var repo = new CustomFormRepo();
            repo.Insert(form);
            return CurrentUmbracoPage();
        }

        public IList<ContactForm> GetAll()
        {
            var repo = new CustomFormRepo();
            return repo.GetAll<ContactForm>();
        }
    }
}