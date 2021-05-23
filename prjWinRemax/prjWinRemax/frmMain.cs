using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace prjWinRemax
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                frmAdmin obj1 = new frmAdmin();
                obj1.Show();
            }

            else if(txtUsername.Text == "employee" && txtPassword.Text == "employee")
            {
                frmAgent obj2 = new frmAgent();
                obj2.Show();
            }

            else if (txtUsername.Text == "user" && txtPassword.Text == "user")
            {
                frmUser obj3 = new frmUser();
                obj3.Show();
            }

            else
            {
                MessageBox.Show("Incorrect username or password","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Create a global dataset
            clsGlobal.mySet = new DataSet();

            clsGlobal.myCon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_REMAX;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            clsGlobal.myCon.Open();

            // Re cuperate and insert the table agents from the database to the dataset.
            SqlCommand myCmd = new SqlCommand("SELECT * FROM agents", clsGlobal.myCon);
            clsGlobal.adpEmployees = new SqlDataAdapter(myCmd);
            clsGlobal.adpEmployees.Fill(clsGlobal.mySet, "agents");

            // Re cuperate and insert the table clients from the database to the dataset.
            myCmd = new SqlCommand("SELECT * FROM Clients", clsGlobal.myCon);
            clsGlobal.adpClients = new SqlDataAdapter(myCmd);
            clsGlobal.adpClients.Fill(clsGlobal.mySet, "clients");

            // Re cuperate and insert the table houses from the database to the dataset.
            myCmd = new SqlCommand("SELECT * FROM houses", clsGlobal.myCon);
            clsGlobal.adpHouses = new SqlDataAdapter(myCmd);
            clsGlobal.adpHouses.Fill(clsGlobal.mySet, "houses");
        }
    }
}
