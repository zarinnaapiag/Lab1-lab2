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
using System.IO;


namespace Apiag
{
    
    public partial class FrmRegistration : Form
    {
        private String _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        /////return methods 
        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine(_StudentNo);
            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);

                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine(_ContactNo);
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            finally
            {
                Console.WriteLine("Error");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }
        
        public FrmRegistration()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
 StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtFirstName.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;
            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
            StudentInformationClass.SetAge = Age(txtAge.Text);
            StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyyMM-dd");

            string getStudNo = txtStudentNo.Text;
            string getLastName = txtLastName.Text;
            string getAge = txtAge.Text;
            string getBirthday = datePickerBirthday.Text;
            string getProgram = cbPrograms.Text;
            string getFirstName = txtFirstName.Text;
            string getMiddleName = txtMiddleName.Text;
            string getGender = cbGender.Text;
            string getContactNo = txtContactNo.Text;

            FrmFileName frm = new FrmFileName();
            frm.ShowDialog();

            string docPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,
            FrmFileName.SetFileName)))
            {
                outputFile.WriteLine("Student No. : " + getStudNo);
                

                outputFile.Write("Full Name: " + getLastName + ", ");
                

                outputFile.Write(getFirstName + ", ");
                

                outputFile.WriteLine(getMiddleName + ".");
                

                outputFile.WriteLine("Program: " + getProgram);
                

                outputFile.WriteLine("Gender" + getGender);
                

                outputFile.WriteLine("Age: " + getAge);
                

                outputFile.WriteLine("Birthday: " + getBirthday);
               
                outputFile.WriteLine("Contact No. : " + getContactNo);
                
            }


            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtStudentNo.Clear();
            txtAge.Clear();
            cbPrograms.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            txtContactNo.Clear();

            Close();

            
        }
    }
}
