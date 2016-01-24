using CustomForms.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace CustomForms.Repositories
{
    public class CustomFormRepo
    {
        private readonly UmbracoDatabase _db;

        public CustomFormRepo()
        {
            _db = ApplicationContext.Current.DatabaseContext.Database;
        }

        private string GetTableName<T>()
        {
            Attribute attr = Attribute.GetCustomAttribute(typeof(T), typeof(TableNameAttribute));
            TableNameAttribute tn = (TableNameAttribute)attr;
            return tn.Value;
        }

        public virtual IList<T> GetAll<T>() where T : CustomForm
        {
            string tableName = GetTableName<T>();
            return _db.Fetch<T>(string.Format("SELECT * FROM {0}", tableName));
        }

        public virtual IList<T> GetAll<T>(string columns) where T : CustomForm
        {
            string tableName = GetTableName<T>();
            return _db.Fetch<T>(string.Format("SELECT {0} FROM {1}", columns, tableName));
        }

        public virtual T GetById<T>(int id) where T : CustomForm
        {
            string tableName = GetTableName<T>();
            return _db.Fetch<T>(string.Format("SELECT * FROM {0} WHERE id = {1}", tableName, id)).FirstOrDefault();
        }

        public virtual T GetById<T>(int id, string columns) where T : CustomForm
        {
            string tableName = GetTableName<T>();
            return _db.Fetch<T>(string.Format("SELECT {0} FROM {1} WHERE id = {2}", columns, tableName, id)).FirstOrDefault();
        }

        public void Insert<T>(T form) where T : CustomForm
        {
            _db.Insert(form);
        }

        public void Update<T>(T form) where T : CustomForm
        {
            _db.Update(form);
        }
    }
}