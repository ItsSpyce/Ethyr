using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ethyr.API.Net
{
  public interface INetClient
  {
    string Id { get; }
    IPEndPoint EndPoint { get; }
    void Disconnect(string reason);

    void Flush();
  }
}
