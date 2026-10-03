using Microsoft.EntityFrameworkCore;
using Patients.Domain;
using Patients.Domain.Enums;
using Patients.Services;
using Patients.Services.Abstractions;

namespace Patients.Data.Seeders;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(PatientsContext context, IPasswordHasher passwordHasher)
    {
        if (await context.Users.AnyAsync())
        {
            return;
        }

        var specialties = new List<Specialty>
        {
            new() { Title = "Терапевт" },
            new() { Title = "Хирург" },
            new() { Title = "Невролог" },
            new() { Title = "Офтальмолог" },
            new() { Title = "Кардиолог" },
            new() { Title = "Педиатр" }
        };

        await context.Specialties.AddRangeAsync(specialties);
        await context.SaveChangesAsync();

        var defaultPasswordHash = passwordHasher.HashValue("123456");

        var registrators = new List<User>
        {
            new() { Login = "reg1", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Иванова", FirstName = "Анна", MiddleName = "Сергеевна" },
            new() { Login = "reg2", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Смирнова", FirstName = "Елена", MiddleName = "Викторовна" },
            new() { Login = "reg3", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Кузнецова", FirstName = "Ольга", MiddleName = "Алексеевна" },
            new() { Login = "reg4", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Попова", FirstName = "Мария", MiddleName = "Игоревна" }
        };

        await context.Users.AddRangeAsync(registrators);

        var doctorUsers = new List<User>
        {
            new() { Login = "doc1", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Петров", FirstName = "Дмитрий", MiddleName = "Николаевич" },
            new() { Login = "doc2", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Сидоров", FirstName = "Алексей", MiddleName = "Петрович" },
            new() { Login = "doc3", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Васильев", FirstName = "Игорь", MiddleName = "Сергеевич" },
            new() { Login = "doc4", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Соколов", FirstName = "Михаил", MiddleName = "Андреевич" },
            new() { Login = "doc5", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Михайлов", FirstName = "Артем", MiddleName = "Владимирович" },
            new() { Login = "doc6", PasswordHash = defaultPasswordHash, Role = UserRole.Doctor, LastName = "Новиков", FirstName = "Евгений", MiddleName = "Олегович" }
        };

        await context.Users.AddRangeAsync(doctorUsers);

        var chiefDoctor = new User
        {
            Login = "chief1",
            PasswordHash = defaultPasswordHash,
            Role = UserRole.ChiefDoctor,
            LastName = "Быков",
            FirstName = "Андрей",
            MiddleName = "Евгеньевич"
        };

        await context.Users.AddAsync(chiefDoctor);
        await context.SaveChangesAsync();

        var doctors = new List<Doctor>
        {
            new() { UserId = doctorUsers[0].Id, SpecialtyId = specialties[0].Id, RoomNumber = "101", Phone = "+7 (999) 111-00-01" },
            new() { UserId = doctorUsers[1].Id, SpecialtyId = specialties[1].Id, RoomNumber = "202", Phone = "+7 (999) 111-00-02" },
            new() { UserId = doctorUsers[2].Id, SpecialtyId = specialties[2].Id, RoomNumber = "303", Phone = "+7 (999) 111-00-03" },
            new() { UserId = doctorUsers[3].Id, SpecialtyId = specialties[3].Id, RoomNumber = "404", Phone = "+7 (999) 111-00-04" },
            new() { UserId = doctorUsers[4].Id, SpecialtyId = specialties[4].Id, RoomNumber = "102", Phone = "+7 (999) 111-00-05" },
            new() { UserId = doctorUsers[5].Id, SpecialtyId = specialties[5].Id, RoomNumber = "205", Phone = "+7 (999) 111-00-06" }
        };

        await context.Doctors.AddRangeAsync(doctors);

        var patients = new List<Patient>
        {
            new() { CardNumber = "CARD-001", LastName = "Федоров", FirstName = "Александр", MiddleName = "Сергеевич", BirthDate = new DateOnly(1985, 4, 12), Gender = "Мужской", Phone = "+7 (911) 222-33-01", PolicyNumber = "1111222233334441" },
            new() { CardNumber = "CARD-002", LastName = "Морозова", FirstName = "Наталья", MiddleName = "Павловна", BirthDate = new DateOnly(1992, 8, 25), Gender = "Женский", Phone = "+7 (911) 222-33-02", PolicyNumber = "1111222233334442" },
            new() { CardNumber = "CARD-003", LastName = "Волков", FirstName = "Сергей", MiddleName = "Анатольевич", BirthDate = new DateOnly(1978, 1, 15), Gender = "Мужской", Phone = "+7 (911) 222-33-03", PolicyNumber = "1111222233334443" },
            new() { CardNumber = "CARD-004", LastName = "Алексеева", FirstName = "Екатерина", MiddleName = "Дмитриевна", BirthDate = new DateOnly(2000, 11, 30), Gender = "Женский", Phone = "+7 (911) 222-33-04", PolicyNumber = "1111222233334444" },
            new() { CardNumber = "CARD-005", LastName = "Лебедев", FirstName = "Максим", MiddleName = "Юрьевич", BirthDate = new DateOnly(1995, 3, 5), Gender = "Мужской", Phone = "+7 (911) 222-33-05", PolicyNumber = "1111222233334445" },
            new() { CardNumber = "CARD-006", LastName = "Семенова", FirstName = "Татьяна", MiddleName = "Николаевна", BirthDate = new DateOnly(1967, 7, 18), Gender = "Женский", Phone = "+7 (911) 222-33-06", PolicyNumber = "1111222233334446" },
            new() { CardNumber = "CARD-007", LastName = "Егоров", FirstName = "Роман", MiddleName = "Денисович", BirthDate = new DateOnly(1989, 9, 9), Gender = "Мужской", Phone = "+7 (911) 222-33-07", PolicyNumber = "1111222233334447" },
            new() { CardNumber = "CARD-008", LastName = "Степанова", FirstName = "Юлия", MiddleName = "Олеговна", BirthDate = new DateOnly(2002, 5, 21), Gender = "Женский", Phone = "+7 (911) 222-33-08", PolicyNumber = "1111222233334448" },
            new() { CardNumber = "CARD-009", LastName = "Павлов", FirstName = "Владимир", MiddleName = "Константинович", BirthDate = new DateOnly(1981, 12, 14), Gender = "Мужской", Phone = "+7 (911) 222-33-09", PolicyNumber = "1111222233334449" },
            new() { CardNumber = "CARD-010", LastName = "Козлова", FirstName = "Ирина", MiddleName = "Васильевна", BirthDate = new DateOnly(1974, 2, 28), Gender = "Женский", Phone = "+7 (911) 222-33-10", PolicyNumber = "1111222233334450" }
        };

        await context.Patients.AddRangeAsync(patients);
        await context.SaveChangesAsync();

        var appointments = new List<Appointment>
        {
            new()
            {
                PatientId = patients[0].Id,
                DoctorId = doctors[0].Id,
                CreatedByUserId = registrators[0].Id,
                AppointmentDate = new DateTime(2026, 10, 01, 09, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 01, 09, 15, 00),
                    Complaints = "Высокая температура, кашель",
                    Anamnesis = "Болеет 2 дня",
                    Diagnosis = "ОРВИ",
                    Recommendations = "Обильное питье, покой",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Парацетамол", Dosage = "500мг", Instructions = "3 раза в день" },
                        new() { MedicationName = "Ибупрофен", Dosage = "400мг", Instructions = "При боли" }
                    },
                    Referrals = new List<Referral>
                    {
                        new() { ReferralType = "Лабораторное исследование", TargetDescription = "Общий анализ крови" }
                    }
                }
            },
            new()
            {
                PatientId = patients[1].Id,
                DoctorId = doctors[0].Id,
                CreatedByUserId = registrators[1].Id,
                AppointmentDate = new DateTime(2026, 10, 02, 10, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 02, 10, 20, 00),
                    Complaints = "Боль в горле, сухой кашель",
                    Anamnesis = "Контакт с больными ОРВИ",
                    Diagnosis = "ОРВИ",
                    Recommendations = "Полоскание горла, витамин С",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Парацетамол", Dosage = "500мг", Instructions = "2 раза в день" }
                    }
                }
            },
            new()
            {
                PatientId = patients[2].Id,
                DoctorId = doctors[1].Id,
                CreatedByUserId = registrators[0].Id,
                AppointmentDate = new DateTime(2026, 10, 03, 11, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 03, 11, 15, 00),
                    Complaints = "Боль в праве колене после нагрузки",
                    Anamnesis = "Травма на тренировке",
                    Diagnosis = "Ушиб коленного сустава",
                    Recommendations = "Холод на колено, ограничение нагрузок",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Ибупрофен", Dosage = "400мг", Instructions = "2 раза в день после еды" }
                    },
                    Referrals = new List<Referral>
                    {
                        new() { ReferralType = "Инструментальное исследование", TargetDescription = "Рентгенография коленного сустава" }
                    }
                }
            },
            new()
            {
                PatientId = patients[3].Id,
                DoctorId = doctors[4].Id,
                CreatedByUserId = registrators[2].Id,
                AppointmentDate = new DateTime(2026, 10, 04, 14, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 04, 14, 25, 00),
                    Complaints = "Головные боли, давящие ощущения в затылке",
                    Anamnesis = "Повышение АД до 150/90",
                    Diagnosis = "Гипертоническая болезнь",
                    Recommendations = "Контроль АД дважды в день, диета с ограничением соли",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Лизиноприл", Dosage = "10мг", Instructions = "1 раз в день утром" }
                    },
                    Referrals = new List<Referral>
                    {
                        new() { ReferralType = "Инструментальное исследование", TargetDescription = "ЭКГ в 12 отведениях" }
                    }
                }
            },
            new()
            {
                PatientId = patients[4].Id,
                DoctorId = doctors[2].Id,
                CreatedByUserId = registrators[3].Id,
                AppointmentDate = new DateTime(2026, 10, 05, 12, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 05, 12, 15, 00),
                    Complaints = "Острая пульсирующая боль в виске",
                    Anamnesis = "Периодические приступы мигрени",
                    Diagnosis = "Мигрень",
                    Recommendations = "Покой в темном помещении",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Ибупрофен", Dosage = "400мг", Instructions = "При начале приступа" }
                    }
                }
            },
            new()
            {
                PatientId = patients[5].Id,
                DoctorId = doctors[0].Id,
                CreatedByUserId = registrators[1].Id,
                AppointmentDate = new DateTime(2026, 10, 06, 09, 30, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 06, 09, 50, 00),
                    Complaints = "Слабость, недомогание, першение в горле",
                    Anamnesis = "Заболела вчера",
                    Diagnosis = "ОРВИ",
                    Recommendations = "Симптоматическая терапия"
                }
            },
            new()
            {
                PatientId = patients[6].Id,
                DoctorId = doctors[1].Id,
                CreatedByUserId = registrators[0].Id,
                AppointmentDate = new DateTime(2026, 10, 07, 15, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 10, 07, 15, 20, 00),
                    Complaints = "Боль в эпигастрии после еды",
                    Anamnesis = "Погрешность в диете",
                    Diagnosis = "Острый гастрит",
                    Recommendations = "Щадящая диета",
                    Prescriptions = new List<Prescription>
                    {
                        new() { MedicationName = "Омепразол", Dosage = "20мг", Instructions = "1 капсула утром до еды" }
                    },
                    Referrals = new List<Referral>
                    {
                        new() { ReferralType = "Инструментальное исследование", TargetDescription = "ФГДС" }
                    }
                }
            },
            new()
            {
                PatientId = patients[7].Id,
                DoctorId = doctors[0].Id,
                CreatedByUserId = registrators[2].Id,
                AppointmentDate = new DateTime(2026, 10, 08, 10, 00, 00),
                Status = AppointmentStatus.Scheduled
            },
            new()
            {
                PatientId = patients[8].Id,
                DoctorId = doctors[3].Id,
                CreatedByUserId = registrators[0].Id,
                AppointmentDate = new DateTime(2026, 10, 09, 11, 30, 00),
                Status = AppointmentStatus.Cancelled
            },
            new()
            {
                PatientId = patients[9].Id,
                DoctorId = doctors[0].Id,
                CreatedByUserId = registrators[1].Id,
                AppointmentDate = new DateTime(2026, 09, 15, 10, 00, 00),
                Status = AppointmentStatus.Completed,
                Examination = new Examination
                {
                    ExaminationDate = new DateTime(2026, 09, 15, 10, 15, 00),
                    Complaints = "Профилактический осмотр",
                    Anamnesis = "Жалоб нет",
                    Diagnosis = "Здоров",
                    Recommendations = "Плановый осмотр через год"
                }
            }
        };

        await context.Appointments.AddRangeAsync(appointments);
        await context.SaveChangesAsync();
    }
}