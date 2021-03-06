﻿using System;
using Newtonsoft.Json;

namespace KDG.DataObjectHandler.BaseTypes
{
    public abstract class DataObject
    {
        public Guid Id { get; private set; }

        public DateTime? ValidTo { get; private set; }

        [JsonIgnore]
        public bool IsValid => this.ValidTo == null || this.ValidTo > DateTime.Now;

        protected DataObject()
        {
            this.Id = Guid.NewGuid();
        }

        public void Terminate()
        {
            this.ValidTo = DateTime.Now;
        }
    }
}