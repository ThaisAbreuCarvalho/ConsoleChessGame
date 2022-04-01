using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XadrezDeConsole.Helpers.Enums
{
    public enum Color : int
    {
        [Description("Red")]
        Red = ConsoleColor.Red,
        [Description("Yellow")]
        Yellow = ConsoleColor.Yellow
    }
}
