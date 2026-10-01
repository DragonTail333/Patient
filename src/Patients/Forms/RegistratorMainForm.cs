using Microsoft.Extensions.DependencyInjection;
using Patients.Domain;

namespace Patients.Forms;

public partial class RegistratorMainForm : Form
{
    private readonly IServiceScopeFactory? _scopeFactory;
    private User? _currentUser;

    public bool IsLogoutRequested { get; private set; }

    // Конструктор для Visual Studio Designer
    public RegistratorMainForm()
    {
        InitializeComponent();
    }

    // Конструктор для DI
    public RegistratorMainForm(IServiceScopeFactory scopeFactory) : this()
    {
        _scopeFactory = scopeFactory;
    }

    public void Initialize(User user)
    {
        _currentUser = user;
        Text = $"АРМ регистратора — {user.LastName} {user.FirstName}";
        lblWelcome.Text = $"Добро пожаловать, {user.LastName} {user.FirstName} {user.MiddleName}";
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        IsLogoutRequested = true;
        Close();
    }

    private void btnCreatePatient_Click(object sender, EventArgs e)
    {
        if (_scopeFactory == null) return;

        // Создаем изолированный скоуп для модального окна
        using var scope = _scopeFactory.CreateScope();
        var createPatientForm = scope.ServiceProvider.GetRequiredService<CreatePatientForm>();

        // Открываем как модальный диалог (блокирует главную форму до закрытия)
        createPatientForm.ShowDialog(this);
    }
}
