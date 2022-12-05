using Business;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace View.WinFormApp
{
    public partial class VisualFormer : Form
    {
        private static UserBLL manipulator = new UserBLL();

        public VisualFormer()
        {
            InitializeComponent();
            ListData();
        }

        public void ListData()
        {
            organizer.Controls.Remove(organizer.GetControlFromPosition(0, 1));

            List<string> users = manipulator.ListData();
            int totalData = users.Count;

            if (totalData > 0)
            {
                #region Header
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.Dock = DockStyle.Fill;

                int columns = 6;
                panel.ColumnCount = columns;
                for (int a = 0; a < columns; a++)
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66F));

                panel.RowCount = 1;
                string[] labels = new string[] { "Id", "Name", "Email", "Read", "Delete", "Update" };
                for (int i = 0; i < columns; i++)
                    panel.Controls.Add(new Label() { Text = labels[i], TextAlign = ContentAlignment.MiddleCenter }, i, 0);
                #endregion

                string[] splitData;
                for (int j = 1; j < totalData; j++)
                {
                    panel.RowCount++;
                    int actualRow = panel.RowCount - 1;

                    splitData = users[j].Split(' ');
                    string id = splitData[0];
                    string name = splitData[2];
                    string email = splitData[4];

                    #region Buttons
                    Button btnRead = new Button();
                    btnRead.Text = "Read Details";
                    btnRead.Click += (sender, EventArgs) => { ReadData(sender, EventArgs, Convert.ToInt32(id)); };
                    btnRead.Dock = DockStyle.Top;
                    btnRead.TextAlign = ContentAlignment.MiddleCenter;

                    Button btnDelete = new Button();
                    btnDelete.Text = "Delete User";
                    btnDelete.Click += (sender, EventArgs) => { DeleteData(sender, EventArgs, Convert.ToInt32(id), email); };
                    btnDelete.Dock = DockStyle.Top;
                    btnDelete.TextAlign = ContentAlignment.MiddleCenter;

                    Button btnUpdate = new Button();
                    btnUpdate.Text = "Update Info";
                    btnUpdate.Click += (sender, EventArgs) => { UpdateData(sender, EventArgs, manipulator.Retrieve(Convert.ToInt32(id))); };
                    btnUpdate.Dock = DockStyle.Top;
                    btnUpdate.TextAlign = ContentAlignment.MiddleCenter;
                    #endregion

                    #region TableLayoutPanel
                    panel.Controls.Add(new Label() { Text = id, TextAlign = ContentAlignment.MiddleCenter }, 0, actualRow);
                    panel.Controls.Add(new Label() { Text = name, TextAlign = ContentAlignment.MiddleCenter }, 1, actualRow);
                    panel.Controls.Add(new Label() { Text = email, TextAlign = ContentAlignment.MiddleCenter }, 2, actualRow);
                    panel.Controls.Add(btnRead, 3, actualRow);
                    panel.Controls.Add(btnDelete, 4, actualRow);
                    panel.Controls.Add(btnUpdate, 5, actualRow);
                    #endregion
                }

                organizer.Controls.Add(panel, 0, 1);

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
            organizer.Controls.Add(place, 0, 1);
        }

        public void ReadData(object sender, EventArgs e, int id)
        {            
            User targetUser = manipulator.Retrieve(id);
            Read form = new Read(targetUser);
            form.ShowDialog();
        }
        public void UpdateData(object sender, EventArgs e, User targetUser)
        {
            Update form = new Update(targetUser, manipulator);
            form.ShowDialog();
            ListData();
        }
        public void DeleteData(object sender, EventArgs e, int id, string email)
        {
            Delete form = new Delete(id, email, manipulator);
            form.ShowDialog();
            ListData();
        }

        private void Button_CreateNew_Click(object sender, EventArgs e)
        {
            Create form = new Create(manipulator);
            form.ShowDialog();
            ListData();
        }
    }
}
