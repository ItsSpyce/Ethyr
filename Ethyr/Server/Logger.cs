using Ethyr.API.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ethyr.Server
{
  public class Logger : ILogger
  {
    private static string GetTimestamp()
    {
      return $"[{Thread.CurrentThread.Name} - {DateTime.Now.ToShortTimeString()}] ";
    }

    private static void WriteWithTimestamp(object content, ConsoleColor? color)
    {
      Console.Write(GetTimestamp());
      var oldColor = Console.ForegroundColor;
      if (color.HasValue)
      {
        Console.ForegroundColor = color.Value;
      }
      Console.Write(content);
      Console.ForegroundColor = oldColor;
      Console.Write(Environment.NewLine);
    }

    public void Debug(params object[] content)
    {
      if (ServerEnvironment.IsDebugging)
      {
        foreach (var line in content)
        {
          WriteWithTimestamp(line, ConsoleColor.Green);
        }
      }
    }

    public void Error(params object[] content)
    {
      foreach (var line in content)
      {
        WriteWithTimestamp(line, ConsoleColor.Red);
      }
    }

    public void Log(params object[] content)
    {
      foreach (var line in content)
      {
        WriteWithTimestamp(line, null);
      }
    }

    public void Warn(params object[] content)
    {
      foreach (var line in content)
      {
        WriteWithTimestamp(line, ConsoleColor.Yellow);
      }
    }
  }
}
