using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// WEB操作辅助类
/// </summary>
public class WebHelper
{
    #region 截取Html中的图片
    /// <summary>
    /// 截取Html中第一张图片
    /// </summary>
    /// <param name="articleContent"></param>
    /// <returns></returns>
    public static string GetImageUrlFromArticle(string articleContent)
    {
        Regex r = new Regex(@"<IMG[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
        MatchCollection mc = r.Matches(articleContent);
        if (mc.Count != 0)
        {
            return mc[0].Groups["src"].Value.ToLower();
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 截取Html中所有图片,有循环
    /// </summary>
    /// <param name="articleContent"></param>
    /// <returns></returns>
    public static string GetImageUrl(string articleContent)
    {
        try
        {
            string imgStr = string.Empty;
            string str = articleContent;
            string Pattern = @"<\s?img[^>]+?>";

            MatchCollection mc = Regex.Matches(str, Pattern, RegexOptions.IgnoreCase);
            foreach (Match m in mc)
            {
                if (!string.IsNullOrEmpty(m.Value))
                {
                    imgStr += m.Value;
                }
                else
                {
                    imgStr = "";
                }
            }
            return imgStr;
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// 截取Html中所有图片,无循环
    /// </summary>
    /// <param name="articleContent"></param>
    /// <returns></returns>
    public static MatchCollection GetImageUrlStr(string articleContent)
    {
        try
        {

            string str = articleContent;
            string Pattern = @"<\s?img[^>]+?>";

            MatchCollection mc = Regex.Matches(str, Pattern, RegexOptions.IgnoreCase);
            return mc;
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion

    #region 截取Html中第一个Flash
    /// <summary>
    /// 截取Html中第一个Flash
    /// </summary>
    /// <param name="articleContent"></param>
    /// <returns></returns>
    public static string GetFlashUrlFromArticle(string articleContent)
    {
        Regex r = new Regex(@"<embed[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
        MatchCollection mc = r.Matches(articleContent);
        if (mc.Count != 0)
        {
            return mc[0].Groups["src"].Value.ToLower();
        }
        else
        {
            return "";
        }
    }

    #endregion


    #region 清空Html标签，获取纯字符串

    /// <summary>
    /// 清空Html标签，获取纯字符串
    /// </summary>
    /// <param name="HtmlStr">Html字符串</param>
    /// <returns>String</returns>
    public static string NullHtmlStr(string HtmlStr)
    {
        try
        {
            string str = Regex.Replace(HtmlStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            if (str != "")
            {
                return str;
            }
            else
            {
                return "";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion


    #region 返回随机数

    /// <summary>
    /// 获取随机数（99%不重复率）
    /// </summary>
    /// <returns></returns>
    public static string Randoms()
    {
        try
        {
            int seed = DateTime.Now.ToFileTimeUtc().GetHashCode();
            Random r = new Random(seed);
            int iSeed = r.Next();
            Random ro = new Random(iSeed);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            var v = ran.Next(100000, 1000000).ToString();
            return v;
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion


    #region 返回评分/排序
    /// <summary>
    /// 返回评分/排序
    /// </summary>
    /// <param name="p">投票数</param>
    /// <param name="t">相差小时</param>
    /// <returns></returns>
    public static string Order(double p, double t)
    {
        try
        {
            double m = Math.Pow((t + 2), 1 / 1.8);
            double o = p - 1;
            double r = (o / m);
            return r.ToString("0.000000");
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

    #region 返回验证码

    /// <summary>
    /// 英文大写字母数组
    /// </summary>
    private static char[] constant = { 'A', '0', 'b', '2', 'C', '4', 'd', 'E', 'f', '6', 'G', 'h', 'I', '8', 'j', 'K', 'l', 'M', 'n', 'O', 'p', 'Q', 'r', 'S', 't', 'U', 'v', 'W', 'x', 'Y', 'z', 'a', 'B', '1', 'c', '3', 'D', 'e', '5', 'F', 'g', '7', 'H', 'i', 'J', 'k', '9', 'L', 'm', 'N', 'o', 'P', 'q', 'R', 's', 'T', 'u', 'V', 'w', 'X', 'y', 'Z' };
    /// <summary>
    /// 按条件生成英文字母验证码
    /// </summary>
    /// <param name="Length"></param>
    /// <returns></returns>
    public static string GenerateRandom(int Length)
    {
        System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(62)]);
        }
        return newRandom.ToString();
    }
    #endregion

    #region 获取一个a标签中的某个后缀的文件路径
    /// <summary>
    /// 获取一个a标签中的某个后缀的文件路径
    /// </summary>
    /// <param name="articleContent">含有一个a标签的html文本</param>
    /// <param name="ext">所要获取格式后缀（例如：.pdf）</param>
    /// <returns></returns>
    public static string GetFlashUrlFromExtension(string articleContent, string ext)
    {
        Regex r = new Regex(@"<a[^>]*href=([""'])?(?<href>[^'""]+)\1[^>]*>", RegexOptions.IgnoreCase);
        MatchCollection mc = r.Matches(articleContent);
        if (mc.Count != 0)
        {
            var pdf = mc[0].Groups["href"].Value.ToLower();
            string extension = System.IO.Path.GetExtension(pdf);
            if (extension == ext)
            {
                return pdf;
            }
            else
            {
                return "";
            }

        }
        else
        {
            return "";
        }
    }
    #endregion
}

