using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDatabase
{
    public partial class Form1 : Form
    {

        T4DBEntities MyDataBase = new T4DBEntities();
        public Form1()
        {
            InitializeComponent();

            //Hämta från databas och visa upp i listbox
            //EF är en ORM = object relational mapper
            //EF kopplar ihop databastabellen med en klass i c# windowsprogrammet



            DisplayTables();
        }

        private void DisplayTables()
        {
            listBox1.Items.Clear();
            foreach (var item in MyDataBase.Tables)
            {
                listBox1.Items.Add(item);
            }
            listBox1.DisplayMember = "Headline";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Demo som lägger till ny artikel

            string headline = "Demo headline";
            string content = " OAJSDOJASOIJDSA";

            Table MyTable = new Table() { Headline = headline, Content = content };

            //Ny fin article(table) nu ska den in i DB
            //Prata med EF som sköter kommunikation med DB

            MyDataBase.Tables.Add(MyTable);

            //table/artikel) tillagd bara i winforms, ej i DB
            //Be EF att spara till BD
            MyDataBase.SaveChanges();

            MessageBox.Show("Data saved to DB");
            DisplayTables();
        }
    }
}
