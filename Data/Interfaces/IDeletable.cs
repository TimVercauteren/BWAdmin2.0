using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
