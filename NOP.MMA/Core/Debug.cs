﻿using NOP.Common.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NOP.MMA.Core
{
    /// <summary>
    /// Represents a simple logging class
    /// </summary>
    public static class Debug
    {
        private static FileHandler File;

        /// <summary>
        /// The fully qualified path to the folder that contains all log files
        /// </summary>
        public static string LogPath { get; } = $"{Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location)}\\Logs";
        /// <summary>
        /// The date and time of the last time an <see cref="FileHandler"/> was created for the <see cref="Debug"/> instance
        /// </summary>
        public static DateTime LastHandlerCreated { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated <see cref="DateTime"/> as a short time string</returns>
        private static string LogStamp ()
        {
            return $"-|>{DateTime.Now.ToShortTimeString ()}<|-";
        }

        /// <summary>
        /// Check whether or not there's a <see cref="FileHandler"/> attached to the debugger
        /// </summary>
        /// <returns><see langword="True"/> if there's no <see cref="FileHandler"/> attached, otherwise, <see langword="false"/></returns>
        private static bool NoHandler ()
        {
            return File == null;
        }

        /// <summary>
        /// Creates a new <see cref="FileHandler"/> if there's no handler already attached to the debugger, or if the last logged entry is more than an hour old
        /// </summary>
        private static void CreateHandler ()
        {
            if ( NoHandler () || ( LastHandlerCreated.AddHours (1) ) < DateTime.Now )
            {
                if ( !Directory.Exists (LogPath) )
                {
                    Directory.CreateDirectory (LogPath);
                }

                DateTime date = DateTime.Now;
                File = new FileHandler ($"{LogPath}\\MMA_{date.ToShortDateString ().Replace ("/", string.Empty)}_{date.ToShortTimeString ()}_Log.txt");
                LastHandlerCreated = date;
            }
        }

        /// <summary>
        /// Log a message to the log file
        /// </summary>
        /// <param name="_message">The message to log</param>
        public static void Log ( string _message )
        {
            CreateHandler ();

            File.WriteLine ($"{LogStamp ()} {_message}", true);
        }

        /// <summary>
        /// Log an <see cref="Exception"/> to the log file
        /// </summary>
        /// <param name="_error">The <see cref="Exception"/> to log</param>
        public static void LogError ( Exception _error )
        {
            CreateHandler ();

            File.WriteLine ($"[ERROR]: {LogStamp ()} {_error.Message}{Environment.NewLine}{_error.StackTrace}", true);
        }

        /// <summary>
        /// Log an <see cref="Exception"/> to the log file with a custom message
        /// </summary>
        /// <param name="_message">The custom message to log along with the <see cref="Exception"/></param>
        /// <param name="_error">The <see cref="Exception"/> to log</param>
        /// <param name="_includeExceptionMessage">Whether or not the original <see cref="Exception.Message"/> should be logged as well</param>
        public static void LogError ( string _message, Exception _error, bool _includeExceptionMessage = false )
        {
            CreateHandler ();
            File.WriteLine ($"[ERROR]: {LogStamp ()} {_message}{Environment.NewLine}{( ( _includeExceptionMessage ) ? ( _error.ToString () ) : ( _error.StackTrace ) )}", true);
        }

        /// <summary>
        /// Log a warning to the log file
        /// </summary>
        /// <param name="_message">The message to log</param>
        public static void LogWarning ( string _message )
        {
            CreateHandler ();
            File.WriteLine ($"[WARNING]: {LogStamp ()} {_message}", true);
        }
    }
}