using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


public class Data
{
    public string bookName;
    public string PY;
    public string AuthorName;
    public string Email;
}

namespace book_managment_system
{

    class Book
    {

        static public int count = 0;
        static public int SN = 0;

        //fatema & esraa task
        string booksFile = "books.txt";
        string authorsFile = "authors.txt";


        // Asmaa task

        public void AddBook(Data NewBook)
        {
            if (!CheckBook(NewBook.bookName))
            {
                string ID = AddAuthor(NewBook);
                WriteBook(NewBook, ID);
            }
            else
            {
                MessageBox.Show("this book already exist!!");
                return;

            }
        }

        public bool CheckBook(string bookName)//function to check books
        {
            FileStream FR = new FileStream(booksFile, FileMode.Open);
            StreamReader SR = new StreamReader(FR);

            bool found = false;
            string[] record;
            string[] fields;

                
            while ((SR.Peek() != -1) && (found == false))
            {
                record = SR.ReadToEnd().Split('#');
                for (int i = 0; i < record.Length - 1; i++)
                {
                    fields = record[i].Split('@');
                    SN = int.Parse(fields[0]);

                    if (bookName.CompareTo(fields[1]) == 0)
                    {
                        found = true;
                    }
                }
            }
            SR.Close();

            return (found == true);
        }

        public void WriteBook(Data book, string id)//write book in files
        {
            string str;
            FileStream BookFile = new FileStream(booksFile, FileMode.Open, FileAccess.ReadWrite);
            StreamWriter SW = new StreamWriter(BookFile);
            StreamReader SR = new StreamReader(BookFile);
            string sn = (SN+1).ToString();
            str = sn + "@" + book.bookName + "@" + book.PY + "@" + id + "#";
            long offset = SW.BaseStream.Length;
            SW.BaseStream.Seek(offset, SeekOrigin.Begin);
            SW.Write(str);
            SW.Close();

        }

       /* public int Counter_SN(FileStream Books)//**********************
        {
             StreamReader SR = new StreamReader(Books);
            //FileStream BookFile = new FileStream(booksFile, FileMode.Open);
           // StreamReader SR = new StreamReader(BookFile);

            //if the file is empty
            if (new FileInfo(booksFile).Length == 0)
                return 1;

            else
            {
                string[] records, fields;
                int SN = 0;
                if (SR.Peek() != -1)
                {

                    records = SR.ReadToEnd().Split('#');
                    for (int i = 0; i < records.Length - 1; i++)
                    {
                        fields = records[i].Split('@');
                        SN = int.Parse(fields[0]);
                    }
                }
                return (SN++);
            }
        }*/

        //Author class
        public bool CheckAuthor(string Name)//**********************
        {
            FileStream FR = new FileStream(authorsFile, FileMode.Open);
            StreamReader SR = new StreamReader(FR);

            char[] recored = new char[50];


            while (SR.Peek() != -1)
            {
                SR.Read(recored, 0, 50);
                string Recored = new string(recored);

                string id = Recored.Substring(0, 5).Trim();
                if (id.Length == 0)
                    break;
                string name = Recored.Substring(5, 20).Trim();
                string email = Recored.Substring(25, 25).Trim();

                count = int.Parse(id);

                if (Name.CompareTo(name)==0)
                {
                    SR.Close();
                    return (true);
                    
                }
            }
            SR.Close();
            return (false);
        }

        public String AddAuthor(Data Auth)//**********************
        {
            if (CheckAuthor(Auth.AuthorName) == true)
            {
                return count.ToString(); 
            }
            else
            {
                return WriteAouther(Auth);
            }
        }

        public String WriteAouther(Data A)//**********************
        {
            char[] id = new char[5];
            char[] name = new char[20];
            char[] email = new char[25];

            FileStream FS = new FileStream(authorsFile, FileMode.Open);
            StreamWriter SW = new StreamWriter(FS);
            int offset = (int)SW.BaseStream.Length;
            SW.BaseStream.Seek(offset, SeekOrigin.Begin);
            string ID = (count + 1).ToString();
            ID.CopyTo(0, id, 0, ID.Length);
            A.AuthorName.CopyTo(0, name, 0, A.AuthorName.Length);
            A.Email.CopyTo(0, email, 0, A.Email.Length);

            SW.Write(id, 0, 5);
            SW.Write(name, 0, 20);
            SW.Write(email, 0, 25);

            SW.Close();
            return ID;
        }

        /* public int Counter_ID()//**********************
         {

             FileStream AuthorFile = new FileStream(authorsFile, FileMode.Open);
             StreamReader SR = new StreamReader(AuthorFile);

             if (new FileInfo(authorsFile).Length == 0)
                 return 1;

             else
             {
                 char[] recored = new char[50];
                 string id;
                 int count = 0;
                 while (!SR.EndOfStream)
                 {
                     SR.Read(recored, 0, 50);
                     string Recored = new string(recored);
                     id = Recored.Substring(0, 5);
                     count = int.Parse(id);
                 }
                 return (count++);
             }
         }*/

        //*taghreed task*
        public Data[] SearchingByYear(string year)
        {
            FileStream fs = new FileStream(booksFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            FileStream fs2 = new FileStream(authorsFile, FileMode.Open);
            StreamReader sr2 = new StreamReader(fs2);

            string[] records, fields;
            List<Data> Books = new List<Data>();
            char[] recored = new char[50];
           // bool check = false;
            //string id = "";
            //string Aname;

            if ((sr.Peek() != -1))
            {
                records = sr.ReadLine().Split('#');

                for (int i = 0; i < records.Length - 1; i++)
                {
                    fields = records[i].Split('@');
                    if (fields[2].CompareTo(year) == 0)
                    {

                        Data d = new Data();
                        d.bookName = fields[1];
                        d.Email = "";
                        d.PY = fields[2];
                        d.AuthorName = " ";
                        

                        /*sr2.Read(recored, 0, 50);
                        string Recored = new string(recored);
                        id = Recored.Substring(0, 5).Trim();
                        Aname = Recored.Substring(5, 20).Trim();

                        for (int j = 0; j <= Books.)
                        {

                        }*/

                        Books.Add(d);

                    }
                }
            }
            sr.Close();
            sr2.Close();
            if (Books != null)
                return Books.ToArray();

            else
                return null;
        }


        //Rawan task
        public Data[] SearchingByAuthor(string AuthorName)
        {
            FileStream fs = new FileStream(booksFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            FileStream fs2 = new FileStream(authorsFile, FileMode.Open);
            StreamReader sr2 = new StreamReader(fs2);


            char[] recored = new char[50];
            bool check = false;
            string id = "";
            string Aname;

            while (sr2.Peek() != -1)
            {
                sr2.Read(recored, 0, 50);
                string Recored = new string(recored);
                id = Recored.Substring(0, 5).Trim();
                Aname = Recored.Substring(5, 20).Trim();

                if (AuthorName.CompareTo(Aname) == 0)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                string[] records;
                string[] fields;
                List<Data> Books = new List<Data>();
                               
                    records = sr.ReadLine().Split('#');
                
                for (int i = 0; i < records.Length - 1; i++)
                    {
                    fields = records[i].Split('@');
                       

                        if (id.CompareTo(fields[3]) == 0)
                        {
                        Data d = new Data();
                        d.bookName = fields[1];
                        d.Email = "";
                        d.PY = fields[2];
                        d.AuthorName = "  ";
                        Books.Add(d); 
                        
                        }
                    }
                
                sr.Close();
                sr2.Close();
                return Books.ToArray();
            }
            else
            {
                return null;
            }
        }

       
    }
}
