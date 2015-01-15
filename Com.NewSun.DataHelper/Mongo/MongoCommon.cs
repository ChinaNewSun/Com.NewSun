using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.NewSun.DataHelper.Mongo
{
    public class MongoCommon
    {
    }

    public enum QueryType
    {
        And,   //Query.And(Query.EQ("name", "a"), Query.EQ("title", "t"));//同时满足多个条件
        Or,     //Query.Or(Query.EQ("name", "a"), Query.EQ("title", "t"));//满足其中一个条件
        Not,          //Query.Not("name");//元素条件语句
    }

    public enum QueryItemType
    {
        EQ,          //等于
        Exists,      //Query.Exists("type", true);//判断键值是否存在
        GT,           //大于
        GTE,         //大于等于
        In,            //Query.In("name", "a", "b");//包括指定的所有值,可以指定不同类型的条件和值
        LT,            //小于
        LTE,          //小于等于<=
        //Mod,        //Query.Mod("value", 3, 1);//将查询值除以第一个给定值,若余数等于第二个给定值则返回该结果
        NE,           //不等于
        Nor,          //Query.Nor(Array);//不包括数组中的值
        NotIn,       //Query.NotIn("name", "a", 2);//返回与数组中所有条件都不匹配的文档
        Size,          //Query.Size("name", 2);//给定键的长度
        //Type,         //Query.Type("_id", BsonType.ObjectId );//给定键的类型
        //Where,      //Query.Where(BsonJavaScript);//执行JavaScript
        Matches,   //Query.Matches("Title",str);//模糊查询 相当于sql中like -- str可包含正则表达式
    }

    public class QueryPropertyItem
    {
        public string PropertyName { get; set; }
        public QueryItemType OpType { get; set; }
        public object PropertyValue { get; set; }
        public QueryPropertyItem(string propertyName, object propertyValue, QueryItemType type)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            OpType = type;
        }
    }
}
