using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using log4net;
using log4net.Repository;
using log4net.Appender;

namespace kosal.core.common.logger {
    public sealed class logger {

        private static object syncObject = new object();
        private static string fileAppenderName { get; set; }
        
        private string instanceName { get; set; }

        private ILog instance { get; set; }

        private static Dictionary<string, logger> loggers { get; set; }

        static logger() {
            fileAppenderName = "LogFileAppender";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        private logger(string loggerName, ILog logger) {
            this.instance=  logger;
            this.instanceName = loggerName;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerName"></param>
        /// <returns></returns>
        public static logger getInstance(string loggerName) {

            if ( loggers != null && loggers.ContainsKey( loggerName ) ) {
                return loggers[loggerName];
            }

            lock ( syncObject ) {

                if ( loggers != null && loggers.ContainsKey( loggerName ) ) {
                    return loggers[loggerName];
                }

                loggers = loggers ?? new Dictionary<string, logger>( 1 );

                logger instLocal = new logger( loggerName, LogManager.GetLogger( loggerName ) );

                ILoggerRepository RootRep = instLocal.instance.Logger.Repository;

                IAppender iApp = RootRep.GetAppenders().Where(item => item is log4net.Appender.RollingFileAppender && item.Name == string.Format("{0}_LogFileAppender", loggerName) ).FirstOrDefault();

                if ( iApp != null ) {
                    FileAppender fApp = (log4net.Appender.FileAppender) iApp;
                    //fApp.File = Path.GetExtension(fApp.File ) != string.Empty ? Path.GetDirectoryName(fApp.File) : fApp.File ;
                    fApp.File = Path.Combine( fApp.File, loggerName + ".log" );
                    fApp.ActivateOptions();

                }

                loggers.Add( loggerName, instLocal );

                return instLocal;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void logInfo( string message ) {
            this.log( message, logLevel.Information );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void logDebug(string message) {
            this.log(message, logLevel.Debug);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void logError(string message) {
            this.log(message, logLevel.Error);
        }

        public void logError( Exception ex ) {
            this.log( ex.ToString(), logLevel.Error );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void log(string message, logLevel level) {
            if(this.instance != null) {
                switch (level) {
                    case logLevel.Error:
                        this.instance.Error(message);
                        break;
                    case logLevel.Fatal:
                        this.instance.Fatal(message);
                        break;
                    case logLevel.Information:
                        this.instance.Info(message);
                        break;
                    case logLevel.Warning:
                        this.instance.Warn(message);
                        break;
                    case logLevel.Debug:
                        this.instance.Debug(message);
                        break;
                }
            }
        }
    }
}