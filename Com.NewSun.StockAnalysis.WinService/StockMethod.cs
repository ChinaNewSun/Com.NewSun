using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.NewSun.Common;
using Com.NewSun.DataHelper;
using Com.NewSun.StockAnalysis.Model;
using System.Text.RegularExpressions;
using System.Data;

namespace Com.NewSun.StockAnalysis.WinService
{
    public class StockMethod
    {

        public readonly string analysisStockListRegularExpression = "<li><a href=\\\"http://bbs\\.10jqka\\.com\\.cn\\/[sz|sh|fu][\\s\\S]*?>[\\s\\S]*?<\\/a><\\/li>";

        #region StockList Option Methods

        public void StockInfoListManage(string tmpUrl)
        {
            var dbStockInfoList = GetStockList();
            var webStockInfoList = AnalysisStcokListItem(GetStockListHttpHtml(tmpUrl));
           //pare the two projects, the new project in the database
            var newStockInfoList = CompareStockInfo(webStockInfoList, dbStockInfoList);

            if (newStockInfoList.Count > 0)
            {
                using (var db = Execute.CreateDbBase())
                {
                    if (newStockInfoList.Count > 0)
                    {
                        IDbTransaction tran = db.DbTransaction;
                        if (db.InsertBatch<StockInfo>(newStockInfoList, tran))
                            tran.Commit();
                        else
                            tran.Rollback();
                    }
                }
            }
        }
        public List<StockInfo> CompareStockInfo(List<StockInfo> source, List<StockInfo> target)
        {
            List<StockInfo> result = new List<StockInfo>();

            foreach (StockInfo bean in source)
            {
                if (!target.Any(t => t.Code == bean.Code))
                    result.Add(bean);
            }
            return result;
        }
        public string GetStockListHttpHtml(string url)
        {
            return HttpClientHelper.GetResponse(url,true);
        }
        public List<StockInfo> AnalysisStcokListItem(string tmpHtml)
        {
            List<StockInfo> result = new List<StockInfo>();
            Regex regex = new Regex(analysisStockListRegularExpression);
            var items = regex.Matches(tmpHtml);
            foreach (Match item in items)
            {
                string tmpStr = item.Value;

                string tmpCode = tmpStr.Substring(tmpStr.IndexOf(",") + 1, 6);
                string tmpName = tmpStr.Substring(tmpStr.IndexOf("title=\"") + 7, tmpStr.IndexOf("\">") - (tmpStr.IndexOf("title=\"") + 7));
                string tmpType = tmpStr.Substring(tmpStr.IndexOf(".com.cn/") + 8, 2);
                tmpType = tmpType.ToLower();
                StockInfo bean = new StockInfo();
                bean.ID = Guid.NewGuid();
                bean.Name = tmpName;
                bean.Code = tmpCode;
                bean.Type = tmpType == "sh" ? (int)StockType.SH : tmpType == "hs" ? (int)StockType.HS : (int)StockType.JJ;
                bean.Status = (int)StockStatus.New;
                result.Add(bean);
            }
            return result;
        }
        public List<StockInfo> GetStockList()
        {
            //Perform database read operations here
            List<StockInfo> result = new List<StockInfo>();
            using (var db = Execute.CreateDbBase())
            {
                var source = db.Query<StockInfo>();
                if (source.Count > 0)
                    result.AddRange(source);
            }
            return result;
        }

        #endregion

        #region StockData Option Methods
        public StockData GetStockData(string url)
        {
            return null;
        }

        public List<StockData> GetStockHistoryData(string url)
        {
            return null;
        }
        #endregion
    }
}
