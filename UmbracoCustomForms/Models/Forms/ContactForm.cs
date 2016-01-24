using System;
using Umbraco.Core.Persistence;

namespace CustomForms.Models.Forms
{
    [TableName("ContactForm")]
    public class ContactForm : CustomForm
    {
        public DateTime DateSubmitted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Enquiry { get; set; }
        public string EnquiryType { get; set; }
    }
}