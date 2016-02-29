using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    public enum ToolboxOrientation
    {
        None, Left, Center, Right
    }

    [Designer(typeof(ParentControlDesigner))]
    public partial class Toolbox : UserControl
    {
        public ToolboxOrientation Orientation
        {
            get
            {
                if (leftPictureBox.Visible && rightPictureBox.Visible)
                    return ToolboxOrientation.Center;
                else if (!leftPictureBox.Visible && !rightPictureBox.Visible)
                    return ToolboxOrientation.None;
                else if (leftPictureBox.Visible)
                    return ToolboxOrientation.Right;
                else if (rightPictureBox.Visible)
                    return ToolboxOrientation.Left;

                throw new InvalidEnumArgumentException("Unknown orientation.");
            }
            set
            {
                leftPictureBox.Visible = (value == ToolboxOrientation.Center || value == ToolboxOrientation.Right);
                rightPictureBox.Visible = (value == ToolboxOrientation.Center || value == ToolboxOrientation.Left);
            }
        }

        public ContentAlignment HeaderAlign { get { return headerLabel.TextAlign; } set { headerLabel.TextAlign = value; } }
        public string HeaderText { get { return headerLabel.Text; } set { headerLabel.Text = value; } }
        public override Color BackColor { get { return base.BackColor; } set { base.BackColor = value; headerPanel.BackColor = value; } }
        public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value; headerLabel.ForeColor = value; } }

        public Toolbox()
        {
            InitializeComponent();
        }
    }
}
