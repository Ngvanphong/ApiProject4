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
    public partial class frmMoveKeynote : System.Windows.Forms.Form
    {
        public frmMoveKeynote()
        {
            InitializeComponent();
        }

        private void btnKeynoteMoveBinding_Click(object sender, EventArgs e)
        {
            string idParent = AppPenalKeynoteManager.myFormKeynoteMove.textBoxIdKeynote.Text;
            int count = AppPenalKeynoteManager.entryTableKeynote.Where(x => x.Key == idParent).Count();
            if (count == 0)
            {
                MessageBox.Show("Id of keynote group is not existed.");
                return;
            }
            var rowSelect = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.SelectedRows;

            foreach(DataGridViewRow item in rowSelect)
            {
                string value = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[item.Index].Cells[1].Value.ToString();
                string text = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[item.Index].Cells[2].Value.ToString();
                var entryOld = AppPenalKeynoteManager.entryTableKeynote.Where(x => x.Key == value).First();
                KeynoteEntry entryNew = new KeynoteEntry(value, idParent, text);
                AppPenalKeynoteManager.entryTableKeynote.Remove(entryOld);
                AppPenalKeynoteManager.entryTableKeynote.Add(entryNew);
            }

            AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.DataSource = frmKeynoteManager.createtestdata();
            AppPenalKeynoteManager.groupKeyNoteTree = new Subro.Controls.DataGridViewGrouper(AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote);
            AppPenalKeynoteManager.groupKeyNoteTree.SetGroupOn("ParentId");
            AppPenalKeynoteManager.groupKeyNoteTree.DisplayGroup += frmKeynoteManager.grouper_DisplayGroup;
            AppPenalKeynoteManager.myFormKeynoteMove.Close();

        }
       

        private void frmMoveKeynote_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        private void frmMoveKeynote_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
        }

    }
}
