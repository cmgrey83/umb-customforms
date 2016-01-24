using System;
using Umbraco.Core.Persistence;

namespace CustomForms.Models.Forms
{
    [TableName("OtherForm")]
    public class OtherForm : CustomForm
    {
        public DateTime DateSubmitted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}