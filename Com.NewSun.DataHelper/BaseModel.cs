using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;

namespace Com.NewSun.DataHelper
{
    public abstract class BaseModel
    {
        public ObjectId? _id;
        [Id]
        public Guid ID { get; set; }
        [Column]
        public Guid Creator { get; set; }
        [Column]
        public DateTime? Created { get; set; }
        [Column]
        public Guid Modifier { get; set; }
        [Column]
        public DateTime? Modified { get; set; }
    }
}
