using Patients.Domain;

namespace Patients.Forms;

public partial class RegistratorMainForm : Form
{
    private User? _currentUser;

    public bool IsLogoutRequested { get; private set; }

    public RegistratorMainForm()
    {
        InitializeComponent();
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
}
