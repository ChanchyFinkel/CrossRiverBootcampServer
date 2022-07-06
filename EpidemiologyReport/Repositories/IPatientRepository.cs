using EpidemiologyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.Repositories
{
    public interface  IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
    }
}
