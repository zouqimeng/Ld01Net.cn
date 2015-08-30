#region zh-CN 零度 Soft | en-US ld01.cn Soft
#region zh-CN 编码档案 | en-US Coding History
/* **************************************************
 * Author        :  邹启蒙 ( zouqimeng )
 * E-Mail        :  zouqimeng@126.com
 * Name          :  LogFactory
 * DateTime      :  2015/8/30 3:43:31
 * Code Type     :  通用类
 * Content       :  通用类模板
 * .Net Version  :  4.5
 * ************************************************ */
#endregion

#region zh-CN 命名空间引用 | en-US USING NAMESPACE
using log4net;
using System;
using System.IO;
#endregion

namespace LdNet.Log
{
    /// <summary>
    /// LogFactory
    /// </summary>    
    public class LogFactory
    {
        #region zh-CN 构造函数 | en-US Constructor

        #region zh-CN 静态构造函数 | en-US Static Constructor

        static LogFactory()
        {
            try
            {
                var path = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "Config\\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileInfo configFile = new FileInfo(path + @"Log.config");
                log4net.Config.XmlConfigurator.Configure(configFile);
            }
            catch (Exception er)
            {
 
            }
        }


        #endregion

        #endregion


        #region zh-CN 方法 | en-US Methods

        #region zh-CN 静态方法 | en-US Static Methods

        #region zh-CN 静态公开方法 | en-US Static Public Methods

        public static LogHelp GetLogger(Type type)
        {
            return new LogHelp(LogManager.GetLogger(type));
        }

        public static LogHelp GetLogger(string str)
        {
            return new LogHelp(LogManager.GetLogger(str));
        }

        #endregion

        #endregion

        #endregion
    }
}
#endregion
/* ******************** END *************************
 * DateTime : 2015/8/30 3:43:31
 * Name     : LogFactory
 * ************************************************ */