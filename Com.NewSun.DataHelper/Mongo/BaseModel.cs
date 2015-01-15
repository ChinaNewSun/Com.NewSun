using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace Com.NewSun.DataHelper.Mongo
{
    public abstract class BaseModel
    {
        public ObjectId? _id;
        public Guid ID { get; set; }
        public DateTime? created;
    }
}
