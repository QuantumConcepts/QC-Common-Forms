using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QuantumConcepts.Common.Forms.Properties;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    public class ClosableTabControl : TabControl
    {
        public delegate void TabControlClosingEventHandler(object sender, ClosableTabControlTabClosingEventArgs e);
        public event TabControlClosingEventHandler TabClosing;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Graphics g = this.CreateGraphics();

            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle tabRectangle = this.GetTabRect(i);

                DrawCloseIcon(i, g, tabRectangle);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            using (Image closeIcon = Resources.CloseIcon)
            {
                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    Rectangle tabRectangle = this.GetTabRect(i);
                    Rectangle closeIconRectangle = GetCloseIconRectangle(closeIcon, tabRectangle);

                    if (closeIconRectangle.Contains(e.Location))
                    {
                        OnTabClosing(i);
                        return;
                    }
                }
            }

            base.OnMouseUp(e);
        }

        private void DrawCloseIcon(int index, Graphics g, Rectangle tabRectangle)
        {
            using (Image closeIcon = Resources.CloseIcon)
            {
                g.DrawImage(closeIcon, GetCloseIconRectangle(closeIcon, tabRectangle).Location);
            }
        }

        private Rectangle GetCloseIconRectangle(Image closeIcon, Rectangle tabRectangle)
        {
            return new Rectangle(tabRectangle.Right - closeIcon.Width - 2, 3, closeIcon.Width, closeIcon.Height);
        }
        
        private void OnTabClosing(int index)
        {
            if (this.TabClosing != null)
                this.TabClosing(this, new ClosableTabControlTabClosingEventArgs(index, this.TabPages[index]));
        }
    }

    public class ClosableTabControlTabClosingEventArgs : EventArgs
    {
        public int TabIndex { get; private set; }
        public TabPage TabPage { get; private set; }
        public bool Cancel { get; set; }

        public ClosableTabControlTabClosingEventArgs(int tabIndex, TabPage tabPage)
        {
            this.TabIndex = tabIndex;
            this.TabPage = tabPage;
        }
    }
}
