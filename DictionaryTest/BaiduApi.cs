using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace DictionaryTest
{
    public class TranslationResult
    {
        public string Error_code { get; set; }
        public string Error_msg { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Query { get; set; }
        public List<Translation> Trans_result { get; set; }
    }
    public class Translation:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string dst;
        public string Src { get; set; }
        public string Dst
        {
            get
            {
                return dst;
            }
            set
            {
               dst = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Dst"));
                }
            }
        }
        
    }
    public class BaiduApi
    {
        public  string getMd5(string sign)
        {
            var md5 = new MD5CryptoServiceProvider();
            var result = Encoding.UTF8.GetBytes(sign);
            var output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "").ToLower();
        }
        public TranslationResult GetTranslationFromBaiduFanyi(string q, Language from = Language.auto, Language to = Language.auto)
        {
            if (!string.IsNullOrEmpty(q))
            {
                string appid = "20170710000063945";
                string salt = "12345";
                string key = "scPOdrnw4olkt164KDOo";
                string sign = getMd5(appid + q + salt + key);
                string jsonResult = string.Empty;
                string url = string.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q=" + q + "&from=" + from + "&to=" + to + "&appid=20170710000063945&salt=12345&sign=" + sign + "");
                WebClient wc = new WebClient();
                try
                {
                    jsonResult = wc.DownloadString(url);
                }
                catch (Exception e)
                {
                    jsonResult = string.Empty;
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                TranslationResult ret = jss.Deserialize<TranslationResult>(jsonResult);
                return ret;
            }
            else
            {
                return null;
            }
        }
    }
    public enum Language
    {
        auto = 0,
        zh = 1,
        jp = 2,
        en = 3,
        kor = 4,
        spa = 5,
        kfa = 6,
        th = 7,
        ara = 8,
        ru = 9,
        pt = 10,
        yue = 11,
        wyw = 12,
        de = 13,
        nl = 14,
        it = 15,
        el = 16
    }
}
