using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.Common.Forms.Extensions
{
    public static class ControlExtensions
    {
        public static bool TryAddRange(this ComboBox.ObjectCollection comboBoxObjects, IEnumerable<object> objects)
        {
            if (comboBoxObjects == null || objects.IsNullOrEmpty())
                return false;

            try
            {
                comboBoxObjects.AddRange(objects.ToArray());
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}
