using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.IO;

namespace yeni1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string a;
        string kopyalanacakDosya = "", kopyalanacakDosyaIsmi = "", dosyanınKopyanacagiKlasor = "";
       
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox1.ReadOnly = true;
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                a = textBox2.Text;

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(a);


                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = a;


                if
                    (file.ShowDialog() == DialogResult.OK)
                {

                    kopyalanacakDosyaIsmi = file.SafeFileName.ToString();

                    kopyalanacakDosya = file.FileName.ToString();

                    textBox3.Text = kopyalanacakDosya;


                };


            }
         catch{
             MessageBox.Show("Ftp Yanlış veya Eksik Girdiniz !", "Bilgilendirme Penceresi");
            }

           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();


                if (fbd.ShowDialog() == DialogResult.OK)

                    dosyanınKopyanacagiKlasor = fbd.SelectedPath.ToString();
                textBox1.Text = dosyanınKopyanacagiKlasor;
            }
            catch
            {
                MessageBox.Show("Hata Oluştu  !", "Bilgilendirme Penceresi");
            }
               
                
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                Byte[] dosya = File.ReadAllBytes(textBox3.Text);
                for (int i = 0; i < dosya.Length; i++)
                {

                    dosya[i] = (Byte)((int)dosya[i]);

                    if (dosya[i] > 255)
                    {
                        dosya[i] = 0;
                    }
                }



                File.WriteAllBytes(textBox1.Text + "\\" + kopyalanacakDosyaIsmi, dosya);

            }
            catch
            {
                MessageBox.Show("Ftp Yolunu veya Kayıt Edilcek Dosya Yolunu seçmediniz", "Bilgilendirme Penceresi");
            }
            textBox3.Text = "";
           
            textBox1.Text = "";
        }
 

        
        }
    }

