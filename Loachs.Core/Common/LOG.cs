using System;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Loachs.Core.Common
{
    public static class LOG
    {
        private static Logger log;

        static LOG()
        {
            var config=new LoggingConfiguration();

            var consoleTarget=new ColoredConsoleTarget();
            config.AddTarget("ANLogC",consoleTarget);


            var fileTarget=new FileTarget();
            config.AddTarget("ANLogFile",fileTarget);

            consoleTarget.Layout =
                "${longdate}|${level}|${message}|${stacktrace}";

            fileTarget.FileName = "${basedir}/App_Data/${level}_${shortdate}.log";
            fileTarget.Layout = "${longdate}|${level}|${message}|${stacktrace}|${onexception:inner=${newline} *****Error***** ${newline} ${exception:format=ToString}}";

            var ruleConsole=new LoggingRule("*",LogLevel.Trace,fileTarget);
            var ruleFile=new LoggingRule("*",LogLevel.Warn,fileTarget);

            config.LoggingRules.Add(ruleConsole);
            config.LoggingRules.Add(ruleFile);

            LogManager.Configuration = config;

            log = LogManager.GetCurrentClassLogger();
        }

        public static void Error(string error, params object[] args)
        {
            log.Error(error,args);
        }

        public static void Error(string message, Exception exception)
        {
            log.Error(message,exception);
        }
        public static void Error( Exception exception)
        {
            log.Error(exception);
        }

        public static void Info(string info, params object[] args)
        {
           log.Info(info,args);
        }

        public static void Trace(string info, params object[] args)
        {
            log.Trace(info, args);
        }

        public static void Info(string message, Exception exception)
        {
           log.Info(message,exception);
        }

        public static void Debug(string debug,params object[] args)
        {
          log.Debug(debug,args);
        }

        public static void Debug(string message, Exception exception)
        {
            log.Debug(message,exception);

        }


        public static void Warn(string warn, params object[] args)
        {
            log.Warn(warn,args);
        }

        public static void Warn(string message, Exception exception)
        {
            log.Warn(message,exception);
        }

        public static void Fatal(string message, params object[] args)
        {
            log.Fatal(message,args);
        }

        public static void Fatal(string message, Exception exception)
        {
            log.Fatal(message,exception);
        }

    }
}
