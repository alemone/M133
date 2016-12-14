using System.Collections.Generic;
using Helpers.BaseTypes;

namespace Helpers.Serializers
{
    public class SavingObject<T>
        where T : DataObject
    {
        public List<T> ObjectsToSave { get; set; }
        public SavingObject()
        {
            this.ObjectsToSave = new List<T>();
        }

        internal SavingObject(List<T> objectsToSave)
        {
            this.ObjectsToSave = objectsToSave;
        }
    }
}
