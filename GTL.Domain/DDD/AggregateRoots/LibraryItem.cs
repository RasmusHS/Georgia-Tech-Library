using GTL.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Domain.DDD.AggregateRoots
{
    public class LibraryItem : AggregateRoot
    {
        public LibraryItem()
        {

        }

        public string Type { get; set; }
        public List<string> SubjectArea { get; set; }
        public bool LendAble { get; set; }
    }
}
