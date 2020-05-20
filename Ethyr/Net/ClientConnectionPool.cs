using Ethyr.API.Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.Net
{
  public sealed class ClientConnectionPool
  {
    private const int MAX_CONNECTION_COUNT = 8;
    private object m_Lock = new object();
    private List<HashSet<INetClient>> m_Clients = new List<HashSet<INetClient>>();

    public ClientConnectionPool()
    {
      m_Clients.Add(new HashSet<INetClient>(MAX_CONNECTION_COUNT)); // init with 1
    }

    private HashSet<INetClient> GetCurrentPool(out int id)
    {
      var pool = m_Clients.Last().Count == MAX_CONNECTION_COUNT ? new HashSet<INetClient>(MAX_CONNECTION_COUNT) : m_Clients.Last();
      if (pool.Count == 0) m_Clients.Add(pool);
      id = m_Clients.Count - 1;
      return pool;
    }

    private bool TryGetPool(string id, out HashSet<INetClient> pool)
    {
      pool = null;
      var poolId = int.Parse(id.Substring(0, id.IndexOf('_')));
      if (m_Clients.Count >= poolId) return false;
      pool = m_Clients[poolId];
      return true;
    }

    public INetClient GetClient(string id)
    {
      if (TryGetPool(id, out var pool)) return pool.FirstOrDefault(client => client.Id == id);
      else return null;
    }

    public INetClient CreateClient(Stream stream)
    {
      var pool = GetCurrentPool(out var poolId);
      var id = $"{poolId}{Guid.NewGuid()}";
      var client = new ClientConnection(id, stream);
      pool.Add(client);
      return client;
    }

    public void RemoveClient(string id)
    {
      if (TryGetPool(id, out var pool))
      {
        lock (m_Lock)
        {
          pool.RemoveWhere(client => client.Id == id);
        }
      }
      else
      {
        throw new KeyNotFoundException($"No client found with id {id}");
      }
    }

    public void RemoveClient(INetClient client)
    {
      if (TryGetPool(client.Id, out var pool))
      {
        lock (m_Lock)
        {
          pool.Remove(client);
        }
      }
      else
      {
        throw new ArgumentException("No matching client found in given pool");
      }
    }
  }
}
