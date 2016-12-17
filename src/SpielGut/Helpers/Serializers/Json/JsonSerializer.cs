using System;
using System.Collections.Generic;
using System.IO;
using JsonNet.PrivateSettersContractResolvers;
using KDG.DataObjectHandler.BaseTypes;
using Newtonsoft.Json;

namespace KDG.DataObjectHandler.Serializers.Json
{
    public class JsonSerializer : ISerializer
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

        private StreamWriter GetWriterStream(Type type)
        {
            var fileStream = new FileStream(this.GetPath(type), FileMode.Create);
            return new StreamWriter(fileStream);
        }

        private StreamReader GetReaderStream(Type type)
        {
            var fileStream = new FileStream(this.GetPath(type), FileMode.OpenOrCreate);
            return new StreamReader(fileStream);
        }


        private SavingObject<T> ReadSavingObjectFromFile<T>()
            where T : DataObject
        {
            SavingObject<T> savingObject;
            using (var reader = this.GetReaderStream(typeof(T)))
            {
                var json = reader.ReadToEnd();
                var settings = new JsonSerializerSettings {ContractResolver = new PrivateSetterContractResolver()};
                savingObject = JsonConvert.DeserializeObject<SavingObject<T>>(json, settings);
            }
            return savingObject ?? new SavingObject<T>();
        }

        private void WriteSavingObjectToFile<T>(SavingObject<T> savingObject)
            where T : DataObject
        {
            using (var writer = this.GetWriterStream(typeof(T)))
            {
                var settings = new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() };
                var json = JsonConvert.SerializeObject(savingObject, settings);
                writer.Write(json);
            }
        }

        public void SaveObject<T>(T objectToSerialize)
          where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            savingObject.ObjectsToSave.RemoveAll(o => o.Id == objectToSerialize.Id);
            savingObject.ObjectsToSave.Add(objectToSerialize);
            this.WriteSavingObjectToFile(savingObject);
        }
        public T LoadObject<T>(Guid id)
            where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            return savingObject.ObjectsToSave.Find(o => o.Id == id);
        }
        public List<T> LoadAllObjects<T>()
            where T : DataObject
        {
            var savingObject = this.ReadSavingObjectFromFile<T>();
            return savingObject.ObjectsToSave;
        }
    }
}
