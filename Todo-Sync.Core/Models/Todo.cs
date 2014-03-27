using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Sync.Core.Models
{
    public class Todo
    {
        public Todo()
        {
            Description = string.Empty;
            Complete = false;
            IsDirty = true;
        }
        public int TodoId { get; set; }

        public string Description { get; set; }

        public bool Complete { get; set; }

        public bool IsDirty { get; set; }
    }
}
