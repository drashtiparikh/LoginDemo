using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for LoggError
/// </summary>
public class LoggError
{
    /// <summary>
    /// Writes error occured in log file,if log file does not exist,it creates the file first.
    /// </summary>
    /// <param name="exception">Exception</param>
    public static void Write(Exception exception)
    {
        string logFile = String.Empty;
        StreamWriter logWriter;
        try
        {
            logFile = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["ErrorLog"].ToString());
            if (File.Exists(logFile))
                logWriter = File.AppendText(logFile);
            else
                logWriter = File.CreateText(logFile);
            logWriter.WriteLine("=>" + DateTime.Now + " " + " An Error occured : " +
                exception.StackTrace + " Message : " + exception.Message + "\n\n");
            logWriter.Close();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}