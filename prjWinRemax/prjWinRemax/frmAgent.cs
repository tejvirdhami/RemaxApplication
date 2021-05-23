using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace prjWinRemax
{
    public partial class frmAgent : Form
    {
        public frmAgent()
        {
            InitializeComponent();
        }
        // form global variables
        DataTable tabClients, tabHouses;
        int currentIndex, currentIndexHouses;
        string mode;

        private void frmAgent_Load(object sender, EventArgs e)
        {
            tabClients = clsGlobal.mySet.Tables["clients"];
            tabHouses = clsGlobal.mySet.Tables["houses"];
            // Display the first datarow in the textboxes
            currentIndex = 0;
            currentIndexHouses = 0;
            DisplayClients();
            DisplayHouses();
            btnCancelClient.Enabled = btnSaveClient.Enabled = btnCancelHouses.Enabled = btnSaveHouses.Enabled = false;
        }

        private void DisplayClients()
        {
            // Put the data in the textboxes
            txtClientNumber.Text = tabClients.Rows[currentIndex]["ClientNumber"].ToString();
            txtFirstNameClient.Text = tabClients.Rows[currentIndex]["FirstName"].ToString();
            txtLastNameClient.Text = tabClients.Rows[currentIndex]["LastName"].ToString();
            txtEmailClient.Text = tabClients.Rows[currentIndex]["Email"].ToString();
            txtStatus.Text = tabClients.Rows[currentIndex]["Status"].ToString();
            txtPhoneClient.Text = tabClients.Rows[currentIndex]["Phone"].ToString();
            txtRefAgent.Text = tabClients.Rows[currentIndex]["RefAgent"].ToString();
            // To display the current record number on the total
            lblClients.Text = "Client " + (currentIndex + 1) + " on a total of " + tabClients.Rows.Count;
        }

        private void DisplayHouses()
        {
            // Put the data in the textboxes
            txtHouseNumber.Text = tabHouses.Rows[currentIndexHouses]["HouseNumber"].ToString();
            txtAddress.Text = tabHouses.Rows[currentIndexHouses]["Address"].ToString();
            txtRooms.Text = tabHouses.Rows[currentIndexHouses]["Rooms"].ToString();
            txtType.Text = tabHouses.Rows[currentIndexHouses]["Type"].ToString();
            dtPicker.Value = Convert.ToDateTime(tabHouses.Rows[currentIndexHouses]["DateListed"]);
            txtRefSeller.Text = tabHouses.Rows[currentIndexHouses]["RefSeller"].ToString();
            // To display the current record number on the total
            lblHouses.Text = "House " + (currentIndexHouses + 1) + " on a total of " + tabHouses.Rows.Count;
        }
        private void DisableAllButtons()
        {
           btnAddClient.Enabled = btnEditClient.Enabled = btnDeleteClient.Enabled = btnNextClient.Enabled = btnPreviousClient.Enabled = btnFirstClient.Enabled = btnLastClient.Enabled =
               btnAddHouses.Enabled = btnEditHouses.Enabled = btnDeleteHouses.Enabled = btnNextHouses.Enabled = btnPreviousHouses.Enabled = btnFirstHouses.Enabled = btnLastHouses.Enabled = false;
        }

        private void EnableAllButtons()
        {
         btnAddClient.Enabled = btnEditClient.Enabled = btnDeleteClient.Enabled = btnNextClient.Enabled = btnPreviousClient.Enabled = btnFirstClient.Enabled = btnLastClient.Enabled =
               btnAddHouses.Enabled = btnEditHouses.Enabled = btnDeleteHouses.Enabled = btnNextHouses.Enabled = btnPreviousHouses.Enabled = btnFirstHouses.Enabled = btnLastHouses.Enabled = true;
        }


        private void btnAddClient_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtClientNumber.Text = txtFirstNameClient.Text = txtLastNameClient.Text = txtEmailClient.Text = txtPhoneClient.Text = txtStatus.Text = txtPhoneClient.Text = txtRefAgent.Text = "";
            txtClientNumber.Focus();
            lblClients.Text = "--- ADDING MODE ---";
            DisableAllButtons();
            btnCancelClient.Enabled = btnSaveClient.Enabled = true;
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtFirstNameClient.Focus();
            lblClients.Text = "--- EDITING MODE ---";
            DisableAllButtons();
            btnCancelClient.Enabled = btnSaveClient.Enabled = true;
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this Client ?", "Deletion Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete the record at the currentindex
                tabClients.Rows[currentIndex].Delete();

                // Save the contents of the myset.tabels["Clients"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.mySet, "clients");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("clients");
                clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");

                currentIndex = 0;
                DisplayClients();
            }
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
            if (mode == "add")
            {
                currentRow = tabClients.NewRow();
                // affect the contents of textboxes in the currentrow
                currentRow["ClientNumber"] = txtClientNumber.Text;
                currentRow["FirstName"] = txtFirstNameClient.Text;
                currentRow["LastName"] = txtLastNameClient.Text;
                currentRow["Email"] = txtEmailClient.Text;
                currentRow["Status"] = txtStatus.Text;
                currentRow["Phone"] = txtPhoneClient.Text;
                currentRow["RefAgent"] = txtRefAgent.Text;
                // add the cureentrow in the collection tabclients.Rows
                tabClients.Rows.Add(currentRow);

                // Save the contents of the myset.tabels["agents"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.mySet, "clients");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("clients");
                clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");

                currentIndex = tabClients.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                currentRow = tabClients.Rows[currentIndex];
                // change the contents of the currentrow from the textboxes 
                currentRow["ClientNumber"] = txtClientNumber.Text;
                currentRow["FirstName"] = txtFirstNameClient.Text;
                currentRow["LastName"] = txtLastNameClient.Text;
                currentRow["Email"] = txtEmailClient.Text;
                currentRow["Status"] = txtStatus.Text;
                currentRow["Phone"] = txtPhoneClient.Text;
                currentRow["RefAgent"] = txtRefAgent.Text;

                // Save the contents of the myset.tabels["Clients"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.mySet, "clients");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("clients");
                clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");
            }
            mode = "";
            DisplayClients();
            EnableAllButtons();
            btnCancelClient.Enabled = btnSaveClient.Enabled = false;
        }

        private void btnCancelClient_Click(object sender, EventArgs e)
        {
            DisplayClients();
            EnableAllButtons();
            btnCancelClient.Enabled = btnSaveClient.Enabled = false;
        }

        private void btnFirstClient_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayClients();
        }

        private void btnPreviousClient_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayClients();
            }
        }

        private void btnNextClient_Click(object sender, EventArgs e)
        {
            if (currentIndex < (tabClients.Rows.Count - 1))
            {
                currentIndex++;
                DisplayClients();
            }
        }

        private void btnLastClient_Click(object sender, EventArgs e)
        {
            currentIndex = tabClients.Rows.Count - 1;
            DisplayClients();
        }


        private void btnAddHouses_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtHouseNumber.Text = txtAddress.Text = txtRooms.Text = txtType.Text = txtRefSeller.Text = "";
            txtHouseNumber.Focus();
            lblHouses.Text = "--- ADDING MODE ---";
            DisableAllButtons();
            btnSaveHouses.Enabled = btnCancelHouses.Enabled = true;
        }

        private void btnEditHouses_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtAddress.Focus();
            lblHouses.Text = "--- EDITING MODE ---";
            DisableAllButtons();
            btnSaveHouses.Enabled = btnCancelHouses.Enabled = true;
        }

        private void btnDeleteHouses_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this House ?", "Deletion Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete the record(or datarow) positioned at the currentindex
                tabHouses.Rows[currentIndexHouses].Delete();

                // Save (or synchronize) the contents of the myset.tabels["Houses"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouses);
                clsGlobal.adpHouses.Update(clsGlobal.mySet, "houses");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("houses");
                clsGlobal.adpHouses.Fill(clsGlobal.mySet, "houses");

                currentIndexHouses = 0;
                DisplayHouses();
            }
        }

        private void btnSaveHouses_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
            if (mode == "add")
            {
                currentRow = tabHouses.NewRow();
                currentRow["HouseNumber"] = txtHouseNumber.Text;
                currentRow["Address"] = txtAddress.Text;
                currentRow["Rooms"] = txtRooms.Text;
                currentRow["Type"] = txtType.Text;
                currentRow["DateListed"] = dtPicker.Value;
                currentRow["RefSeller"] = txtRefSeller.Text;

                tabHouses.Rows.Add(currentRow);

                // Save (or synchronize) the contents of the myset.tabels["houses"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouses);
                clsGlobal.adpHouses.Update(clsGlobal.mySet, "houses");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("houses");
                clsGlobal.adpHouses.Fill(clsGlobal.mySet, "houses");

                currentIndexHouses = tabHouses.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                currentRow = tabHouses.Rows[currentIndexHouses];
                // change the contents of the currentrow from the textboxes 
                currentRow["HouseNumber"] = txtHouseNumber.Text;
                currentRow["Address"] = txtAddress.Text;
                currentRow["Rooms"] = txtRooms.Text;
                currentRow["Type"] = txtType.Text;
                currentRow["DateListed"] = dtPicker.Value;
                currentRow["RefSeller"] = txtRefSeller.Text;

                // Save (or synchronize) the contents of the myset.tabels["houses"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpHouses);
                clsGlobal.adpHouses.Update(clsGlobal.mySet, "houses");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("houses");
                clsGlobal.adpHouses.Fill(clsGlobal.mySet, "houses");
            }
            mode = "";
            DisplayHouses();
            EnableAllButtons();
            btnSaveHouses.Enabled = btnCancelHouses.Enabled = false;
        }

        private void btnCancelHouses_Click(object sender, EventArgs e)
        {
            DisplayHouses();
            EnableAllButtons();
            btnSaveHouses.Enabled = btnCancelHouses.Enabled = false;
        }

        private void btnFirstHouses_Click(object sender, EventArgs e)
        {
            currentIndexHouses = 0;
            DisplayHouses();
        }

        private void btnPreviousHouses_Click(object sender, EventArgs e)
        {
            if (currentIndexHouses > 0)
            {
                currentIndexHouses--;
                DisplayHouses();
            }
        }

        private void btnCLoseHouses_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close this application?", "Quit? ",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNextHouses_Click(object sender, EventArgs e)
        {
            if (currentIndexHouses < (tabHouses.Rows.Count - 1))
            {
                currentIndexHouses++;
                DisplayHouses();
            }
        }

        private void btnLastHouses_Click(object sender, EventArgs e)
        {
            currentIndexHouses = tabHouses.Rows.Count - 1;
            DisplayHouses();
        }
    }
}
