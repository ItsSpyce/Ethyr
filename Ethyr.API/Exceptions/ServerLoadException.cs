using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethyr.API.Exceptions
{
    public class ServerLoadException : Exception
    {
        public ServerLoadException(string message): base("An error occured when loading the server: " + message)
        {

        }
    }
}
