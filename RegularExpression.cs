using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// 正则表达式验证类
/// </summary>
public class RegularExpression
{
    #region QQ
    /// <summary>
    /// 验证QQ
    /// </summary>
    public static Regex regxQQ = new Regex(@"^[1-9][0-9]{4,}$");
    #endregion
    #region 验证邮箱
    /// <summary>
    /// 验证邮箱
    /// </summary>
    public static Regex regxEml = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    #endregion
    #region 验证url(http://)
    /// <summary>
    /// 验证url(http://)
    /// </summary>
    public static Regex regxUrl = new Regex(@"^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$");
    #endregion
    #region 验证邮编
    /// <summary>
    /// 验证邮编
    /// </summary>
    public static Regex regxZipCode = new Regex(@"^\d{6}$");
    #endregion
    #region 验证身份证号码
    /// <summary>
    /// 验证身份证号码
    /// </summary>
    public static Regex regxIdCode = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
    #endregion
    #region 验证密码(字母开头，允许5-16字节，允许字母数字下划线)
    /// <summary>
    /// 验证密码(字母开头，允许5-16字节，允许字母数字下划线)
    /// </summary>
    public static Regex regxPwd = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]{4,15}$");
    #endregion
    #region 匹配中文
    /// <summary>
    /// 匹配中文
    /// </summary>
    public static Regex regxCN = new Regex(@"^[\u4e00-\u9fa5]$");
    #endregion
    #region 验证国内电话号码（匹配形式如 05114405222 或 02187888822 ）
    /// <summary>
    /// 验证国内电话号码（匹配形式如 0511-4405222 或 0211-87888822 ）
    /// </summary>
    public static Regex regxTel = new Regex(@"^(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}$");
    #endregion
    #region 匹配正浮点数
    /// <summary>
    /// 匹配正浮点数
    /// </summary>
    public static Regex regxPfNum = new Regex(@"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$");
    #endregion
    #region 匹配非正浮点数
    /// <summary>
    /// 匹配非正浮点数
    /// </summary>
    public static Regex regxNfNum = new Regex(@"^((-\d+(\.\d+)?)|(0+(\.0+)?))$");
    #endregion
    #region 匹配负浮点数
    /// <summary>
    /// 匹配负浮点数
    /// </summary>
    public static Regex regxFNum = new Regex(@"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$");
    #endregion

    #region 验证手机号码
    /// <summary>
    /// 验证手机号码
    /// </summary>
    public static Regex regxPhone = new Regex(@"^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)$");
    #endregion
    #region 验证价格
    /// <summary>
    /// 验证价格
    /// </summary>
    public static Regex regxPrice = new Regex(@"^(d*.d{0,2}|d+).*$");
    #endregion
    #region 匹配正整数
    /// <summary>
    /// 匹配正整数
    /// </summary>
    public static Regex regxNum = new Regex(@"^[1-9]\d*$");
    #endregion
}

