using HospitalMgmt.Models;
using System.Linq;
using System;


namespace HospitalMgmt
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program p = new Program();

            int choice;

            do
            {
                Console.WriteLine("Your are an 1.Admin 2.Patient 3.Doctor 4.Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        p.Admin();
                        break;
                    case 2:
                        p.Patient();
                        break;
                    case 3:
                        p.Doctor();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != 4);
        }
        public void Admin()
        { int choice;
            string adminName, Password;
            Console.WriteLine("Enter adminName");
            adminName = Console.ReadLine();
            Console.WriteLine("Enter Password");
            Password = Console.ReadLine();
            if (adminName == "admin" && Password == "admin")
            {
                do
                {
                    Console.WriteLine(" 1.Add Doctor 2.Add Healthcare Assistant 3.Add Department 4.Add Drug 5. Exit");
                    Console.WriteLine("Enter your choice");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddDoctor();
                            break;
                        case 2:
                            AddHealthCareAssistant();
                            break;
                        case 3:
                            AddDepartment();
                            break;
                        case 4:
                            AddDrugs();
                            break;
                        case 5:
                            Console.WriteLine("Exit");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                } while (choice != 5);

            }
            else
            {
                Console.WriteLine("Invalid Credentials");
            }

        }
        public void AddDoctor()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                int departmentId;
                string DoctorName, DepartmentName;
                Console.WriteLine("Enter Doctor Name");
                DoctorName = Console.ReadLine();
                Console.WriteLine("Add Doctor Department");
                DepartmentName = Console.ReadLine();


                var Departments = HospitalMgmt.Departments.SingleOrDefault<Departments>(t => t.DepartmentName == DepartmentName);
               
                    departmentId = Departments.DepartmentId;
                
                var doctor = new Doctors
                {
                    DoctorName = DoctorName,
                    DepartmentId = departmentId
                };
                HospitalMgmt.Doctors.Add(doctor
                    );
                HospitalMgmt.SaveChanges();

                Console.WriteLine("Successfully Added");
            }
        }   
        
        
        public void AddHealthCareAssistant()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                int departmentId;
                string assistantName, DepartmentName;
                Console.WriteLine("Enter Assistant Name");
                assistantName = Console.ReadLine();
                Console.WriteLine("Enter Department Name");
                DepartmentName = Console.ReadLine();


                var Departments = HospitalMgmt.Departments.SingleOrDefault<Departments>(t => t.DepartmentName == DepartmentName);

                departmentId = Departments.DepartmentId;

                var healthcareAssistants = new HealthcareAssistants
                {
                    AssistantName = assistantName,
                    DepartmentId = departmentId
                };
                HospitalMgmt.HealthcareAssistants.Add(healthcareAssistants);
                  
                HospitalMgmt.SaveChanges();

                Console.WriteLine("Successfully Added");
            }
        }

        public void AddDepartment()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                string DepartmentName;
                Console.WriteLine("Enter Department Name");
                DepartmentName = Console.ReadLine();

                var department = new Departments
                {
                    DepartmentName = DepartmentName
                   
                };
                HospitalMgmt.Departments.Add(department);

                HospitalMgmt.SaveChanges();

                Console.WriteLine("Successfully Added");
            }

        }
        public void AddDrugs()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                string DrugName;
                Console.WriteLine("Enter Drug Name");
                DrugName = Console.ReadLine();

                var drug = new Drugs
                {
                    DrugName = DrugName

                };
                HospitalMgmt.Drugs.Add(drug);

                HospitalMgmt.SaveChanges();

                Console.WriteLine("Successfully Added");
            }
        }
        public void Patient()
        {
            int choice;

            do
            {
                Console.WriteLine(" 1.Appointment 2.View Departments 3.View Doctors 3.Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        ViewDepartments();
                        break;
                    case 3:
                        ViewDoctors();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            while (choice != 4);

        }
        public void AddPatient()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                string PatientName, ContactNumber, Gender, BloodGroup, Disease;
                int age,patientId;
                Console.WriteLine("Enter Patient Name");
                PatientName = Console.ReadLine();
                Console.WriteLine("Enter Contact Number");
                ContactNumber = Console.ReadLine();
                Console.WriteLine("Enter Patient Age");
                age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Patient Gender");
                Gender = Console.ReadLine();
                Console.WriteLine("Enter Patient BloodGroup");
                BloodGroup = Console.ReadLine();
                Console.WriteLine("Enter Disease");
                Disease = Console.ReadLine();

                var patient = new Patients
                {
                    PatientName = PatientName,
                    ContactNumber = ContactNumber,
                    Age = age,
                    Gender = Gender,
                    BloodGroup = BloodGroup,
                    Disease = Disease
                };
                HospitalMgmt.Patients.Add(patient);

                HospitalMgmt.SaveChanges();
                patientId = patient.PatientId;

                Console.WriteLine("Successfully Added");

                Appointment(patientId);

            }
        }
        public void ViewDepartments()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                var departments = HospitalMgmt.Departments;
                foreach(var department in departments)
                {
                    Console.WriteLine("DepartmentId :" + department.DepartmentId + "DepartmentName :" + department.DepartmentName);
                }

            }
        }
        public void ViewDoctors()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
        
                var doctors = HospitalMgmt.Doctors;
                foreach (var doctor in doctors)
                {
                    var DepartmentName =HospitalMgmt.Departments.SingleOrDefault<Departments>(t => t.DepartmentId == doctor.DepartmentId).DepartmentName;

                    Console.WriteLine( "DoctorName :" + doctor.DoctorName+"Department :"+DepartmentName);
                }

            }

        }
        public void Appointment(int patientId)
        {
            string DepartmentName;
            int doctorId;
            DateTime appointmentTime;
            Console.WriteLine("Enter DepartmentName");
            DepartmentName = Console.ReadLine();
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                var DepartmentId = HospitalMgmt.Departments.SingleOrDefault<Departments>(t => t.DepartmentName == DepartmentName).DepartmentId;
                var doctors = HospitalMgmt.Doctors.Where(t => t.DepartmentId == DepartmentId);
                foreach(var doctor in doctors)
                {
                    Console.WriteLine("DoctorId :" + doctor.DoctorId + "DoctorName :" + doctor.DoctorName);
                }

                Console.WriteLine("Enter Doctor Id to fix Appointment");
                doctorId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Appointment Date (YYYY/MM/DD)");
                appointmentTime = Convert.ToDateTime(Console.ReadLine());

                var appointment = new Appointments
                {
                    PatientId = patientId,
                    DoctorId=doctorId,
                    AppointmentTime=appointmentTime

                };
                HospitalMgmt.Appointments.Add(appointment);

                HospitalMgmt.SaveChanges();

                Console.WriteLine("Appointment Fixed");
            }
        }
        public void Doctor()
        {

            int choice, DoctorId;
            Console.WriteLine("Enter DoctorId");
            DoctorId = Convert.ToInt32(Console.ReadLine());

            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                int doctorId = HospitalMgmt.Doctors.Count(t => t.DoctorId == DoctorId);
                if (doctorId != 0)
                {
                    do
                    {
                        Console.WriteLine(" 1.AssignAssistant 2.PatientTreatment 3.Exit");
                        Console.WriteLine("Enter your choice");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                AssignAssistant();
                                break;
                            case 2:
                                PatientTreatment(doctorId);
                                break;

                            case 3:
                                Console.WriteLine("Exit");
                                break;
                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }
                    }
                    while (choice != 3);
                }
                else
                {
                    Console.WriteLine("Enter Valid DoctorId");
                }
            }
        }
        public void AssignAssistant()
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                int assistantid, appoinmentId;
                Console.WriteLine("Enter assistantid you want to assign");
                assistantid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter AppointmentId in which you assign assistant");
                appoinmentId = Convert.ToInt32(Console.ReadLine());

                var assignassistant = new AssignAssistants
                {
                    AssistantId=assistantid,
                    AppointmentId=appoinmentId
                };
                HospitalMgmt.AssignAssistants.Add(assignassistant);

                HospitalMgmt.SaveChanges();

                Console.WriteLine(" Successfully Assigned HealthCare Assistant");
            }
        }
        public void PatientTreatment(int doctorId)
        {
            using (var HospitalMgmt = new HospitalManagementDbContext())
            {
                string drugname,Timing;
                int patientId;
                Console.WriteLine("Enter drugName");
                drugname = Console.ReadLine();

                var DrugId = HospitalMgmt.Drugs.SingleOrDefault<Drugs>(t => t.DrugName == drugname).DrugId;
                Console.WriteLine("Enter PatientId");
                patientId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Drug Timing");
                Timing = Console.ReadLine();

                var patientTreatment = new Treatments
                {
                    PatientId=patientId,
                    DoctorId=doctorId,
                    Timing=Timing,
                    DrugId=DrugId
                };
                HospitalMgmt.Treatments.Add(patientTreatment);

                HospitalMgmt.SaveChanges();

                Console.WriteLine(" Patient Traetment Done");

            }
        }
    }
}
