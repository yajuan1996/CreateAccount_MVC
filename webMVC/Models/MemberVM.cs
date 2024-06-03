using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webMVC.Models
{
    public class MemberVM
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
    }
}