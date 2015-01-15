using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Com.NewSun.DataHelper;

namespace Com.NewSun.StockAnalysis.Model
{
    public class StockInfo : BaseModel
    {
        [Column]
        public string Name { get; set; }
        [Column]
        public string Code { get; set; }
        [Column]
        public int Type { get; set; }
        [Column]
        public int Status { get; set; }
    }
}
