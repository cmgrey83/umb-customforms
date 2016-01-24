
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace CustomForms.Models.Forms
{
    [PrimaryKey("ID", autoIncrement = true)]
    public abstract class CustomForm
    {
        // Base class - Do not remove
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int ID { get; set; }
    }
}