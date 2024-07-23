using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gelengidentablosu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        giderdatabaseEntities3 db = new giderdatabaseEntities3();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.gelenler.ToList();
            dataGridView2.DataSource=db.gidenler.ToList();
            ciro();
            gelen();
            giden();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2 .Text !="" & textBox4.Text != "")
            {
                gelenler gel = new gelenler();
                gel.tarih = dateTimePicker1.Value;
                gel.gonderen = textBox2.Text;
                gel.aciklama = richTextBox1.Text;
                gel.fiyat = Convert.ToInt32(textBox4.Text);
                db.gelenler.Add(gel);
                db.SaveChanges();
                MessageBox.Show("Gelen Miktar Kaydedilmiştir.!");
                dataGridView1.DataSource = db.gelenler.ToList();
                ciro();
                gelen();
                giden();
                textBox2.Text = "";
                richTextBox1.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen Veri giriniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = db.gelenler.Find(id);
                db.gelenler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Silindi.");
                dataGridView1.DataSource = db.gelenler.ToList();
                ciro();
                gelen();
                giden();
                textBox2.Text = "";
                richTextBox1.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("id Giriniz!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & textBox4.Text != "")
            {
                gidenler git = new gidenler();
                git.tarih = dateTimePicker1.Value;
                git.kisi = textBox2.Text;
                git.aciklama = richTextBox1.Text;
                git.fiyat = Convert.ToInt32(textBox4.Text);
                db.gidenler.Add(git);
                db.SaveChanges();
                MessageBox.Show("Giden Miktar Kaydedilmiştir.!");
                dataGridView2.DataSource = db.gidenler.ToList();
                ciro();
                gelen();
                giden();
                textBox2.Text = "";
                richTextBox1.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Lütfen Veri giriniz");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = db.gidenler.Find(id);
                db.gidenler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Silindi.");
                dataGridView2.DataSource = db.gidenler.ToList();
                ciro();
                gelen();
                giden();
                textBox2.Text = "";
                richTextBox1.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("id Giriniz!!");
            }
        }
        void ciro()
        {
            var ciro = db.gelenler.Sum(p => p.fiyat);
            var ciro2 = db.gidenler.Sum(p => p.fiyat);
            var toplam = ciro - ciro2;
            richTextBox3.Text = toplam.ToString();
        }
        void gelen()
        {
            var ciro = db.gelenler.Sum(p => p.fiyat);
            richTextBox2.Text = ciro.ToString();

        }
        void giden()
        {
            var ciro2 = db.gidenler.Sum(p => p.fiyat);
            richTextBox4.Text = ciro2.ToString();

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
