using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiProject4.ScopeBox
{
    public partial class frmScopeBox : Form
    {
        private ScopeBoxHandler _scopeHandler;
        private ExternalEvent _scopeEvent;
        public frmScopeBox(ExternalEvent scopeEvent, ScopeBoxHandler scopeHandler)
        {
            InitializeComponent();
            _scopeEvent = scopeEvent;
            _scopeHandler = scopeHandler;
        }

        private void frmScopeBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scopeEvent.Raise();
        }

        private void listViewScopeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewScopeBox_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listItemChecked = AppPanelScopeBox.myFormScopeBox.listViewScopeBox.CheckedItems;
            if (listItemChecked.Count > 1)
            {
                foreach (ListViewItem item in listItemChecked)
                {
                    if (item.Index != e.Item.Index)
                    {
                        item.Checked = false;
                    }
                }
            }
        }
    }
}
