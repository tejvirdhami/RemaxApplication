A.	Start by adding a short description of your project, and the languages (technologies) used:
1.	Language C#
2.	Microsoft Visual Studio 2019

B.	Present the print screens of yours forms, and have a detailed description of the functionalities (step by step).
 
1.	This is the opening tab of the dashboard.
2.	Click on the flag, you can access personal information.
 
3.	Now you can see personal information.
4.	Click on exit button then press OK button to exit personal information.

 

1.	This is the Generated numbers tab which contains lotto max and lotto 649.
2.	If you click on Lotto max button you will enter the lotto max application and if you click lotto 649 button you will enter lotto 649 application.
 
3.	If you click on generate button It will show 7( + 1 extra) random numbers numbers. And will store them in a text file.
4.	If you click on read file button, U can view the text files and the winning numbers.
 

 
1.	This is lotto 649 Application.
2.	If you click generate button, it will create 6(+1 extra) numbers and will store them in the text file.
3.	If you click on Read button, you can view the winning numbers.
 
4.	If you click on exit button, you can close the application by confirming yes.



 
1.	This is the third tab containing conversion applications.
2.	If you click on Money exchange button, you will enter money exchange application.
3.	If you click on temperature conversion button, you will enter temperature conversion application.
 
1.	This is the money exchange application.
2.	You need to select both the currencies to convert to, and convert from and enter the number.
3.	If you click on convert button, it will convert the currencies and store them in a text file.
4.	If you click in read file button ,you can view the exchanged currencies.
 
5.	You can exit the application by clicking on exit button.


 
1.	This is the temperature exchange application.
2.	You need to select one of the radio buttons and enter the temperature to be converted.
3.	If you click on convert button, it will convert the temperature depending on the button you selected and will Save the temperatures in a text file.
4.	If you click the read file button, you can view the text file containing the temperatures.
 
5.	If you click on exit button, you can exit the application buy confirming yes.



 
1.	This is the 4th tab containing the calculator.
2.	If you click on calculator button, you will enter the simple calculator application.

 

3.	Now you need to enter the first number, then select operation , then you need to enter second number and finally click on equal(=) to display the result.
4.	It will also store the calculations in a text file.
5.	If you click on clear, you can clear the screen.
6.	If you click on exit, you can exit the calculator application.

 
1.	This is the 5th tab containing the IP Validator.
2.	If you click on IP button, you will enter the IP validator application.
 
3.	Now you need to enter the IP address and click on validate IP to check if the IP is valid or not.
 
4.	If the IP is valid, it will show this result otherwise it will return error.

C.	Present the code of your application (forms).
	

LOTTO MAX :

/*Tejvir Singh
 * 7/21/2020*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool NumBr(int[] array, int a)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(a == array[i])
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = new int[8];
            int i = 0;
            int randomNumber = 0;
            while (i < 8)
            {
                do
                {
                    Random random = new Random();
                    randomNumber = random.Next(1, 49);
                }
                while (NumBr(nums, randomNumber));
                nums[i] = randomNumber;
                ++i;
            }
            textBox1.Text = Convert.ToString(nums[0] + "\r\n" + nums[1] + "\r\n" + nums[2] + "\r\n" + nums[3] + "\r\n" + nums[4] + "\r\n" + nums[5] + "\r\n" + nums[6] + "\r\n" + nums[7]);
            string numbers = Convert.ToString(nums[0] + "," + nums[1] + "," + nums[2] + "," + nums[3] + "," +  nums[4] + "," + nums[5] + "," + nums[6]);
            try
            {
                string path = "LottoNbrs.txt";
                DateTime lDate = DateTime.Now;
                if(!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Max,      {0},    {1}     Extra {2}", lDate.ToString(), numbers, Convert.ToString(nums[7]));
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("Max,      {0},    {1}     Extra {2}", lDate.ToString(), numbers, Convert.ToString(nums[7]));
                    }
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("LottoNbrs.txt"))
                {
                    String l = sr.ReadToEnd();
                    MessageBox.Show(l, "Tejvir's Lotto");
                }
            }
            catch (IOException ex1)
            {
                MessageBox.Show("The file cannot be read:");
                MessageBox.Show(ex1.Message, "Error");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

LOTTO 649:

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit this application?", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public bool FindNbrs(int a, int[]array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (a == array[i])
                    return true;
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] nums = new int[7];
            int randomNumber = 0;
            int i = 0;
            while(i < 7)
            {
                do
                {
                    Random random = new Random();
                    randomNumber = random.Next(1, 49);
                }
                while (FindNbrs(randomNumber, nums));
                nums[i] = randomNumber;
                ++i;
            }
            textBox1.Text = Convert.ToString(nums[0] + "\r\n" + nums[1] + "\r\n" + nums[2] + "\r\n" + nums[3] + "\r\n" + nums[4] + "\r\n" + nums[5] + "\r\n" + nums[6]);
            string numbers = Convert.ToString(nums[0] + "," + nums[1] + "," + nums[2] + "," + nums[3] + "," + nums[4] + "," + nums[5]);
            try
            {
                string path = "LottoNbrs.txt";
                DateTime lDate = DateTime.Now;
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("649,      {0},    {1}     Extra {2}", lDate.ToString(), numbers, Convert.ToString(nums[6]));
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("649,      {0},    {1}     Extra {2}", lDate.ToString(), numbers, Convert.ToString(nums[6]));
                    }
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("LottoNbrs.txt"))
                {
                    String l = sr.ReadToEnd();
                    MessageBox.Show(l, "Tejvir's Lotto 649");
                }
            }
            catch (IOException ex1)
            {
                MessageBox.Show("The file cannot be read:");
                MessageBox.Show(ex1.Message, "Error");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}


MONEY EXCHANGE:

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

namespace WindowsFormsProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quit the application\nMoney Exchange", "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool country = true;
            double to = 0, from;
            string convertTo = "", convertFrom = "";
            if(radioButton1.Checked)
            {
                to = Convert.ToDouble(textBox1.Text);
                convertFrom = "CAD";
            }
            else if(radioButton2.Checked)
            {
                to = Convert.ToDouble(textBox1.Text) * 1.34;
                convertFrom = "USD";
            }
            else if (radioButton3.Checked)
            {
                to = Convert.ToDouble(textBox1.Text) * 1.56;
                convertFrom = "EUR";
            }
            else if (radioButton4.Checked)
            {
                to = Convert.ToDouble(textBox1.Text) * 1.74;
                convertFrom = "GBP";
            }
            else if (radioButton5.Checked)
            {
                to = Convert.ToDouble(textBox1.Text) * 0.018;
                convertFrom = "INR";
            }
            else
            {
                MessageBox.Show("Kindly select currency to convert from");
                country = false;
            }
            if(radioButton6.Checked)
            {
                from = to;
                textBox2.Text = Convert.ToString(from);
                convertTo = "CAD";
            }
            else if (radioButton7.Checked)
            {
                from = to * 0.74;
                textBox2.Text = Convert.ToString(from);
                convertTo = "USD";
            }
            else if (radioButton8.Checked)
            {
                from = to * 0.64;
                textBox2.Text = Convert.ToString(from);
                convertTo = "EUR";
            }
            else if (radioButton9.Checked)
            {
                from = to * 0.59;
                textBox2.Text = Convert.ToString(from);
                convertTo = "GBP";
            }
            else if (radioButton10.Checked)
            {
                from = to * 55.50;
                textBox2.Text = Convert.ToString(from);
                convertTo = "INR";
            }
            else
            {
                MessageBox.Show("Please select a cureency to convert");
                country = false;
            }
            if(country)
            {
                string path = "MoneyConversions.txt";
                DateTime lDate = DateTime.Now;
                if(!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(textBox1.Text + " " + convertFrom + " = " + textBox2.Text + " " + convertTo + "        " + lDate.ToString());
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(textBox1.Text + " " + convertFrom + " = " + textBox2.Text + " " + convertTo + "        " + lDate.ToString());
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("MoneyConversions.txt"))
                {
                    String l = sr.ReadToEnd();
                    MessageBox.Show(l, "Tejvir's Money Conversion");
                }
            }
            catch (IOException ex1)
            {
                MessageBox.Show("The file cannot be read:");
                MessageBox.Show(ex1.Message, "Error");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}


TEMPERATURE CONVERSION:

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close Temp Conversion App", "Exit?", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if(radioButton1.Checked)
            {
                textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * 1.8 + 32);
            }
            else
            {
                textBox1.Text = Convert.ToString((Convert.ToDouble(textBox2.Text) - 32) / 1.8);
            }
            if (textBox1.Text == "100")
            {
                textBox3.Text = "Water Boils";
            }
            else if (textBox1.Text == "40")
            {
                textBox3.Text = "Hot Bath";
            }
            else if (textBox1.Text == "37")
            {
                textBox3.Text = "Body Temperature";
            }
            else if (textBox1.Text == "30")
            {
                textBox3.Text = "Beach weather";
            }
            else if (Convert.ToInt32(textBox1.Text) > 10 && Convert.ToInt32(textBox1.Text) < 30)
            {
                textBox3.Text = "Room Temperature";
            }
            else if (textBox1.Text == "10")
            {
                textBox3.Text = "Cool Day";
            }
            else if (textBox1.Text == "0")
            {
                textBox3.Text = "Freezing point of water";
            }
            else if (Convert.ToInt32(textBox1.Text) > -40 && Convert.ToInt32(textBox1.Text) < 0)
            {
                textBox3.Text = "Very Cold Day";
            }
            else if (textBox1.Text == "-40")
            {
                textBox3.Text = "Extremely Cold day (and same number!)";
            }
            string path = "TempConversions.txt";
            DateTime lDate = DateTime.Now;
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(textBox1.Text + "C" + "  =  " + textBox2.Text + "F" + ",     " + lDate.ToString());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(textBox1.Text + "C" + "  =  " + textBox2.Text + "F" + ",     " + lDate.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("TempConversions.txt"))
                {
                    String l = sr.ReadToEnd();
                    MessageBox.Show(l, "Tejvir's Temperature Conversion");
                }
            }
            catch (IOException ex1)
            {
                MessageBox.Show("The file cannot be read:");
                MessageBox.Show(ex1.Message, "Error");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}


CALCULATOR:

/*Tejvir Singh
 * 7/20/2020*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class Form5 : Form
    {
        double NumOne;
        string Operand;
        public Form5()
        {
            InitializeComponent();
        }
        void reset()
        {
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit Calculator?", "Exit?", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            NumOne = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";
            Operand = "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            NumOne = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";
            Operand = "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            NumOne = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";
            Operand = "*";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            NumOne = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";
            Operand = "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            double NumTwo;
            double Result = 0;
            NumTwo = Convert.ToDouble(textBox1.Text);

            if( Operand == "+")
            {
                Result = (NumOne + NumTwo);
                textBox1.Text = Convert.ToString(Result);
            }
            if (Operand == "-")
            {
                Result = (NumOne - NumTwo);
                textBox1.Text = Convert.ToString(Result);
            }
            if (Operand == "*")
            {
                Result = (NumOne * NumTwo);
                textBox1.Text = Convert.ToString(Result);
            }
            if (Operand == "/")
            {
                if (NumTwo == 0)
                {
                    textBox1.Text = "Cannot divide by zero.\nPlease enter a valid numver";
                }
                else
                {
                    Result = (NumOne / NumTwo);
                    textBox1.Text = Convert.ToString(Result);
                }

            }
            string path = "Calculator.txt"; //This is added only one time
            if(!File.Exists(path)) //If file is already there
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("{0} {1} {2} = {3}", Convert.ToString(NumOne), Operand, Convert.ToString(NumTwo), Convert.ToString(Result));
                }
            }
            else // Creates new one
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("{0} {1} {2} = {3}", Convert.ToString(NumOne), Operand, Convert.ToString(NumTwo), Convert.ToString(Result));
                }
            }
            NumOne = Result;
        }
    }
}


IP 4 VALIDATOR:

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsProject
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            label2.Text = DateTime.Now.ToLongDateString();
        }
        void reset()
        {
            textBox1.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close IP v4 Validator", "Exit?", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex obj = new Regex(@"^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$");
            if (obj.IsMatch(textBox1.Text.Trim()) == true)
            {
                MessageBox.Show(textBox1.Text + "\nThe ip is correct", "Valid IP", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(textBox1.Text + "\nThe IP must have 4 bytes\ninteger numbers between 0 to 255\nseparated by a dot (255.255.255.255)", "Error", MessageBoxButtons.OK);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
D.	Present the classes and/or methods that you create or you did use in the project.
Class/Method Name	Description
1.	Convert.ToString()	This is used to change the data type to string.
2.	Conver.ToDouble()	This is used to change the data type to Double.
3.	Try and catch()	This is used to catch and eliminate the errors.
4.	This.close()	This is used to close the application.

E.	Present the difficulties that you have, what was the hardest and the easiest part of your project.
There we lots of ups and downs in the project. Especially the calculator, It was hard to achieve.
It was first time working with so many multi-forms and so many codes so it stressed us a little bit. However, overall, I learnt many new things and mastered my problems. Easiest part was creating the designs. It was a good project and made us revise all the things that were done in classes. I feel happy that I finished my project after lots of efforts and time.
