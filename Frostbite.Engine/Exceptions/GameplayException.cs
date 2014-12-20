using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frostbite.Engine.Exceptions
{
    class GameplayException:Exception
    {
        public GameplayException(string message):base(message)
        {
        }
    }
}
