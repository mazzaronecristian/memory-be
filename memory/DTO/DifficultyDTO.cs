using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory.DTO
{
    public class DifficultyDTO
    {

        public virtual uint id { get; set; }
        public virtual string note { get; set; }
        public virtual int totTime { get; set; }
        public virtual int flipTime { get; set; }
    }
}