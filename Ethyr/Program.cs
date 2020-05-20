using Ethyr.API.Server;
using Ethyr.Config;
using Ethyr.Server;
using System;
using System.Linq;
using Utility.CommandLine;

namespace Ethyr
{
  class Program
  {
    static IServer game;
    
    [Argument('d', "debug", "Run in debug mode")]
    static bool m_IsDebugging { get; set; }

    [Argument('c', "config", "The configuration file to use")]
    static string m_ConfigFileLocation { get; set; }

    static void Main(string[] args)
    {
      Arguments.Populate();

      game = MultiplayerServer.Builder
        .UseConfig(JsonConfiguration.FromFile(m_ConfigFileLocation ?? "config.json"))
        .Debug(m_IsDebugging)
        .Build();
      Bootstrap();
      game.Logger.Log($"Starting server on {game.Port}");
      game.Start();
      game.Logger.Log("Server successfully started");
      while (game.IsRunning)
      {
        var input = Console.ReadLine().ToLower();
        if (game.CommandManager.TryGetCommand(input, out var command))
        {
          try
          {
            command.Execute(input.Split(' ').Skip(1));
          }
          catch (Exception ex)
          {
            game.Logger.Error("An error occured when running the command", ex);
          }
        }
      }
    }

    static void Bootstrap()
    {
      game.CommandManager.RegisterCommand("stop", args =>
      {
        game.Stop();
        game.Logger.Log("Server successfully stopped. Press any key to continue.");
        Console.ReadKey();
      });
    }
  }
}
