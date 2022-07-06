using EpidemiologyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemiologyReport.DL
{
    public interface IPatientDL
    {
        public Task<List<Patient>> getAllLocations();
        public Task<List<Report>> getLocationByCity(string city);
        public Task<Patient> getLocationByPatientId(int id);
        public Task<Boolean> addNewLocation(Patient newPatient);
        public Task<int> DeleteLocation(Patient deletedLocation);
    }
}
