using Patients.Domain;
namespace Patients.Forms;

public partial class DoctorMainForm : Form
{
    private User? _currentUser;

    public bool IsLogoutRequested { get; private set; }

    public DoctorMainForm()
    {
        InitializeComponent();
    }

    public void Initialize(User user)
    {
        _currentUser = user;
        Text = $"АРМ Врача — {user.LastName} {user.FirstName}";
        lblWelcome.Text = $"Добро пожаловать, {user.LastName} {user.FirstName} {user.MiddleName}";
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        IsLogoutRequested = true;
        Close();
    }
}
