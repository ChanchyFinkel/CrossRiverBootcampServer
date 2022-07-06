using EpidemiologyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace EpidemiologyReport.DB
{
    public class Dal : IDAL
    {
        public async Task<List<Patient>> getAllLocations()
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {

                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    allPatients.Add(_patient);
                    //if (user.email == email && user.password == password);
                }
                return allPatients;

            }

        }

        public async Task<List<Report>> getLocationByCity(string city)
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {

                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    allPatients.Add(_patient);
                }
                List<Report> requieredLocation = new List<Report>();
                allPatients.ForEach(patient =>
                {
                    patient.reports.ForEach(report =>
                    {
                        if (report.city.ToLower().Contains(city))
                            requieredLocation.Add(report);
                    });
                });
                return requieredLocation;
            }
        }

        public async Task<Patient> getLocationByPatientId(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {

                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    if (_patient.Id == id)
                        return _patient;
                }

                return null;
            }


        }

        public async Task<Boolean> addNewLocation(Patient newPatient)
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {
                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    allPatients.Add(_patient);
                }
                reader.Close();
                int patientIsExists = allPatients.FindIndex(patient => patient.Id == newPatient.Id);
                if (patientIsExists != -1)
                {
                    allPatients[patientIsExists].reports.Add(newPatient.reports[0]);
                    System.IO.File.Delete("./Patients.txt");
                    foreach (var patient in allPatients)
                    {
                        string userJson = JsonSerializer.Serialize(patient);
                        await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
                    }
                    return true;
                }

                else
                {
                    string userJson = JsonSerializer.Serialize(newPatient);
                    await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
                    return true;
                }
            }

        }
        public async Task<int> DeleteLocation(Patient deletedLocation)
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {
                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    allPatients.Add(_patient);
                }
                reader.Close();
                int patientIsExists = allPatients.FindIndex(patient => patient.Id == deletedLocation.Id);
                if (patientIsExists != -1)
                {
                    for (int i = 0; i < allPatients[patientIsExists].reports.Count(); i++)
                    {
                        if (allPatients[patientIsExists].reports[i].city.Equals(deletedLocation.reports[i].city) &&
                            allPatients[patientIsExists].reports[i].location.Equals(deletedLocation.reports[i].location) &&
                            DateTime.Compare(allPatients[patientIsExists].reports[i].startDate, deletedLocation.reports[i].startDate) == 0 &&
                             DateTime.Compare(allPatients[patientIsExists].reports[i].endDate, deletedLocation.reports[i].endDate) == 0)
                        {
                            if (allPatients[patientIsExists].reports.Count() == 1)
                            {
                                allPatients.RemoveAt(patientIsExists);
                                break;
                            }
                            else
                            {
                                allPatients[patientIsExists].reports.RemoveAt(i);
                                break;
                            }

                        }
                    }

                    System.IO.File.Delete("./Patients.txt");
                    foreach (var patient in allPatients)
                    {
                        string userJson = JsonSerializer.Serialize(patient);
                        await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
                    }
                    return patientIsExists;

                }
            }
            return -1;
        }

    }
}

