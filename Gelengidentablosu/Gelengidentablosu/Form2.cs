using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gelengidentablosu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        giderdatabaseEntities3 db = new giderdatabaseEntities3();
        private void button1_Click(object sender, EventArgs e)
        {
            kartlar kart = new kartlar();
            kart.tarih = dateTimePicker1.Value;
            kart.kartad = listBox1.Text;
            kart.alınan = richTextBox1.Text;
            kart.fiyat = Convert.ToInt32(textBox4.Text);
            db.kartlar.Add(kart);
            db.SaveChanges();
            MessageBox.Show("Kaydedilmiştir.!");
            dataGridView1.DataSource = db.kartlar.ToList();
            giden();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int id = Convert.ToInt32(textBox1.Text);
                var x = db.kartlar.Find(id);
                db.kartlar.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Başarıyla Silindi.");
                dataGridView1.DataSource = db.kartlar.ToList();
                richTextBox1.Text = "";
                textBox4.Text = "";
                giden();
            }
            else
            {
                MessageBox.Show("id Giriniz!!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.kartlar.ToList();
            giden();
        }
        void giden()
        {
            var ciro2 = db.kartlar.Sum(p => p.fiyat);
            richTextBox4.Text = ciro2.ToString();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<kartlar> liste4 = db.kartlar.Where(p => p.kartad =="Hanife Denizbank").ToList();
            dataGridView1.DataSource = liste4;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<kartlar> liste4 = db.kartlar.Where(p => p.kartad == "Tezcan Enpara").ToList();
            dataGridView1.DataSource = liste4;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            List<kartlar> liste4 = db.kartlar.Where(p => p.kartad == "Tezcan Akbank").ToList();
            dataGridView1.DataSource = liste4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.kartlar.ToList();
        }
    }
}
