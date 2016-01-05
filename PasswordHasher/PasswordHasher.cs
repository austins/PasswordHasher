using System;
using System.Diagnostics;
using System.Web.Security;
using System.Windows.Forms;

namespace PasswordHasher
{
    public partial class frmPasswordHasher : Form
    {
        public frmPasswordHasher()
        {
            InitializeComponent();
        }

        private void HashPasswords()
        {
            dgvResults.Rows.Clear();

            if (String.IsNullOrWhiteSpace(txtPassword.Text))
                return;


            // Method
            var watch = Stopwatch.StartNew();
            var passwordHashed = Defuse_PasswordHash.PasswordHash.CreateHash(txtPassword.Text);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds.ToString();
            dgvResults.Rows.Add("Defuse PasswordHash [PBKDF2-SHA1, Salted]", passwordHashed,
                passwordHashed.Length.ToString(), elapsedMs);

            // Method
            watch = Stopwatch.StartNew();
            passwordHashed = Defuse_PasswordHashCompatible.PasswordHash.CreateHash(txtPassword.Text);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds.ToString();
            dgvResults.Rows.Add("Defuse PasswordHash Compatible [PBKDF2-SHA1, Salted]", passwordHashed,
                passwordHashed.Length.ToString(), elapsedMs);

            // Method
            watch = Stopwatch.StartNew();
            passwordHashed = Defuse_PasswordSecurity.PasswordHash.CreateHash(txtPassword.Text);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds.ToString();
            dgvResults.Rows.Add("Defuse PasswordHash Compatible Version [PBKDF2-SHA1, Salted]", passwordHashed,
                passwordHashed.Length.ToString(), elapsedMs);
            
            // Method
            watch = Stopwatch.StartNew();
            passwordHashed = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds.ToString();
            dgvResults.Rows.Add("FormsAuthentication.HashPasswordForStoringInConfigFile() [SHA1]", passwordHashed,
                passwordHashed.Length.ToString(), elapsedMs);

            // Method
            watch = Stopwatch.StartNew();
            passwordHashed = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds.ToString();
            dgvResults.Rows.Add("FormsAuthentication.HashPasswordForStoringInConfigFile() [MD5]", passwordHashed,
                passwordHashed.Length.ToString(), elapsedMs);
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            lblPasswordLength.Text = "Length: " + txtPassword.Text.Length;
        }

        private void dgvResults_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    dgvResults.CurrentCell = dgvResults.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    mnuResults.Show();
                }
            }
        }

        private void mnuResultsCopy_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentCell != null && dgvResults.CurrentCell.Value != null
                && !String.IsNullOrWhiteSpace(dgvResults.CurrentCell.Value.ToString()))
                Clipboard.SetText(dgvResults.CurrentCell.Value.ToString());
            else
                Clipboard.SetText("");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            HashPasswords();
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}