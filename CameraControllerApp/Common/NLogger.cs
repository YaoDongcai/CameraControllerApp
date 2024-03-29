﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Log
    {
        public long Id { get; set; }
        /// <summary>
        /// 日志级别 Trace|Debug|Info|Warn|Error|Fatal
        /// </summary>
        public string Level { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string Amount { get; set; }
        public string StackTrace { get; set; }
        public DateTime Timestamp { get; set; }

        private Log() { }
        public Log(string level, string message, string action = null, string amount = null)
        {
            this.Level = level;
            this.Message = message;
            this.Action = action;
            this.Amount = amount;
        }
    }
    public class NLogger
    {
        NLog.Logger _logger;

        private NLogger(NLog.Logger logger)
        {
            _logger = logger;
        }

        public NLogger(string name) : this(LogManager.GetLogger(name))
        {
        }

        public static NLogger Default
        {
            get;
            private set;
        }
        static NLogger()
        {
            Default = new NLogger(NLog.LogManager.GetCurrentClassLogger());
        }

        #region Debug
        public void Debug(string msg, params object[] args)
        {
            _logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            _logger.Debug(err, msg);
        }
        #endregion

        #region Info
        public void Info(string msg, params object[] args)
        {
            _logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            _logger.Info(err, msg);
        }
        #endregion

        #region Warn
        public void Warn(string msg, params object[] args)
        {
            _logger.Warn(msg, args);
        }

        public void Warn(string msg, Exception err)
        {
            _logger.Warn(err, msg);
        }
        #endregion

        #region Trace
        public void Trace(string msg, params object[] args)
        {
            _logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            _logger.Trace(err, msg);
        }
        #endregion

        #region Error
        public void Error(string msg, params object[] args)
        {
            _logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            _logger.Error(err, msg);
        }
        #endregion

        #region Fatal
        public void Fatal(string msg, params object[] args)
        {
            _logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            _logger.Fatal(err, msg);
        }
        #endregion

        #region Custom

        public void Process(Log log)
        {
            //var level = LogLevel.Info;
            //if (log.Level == Models.EFLogLevel.Trace)
            //    level = LogLevel.Trace;
            //else if (log.Level == Models.EFLogLevel.Debug)
            //    level = LogLevel.Debug;
            //else if (log.Level == Models.EFLogLevel.Info)
            //    level = LogLevel.Info;
            //else if (log.Level == Models.EFLogLevel.Warn)
            //    level = LogLevel.Warn;
            //else if (log.Level == Models.EFLogLevel.Error)
            //    level = LogLevel.Error;
            //else if (log.Level == Models.EFLogLevel.Fatal)
            //    level = LogLevel.Fatal;
            //var ei = new MyLogEventInfo(level, _logger.Name, log.Message);
            //ei.TimeStamp = log.Timestamp;
            //ei.Properties["Action"] = log.Action;
            //ei.Properties["Amount"] = log.Amount;
            //_logger.Log(level, ei);
        }

        #endregion

        /// <summary>
        /// Flush any pending log messages (in case of asynchronous targets).
        /// </summary>
        /// <param name="timeoutMilliseconds">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
        public void Flush(int? timeoutMilliseconds = null)
        {
            if (timeoutMilliseconds != null)
                NLog.LogManager.Flush(timeoutMilliseconds.Value);
            NLog.LogManager.Flush();
        }
    }

    public class MyLogEventInfo : LogEventInfo
    {
        public MyLogEventInfo() { }
        public MyLogEventInfo(LogLevel level, string loggerName, string message) : base(level, loggerName, message)
        { }

        public override string ToString()
        {
            //Message format
            //Log Event: Logger='XXX' Level=Info Message='XXX' SequenceID=5
            return FormattedMessage;
        }
    }
}
