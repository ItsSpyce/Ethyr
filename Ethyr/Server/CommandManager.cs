using Ethyr.API.Server;
using System;
using System.Collections.Generic;

namespace Ethyr.Server
{
  public class CommandManager : ICommandManager
  {
    private Dictionary<string, Command> m_RegisteredCommands;

    public CommandManager()
    {
      m_RegisteredCommands = new Dictionary<string, Command>();
    }

    public bool TryGetCommand(string name, out Command command)
    {
      return m_RegisteredCommands.TryGetValue(name, out command);
    }

    public bool RegisterCommand<TCommand>() where TCommand : Command
    {
      // each command must have a zero parameter constructor to build
      if (!(typeof(TCommand).GetConstructor(Type.EmptyTypes).Invoke(null) is TCommand instance)) return false;
      if (m_RegisteredCommands.ContainsKey(instance.Name)) return false;
      m_RegisteredCommands.Add(instance.Name, instance);
      return true;
    }

    public bool RegisterCommand(string name, CommandExecutor executor)
    {
      if (m_RegisteredCommands.ContainsKey(name)) return false;
      m_RegisteredCommands.Add(name, new DefaultCommand(name, executor));
      return true;
    }

    public bool RegisterCommand(string name, string permission, CommandExecutor executor)
    {
      if (m_RegisteredCommands.ContainsKey(name)) return false;
      m_RegisteredCommands.Add(name, new DefaultCommand(name, permission, executor));
      return true;
    }

    public bool UnregisterCommand<TCommand>() where TCommand : Command
    {
      // each command must have a zero parameter constructor to build
      if (!(typeof(TCommand).GetConstructor(Type.EmptyTypes).Invoke(null) is TCommand instance)) return false;
      if (!m_RegisteredCommands.ContainsKey(instance.Name)) return false;
      m_RegisteredCommands.Remove(instance.Name);
      return true;
    }

    public bool UnregisterCommand(string name)
    {
      if (!m_RegisteredCommands.ContainsKey(name)) return false;
      m_RegisteredCommands.Remove(name);
      return true;
    }
  }
}
