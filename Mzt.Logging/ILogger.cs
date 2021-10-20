using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzt.Logging
{
    public interface ILogger
    {
        void Debug(string message);
        void DebugWithData(object data, string message, string property = "data");
        void Info(string message);
        void InfoWithData(object data, string message, string property = "data");
        void Warn(string message);
        void WarnWithData(object data, string message, string property = "data");
        void Error(Exception exception, string message);
        void Error(string message, Exception exception);
        void Fatal(Exception exception, string message);
        MztLogger AddProperty(string key, object value);
        MztLogger ConfigureName(string loggerName);
        MztLogger RemoveProperty(string key);
        MztLogger UseStopWatch(string watchName = "stopWatch");
    }
}
