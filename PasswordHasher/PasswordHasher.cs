using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using Defuse_PasswordHash;

namespace PasswordHasher
{
    public partial class frmPasswordHasher : Form
    {
        private Thread FrmThread;

        public frmPasswordHasher()
        {
            InitializeComponent();
        }

        private void frmPasswordHasher_Load(object sender, EventArgs e)
        {
            dgvResults.Font = new Font(dgvResults.Font.FontFamily, 9);
        }

        private void CancelTask()
        {
            // Sleep to avoid thread being null still
            Thread.Sleep(10);

            // Cancel the task by aborting the thread
            if (FrmThread != null)
            {
                FrmThread.Abort();
                FrmThread = null;
            }
        }

        private void BeforeTaskInit()
        {
            dgvResults.Invoke(new MethodInvoker(delegate { dgvResults.Rows.Clear(); }));

            txtPassword.Invoke(new MethodInvoker(delegate { txtPassword.ReadOnly = true; }));

            // Show progress bar.
            btnCancel.Invoke(new MethodInvoker(delegate
            {
                btnCancel.Visible = true;
                btnCancel.Enabled = true;
            }));

            prgResults.Invoke(new MethodInvoker(delegate
            {
                prgResults.Visible = true;
                prgResults.Style = ProgressBarStyle.Marquee;
                prgResults.MarqueeAnimationSpeed = 50;
                prgResults.Enabled = true;
            }));
        }

        private void AfterTask()
        {
            txtPassword.Invoke(new MethodInvoker(delegate { txtPassword.ReadOnly = false; }));

            // Hide progress bar.
            btnCancel.Invoke(new MethodInvoker(delegate
            {
                btnCancel.Visible = false;
                btnCancel.Enabled = false;
            }));

            prgResults.Invoke(new MethodInvoker(delegate
            {
                prgResults.Enabled = false;
                prgResults.Visible = false;
                prgResults.Style = ProgressBarStyle.Continuous;
                prgResults.MarqueeAnimationSpeed = 0;
            }));
        }

        private void AddMethodResult(string methodName, string hashedPassword, int hashedPasswordLength, long elapsedMs)
        {
            dgvResults.Invoke(
                new MethodInvoker(
                    delegate
                    {
                        dgvResults.Rows.Add(methodName, hashedPassword, hashedPasswordLength.ToString(),
                            elapsedMs.ToString());
                    }));
        }

        private void HashPasswords()
        {
            CancelTask();

            // Method
            var task = Task.Run(() =>
            {
                // Start of task
                FrmThread = Thread.CurrentThread;
                BeforeTaskInit();

                Stopwatch watch = null;

                try
                {
                    // Method
                    watch = Stopwatch.StartNew();
                    var hashedPassword = PasswordHash.CreateHash(txtPassword.Text);
                    watch.Stop();
                    AddMethodResult("Defuse PasswordHash [PBKDF2-SHA1, Salted]", hashedPassword, hashedPassword.Length,
                        watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = Defuse_PasswordHashCompatible.PasswordHash.CreateHash(txtPassword.Text);
                    watch.Stop();
                    AddMethodResult("Defuse PasswordHash Compatible [PBKDF2-SHA1, Salted]", hashedPassword,
                        hashedPassword.Length, watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = Defuse_PasswordSecurity.PasswordHash.CreateHash(txtPassword.Text);
                    watch.Stop();
                    AddMethodResult("Defuse PasswordHash Compatible Version [PBKDF2-SHA1, Salted]", hashedPassword,
                        hashedPassword.Length, watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                    watch.Stop();
                    AddMethodResult("FormsAuthentication.HashPasswordForStoringInConfigFile() [SHA1]", hashedPassword,
                        hashedPassword.Length, watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "MD5");
                    watch.Stop();
                    AddMethodResult("FormsAuthentication.HashPasswordForStoringInConfigFile() [MD5]", hashedPassword,
                        hashedPassword.Length, watch.ElapsedMilliseconds);


                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = Sodium.PasswordHash.ArgonHashString(txtPassword.Text,
                        Sodium.PasswordHash.StrengthArgon.Interactive);
                    watch.Stop();
                    AddMethodResult("Sodium PasswordHash [Argon2, Interactive]", hashedPassword, hashedPassword.Length,
                        watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = Sodium.PasswordHash.ArgonHashString(txtPassword.Text,
                        Sodium.PasswordHash.StrengthArgon.Moderate);
                    watch.Stop();
                    AddMethodResult("Sodium PasswordHash [Argon2, Moderate]", hashedPassword, hashedPassword.Length,
                        watch.ElapsedMilliseconds);

                    // Method
                    watch = Stopwatch.StartNew();
                    hashedPassword = Sodium.PasswordHash.ArgonHashString(txtPassword.Text,
                        Sodium.PasswordHash.StrengthArgon.Sensitive);
                    watch.Stop();
                    AddMethodResult("Sodium PasswordHash [Argon2, Sensitive]", hashedPassword, hashedPassword.Length,
                        watch.ElapsedMilliseconds);
                }
                catch (OutOfMemoryException ex)
                {
                    if (watch != null)
                        watch.Stop();

                    AddMethodResult("EXCEPTION OCCURRED", "OUT OF MEMORY", 0, 0);
                }

                // End of task
                AfterTask();
            });
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
                && !string.IsNullOrWhiteSpace(dgvResults.CurrentCell.Value.ToString()))
                Clipboard.SetText(dgvResults.CurrentCell.Value.ToString());
            else
                Clipboard.SetText("");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password text box cannot be empty.", "Input Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            HashPasswords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelTask();
            AfterTask();
        }
    }
}