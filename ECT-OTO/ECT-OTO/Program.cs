using ECT__Oto;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ECT_OTO.Ekranlar
{
    internal static class Program
    {
        public static int dbControl(string db)
        {
            ArrayList DBS = new ArrayList();
            int sonuc = 0;
            MySqlConnection baglanti = new MySqlConnection("Server=localhost;Uid=root;Pwd='';");
            MySqlCommand komut = new MySqlCommand("SHOW DATABASES;", baglanti);
            MySqlDataReader Reader;
            baglanti.Open();

            Reader = komut.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++) DBS.Add(Reader.GetValue(i).ToString());
            }
            baglanti.Close();
            for (int k = 0; k < DBS.Count; k++)
            {
                if (string.Equals(db, DBS[k].ToString())) sonuc++;
            }
            return sonuc;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (dbControl("ect_oto") == 0)
            {
                Application.Run(new Ayarlar(0));
            }
            else
            {
                Application.Run(new Giris());
            }
        }
    }
}