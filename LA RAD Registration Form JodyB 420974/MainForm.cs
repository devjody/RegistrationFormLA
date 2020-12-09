using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LA_RAD_Registration_Form_JodyB_420974
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Output_PANEL.Hide();
        }

        #region Force Close is Validation not complete
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                e.Cancel = false;
            }
        }
        #endregion

        #region Button Visual Styles
        private void Submit_BUTTON_MouseEnter(object sender, EventArgs e)
        {
            Submit_BUTTON.Font = new Font(Submit_BUTTON.Font, FontStyle.Bold);
        }

        private void Submit_BUTTON_MouseLeave(object sender, EventArgs e)
        {
            Submit_BUTTON.Font = new Font(Submit_BUTTON.Font, FontStyle.Regular);
        }
        #endregion

        #region Text Input Visual Styles
        private void ResetForm_BUTTON_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            OutputFullName_LABEL.Text = $"Full Name :";
            OutputEmail_LABEL.Text = $"Email :";
            OutputPostcode_LABEL.Text = $"PostCode :";
            OutputPhone_LABEL.Text = $"Phone Number :";
            Output_PANEL.Hide();

            FName_TB.Text = "";
            LName_TB.Text = "";
            Phone_MTB.Text = "";
            Postcode_MTB.Text = "";
            Email_TB.Text = "";
        }
        #endregion

        #region First Name Val
        private void FName_TB_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in FName_TB.Text)
            {
                if (!char.IsLetter(c))
                {
                    FName_TB.Text = FName_TB.Text.Remove(FName_TB.Text.LastIndexOf(c));
                }
            }
        }
        private void FName_TB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NameChecker(FName_TB.Text))
            {
                e.Cancel = true;
                errProvider.SetError(FName_TB, "Please Enter Your First Name");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(FName_TB, null);
                Output_PANEL.Show();
            }

            OutputFullName_LABEL.Text = $"Full Name : {FName_TB.Text} TBC";
        }

        #endregion

        #region Last Name Val
        private void LName_TB_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in LName_TB.Text)
            {
                if (!char.IsLetter(c))
                {
                    LName_TB.Text = LName_TB.Text.Remove(LName_TB.Text.LastIndexOf(c));
                }
            }
        }
        private void LName_TB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NameChecker(LName_TB.Text))
            {
                e.Cancel = true;
                errProvider.SetError(LName_TB, "Please Enter Your First Name");
            }
            else
            {
                e.Cancel = false;
                errProvider.SetError(LName_TB, null);
            }

            OutputFullName_LABEL.Text = $"Full Name : {FName_TB.Text} {LName_TB.Text}";
        }
        #endregion

        #region Email Val
        private void Email_TB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = Email_TB.Text.ToLower();

            Regex email = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (email.IsMatch(input))
            {
                e.Cancel = false;
                errProvider.Clear();
            }
            else
            {
                e.Cancel = true;
                errProvider.SetError(Email_TB, "Please enter a valid email address.");
            }

            OutputEmail_LABEL.Text = $"Email : {input}";
        }
        #endregion

        #region Postcode Val
        private void Postcode_MTB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string input = Postcode_MTB.Text.ToUpper();
            OutputPostcode_LABEL.Text = $"PostCode : {input}";

            Regex postcode = new Regex(@"^[ABCEGHJKLMPRSTUVXY]\d[A-Z]-?\d[A-Z]\d$");

            if (postcode.IsMatch(input))
            {
                e.Cancel = false;
                errProvider.Clear();
            }
            else
            {
                e.Cancel = true;
                errProvider.SetError(Postcode_MTB, "Please enter a valid postcode.");
                return;
            }

        }
        #endregion

        #region Phone Number Val
        private void Phone_MTB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OutputPhone_LABEL.Text = $"Phone Number : {Phone_MTB.Text}";
        }
        #endregion

        #region OnSubmit operations
        private void Submit_BUTTON_Click(object sender, EventArgs e)
        {
            OutputFullName_LABEL.Text = $"Full Name : {FName_TB.Text} {LName_TB.Text}";
            OutputEmail_LABEL.Text = $"Email : {Email_TB.Text}";
            OutputPostcode_LABEL.Text = $"PostCode : {Postcode_MTB.Text}";
            OutputPhone_LABEL.Text = $"Phone Number : {Phone_MTB.Text}";

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("See you at the PARTY!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }
        #endregion

        #region First Name and Last Name Checker Method
        public bool NameChecker(string txt)
        {
            bool blankInput = string.IsNullOrEmpty(txt);
            bool length = txt.Length < 2;

            if (blankInput || length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}