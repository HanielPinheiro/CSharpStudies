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
        private static UserBLL businessRules = new UserBLL();
        private static UserValidator validator = new UserValidator();
        private List<User> users;
        private TableLayoutPanel panel;
        private Button btnRead, btnDelete, btnUpdate;
        private string name, email;

        private int totalData, columns = 6, id = 0, actualRow = 0;

        public VisualFormer()
        {
            try
            {
                InitializeComponent();
                ListData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void ListData()
        {
            try
            {
                organizer.Controls.Remove(organizer.GetControlFromPosition(0, 1));

                users = businessRules.ListData();
                totalData = users.Count;

                if (totalData > 0)
                    CreatePanel();
                else
                    EmptyBd();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Panel Methods
        private void CreatePanel()
        {
            try
            {
                InitializePanel();

                foreach (User user in users)
                {
                    panel.RowCount++;
                    actualRow++;

                    id = user.Id;
                    name = user.Name;
                    email = user.Email;

                    CreateButtons();
                    AddButtonsToPanel();
                }

                organizer.Controls.Add(panel, 0, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InitializePanel()
        {
            try
            {
                panel = new TableLayoutPanel();
                panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                panel.Dock = DockStyle.Fill;

                DefineColumnsSize();

                CreateHeader();

                actualRow = 0;
                id = 0;
                name = null;
                email = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DefineColumnsSize()
        {
            try
            {
                panel.ColumnCount = columns;
                for (int a = 0; a < columns; a++)
                    panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66F));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateHeader()
        {
            try
            {
                panel.RowCount = 1;
                string[] labels = new string[] { "Id", "Name", "Email", "Read", "Delete", "Update" };
                for (int i = 0; i < columns; i++)
                    panel.Controls.Add(new Label() { Text = labels[i], TextAlign = ContentAlignment.MiddleCenter }, i, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateButtons()
        {
            try
            {
                btnRead = new Button();
                btnRead.Text = "Read Details";
                btnRead.Click += (sender, EventArgs) => { ReadData(sender, EventArgs, Convert.ToInt32(id)); };
                btnRead.Dock = DockStyle.Top;
                btnRead.TextAlign = ContentAlignment.MiddleCenter;

                btnDelete = new Button();
                btnDelete.Text = "Delete User";
                btnDelete.Click += (sender, EventArgs) => { DeleteData(sender, EventArgs, Convert.ToInt32(id), email); };
                btnDelete.Dock = DockStyle.Top;
                btnDelete.TextAlign = ContentAlignment.MiddleCenter;

                btnUpdate = new Button();
                btnUpdate.Text = "Update Info";
                btnUpdate.Click += (sender, EventArgs) => { UpdateData(sender, EventArgs, businessRules.Retrieve(Convert.ToInt32(id))); };
                btnUpdate.Dock = DockStyle.Top;
                btnUpdate.TextAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddButtonsToPanel()
        {
            try
            {
                panel.Controls.Add(new Label() { Text = id.ToString(), TextAlign = ContentAlignment.MiddleCenter }, 0, actualRow);
                panel.Controls.Add(new Label() { Text = name, TextAlign = ContentAlignment.MiddleCenter }, 1, actualRow);
                panel.Controls.Add(new Label() { Text = email, TextAlign = ContentAlignment.MiddleCenter }, 2, actualRow);
                panel.Controls.Add(btnRead, 3, actualRow);
                panel.Controls.Add(btnDelete, 4, actualRow);
                panel.Controls.Add(btnUpdate, 5, actualRow);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EmptyBd()
        {
            try
            {
                Label place = new Label();
                place.Dock = DockStyle.Fill;
                place.TextAlign = ContentAlignment.MiddleCenter;
                place.BorderStyle = BorderStyle.FixedSingle;
                place.Text = "The database is empty, add a new contact!";
                organizer.Controls.Add(place, 0, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Button Methods
        private void ReadData(object sender, EventArgs e, int id)
        {
            try
            {
                User targetUser = businessRules.Retrieve(id);
                Read form = new Read(targetUser);
                form.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void UpdateData(object sender, EventArgs e, User targetUser)
        {
            try
            {
                Update form = new Update(targetUser, businessRules);
                form.ShowDialog();
                ListData();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DeleteData(object sender, EventArgs e, int id, string email)
        {
            try
            {
                Delete form = new Delete(id, email, businessRules);
                form.ShowDialog();
                ListData();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Button_CreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                Create form = new Create(businessRules);
                form.ShowDialog();
                ListData();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
