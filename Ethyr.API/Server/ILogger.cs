using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Server
{
  public interface ILogger
  {
    void Log(params object[] content);
    void Warn(params object[] content);
    void Error(params object[] content);
    void Debug(params object[] content);
  }
}
