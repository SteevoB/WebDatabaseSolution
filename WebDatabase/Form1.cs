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
        public Form1()
        {
            InitializeComponent();

            //Hämta från databas och visa upp i listbox
            //EF är en ORM = object relational mapper
            //EF kopplar ihop databastabellen med en klass i c# windowsprogrammet

            T4DBEntities MyDataBase = new T4DBEntities();

            foreach (var item in MyDataBase.Tables)
            {
                listBox1.Items.Add(item);
            }
            listBox1.DisplayMember = "Headline";
        }
    }
}
