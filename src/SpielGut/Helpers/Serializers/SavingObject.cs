using System.Collections.Generic;
using KDG.DataObjectHandler.BaseTypes;

namespace KDG.DataObjectHandler.Serializers
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
