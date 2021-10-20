//using Common.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mzt.Serialization;
using System.Diagnostics;

namespace Mzt.Logging
{
    public class MztLogger : ILogger
    {
        Logger _logger;
        string _loggerName;
        KeyValuePair<string, Stopwatch> _sw;
        public Logger Logger => _logger ?? (_logger = NLog.LogManager.GetLogger(_loggerName));

        private string LoggerName
        {
            get
            {
                return _loggerName;
            }
            set
            {
                _loggerName = value;
                if (_logger != null)
                    //если идет попытка поменять имя, то логгер тоже меняем
                    _logger = LogManager.GetLogger(_loggerName);
            }
        }

        public MztLogger()
        {
            _loggerName = "defaultLogger";
            //альтернативный способ конфигурирования
            //var config = new NLog.Config.LoggingConfiguration();
            //var logfile = new NLog.Targets.FileTarget() { FileName = $@"Logs\{loggerName}.txt", Name = "logfile", Layout = @"${date} ${machinename} ${level} ${message} ${event-properties:item=data} ${exception:format=toString,Data:maxInnerExceptionLevel=3} " };
            //config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));
            //NLog.LogManager.Configuration = config;
        }

        public MztLogger ConfigureName(string loggerName)
        {
            LoggerName = loggerName;
            return this;
        }

        private IDictionary<string, object> _globalProperties;

        public MztLogger AddProperty(string key, object value)
        {
            if (_globalProperties == null)
                _globalProperties = new Dictionary<string, object>();
            if (!_globalProperties.Keys.Contains(key))
            {
                _globalProperties.Add(key, value);
            }
            else
            {
                _globalProperties[key] = value;
            }
            return this;
        }

        public MztLogger RemoveProperty(string key)
        {
            if (_globalProperties != null && _globalProperties.Keys.Contains(key))
            {
                _globalProperties.Remove(key);
            }
            return this;
        }

        public MztLogger ClearAllProperties()
        {
            if (_globalProperties != null)
            {
                _globalProperties.Clear();
            }
            return this;
        }

        public MztLogger UseStopWatch(string watchName = "stopWatch")
        {
            if (_sw.Key == null)
                _sw = new KeyValuePair<string, Stopwatch>(watchName, new Stopwatch());
            _sw.Value.Start();
            return this;
        }

        #region Log
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        public void DebugWithData(object data, string message, string property = "data")
        {
            LogWithData(LogLevel.Debug, data, message, null, property);
        }

        public void Error(Exception exception, string message)
        {
            Log(LogLevel.Error, message, exception);
        }

        public void Error(string message, Exception exception)
        {
            Error(exception, message);
        }

        public void Fatal(Exception exception, string message)
        {
            Log(LogLevel.Fatal, message, exception);
        }

        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public void InfoWithData(object data, string message, string property = "data")
        {
            LogWithData(LogLevel.Info, data, message, null, property);
        }

        public void Warn(string message)
        {
            Log(LogLevel.Warn, message);
        }

        public void WarnWithData(object data, string message, string property = "data")
        {
            LogWithData(LogLevel.Warn, data, message, null, property);
        }

        private void LogWithData(LogLevel level, object data, string message, Exception exception = null, string property = "data")
        {
            string dataString;
            try
            {
                if (data != null)
                    dataString = Serializer.ToJSON(data);
                else
                    dataString = "null";
            }
            catch (Exception)
            {
                dataString = "SerializationFailed";
            }
            var info = new LogEventInfo(level, _loggerName, message);
            if (exception != null)
            {
                //exception as object
                info.Exception = exception;
                //exception as sting
                info.Properties.Add("exceptionString", exception.ToString());
            }

            info.Properties[property] = dataString;
            Log(info);
        }

        private void Log(LogLevel level, string message, Exception exception = null)
        {
            var info = new LogEventInfo(level, _loggerName, message);
            if (exception != null)
            {
                //exception as object
                info.Exception = exception;
                //exception as sting
                info.Properties.Add("exceptionString", exception.ToString());
            }
            Log(info);
        }

        private void Log(LogEventInfo info)
        {
            if (_globalProperties != null)
            {
                foreach (var property in _globalProperties)
                {
                    info.Properties.Add(property.Key, property.Value);
                }
            }
            if (_sw.Key != null)
                info.Properties.Add(_sw.Key, _sw.Value.ElapsedMilliseconds);
            Logger.Log(info);
            if (_sw.Key != null)
                _sw.Value.Restart();
        }
        #endregion
    }
}
