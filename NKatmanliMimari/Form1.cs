using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtGorev.Text = "";
            txtSehir.Text = "";
            txtMaas.Text = "";
        }

        void Listele()
        {
            List<EntityPersonel> PerList = LogicPersonel.PersonelListesi();
            dgvPersonel.DataSource = PerList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Gorev = txtGorev.Text;
            ent.Sehir = txtSehir.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            LogicPersonel.PersonelEkle(ent);
            Listele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = int.Parse(txtID.Text);
            LogicPersonel.PersonelSil(ent.Id);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = int.Parse(txtID.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Gorev = txtGorev.Text;
            ent.Sehir = txtSehir.Text;
            ent.Maas = short.Parse(txtMaas.Text);
            LogicPersonel.PersonelGuncelle(ent);
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
