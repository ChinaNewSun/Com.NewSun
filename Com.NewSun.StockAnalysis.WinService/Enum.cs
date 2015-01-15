using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.NewSun.Common;

namespace Com.NewSun.StockAnalysis.WinService
{
    public enum StockType
    { 
        SH,
        HS,
        JJ
    }

    public enum StockStatus
    { 
        New,
        Comply,
        UnComply,
        Waiting
    }
}
