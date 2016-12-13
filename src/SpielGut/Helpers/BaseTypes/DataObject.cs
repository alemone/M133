using System;

namespace Helpers.BaseTypes
{
    public abstract class DataObject
    {
        public Guid Id { get; set; }

        public bool IsActive { get; set; } = true;

        protected DataObject(Guid id)
        {
            this.Id = id;
        }

        protected DataObject()
        {
            
        }
    }
}