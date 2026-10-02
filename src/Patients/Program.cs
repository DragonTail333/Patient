namespace Patients;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Patients.Data.Seeders;
using Patients.Domain.Enums;
using Patients.Forms;
using Patients.Services;
using Patients.Services.Abstractions;
using System.Reflection;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Сборка конфигурации (appsettings.json + UserSecrets + EnvVars)
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
            .AddEnvironmentVariables()
            .Build();

        // Настройка DI-контейнера
        var services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);

        #region services
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContextFactory<PatientsContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IPatientService, PatientService>();
        services.AddTransient<ISpecialtyService, SpecialtyService>();
        services.AddTransient<IDoctorService, DoctorService>();
        services.AddTransient<IAppointmentService, AppointmentService>();

        #endregion

        #region forms
        services.AddTransient<LoginForm>(); // главная форма

        services.AddTransient<DoctorMainForm>(); // форма доктора
        services.AddTransient<CreateExaminationForm>(); // ворма создания осмотра для выбранного приёма
        services.AddTransient<CreateReferralForm>(); // ворма создания направления для выбранного осмотра
        services.AddTransient<CreatePrescriptionForm>(); // ворма создания рецепта для выбранного осмотра

        services.AddTransient<RegistratorMainForm>(); // форма регистратора
        services.AddTransient<CreatePatientForm>(); // форма добавления нового пациента
        services.AddTransient<CreateAppointmentForm>(); // форма назначения приёма 
        #endregion

        ServiceProvider = services.BuildServiceProvider();

        // Запуск сидинга базы данных
        InitializeDatabaseAsync().GetAwaiter().GetResult();

        RunApplicationLoop();
    }

    private static async Task InitializeDatabaseAsync()
    {
        var factory = ServiceProvider.GetRequiredService<IDbContextFactory<PatientsContext>>();
        var hasher = ServiceProvider.GetRequiredService<IPasswordHasher>();

        using var context = factory.CreateDbContext();

        await context.Database.MigrateAsync();

        await DatabaseSeeder.SeedAsync(context, hasher);
    }

    private static void RunApplicationLoop()
    {
        while (true)
        {
            using var scope = ServiceProvider.CreateScope();

            // Показываем форму логина
            var loginForm = scope.ServiceProvider.GetRequiredService<LoginForm>();
            var dialogResult = loginForm.ShowDialog();

            // Если окно закрыли или авторизация не пройдена — завершит работу
            if (dialogResult != DialogResult.OK || loginForm.AuthenticatedUser == null)
                break;

            var user = loginForm.AuthenticatedUser;

            // Определяем и инициализируем главную форму под роль
            Form mainForm = user.Role switch
            {
                UserRole.Doctor => scope.ServiceProvider.GetRequiredService<DoctorMainForm>(),
                UserRole.Registrator => scope.ServiceProvider.GetRequiredService<RegistratorMainForm>(),
                _ => throw new InvalidOperationException($"Неизвестная роль: {user.Role}")
            };

            if (mainForm is DoctorMainForm docForm) docForm.Initialize(user);
            if (mainForm is RegistratorMainForm regForm) regForm.Initialize(user);

            // Запускаем рабочее окно
            Application.Run(mainForm);

            // Проверяем флаг выхода из аккаунта при закрытии главной формы
            bool isLogoutRequested = mainForm switch
            {
                DoctorMainForm d => d.IsLogoutRequested,
                RegistratorMainForm r => r.IsLogoutRequested,
                _ => false
            };

            if (!isLogoutRequested)
            {
                break; // Обычное закрытие крестиком — выход из программы
            }
        }
    }
}