using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchachConsole.Figures
{
    public abstract class Figure
    {
        public bool IsWhite { get; set; } = true;
        public abstract char Letter { get; }
        public string GetAcronym()
        {
            return $"{(IsWhite ? "w" : "s")} {Letter}";
        }
    }
}
