using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.NewSun.DataHelper
{
    public class BaseAttribute : Attribute
    {
        /// <summary>
        /// 别名，对应数据里面的名字
        /// </summary>
        public string Name { get; set; }
    }
}
