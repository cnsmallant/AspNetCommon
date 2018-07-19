using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


/// <summary>
/// 生成操作日志类
/// </summary>
public class Logs
{
    /// <summary>
    /// 写入日志
    /// </summary>
    /// <param name="time">操作时间</param>
    /// <param name="strMessage">操作内容</param>
    /// <param name="userpath">自定义路径名称（例如：logsfile）</param>
    public static void SetLog(DateTime time, string strMessage, string userpath)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"\logs\" + userpath + @"\" + time.Year.ToString() + @"\" + time.Month.ToString() + @"\";
        string fileName = time.ToString("yyyyMMdd") + ".log";
        string logpath = path + fileName;
        FileStream file;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists(logpath))
        {
            file = File.Create(logpath);
        }
        else
        {
            file = new FileStream(logpath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        }
        StringBuilder str = new StringBuilder();
        str.Append("IP地址：" + GetHostAddress() + "\r\n");
        str.Append("记录时间：" + time.ToString() + "\r\n");
        str.Append("操作信息：" + strMessage + "\r\n");
        str.Append("-----------------------------------------------------------\r\n\r\n");
        string errContent = str.ToString();
        System.Text.Encoding encode = System.Text.UTF8Encoding.UTF8;
        byte[] bytes = encode.GetBytes(errContent);
        file.Position = file.Length;
        file.Write(bytes, 0, bytes.Length);
        file.Flush();
        file.Close();
    }


    /// <summary>
    /// 获取客户端IP地址（无视代理）
    /// </summary>
    /// <returns>若失败则返回回送地址</returns>
    private static string GetHostAddress()
    {
        string userHostAddress = HttpContext.Current.Request.UserHostAddress;

        if (string.IsNullOrEmpty(userHostAddress))
        {
            userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
        if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
        {
            return userHostAddress;
        }
        return "127.0.0.1";
    }

    /// <summary>
    /// 检查IP地址格式
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    private static bool IsIP(string ip)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
    }
}

