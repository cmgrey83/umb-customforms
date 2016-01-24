using CustomForms.Models.Forms;
using CustomForms.Repositories;
using System;
using Umbraco.Core.Persistence;

namespace CustomForms.Setup
{
    public static class CustomFormsSetup
    {
        public static void SetupForms(Database db)
        {
            //[Custom form setup]: Create form tables from model
            //if (!db.TableExist("ContactForm"))
            //{
            //    db.CreateTable<ContactForm>(true);
            //    CustomFormRepo repo = new CustomFormRepo();

            //    ContactForm record = new ContactForm(){
            //        DateSubmitted = DateTime.Now.AddHours(-5),
            //        Name = "Joe Bloggs",
            //        Email = "j.bloggs@gmail.com",
            //        EnquiryType = "Technical support",
            //        Enquiry = "My computer is a bit broken, please help"
            //    };
            //    repo.Insert(record);

            //    record = new ContactForm()
            //    {
            //        DateSubmitted = DateTime.Now.AddHours(-2),
            //        Name = "Joe Bloggs",
            //        Email = "j.bloggs@gmail.com",
            //        EnquiryType = "Technical support",
            //        Enquiry = "My computer is on fire now *sadface*"
            //    };
            //    repo.Insert(record);
            //}
            //if (!db.TableExist("OtherForm"))
            //{
            //    db.CreateTable<OtherForm>(false);
            //}
        }
    }
}