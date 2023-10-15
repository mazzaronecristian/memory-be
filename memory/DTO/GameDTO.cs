using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memory.DTO
{
    public class GameDTO
    {
        public virtual uint id { get; set; }
        public virtual UserDTO relatedUser { get; set; }
        public virtual DifficultyDTO relatedDifficulty { get; set; }
        public virtual int misses { get; set; }
        public virtual int moves { get; set; }
    }
}