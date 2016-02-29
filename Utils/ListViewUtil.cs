using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuantumConcepts.Common.Forms.Utils
{
    public static class ListViewUtil
    {
        public static void SwapListViewItems(ListViewItem lvi1, ListViewItem lvi2)
        {
            ListView listView = lvi1.ListView;
            int firstIndex = lvi1.ListView.Items.IndexOf(lvi1);

            listView.Items.Remove(lvi1);
            listView.Items.Remove(lvi2);

            listView.Items.Insert(firstIndex, lvi2);
            listView.Items.Insert(firstIndex + 1, lvi1);
        }
    }
}
