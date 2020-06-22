using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tripledesanddes
{
    public partial class Form1 : Form
    {

        public string ImeDatoteke { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files|*";
            openFile.FileName = "";
            if (openFile.ShowDialog()== DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                ImeDatoteke = Path.GetFileName(openFile.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TripleDes tripleDes = new TripleDes(textBox2.Text);
                tripleDes.EncryptFile(textBox1.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                TripleDes tripleDes = new TripleDes(textBox2.Text);
                tripleDes.DecyrptFile(textBox1.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {

                if (ex.Message == "Bad Data.\r\n")
                {
                    MessageBox.Show("Napačen ključ");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }






       




        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All Files|*";
            openFile.FileName = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFile.FileName;
                ImeDatoteke = Path.GetFileName(openFile.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DES des = new DES(ShraniKljuctxb2.Text);
                des.EncryptFile(textBox3.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DES des = new DES(ShraniKljuctxb2.Text);
                des.DecryptFile(textBox3.Text);
                GC.Collect();
            }
            catch (Exception ex)
            {

                if (ex.Message == "Bad Data.\r\n")
                {
                    MessageBox.Show("Napačen ključ");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            ShraniKljucbtn.Show();
            NaloziKljucbtn.Show();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            naloziKljucbtn2.Show();
            ShraniKljucbtn2.Show();
           
        }

        private void ShraniKljucbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter= "Text File | *.txt";
            saveFileDialog.FileName = ImeDatoteke;
            if (saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                var path= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ImeDatoteke+"_Key3Des"+".txt");
                using (var pisi= new StreamWriter(path))
                {
                    pisi.WriteLine(textBox2.Text.TrimStart().TrimEnd());
                }
            }
        }

       

        private void NaloziKljucbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter= "Text File | *.txt";
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ImeDatoteke + "_Key3Des" + ".txt");
                using (var beri= new StreamReader(path))
                {
                    textBox2.Text = beri.ReadToEnd().TrimStart().TrimEnd();
                }
            }
        }

        private void ShraniKljucbtn2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.FileName = ImeDatoteke;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ImeDatoteke + "_KeyDes" + ".txt");
                using (var pisi = new StreamWriter(path))
                {
                    pisi.WriteLine(ShraniKljuctxb2.Text.TrimStart().TrimEnd());
                }
            }
        }

        private void naloziKljucbtn2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text File | *.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), ImeDatoteke + "_KeyDes" + ".txt");
                using (var beri = new StreamReader(path))
                {
                    ShraniKljuctxb2.Text = beri.ReadToEnd().TrimStart().TrimEnd();
                }
            }
        }
    }
}
