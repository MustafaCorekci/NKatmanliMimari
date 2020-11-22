using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Windows.Forms;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            if (p.Ad != "" && p.Soyad != "" && p.Maas >= 3500 && p.Ad.Length >= 3)
            {
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Gerçekleşti", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
        }

        public static bool PersonelSil(int per)
        {
            if (per > 1)
            {
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            if (ent.Ad != "" && ent.Soyad != "" && ent.Maas >= 4500)
            {
                MessageBox.Show("Kayıt Başarılı Bir Şekilde Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
