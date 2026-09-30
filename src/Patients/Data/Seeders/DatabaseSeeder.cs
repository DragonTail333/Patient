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
        // Если пользователи уже есть — база инициализирована
        if (await context.Users.AnyAsync())
        {
            return;
        }

        // Специальности
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

        // Регистраторы (4 пользователя)
        var registrators = new List<User>
        {
            new() { Login = "reg1", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Иванова", FirstName = "Анна", MiddleName = "Сергеевна" },
            new() { Login = "reg2", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Смирнова", FirstName = "Елена", MiddleName = "Викторовна" },
            new() { Login = "reg3", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Кузнецова", FirstName = "Ольга", MiddleName = "Алексеевна" },
            new() { Login = "reg4", PasswordHash = defaultPasswordHash, Role = UserRole.Registrator, LastName = "Попова", FirstName = "Мария", MiddleName = "Игоревна" }
        };

        await context.Users.AddRangeAsync(registrators);

        // 3. Врачи (6 пользователей + сущности Doctor)
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
        await context.SaveChangesAsync(); // Сохраняем, чтобы сгенерировались Id для User и Specialty

        var doctors = new List<Doctor>
        {
            new() { UserId = doctorUsers[0].Id, SpecialtyId = specialties[0].Id, RoomNumber = "101", Phone = "+7 (999) 111-00-01" }, // Терапевт
            new() { UserId = doctorUsers[1].Id, SpecialtyId = specialties[1].Id, RoomNumber = "202", Phone = "+7 (999) 111-00-02" }, // Хирург
            new() { UserId = doctorUsers[2].Id, SpecialtyId = specialties[2].Id, RoomNumber = "303", Phone = "+7 (999) 111-00-03" }, // Невролог
            new() { UserId = doctorUsers[3].Id, SpecialtyId = specialties[3].Id, RoomNumber = "404", Phone = "+7 (999) 111-00-04" }, // Офтальмолог
            new() { UserId = doctorUsers[4].Id, SpecialtyId = specialties[4].Id, RoomNumber = "102", Phone = "+7 (999) 111-00-05" }, // Кардиолог
            new() { UserId = doctorUsers[5].Id, SpecialtyId = specialties[5].Id, RoomNumber = "205", Phone = "+7 (999) 111-00-06" }  // Педиатр
        };

        await context.Doctors.AddRangeAsync(doctors);

        // Пациенты (10 человек)
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
    }
}