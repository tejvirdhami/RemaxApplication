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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }
        // form global variables
        DataTable tabEmployees, tabClients, tabHouses;
        int currentIndex, currentIndexClient, currentIndexHouses;
        string mode;
        
        private void frmAdmin_Load(object sender, EventArgs e)
        {

            tabEmployees = clsGlobal.mySet.Tables["agents"];
            tabClients = clsGlobal.mySet.Tables["clients"];
            tabHouses = clsGlobal.mySet.Tables["houses"];
            // Display the first (at index 0) datarow ( or record) in the textboxes
            currentIndex = currentIndexClient = currentIndexHouses = 0;
            DisplayEmployees();
            DisplayClients();
            DisplayHouses();
            btnCancel.Enabled = btnSave.Enabled = btnCancelClient.Enabled = btnSaveClient.Enabled = btnCancelHouses.Enabled = btnSaveHouses.Enabled = false;
        }
        private void DisableAllButtons()
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnFirst.Enabled = btnLast.Enabled = btnAddClient.Enabled = btnEditClient.Enabled = btnDeleteClient.Enabled = btnNextClient.Enabled = btnPreviousClient.Enabled = btnFirstClient.Enabled = btnLastClient.Enabled =
               btnAddHouses.Enabled = btnEditHouses.Enabled = btnDeleteHouses.Enabled = btnNextHouses.Enabled = btnPreviousHouses.Enabled = btnFirstHouses.Enabled = btnLastHouses.Enabled = false;
        }

        private void EnableAllButtons()
        {
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnNext.Enabled = btnPrevious.Enabled = btnFirst.Enabled = btnLast.Enabled = btnAddClient.Enabled = btnEditClient.Enabled = btnDeleteClient.Enabled = btnNextClient.Enabled = btnPreviousClient.Enabled = btnFirstClient.Enabled = btnLastClient.Enabled =
               btnAddHouses.Enabled = btnEditHouses.Enabled = btnDeleteHouses.Enabled = btnNextHouses.Enabled = btnPreviousHouses.Enabled = btnFirstHouses.Enabled = btnLastHouses.Enabled = true;
        }

        private void DisplayEmployees()
        {
            // Put the data in the textboxes
            txtNumber.Text = tabEmployees.Rows[currentIndex]["EmployeeNumber"].ToString();
            txtFirstName.Text = tabEmployees.Rows[currentIndex]["FirstName"].ToString();
            txtLastName.Text = tabEmployees.Rows[currentIndex]["LastName"].ToString();
            txtEmail.Text = tabEmployees.Rows[currentIndex]["Email"].ToString();
            txtPhone.Text = tabEmployees.Rows[currentIndex]["Phone"].ToString();
            // to display the current record number on the total
            lblEmployees.Text = "Employee " + (currentIndex + 1) + " on a total of " + tabEmployees.Rows.Count;
        }

        private void DisplayClients()
        {
            // Put the data in the textboxes
            txtClientNumber.Text = tabClients.Rows[currentIndexClient]["ClientNumber"].ToString();
            txtFirstNameClient.Text = tabClients.Rows[currentIndexClient]["FirstName"].ToString();
            txtLastNameClient.Text = tabClients.Rows[currentIndexClient]["LastName"].ToString();
            txtEmailClient.Text = tabClients.Rows[currentIndexClient]["Email"].ToString();
            txtStatus.Text = tabClients.Rows[currentIndexClient]["Status"].ToString();
            txtPhoneClient.Text = tabClients.Rows[currentIndexClient]["Phone"].ToString();
            txtRefAgent.Text = tabClients.Rows[currentIndexClient]["RefAgent"].ToString();
            // to display the current record number on the total
            lblClients.Text = "Client " + (currentIndexClient + 1) + " on a total of " + tabClients.Rows.Count;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtNumber.Text = txtFirstName.Text = txtLastName.Text = txtEmail.Text = txtPhone.Text = "";
            txtNumber.Focus();
            lblEmployees.Text = "--- ADDING MODE ---";
            DisableAllButtons();
            btnSave.Enabled = btnCancel.Enabled = true;
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtFirstName.Focus();
            lblEmployees.Text = "--- EDITING MODE ---";
            DisableAllButtons();
            btnSave.Enabled = btnCancel.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this Employee ?", "Deletion Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete the record at the currentindex
                tabEmployees.Rows[currentIndex].Delete();

                // Save the contents of the myset.tabels["agents"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpEmployees);
                clsGlobal.adpEmployees.Update(clsGlobal.mySet, "agents");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("agents");
                clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "agents");

                currentIndex = 0;
                DisplayEmployees();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow currentRow;
            if (mode == "add")
            {
                currentRow = tabEmployees.NewRow();
                // affect the contents of textboxes in the currentrow
                currentRow["EmployeeNumber"] = txtNumber.Text;
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["Email"] = txtEmail.Text;
                currentRow["Phone"] = txtPhone.Text;
                // add the cureentrow in the collection tabagents.Rows
                tabEmployees.Rows.Add(currentRow);

                // Save contents of the myset.tabels["agents"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpEmployees);
                clsGlobal.adpEmployees.Update(clsGlobal.mySet, "agents");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("agents");
                clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "agents");

                currentIndex = tabEmployees.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                currentRow = tabEmployees.Rows[currentIndex];
                // change the contents of the currentrow from the textboxes 
                currentRow["EmployeeNumber"] = txtNumber.Text;
                currentRow["FirstName"] = txtFirstName.Text;
                currentRow["LastName"] = txtLastName.Text;
                currentRow["Email"] = txtEmail.Text;
                currentRow["Phone"] = txtPhone.Text;

                // Savethe contents of the myset.tabels["agents"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpEmployees);
                clsGlobal.adpEmployees.Update(clsGlobal.mySet, "agents");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("agents");
                clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "agents");
            }
            mode = "";
            DisplayEmployees();
            EnableAllButtons();
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayEmployees();
            EnableAllButtons();
            btnSave.Enabled = btnCancel.Enabled = false;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayEmployees();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayEmployees();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < (tabEmployees.Rows.Count - 1))
            {
                currentIndex++;
                DisplayEmployees();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentIndex = tabEmployees.Rows.Count - 1;
            DisplayEmployees();
        }


        private void btnAddClient_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtClientNumber.Text = txtFirstNameClient.Text = txtLastNameClient.Text = txtEmailClient.Text = txtStatus.Text = txtPhoneClient.Text = txtRefAgent.Text = "";
            txtClientNumber.Focus();
            lblClients.Text = "--- ADDING MODE ---";
            DisableAllButtons();
            btnSaveClient.Enabled = btnCancelClient.Enabled = true;
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtFirstNameClient.Focus();
            lblClients.Text = "--- EDITING MODE ---";
            DisableAllButtons();
            btnSaveClient.Enabled = btnCancelClient.Enabled = true;
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this Client ?", "Deletion Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Delete the record positioned at the currentindex
                tabClients.Rows[currentIndexClient].Delete();

                // Save (or synchronize) the contents of the myset.tabels["clients"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.mySet, "clients");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("clients");
                clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");

                currentIndexClient = 0;
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
                // add the cureentrow in the collection tabClients.Rows
                tabClients.Rows.Add(currentRow);

                // Save the contents of the myset.tabels["agents"] to the database
                SqlCommandBuilder myBuilder = new SqlCommandBuilder(clsGlobal.adpClients);
                clsGlobal.adpClients.Update(clsGlobal.mySet, "clients");
                // Refresh the datatable with the content of the database in case of changes
                clsGlobal.mySet.Tables.Remove("clients");
                clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");

                currentIndexClient = tabClients.Rows.Count - 1;
            }
            else if (mode == "edit")
            {
                currentRow = tabClients.Rows[currentIndexClient];
                // change the contents of the currentrow from the textboxes 
                currentRow["ClientNumber"] = txtClientNumber.Text;
                currentRow["FirstName"] = txtFirstNameClient.Text;
                currentRow["LastName"] = txtLastNameClient.Text;
                currentRow["Email"] = txtEmailClient.Text;
                currentRow["Status"] = txtStatus.Text;
                currentRow["Phone"] = txtPhoneClient.Text;
                currentRow["RefAgent"] = txtRefAgent.Text;

                // Save (or synchronize) the contents of the myset.tabels["clients"] to the database
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
            currentIndexClient = 0;
            DisplayClients();
        }

        private void btnPreviousClient_Click(object sender, EventArgs e)
        {
            if (currentIndexClient > 0)
            {
                currentIndexClient--;
                DisplayClients();
            }
        }

        private void btnNextClient_Click(object sender, EventArgs e)
        {
            if (currentIndexClient < (tabClients.Rows.Count - 1))
            {
                currentIndexClient++;
                DisplayClients();
            }
        }

        private void btnLastClient_Click(object sender, EventArgs e)
        {
            currentIndexClient = tabClients.Rows.Count - 1;
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

                // Save the contents of the myset.tabels["houses"] to the database
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

                // Save the contents of the myset.tabels["houses"] to the database
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

                // Save the contents of the myset.tabels["houses"] to the database
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
