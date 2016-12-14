using System;
using System.Collections.Generic;
using KDG.DataObjectHandler.BaseTypes;

namespace KDG.DataObjectHandler.Serializers
{
    public interface ISerializer
    {
        void SaveObject<T>(T objectToSerialize)
            where T : DataObject;

        T LoadObject<T>(Guid id)
            where T : DataObject;

        List<T> LoadAllObjects<T>()
            where T : DataObject;
    }
}
