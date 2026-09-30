using Patients.Domain;
using Patients.Services.Abstractions;

namespace Patients.Forms;

public partial class LoginForm : Form
{
    private readonly IAuthService? _authService;

    // Авторизованный пользователь доступен после закрытия окна
    public User? AuthenticatedUser { get; private set; }

    public LoginForm()
    {
        InitializeComponent();
    }

    public LoginForm(IAuthService authService) : this()
    {
        _authService = authService;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (_authService == null) return;

        lblError.Text = string.Empty;
        btnLogin.Enabled = false;

        try
        {
            var user = await _authService.AuthenticateAsync(txtLogin.Text.Trim(), txtPassword.Text);

            if (user == null)
            {
                lblError.Text = "Неверный логин или пароль.";
                return;
            }

            AuthenticatedUser = user;
            DialogResult = DialogResult.OK;
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }
}