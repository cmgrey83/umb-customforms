using CustomForms.Models.Forms;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CustomForms.Repositories
{
    
    public class ContactFormRepo
    {
        private readonly UmbracoDatabase _db;

        public ContactFormRepo()
        {
            _db = ApplicationContext.Current.DatabaseContext.Database;
        }

        public IList<ContactForm> GetAll()
        {
            return _db.Fetch<ContactForm>("SELECT * FROM ContactForm");
        }

        public ContactForm GetById(int id)
        {
            return _db.Fetch<ContactForm>(string.Format("SELECT * FROM ContactForm WHERE id = {0}", id)).FirstOrDefault();
        }

        public void Insert(ContactForm form)
        {
            _db.Insert(form);
        }

        public void Update(ContactForm form)
        {
            _db.Update(form);
        }
    }
}