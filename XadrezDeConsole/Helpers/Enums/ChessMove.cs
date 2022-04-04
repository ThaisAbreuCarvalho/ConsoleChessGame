using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XadrezDeConsole.Helpers.Enums
{
    public enum ChessMove : int
    {
        [Description("Check")]
        Check = 1,
        [Description("Checkmate")]
        Checkmate = 2,
        [Description("None")]
        None = 3
    }
}
