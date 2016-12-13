using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Helpers.BaseTypes;
using Microsoft.SqlServer.Server;

namespace Helpers.Serializers
{
    public class JsonSerializer
    {

        private readonly string root;

        private string Root
        {
            get
            {
                if (!Directory.Exists(this.root))
                {
                    Directory.CreateDirectory(this.root);
                }
                return this.root;
            }
        }

        public JsonSerializer(string rootPath)
        {
            this.root = rootPath;
        }

        private string GetFileName(Type type)
        {
            return type.Name + ".json";
        }

        private string GetPath(Type type)
        {
            var path = this.Root + "\\" + this.GetFileName(type);
            if (!File.Exists(path))
            {
                this.WriteFile(string.Empty, path);
            }
            return path;
        }

        private void WriteFile(string content, string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.Write(content);
            }
        }

        private string ReadFile(string path)
        {
            string jsonObject;
            using (var reader = new StreamReader(path))
            {
                jsonObject = reader.ReadToEnd();
            }
            return jsonObject;
        }

        private SavingObject<T> ReadSavingObjectFromFile<T>()
            where T : DataObject
        {
            var path = this.GetPath(typeof(T));
            var jsonObject = this.ReadFile(path);
            var savingObject = new JavaScriptSerializer().Deserialize<SavingObject<T>>(jsonObject);
            return savingObject ?? new SavingObject<T>();
        }

        private void WriteSavingObjectToFile<T>(SavingObject<T> savingObject)
            where T : DataObject
        {
            var path = this.GetPath(typeof(T));
            var jsonObject = new JavaScriptSerializer().Serialize(savingObject);
            this.WriteFile(jsonObject, path);
        }

        public void SaveObjectToFile<T>(T objectToSerialize)
          where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            savingObject.ObjectsToSave.RemoveAll(o => o.Id == objectToSerialize.Id);
            savingObject.ObjectsToSave.Add(objectToSerialize);
            this.WriteSavingObjectToFile(savingObject);
        }
        public T LoadObjectFromFile<T>(Guid id)
            where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            return savingObject.ObjectsToSave.Find(o => o.Id == id);
        }
        public List<T> LoadAllObjectsFromFile<T>()
            where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            return savingObject.ObjectsToSave;
        }
    }
}
