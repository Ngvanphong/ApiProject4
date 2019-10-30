
using Autodesk.Revit.UI;
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

namespace ApiProject4.KeynoteManager
{
    public partial class frmKeynoteManager : Form
    {
        private KeynoteManagerHandler _handlerKeynote;
        private ExternalEvent _eventKeynote;
        public frmKeynoteManager(ExternalEvent eventKeynote, KeynoteManagerHandler handlerKeynote)
        {
            InitializeComponent();
            _handlerKeynote = handlerKeynote;
            _eventKeynote = eventKeynote;
            dataGridViewKeynote.DataSource = createtestdata();
            //the component can be added in designer, or as done here on the fly
            var grouper = new Subro.Controls.DataGridViewGrouper(dataGridViewKeynote);
            grouper.SetGroupOn("ParentId");
            grouper.DisplayGroup += grouper_DisplayGroup;
        }
        //optionally, you can customize the grouping display by subscribing to the DisplayGroup event
        void grouper_DisplayGroup(object sender, GroupDisplayEventArgs e)
        {
            e.BackColor = (e.Group.GroupIndex % 2) == 0 ? Color.Orange : Color.LightBlue;
            e.Header = "[" + e.Header + "], grp: " + e.Group.GroupIndex;
            e.DisplayValue = "ParentId: " + e.DisplayValue;
            e.Summary = "contains " + e.Group.Count + " rows";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void frmKeynoteManager_Load(object sender, EventArgs e)
        {

        }



        BindingList<TestData> createtestdata()
        {
            var list = new BindingList<TestData>();

            var rnd = new Random();
            var dt = DateTime.Today;

            for (int i = 0; i < 100; i++)
            {
                list.Add(
                    new TestData
                    {
                        ParentId = new string((char)('A' + rnd.Next(0, 25)), 8),
                        Id = rnd.Next(0, 50).ToString(),
                        Discription = dt.AddDays(rnd.Next(-100, 100)).ToString(),
                       
                    }
                    );
            };
            return list;
        }

        private void dataGridViewKeynote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class TestData : INotifyPropertyChanged
    {
        string parentId;
        public string ParentId { get { return parentId; } set { parentId = value; NotifyChanged("ParentId"); } }
        string id;
        public string Id { get { return id; } set { id = value; NotifyChanged("Id"); } }
        string  discription;
        public string Discription { get { return discription; } set { discription = value; NotifyChanged("Discription"); } }

        void NotifyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
