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
using Newtonsoft.Json;

namespace Helpers.Serializers
{
    public class JsonSerializer
    {

        private readonly string root;

        private readonly Newtonsoft.Json.JsonSerializer serializer;

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
            this.serializer = new Newtonsoft.Json.JsonSerializer();
        }

        private string GetFileName(Type type)
        {
            return type.Name + ".json";
        }

        private string GetPath(Type type)
        {
            return this.Root + "\\" + this.GetFileName(type);
        }

        private FileStream GetFileStream(Type type)
        {
            return new FileStream(this.GetPath(type), FileMode.OpenOrCreate);
        }

        private SavingObject<T> ReadSavingObjectFromFile<T>()
            where T : DataObject
        {
            SavingObject<T> savingObject;
            using (var stream = this.GetFileStream(typeof(T)))
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                savingObject = this.serializer.Deserialize<SavingObject<T>>(reader);
            }
            return savingObject ?? new SavingObject<T>();
        }

        private void WriteSavingObjectToFile<T>(SavingObject<T> savingObject)
            where T : DataObject
        {
            using (var stream = this.GetFileStream(typeof(T)))
            using (var writer = new JsonTextWriter(new StreamWriter(stream)))
            {
                this.serializer.Serialize(writer, savingObject);
            }
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
