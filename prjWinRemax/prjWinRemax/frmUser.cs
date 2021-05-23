using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinRemax
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            tabHouses = clsGlobal.mySet.Tables["houses"];
            // Display the first (at index 0) datarow ( or record) in the textboxes
            currentIndex = 0;
            DisplayHouses();
        }
        DataTable tabHouses;
        int currentIndex;
        private void DisplayHouses()
        {
            // Put the data in the textboxes
            txtHouseNumber.Text = tabHouses.Rows[currentIndex]["HouseNumber"].ToString();
            txtAddress.Text = tabHouses.Rows[currentIndex]["Address"].ToString();
            txtRooms.Text = tabHouses.Rows[currentIndex]["Rooms"].ToString();
            txtType.Text = tabHouses.Rows[currentIndex]["Type"].ToString();
            dtPicker.Value = Convert.ToDateTime(tabHouses.Rows[currentIndex]["DateListed"]);
            txtRefSeller.Text = tabHouses.Rows[currentIndex]["RefSeller"].ToString();
            // To display the current record number on the total
            lblHouses.Text = "House " + (currentIndex + 1) + " on a total of " + tabHouses.Rows.Count;
        }

        private void btnFirstHouses_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            DisplayHouses();
        }

        private void btnPreviousHouses_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
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
            if (currentIndex < (tabHouses.Rows.Count - 1))
            {
                currentIndex++;
                DisplayHouses();
            }
        }

        private void btnLastHouses_Click(object sender, EventArgs e)
        {
            currentIndex = tabHouses.Rows.Count - 1;
            DisplayHouses();
        }
    }
}
