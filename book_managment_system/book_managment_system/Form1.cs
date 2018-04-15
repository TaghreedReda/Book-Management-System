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

namespace book_managment_system
{
    public partial class Form1 : Form
    {
        Book books = new Book();
       
        public Form1()
        {
            InitializeComponent();
        }

        
        private void b_add_Click(object sender, EventArgs e)
        {
            Form1 es = new Form1();
            es.Visible = false;
            p_addB.Visible = true;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Form1 es = new Form1();

            es.Visible = false;
            p_searchB.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p_addB.Visible = false;
            Form1 es = new Form1();
            es.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p_searchB.Visible = false;
            Form1 es = new Form1();
            es.Show();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void b_addB_Click(object sender, EventArgs e)
        {
            Data de = new Data();
            de.bookName = textBox3.Text;
            de.PY = textBox4.Text;
            de.AuthorName = textBox5.Text;
            de.Email = textBox6.Text;
            
            books.AddBook(de);
        }

        private void b_displayB_Click(object sender, EventArgs e)
        {
            string display = textBox2.Text;
            Data[] d1 = books.SearchingByAuthor(textBox1.Text);
          
            if (d1.Length!=0)
            {
                for (int i = 0; i < d1.Length; i++)
                {
                    
                    display += d1[i].bookName +"\t" + d1[i].PY + "\r\n";
                    
                }
                textBox2.Text = display;
            }
            else
            {
                MessageBox.Show("This Author is not available ! Please add this author ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox7.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
                string display = textBox2.Text;
                Data[] d2 = books.SearchingByYear(textBox7.Text);

                if (d2.Length != 0)
                {
                    for (int i = 0; i < d2.Length; i++)
                    {

                        display += d2[i].bookName + d2[i].PY + "\r\n";

                    }
                    textBox2.Text = display;
                }
                else
                {
                    MessageBox.Show("no books with this year is available!");

                }
            

        }
    }
}

