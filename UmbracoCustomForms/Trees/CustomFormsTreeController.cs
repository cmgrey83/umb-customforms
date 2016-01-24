using System.Net.Http.Formatting;
using umbraco.BusinessLogic.Actions;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace CustomForms.Controllers
{
    [PluginController("CustomForms")]
    [Tree("CustomForms", "CustomFormsTree", "Custom Forms", iconClosed: "icon-doc")]
    public class CustomFormsTreeController : TreeController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            var nodes = new TreeNodeCollection();

            // [Custom form setup]: Put your forms in web.config - the name must be unique
            var config = CustomFormsConfig.GetConfig();
            foreach (Form form in config.Forms)
            {           
                var formNode = this.CreateTreeNode(form.Name, "-1", queryStrings, form.DisplayName, "icon-truck", false);

                nodes.Add(formNode);
            }

            return nodes;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();
            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions              

                return menu;
            }
            return menu;
        }
    }
}