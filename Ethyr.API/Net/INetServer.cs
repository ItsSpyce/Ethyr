using System;
using System.Collections.Generic;
using System.Text;

namespace Ethyr.API.Net
{
  public interface INetServer
  {
    int ConnectionCount { get; }

    void Start();
    void Stop();
    bool SendPacket<TPacket>(INetClient client, TPacket packet) where TPacket : IPacket;
    INetClient GetClient(Guid id);
  }
}
