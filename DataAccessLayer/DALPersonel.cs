using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut = new SqlCommand("Select * From tblBilgi", Baglanti.baglan);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["Ad"].ToString();
                ent.Soyad = dr["Soyad"].ToString();
                ent.Gorev = dr["Gorev"].ToString();
                ent.Sehir = dr["Sehir"].ToString();
                ent.Maas = short.Parse(dr["Maas"].ToString());
                degerler.Add(ent);
            }
            dr.Close();

            return degerler;
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut = new SqlCommand("insert into tblBilgi (Ad,Soyad,Gorev,Sehir,Maas) values (@p1, @p2, @p3, @p4, @p5)",Baglanti.baglan);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.Ad);
            komut.Parameters.AddWithValue("@p2", p.Soyad);
            komut.Parameters.AddWithValue("@p3", p.Gorev);
            komut.Parameters.AddWithValue("@p4", p.Sehir);
            komut.Parameters.AddWithValue("@p5", p.Maas);

            return komut.ExecuteNonQuery();
        }

        public static bool PersonelSil(int id)
        {
            SqlCommand komut = new SqlCommand("Delete From tblBilgi where ID = @p1", Baglanti.baglan);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", id);
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool PersonelGuncelle(EntityPersonel p)
        {
            SqlCommand komut = new SqlCommand("Update tblBilgi set Ad = @p1, Soyad = @p2, Gorev = @p3, Sehir = @p4, Maas = @p5 Where ID = @p6", Baglanti.baglan);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("@p1", p.Ad);
            komut.Parameters.AddWithValue("@p2", p.Soyad);
            komut.Parameters.AddWithValue("@p3", p.Gorev);
            komut.Parameters.AddWithValue("@p4", p.Sehir);
            komut.Parameters.AddWithValue("@p5", p.Maas);
            komut.Parameters.AddWithValue("@p6", p.Id);
            return komut.ExecuteNonQuery() > 0;
        }
    }
}
