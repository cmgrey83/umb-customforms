
   ______           __                     ____                         
  / ____/_  _______/ /_____  ____ ___     / __/___  _________ ___  _____
 / /   / / / / ___/ __/ __ \/ __ `__ \   / /_/ __ \/ ___/ __ `__ \/ ___/
/ /___/ /_/ (__  ) /_/ /_/ / / / / / /  / __/ /_/ / /  / / / / / (__  ) 
\____/\__,_/____/\__/\____/_/ /_/ /_/  /_/  \____/_/  /_/ /_/ /_/____/  
                                                                        


Setup
------

1. First time use setup:

		-	Copy the custom forms project and files into the webroot of your umbraco application. 
		-	Add the project to your main umbraco solution.
		-	Add a reference to the CustomForms project from your main solution.

2. Create a model for your form in /Models/Forms/
		-	Use the following attribute on the class to define the database table name:     

			[TableName("Your SQL table name here")]

		-	Note: There is no need to add an ID column, this is handled automatically

3. Add your form details to the web config:
	-	name MUST be unique for each form
	-   displayname is used in umbraco backoffice

	Example:
	--------

  <CustomForms>
    <Forms>
      <Form name="ContactForm" displayname="Contact form" />
      <Form name="OtherForm" displayname="Other form" />
    </Forms>
  </CustomForms>

  ALSO: Make sure the section is registered in the web.config with the following in the <configSections> section:
  
  <section name="CustomForms" type="CustomForms.Setup.CustomFormsConfig" />

4. Add your form into /Setup/CustomFormsSetup.cs using the table name you used in the model definition in step 1, example:

            if (!db.TableExist("The table name you used in your model definition"))
            {
                db.CreateTable<YourModelClassName>(false);
            }

   Note: You may also wish to add test data records here.

5. Add your form into /Controllers/CustomFormApiController.cs in the following way, 
   ensuring you use the form name you used in the web.config as the case within the switch statement:

                case "Your form name as defined in the web.config":
                    return repo.GetAll<YourModelClassName>();

   This ApiController is used by the umbraco custom section and is NOT meant for use on the website front end - an umbraco 
   surface controller should be used for that (explained later).

6. Finally, build your solution. Good job, now you have your form data structure and db tables created, and the form will appear 
   in the custom forms application in umbraco. If you don't see this application, make sure it is enabled against your user in umbraco.


NOTE: There is are example forms in the code (ContactForm and OtherForm) - however the DB setup is commented out to prevent the database tables
being created in your project. If you want to view the working examples, uncomment the setup code in the CustomFormsSetup.cs file. OTherwise, you
will probably want to remove the examples / replace with your own implementations.

Quick setup checklist:
----------------------

1. Create model class with TableName petapoco attribute
2. Add form details to the web.config
3. Add form to setup file (/Setup/CustomFormsSetup.cs) to create database table
4. Add form into ApiController (/Controllers/CustomFormApiController.cs)
5. Build and run the site


-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------

WORKING WITH THE FORM:
----------------------

To actually use your form on the website, you will need to create an umbraco Surface Controller and a partial view to display it.

To work with the form, use the CustomFormRepo (respository) within your controller(s).

Submitting data:
----------------

[HttpPost]
public ActionResult SubmitForm(YourFormModel form)
{
    form.DateSubmitted = DateTime.Now;

    var repo = new CustomFormRepo();
    repo.Insert(form);
    return CurrentUmbracoPage();
}


Retrieving data (note the model needs to be passed as the generic type into the GetAll method):
-----------------------------------------------------------------------------------------------

public IList<YourFormModel> GetAll()
{
    var repo = new CustomFormRepo();
    return repo.GetAll<YourFormModel>();
}



Example surface controller:
---------------------------

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
    }
}

All that's left is to create a surface controller your form's partial view and do all the usual guff for an MVC form. It's recommended that you keep this within
the CustomForms project, seperate from the main umbraco project.
Here's an example partial view for your form (note that this does not include validation, look up umbraco form validation for more details):

@model CustomForms.Models.Forms.ContactForm
@using CustomForms.Repositories;
@using CustomForms.Models.Forms;

@{
     var repo = new CustomFormRepo();
}

@using(Html.BeginUmbracoForm("SubmitForm", "ContactFormSurface", null, new { @class="contact-form" }))
{
    @Html.LabelFor(f => f.Name);
    @Html.TextBoxFor(f => f.Name)
    @Html.LabelFor(f => f.Email);
    @Html.TextBoxFor(f => f.Email);
    @Html.LabelFor(f => f.EnquiryType);
    @Html.TextBoxFor(f => f.EnquiryType);
    @Html.LabelFor(f => f.Enquiry);
    @Html.TextBoxFor(f => f.Enquiry);
    <input type="submit" value="Submit" />
}


Disclaimer: 
-----------
The angular implementation for the backoffice is hacked together and most likely horrible! This is my first go at it so please forgive me :D
The goal was to create a basic means of easily adding new forms to umbraco whose data can be viewed via a very simple admin screen.