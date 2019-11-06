using Subro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace ApiProject4.KeynoteManager
{
    public partial class frmAddKeyNote : System.Windows.Forms.Form
    {
        public frmAddKeyNote()
        {
            InitializeComponent();
        }

        private void frmAddKeyNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void btnAddKeynote_Click(object sender, EventArgs e)
        {
            int rowCount = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.RowCount;
            List<string> listIdAdd = new List<string>();
            for (int i = 0; i < rowCount - 1; i++)
            {
                string id = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[1].Value.ToString();
                if (listIdAdd.Exists(x => x == id))
                {
                    MessageBox.Show("Error: Id is existed. You must change id.");
                    return;
                }
                listIdAdd.Add(id);

                string parentId = string.Empty;
                try
                {
                    parentId = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[0].Value.ToString();
                }
                catch { }
                string discription = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[2].Value.ToString();
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(discription) || discription == "" || id == "")
                {
                    MessageBox.Show("Error: You must input enough information");
                    return;
                }
                if (MethodExtend.CheckParentAndId(AppPenalKeynoteManager.entryTableKeynote, parentId, id) == false)
                {
                    return;
                }
            }
            for (int i = 0; i < rowCount - 1; i++)
            {
                string parentId = string.Empty;
                try
                {
                    parentId = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[0].Value.ToString();
                }
                catch { }
                string id = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[1].Value.ToString();
                string discription = AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows[i].Cells[2].Value.ToString();
                KeynoteEntry entry = new KeynoteEntry(id, parentId, discription);
                AppPenalKeynoteManager.entryTableKeynote.Add(entry);
            }
            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.DataSource = frmKeynoteManager.createtestdata();
            AppPenalKeynoteManager.groupKeyNoteTree = new Subro.Controls.DataGridViewGrouper(AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote);
            AppPenalKeynoteManager.groupKeyNoteTree.SetGroupOn("ParentId");
            AppPenalKeynoteManager.groupKeyNoteTree.DisplayGroup += frmKeynoteManager.grouper_DisplayGroup;
            try
            {
                AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[AppPenalKeynoteManager.indexRowCurrent + 1].Selected = true;
                AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.FirstDisplayedScrollingRowIndex = AppPenalKeynoteManager.indexRowCurrent;
            }
            catch { }
            AppPenalKeynoteManager.myFormAddKeynote.Close();
        }

     

        private void frmAddKeyNote_Load_1(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }
    }
}
