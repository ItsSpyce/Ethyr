using Ethyr.API.Server;
using Ethyr.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Server
{
  public class ServerBuilder
  {
    private IServer m_Server;

    private ILogger m_Logger;
    private IServerConfiguration m_Configuration;
    private bool m_Debug = ServerEnvironment.IsDebugging;

    public ServerBuilder()
    {

    }

    public ServerBuilder UseLogger(ILogger logger)
    {
      m_Logger = logger;
      return this;
    }

    public ServerBuilder UseConfig(IServerConfiguration config)
    {
      m_Configuration = config;
      return this;
    }

    public ServerBuilder Debug(bool value)
    {
      m_Debug = value;
      return this;
    }

    public IServer Build()
    {
      var logger = m_Logger ?? new Logger();
      var config = m_Configuration ?? new JsonConfiguration();

      return new MultiplayerServer(logger, config, m_Debug);
    }
  }
}
