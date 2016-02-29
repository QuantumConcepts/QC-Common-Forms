using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.Common.QCConnectWS;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.Common.Forms.UI.Forms
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, EventArgs ea)
        {
            using (new Wait())
            {
                fieldErrorProvider.Clear();

                if (emailAddressTextBox.Text.IsNullOrEmpty() || !RegexUtil.GetRegex(RegexUtil.KnownRegex.EmailAddress).IsMatch(emailAddressTextBox.Text))
                {
                    fieldErrorProvider.SetError(emailAddressTextBox, "Please enter a valid email address.");
                    return;
                }

                if (subjectComboBox.Text.IsNullOrEmpty())
                {
                    fieldErrorProvider.SetError(subjectComboBox, "Please enter a subject.");
                    return;
                }

                if (messageTextBox.Text.IsNullOrEmpty())
                {
                    fieldErrorProvider.SetError(messageTextBox, "Please enter a message.");
                    return;
                }

                try
                {
                    ServiceSoapClient client = new ServiceSoapClient();

                    client.CreateFeedback(BaseApp.ApplicationKey, BaseApp.DeviceUniqueID, emailAddressTextBox.Text, subjectComboBox.Text, messageTextBox.Text);
                }
                catch
                {
                    MessageBox.Show("An error occurred while sending your feedback. Please ensure that you have an active internet connection.", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("Thanks for your feedback!", "Feedback Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
