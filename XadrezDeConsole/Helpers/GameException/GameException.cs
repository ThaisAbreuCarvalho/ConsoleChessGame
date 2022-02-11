using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezDeConsole.Helpers.GameException
{
    public class GameException : Exception
    {
        public GameException(string message) : base(message)
        {
        }
    }
}
