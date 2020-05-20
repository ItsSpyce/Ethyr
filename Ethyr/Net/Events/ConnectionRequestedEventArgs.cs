using Ethyr.API.Net;
using System;

namespace Ethyr.Net.Events
{
  public class ConnectionRequestedEventArgs : EventArgs
  {
    public INetClient Client { get; }

    public ConnectionRequestedEventArgs(INetClient client)
    {
      Client = client;
    }
  }
}
