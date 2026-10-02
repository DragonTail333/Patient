using Patients.Domain;

namespace Patients.Forms;

public partial class ViewExaminationForm : Form
{
    public ViewExaminationForm()
    {
        InitializeComponent();
    }

    public void Initialize(Examination examination, string patientFullName)
    {
        if (examination == null) return;

        Text = $"Протокол осмотра — {patientFullName} ({examination.ExaminationDate:dd.MM.yyyy HH:mm})";
        lblPatientInfo.Text = $"Пациент: {patientFullName} | Осмотр от {examination.ExaminationDate:dd.MM.yyyy HH:mm}";

        txtComplaints.Text = examination.Complaints;
        txtAnamnesis.Text = examination.Anamnesis;
        txtDiagnosis.Text = examination.Diagnosis;
        txtRecommendations.Text = examination.Recommendations;

        dgvPrescriptions.AutoGenerateColumns = false;
        dgvPrescriptions.DataSource = examination.Prescriptions.ToList();

        dgvReferrals.AutoGenerateColumns = false;
        dgvReferrals.DataSource = examination.Referrals.ToList();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}