using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public List<Report> reports { get; set; }

        internal void Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
