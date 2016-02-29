using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.Common.Exceptions;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    public class FieldErrorProvider : ErrorProvider
    {
        public ErrorIconAlignment DefaultErrorIconAlignment { get; set; }

        public void Show(Control parent, ValidationException exception)
        {
            Show(parent, exception, this.DefaultErrorIconAlignment);
        }

        public void Show(Control parent, ValidationException exception, ErrorIconAlignment alignment)
        {
            Control target = null;

            if (!exception.Tag.IsNullOrEmpty())
                target = FindControl(parent, exception.Tag);

            if (target != null)
                this.SetError(target, exception.Message, alignment);
            else
                this.SetError(parent, exception.Message, alignment);
        }

        private Control FindControl(Control parent, string tag)
        {
            foreach (Control control in parent.Controls)
            {
                if (string.Equals(tag, control.Tag))
                    return control;
                else
                {
                    Control found = FindControl(control, tag);

                    if (found != null)
                        return found;
                }
            }

            return null;
        }

        public new void SetError(Control control, string value)
        {
            SetError(control, value, this.DefaultErrorIconAlignment);
        }

        public void SetError(Control control, string value, ErrorIconAlignment alignment)
        {
            base.SetIconAlignment(control, alignment);
            base.SetError(control, value);
        }
    }
}
