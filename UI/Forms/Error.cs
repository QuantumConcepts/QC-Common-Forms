using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace QuantumConcepts.Common.Forms.UI.Forms
{
    public partial class Error : Form
    {
        public Error(Exception ex)
            : this(ex.ToString())
        {
            SendErrorMessage(ex);
        }

        public Error(string message)
        {
            InitializeComponent();

            errorTextBox.Text = message;
        }

        private void SendErrorMessage(Exception ex)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                try
                {
                    QCConnectWS.ServiceSoapClient client = new QCConnectWS.ServiceSoapClient();

                    client.CreateErrorReport(BaseApp.ApplicationKey, BaseApp.DeviceUniqueID, null, ex.Message, ex.StackTrace);
                }
                catch { }
            });

        }
    }
}
