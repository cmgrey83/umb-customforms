using System.Configuration;

namespace CustomForms
{
    public class CustomFormsConfig
            : ConfigurationSection
    {

        public static CustomFormsConfig GetConfig()
        {
            return (CustomFormsConfig)System.Configuration.ConfigurationManager.GetSection("CustomForms") ?? new CustomFormsConfig();
        }

        [System.Configuration.ConfigurationProperty("Forms")]
        [ConfigurationCollection(typeof(Forms), AddItemName = "Form")]
        public Forms Forms
        {
            get
            {
                object o = this["Forms"];
                return o as Forms;
            }
        }

    }

    public class Form : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        [ConfigurationProperty("displayname", IsRequired = true)]
        public string DisplayName
        {
            get
            {
                return this["displayname"] as string;
            }
        }
    }

    public class Forms
        : ConfigurationElementCollection
    {
        public Form this[int index]
        {
            get
            {
                return base.BaseGet(index) as Form;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public new Form this[string responseString]
        {
            get { return (Form)BaseGet(responseString); }
            set
            {
                if (BaseGet(responseString) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(responseString)));
                }
                BaseAdd(value);
            }
        }

        protected override System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new Form();
        }

        protected override object GetElementKey(System.Configuration.ConfigurationElement element)
        {
            return ((Form)element).Name;
        }
    }
}