﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.NewSun.DataHelper
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IdAttribute : BaseAttribute
    {
        /// <summary>
        /// 是否为自动主键
        /// </summary>
        public bool CheckAutoId { get; set; }

        public IdAttribute()
        {
            this.CheckAutoId = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkAutoId">是否为自动主键</param>
        public IdAttribute(bool checkAutoId)
        {
            this.CheckAutoId = checkAutoId;
        }
    }
}
