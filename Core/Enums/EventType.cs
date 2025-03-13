using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Core.Enums
{
    public enum EventType
    {
        [Description("Boda")]
        Wedding,

        [Description("Cumpleaños")]
        Birthday,

        [Description("Baby Shower")]
        BabyShower,

        [Description("Otro")]
        Other
    }
}
