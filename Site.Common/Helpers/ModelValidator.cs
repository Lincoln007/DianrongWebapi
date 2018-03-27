using System;
using System.Text.RegularExpressions;

namespace Site.Common.Helpers
{
    public static class ModelValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="propName"></param>
        public static void NotNull(this string s, string propName)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new BizException($"{propName}不能为空");
            }
        }
        /// <summary>
        /// 不能为空
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propName"></param>
        /// <param name="fullMsg"></param>
        public static void NotNull(this object obj, string propName = "", string fullMsg = "")
        {
            if (obj == null)
            {
                if (!String.IsNullOrEmpty(fullMsg))
                {
                    throw new BizException(fullMsg);
                }
                throw new BizException(String.Format($"{propName}不能为空"));
            }
        }
        /// <summary>
        /// 字符串相等
        /// </summary>
        /// <param name="actualStr"></param>
        /// <param name="exceptStr"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void ShouldBe(this string actualStr, string exceptStr, string format = "", params string[] args)
        {
            if (exceptStr != actualStr)
            {
                throw new BizException(String.Format(format, args));
            }
        }
        /// <summary>
        /// 不能太长
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="propName"></param>
        public static void NotTooLong(this string s, int length, string propName)
        {
            if (String.IsNullOrEmpty(s))
            {
                return;
            }
            if (s.Length > length)
            {
                throw new BizException(string.Format("字段{0}长度不能超过{1}", propName, length));
            }
        }
        /// <summary>
        /// 应小于
        /// </summary>
        /// <param name="val"></param>
        /// <param name="max"></param>
        /// <param name="propName"></param>
        public static void ShouldLessEqThan(this long val, long max, string propName)
        {
            if (val > max)
            {
                throw new BizException($"{propName}应小于{max}");
            }
        }
        /// <summary>
        /// 枚举必须合法
        /// </summary>
        /// <param name="val"></param>
        /// <param name="propName"></param>
        public static void EnumValueValid(this Enum val, string propName)
        {
            var values = Enum.GetValues(val.GetType());

            // Array.FindIndex(values,0,w=>(short)w==(short)val);
            var find = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (String.Compare(values.GetValue(i).ToString(), Convert.ToString(val), true) == 0)
                {
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                throw new BizException($"{propName}对应的值{val}不合法");
            }
            //    var index = Array.IndexOf(values,val);
        }

        public static void RegexValid(this string val, string regex,string propName)
        {
            if (!Regex.Match(val,regex).Success)
            {
                throw new BizException($"{propName}格式不正确");
            }
        }
    }
}