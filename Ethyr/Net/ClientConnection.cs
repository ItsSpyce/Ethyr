using Ethyr.API.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public sealed class ClientConnection : INetClient
  {
    private Stream m_BaseStream;
    private BinaryWriter m_BinaryWriter;

    public string Id { get; }
    public IPEndPoint EndPoint { get; }

    public ConnectionType ConnectionType => ConnectionType.Client;

    public ClientConnection(string id, Stream baseStream)
    {
      Id = id;
      m_BaseStream = baseStream;
      m_BinaryWriter = new BinaryWriter(baseStream);
    }

    public void Disconnect(string reason)
    {

    }

    public void Flush()
    {
      m_BaseStream.Flush();
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }
  }
}
