using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuantumConcepts.Common.Forms.UI
{
    /// <summary>Displays a wait cursor while the application performs some operation.</summary>
    /// <example>
    ///     <code>
    ///         using (new Wait())
    ///         {
    ///             //Perform application logic.
    ///         }
    ///     </code>
    /// </example>
    public class Wait : IDisposable
    {
        private static Wait _wait = null;

        /// <summary>The control (if provided) to be disabled while the Wait is active.</summary>
        public Control ControlToToggle { get; private set; }

        /// <summary>The additional action (if any) to perform once the Wait is disposed.</summary>
        public Action DisposeAction { get; private set; }

        /// <summary>Begins Wait functionality for asynchronous processes when a using(...) statement is not possible. Call <see cref="CancelWait"/> once the processing has completed.</summary>
        public static void BeginWait()
        {
            _wait = new Wait();
        }

        /// <summary>Ends Wait functionality for asynchronous processes when a using(...) statement is not possible. This is called after <see cref="BeginWait"/>, once processing has completed.</summary>
        public static void CancelWait()
        {
            if (_wait != null)
            {
                _wait.Dispose();
                _wait = null;
            }
        }

        /// <summary>Shows the WaitCursor until the instance is disposed.</summary>
        public Wait()
            : this(null, null)
        { 
        }

        /// <summary>Shows the wait cursor and disables the control until the instance is disposed.</summary>
        /// <param name="control">The Control to disable until the instance is disposed.</param>
        public Wait(Control control)
            : this(control, null)
        {
        }

        /// <summary>Shows the wait cursor and disables the control until the instance is disposed.</summary>
        /// <param name="disposeAction">An additional action to perform when the instance is disposed.</param>
        public Wait(Action disposeAction)
            : this(null, disposeAction)
        {
        }

        /// <summary>Shows the wait cursor and disables the control until the instance is disposed.</summary>
        /// <param name="control">The Control to disable until the instance is disposed.</param>
        /// <param name="disposeAction">An additional action to perform when the instance is disposed.</param>
        public Wait(Control control, Action disposeAction)
        {
            this.ControlToToggle = control;
            this.DisposeAction = disposeAction;

            if (this.ControlToToggle != null)
                this.ControlToToggle.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;
        }

        /// <summary>Returns the cursor to Default and enabled the control (if provided).</summary>
        public void Dispose()
        {
            Cursor.Current = Cursors.Default;

            if (this.ControlToToggle != null)
                this.ControlToToggle.Enabled = true;

            if (this.DisposeAction != null)
                this.DisposeAction();
        }
    }
}