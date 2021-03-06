﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// TDES加密类
/// </summary>
public class TDESHelper
{
    //构造一个对称算法
    private static SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();

    #region 加密解密函数

    /// <summary>
    /// 加密方法
    /// </summary>
    /// <param name="sKeystr">密钥（6位英文）</param>
    /// <param name="sIVstr">向量（6位英文）</param>
    /// <param name="Value">需要加密的字符串</param>
    /// <returns>返回加密密文</returns>
    public static string EncryptString(string sKeystr, string sIVstr, string Value)
    {
        try
        {
            sKeystr = MD5Pwd.MD5(sKeystr);//密钥
            byte[] bytes = Encoding.ASCII.GetBytes(sIVstr);
            sIVstr = Convert.ToBase64String(bytes);//向量
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            mCSP.Key = Convert.FromBase64String(sKeystr);
            mCSP.IV = Convert.FromBase64String(sIVstr);
            //指定加密的运算模式
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            //获取或设置加密算法的填充模式
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);//创建加密对象
            byt = Encoding.UTF8.GetBytes(Value);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message, "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return ("Error in Encrypting " + ex.Message);
        }
    }

    /// <summary>
    /// 解密方法
    /// </summary>
    /// <param name="sKeystr">密钥（6位英文）</param>
    /// <param name="sIVstr">向量（6位英文）</param>
    /// <param name="Value">需要加密的字符串</param>
    /// <returns>返回解密明文</returns>
    public static string DecryptString(string sKeystr, string sIVstr, string Value)
    {
        try
        {
            ICryptoTransform ct;//加密转换运算
            MemoryStream ms;//内存流
            CryptoStream cs;//数据流连接到数据加密转换的流
            byte[] byt;
            //将3DES的密钥转换成byte
            mCSP.Key = Convert.FromBase64String(sKeystr);
            //将3DES的向量转换成byte
            mCSP.IV = Convert.FromBase64String(sIVstr);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);//创建对称解密对象
            byt = Convert.FromBase64String(Value);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message, "出现异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return ("Error in Decrypting " + ex.Message);
        }
    }





    #endregion
}

