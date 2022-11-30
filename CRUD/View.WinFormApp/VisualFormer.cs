using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.WinFormApp
{
    public partial class VisualFormer : Form
    {
        private static DataManipulation manipulator = new DataManipulation();

        public VisualFormer()
        {
            InitializeComponent();
            ListData();
        }

        public void ListData()
        {            
            organizer.Controls.Remove(organizer.GetControlFromPosition(0, 1));

            if (manipulator.ListData().Count == 0)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                organizer.Controls.Add(new Label() {Text = "abu" }, 0, 1) ;
                panel.Dock = DockStyle.Fill;
                CreateHeader(panel);
                
            }
            else EmptyBd();
        }

        public void EmptyBd()
        {
            Label place = new Label();
            place.Dock = DockStyle.Fill;
            place.TextAlign = ContentAlignment.MiddleCenter;
            place.BorderStyle = BorderStyle.FixedSingle;
            place.Text = "The database is empty, add a new contact!";
            organizer.Controls.Add(place,0,1);
        }

        public void CreateHeader(TableLayoutPanel panel)
        {
            int columns = panel.ColumnCount;
            string[] labels = new string[] { "Id", "Name", "Email", "Read", "Delete", "Update" };
            for (int i = 0; i < columns; i++)
                panel.Controls.Add(new Label() { Text = labels[i] }, i, 0);
        }
    }
}
