/*
 Producer By QQ:279202647
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace SelectConverter
{
    /// <summary>
    /// 字符串选择转换器
    /// </summary>
    public class SelectStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value;
            }

            //获取绑定的值
            string key;

            if (value == null)
            {
                key = "null";
            }
            else
            {
                key = value.ToString().ToLower();
            }
            //解析可解析的值选项
            string[] arr = parameter.ToString().Split('|');

            Dictionary<string, string> dic = new Dictionary<string, string>();

            //获取键值对
            foreach (var str in arr)
            {
                string[] drr = str.Split(new string[] { "----" }, StringSplitOptions.None);
                dic.Add(drr[0].ToLower(), drr[1]);
            }
            //检索值
            if (dic.ContainsKey(key))
            {
                //判断是否隐藏
                if (dic[key] == "Collapsed")
                    return System.Windows.Visibility.Collapsed;
                //判断是否显示
                if (dic[key] == "Visible")
                    return System.Windows.Visibility.Visible;

                //否则返回对应的值
                return dic[key];
            }
            else
            //判断默认值
                if (dic.FirstOrDefault().Value.ToString() == "Visible")
                    return System.Windows.Visibility.Collapsed;
            else
            //判断默认值
                if (dic.FirstOrDefault().Value.ToString() == "Collapsed")
                    return System.Windows.Visibility.Visible;

            return value;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value.ToString();
            return value;
        }

    }
}
