#region zh-CN 零度 Soft | en-US ld01.cn Soft
#region zh-CN 编码档案 | en-US Coding History
/* **************************************************
 * Author        :  邹启蒙 ( zouqimeng )
 * E-Mail        :  zouqimeng@126.com
 * Name          :  LogHelp
 * DateTime      :  2015/8/30 3:53:10
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
    /// LogHelp
    /// </summary>    
    public class LogHelp
    {
        #region zh-CN 字段 | en-US Fields

        #region zh-CN 动态私有字段 | en-US Dynamic Private Fields

        private ILog logger;

        #endregion

        #endregion


        #region zh-CN 构造函数 | en-US Constructor

        #region zh-CN 动态公开构造函数 | en-US Dynamic Public Constructor

        //<summary>
        //LogHelp的构造函数
        //</summary>
        public LogHelp(Type type)
        {
            this.logger = LogManager.GetLogger(type.Name);
            // this.logger = LogManager.GetLogger("LogHelp");
        }
        public LogHelp(string str)
        {
            this.logger = LogManager.GetLogger(str);
            // this.logger = LogManager.GetLogger("LogHelp");
        }


        #endregion

        #region zh-CN 静态构造函数 | en-US Static Constructor

        static LogHelp()
        {
            var fileConfig = string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"Log.config");
            FileInfo configFile = new FileInfo(fileConfig);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        #endregion

        #endregion

        #region zh-CN 方法 | en-US Methods

        #region zh-CN 动态方法 | en-US Dynamic Methods

        #region zh-CN 动态公开方法 | en-US Dynamic Public Methods

        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Debug(object message, Exception e)
        {
            this.logger.Debug(message, e);
        }

        public void Warming(object message)
        {
            this.logger.Warn(message);
        }

        public void Warming(object message, Exception e)
        {
            this.logger.Warn(message, e);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Error(object message, Exception e)
        {
            this.logger.Error(message, e);
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Info(object message, Exception e)
        {
            this.logger.Info(message, e);
        }

        public void Fatal(object message)
        {
            this.logger.Fatal(message);
        }

        public void Fatal(object message, Exception e)
        {
            this.logger.Fatal(message, e);
        }

        #endregion

        #endregion

        #endregion
    }
}
#endregion
/* ******************** END *************************
 * DateTime : 2015/8/30 3:53:10
 * Name     : LogHelp
 * ************************************************ */