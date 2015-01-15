using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.NewSun.StockAnalysis.WinService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StockMethod sm = new StockMethod();
            //string tmpValue = sm.GetHttpHtml(ConfigurationManager.AppSettings["StockCodeListPath"]);
            sm.StockInfoListManage(ConfigurationManager.AppSettings["StockCodeListPath"]);
            //string result = sm.AnalysisHtml(tmpValue);
        }
    }
}
