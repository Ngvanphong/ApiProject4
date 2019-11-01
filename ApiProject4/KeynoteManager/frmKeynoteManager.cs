
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Subro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiProject4.KeynoteManager
{
    public partial class frmKeynoteManager : System.Windows.Forms.Form
    {
        private KeynoteManagerHandler _handlerKeynote;
        private ExternalEvent _eventKeynote;
        private KeynoteReloadHandler _handlerKeynoteReload;
        private ExternalEvent _eventKeynoteReload;
        public frmKeynoteManager(ExternalEvent eventKeynote, KeynoteManagerHandler handlerKeynote,
            ExternalEvent eventKeynoteReload,KeynoteReloadHandler handlerKeynoteReload)
        {
            InitializeComponent();
            _handlerKeynote = handlerKeynote;
            _eventKeynote = eventKeynote;
            _handlerKeynoteReload = handlerKeynoteReload;
            _eventKeynoteReload = eventKeynoteReload;
            dataGridViewKeynote.DataSource = createtestdata();
            //the component can be added in designer, or as done here on the fly
            AppPenalKeynoteManager.groupKeyNoteTree = new Subro.Controls.DataGridViewGrouper(dataGridViewKeynote);
            AppPenalKeynoteManager.groupKeyNoteTree.SetGroupOn("ParentId");
            AppPenalKeynoteManager.groupKeyNoteTree.DisplayGroup += grouper_DisplayGroup;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void frmKeynoteManager_Load(object sender, EventArgs e)
        {

        }



        public static BindingList<TestData> createtestdata()
        {
            var list = new BindingList<TestData>();

            foreach (var item in AppPenalKeynoteManager.entryTableKeynote)
            {
                string parentId = item.ParentKey.ToString();
                string id = item.Key.ToString();
                string discription = item.KeynoteText;
                list.Add(
                    new TestData
                    {
                        ParentId = parentId,
                        Id = id,
                        Discription = discription
                    }
                    );
            }

            return list;
        }
        //optionally, you can customize the grouping display by subscribing to the DisplayGroup event
        public static void grouper_DisplayGroup(object sender, GroupDisplayEventArgs e)
        {
            e.BackColor = (e.Group.GroupIndex % 2) == 0 ? System.Drawing.Color.Orange : System.Drawing.Color.LightBlue;
            e.Header = "[" + e.Header + "], grp: " + e.Group.GroupIndex;
            e.DisplayValue = "ParentId: " + e.DisplayValue;
            e.Summary = "contains " + e.Group.Count + " rows";
        }


        private void dataGridViewKeynote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AppPenalKeynoteManager.groupKeyNoteTree.CollapseAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppPenalKeynoteManager.groupKeyNoteTree.ExpandAll();
        }

        private void btnSearchKeynote_Click(object sender, EventArgs e)
        {
            //AppPenalKeynoteManager.isSearchKeynote = true;
            _eventKeynote.Raise();

        }

        private void btnDefaultKeynote_Click(object sender, EventArgs e)
        {
           // AppPenalKeynoteManager.isSearchKeynote = false;
            _eventKeynote.Raise();
        }

        private void btnAddRowKeynote_Click(object sender, EventArgs e)
        {
            AppPenalKeynoteManager.ShowAddKeynote();
            string[] row = new string[] { string.Empty, string.Empty, string.Empty };
            try
            {
                var index = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.CurrentRow.Index;
                var value = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[index].Cells[0].Value.ToString();
                string value2 = AppPenalKeynoteManager.myFormKeynoteManager.dataGridViewKeynote.Rows[index].Cells[1].Value.ToString();
                row = new string[] { value, value2, "" };
                AppPenalKeynoteManager.myFormAddKeynote.dataGridViewAddKeynote.Rows.Add(row);
                AppPenalKeynoteManager.indexRowCurrent = index;
            }
            catch { }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _eventKeynoteReload.Raise();
           
        }
    }
    public class TestData : INotifyPropertyChanged
    {
        string parentId;
        public string ParentId { get { return parentId; } set { parentId = value; NotifyChanged("ParentId"); } }
        string id;
        public string Id { get { return id; } set { id = value; NotifyChanged("Id"); } }
        string discription;
        public string Discription { get { return discription; } set { discription = value; NotifyChanged("Discription"); } }

        void NotifyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    
}
