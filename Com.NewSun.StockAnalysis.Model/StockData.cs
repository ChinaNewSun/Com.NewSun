using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.NewSun.DataHelper;

namespace Com.NewSun.StockAnalysis.Model
{
    public class StockData : BaseModel
    {
        [Column]
        public Guid StockID { get; set; }
        [Column]
        public decimal TodayOpenValue { get; set; }
        [Column]
        public decimal YesterdayOpenValue { get; set; }
        [Column]
        public decimal CurrentValue { get; set; }
        [Column]
        public decimal TodayMaxValue { get; set; }
        [Column]
        public decimal TodayMinValue { get; set; }
        [Column]
        public decimal Turnover { get; set; }
        [Column]
        public decimal TurnoverValue { get; set; }
        [Column]
        public DateTime DateTime { get; set; }
    }
}
