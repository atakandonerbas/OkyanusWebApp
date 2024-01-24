using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Giriş Metotları

        public Yonetici YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi=@ka AND Sifre=@sif";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sif", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim, Y.Soyisim, Y.KullaniciAdi, Y.Mail, Y.Sifre, Y.KayitTarihi, Y.Silinmis, Y.Durum FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.KullaniciAdi = @ka AND Y.Sifre = @sif";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sif", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTur_ID = reader.GetInt32(1);
                        y.YoneticiTur = reader.GetString(2);
                        y.Isim = reader.GetString(3);
                        y.Soyisim = reader.GetString(4);
                        y.KullaniciAdi = reader.GetString(5);
                        y.Mail = reader.GetString(6);
                        y.Sifre = reader.GetString(7);
                        y.KayitTarihi = reader.GetDateTime(8);//18.11.2023 00:00:00:000
                        //y.KayitTarihiStr = y.KayitTarihi.ToLongDateString(); //18 Kasım 2023
                        y.KayitTarihiStr = y.KayitTarihi.ToShortDateString(); //18.11.2023
                        y.Silinmis = reader.GetBoolean(9);
                        y.Durum = reader.GetBoolean(10);
                    }
                    return y;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Uye UyeGiris(string kullaniciadi, string sifre) 
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE KullaniciAdi = @ka AND Sifre = @sif";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", kullaniciadi);
                cmd.Parameters.AddWithValue("@sif", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT U.ID, U.Isim, U.Soyisim, U.KullaniciAdi, U.Mail, U.Sifre, U.KayitTarihi, U.Silinmis, U.Durum FROM Uyeler WHERE U.KullaniciAdi = @ka AND U.Sifre = @sif";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ka", kullaniciadi);
                    cmd.Parameters.AddWithValue("@sif", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Mail = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.KayitTarihi = reader.GetDateTime(6);
                        u.Silinmis = reader.GetBoolean(7);
                        u.Durum = reader.GetBoolean(8);
                    }   
                    return u;
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori data)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", data.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Uye Metotları

        public List<Uye> UyeListele()
        {
            try
            {
                List<Uye> uyeler = new List<Uye>();
                cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, KayitTarihi";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read()) 
                {
                Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Soyisim = reader.GetString(2);
                    u.KullaniciAdi = reader.GetString(3);
                    u.Mail = reader.GetString(4);
                    u.KayitTarihi = reader.GetDateTime(5);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch 
            {
                return null;
            }
            finally 
            {
                con.Close();
            }
        }

        public void UyeBanla(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uyeler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Makale Metotları

        
        #endregion
    }

}
   
