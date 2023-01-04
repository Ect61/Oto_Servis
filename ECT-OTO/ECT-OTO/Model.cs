using System;
using System.Collections;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ECT__Oto
{
    public class Model
    {
        public MySqlDataAdapter veriUyarlayici = null;
        public MySqlDataReader veriOkuyucu = null;
        public static MySqlConnection baglayici = new MySqlConnection("Server=localhost;Database='ect_oto';Uid=root;Pwd='';AllowUserVariables=True;UseCompression=True;charset=utf8");
        MySqlCommand komut = baglayici.CreateCommand();

        public bool baglan()
        {
            if (baglayici.State == ConnectionState.Closed)
            {
                baglayici.Open();
                return true;
            }
            return false;
        }

        /// <summary>
        ///MySQL Server'da argüman olarak gönderilen isimde bir veritabanının varlığını sorgular. Veritabanı bulunmuşsa 1, bulunamamışsa 0 döndürür.
        /// </summary>
        public int dbControl(string db)
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
        ///MySQL Server'da argüman olarak gönderilen isimde veritabanı ve tablolarını oluşturur. 
        /// </summary>
        public bool dbSetup(string db)
        {            
            if (dbControl(db) == 0)
            {
                if (Veritabani_olustur("localhost", "root", "", db))
                {
                    if (!tablolariOlustur())
                    {
                        MessageBox.Show("Tablolar oluşturulurken bir hata meydana geldi!..\nLütfen Bilgi-İşlem birimiyle iletişime geçiniz!", "TABLO OLUŞTURMA HATASI !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanı oluşturulurken bir hata meydana geldi!..\nLütfen Bilgi-İşlem birimiyle iletişime geçiniz!", "TABLO OLUŞTURMA HATASI !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                if (!tabloVarmi("ect_oto", "kurulum_tarihi"))
                {
                    if (!tablolariOlustur())
                    {
                        MessageBox.Show("Tablolar oluşturulurken bir hata meydana geldi!..\nLütfen Bilgi-İşlem birimiyle iletişime geçiniz!", "TABLO OLUŞTURMA HATASI !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        ///Fonksiyon yeni bir MySQL veritabanı oluşturur.
        ///Parametrelerden ilki veritabanı sunucusunun ismidir.
        ///İkincisi kullanıcı adı ve üçüncü parametre kullanıcı parolasıdır.
        ///Dördüncü parametre ise veritabanının ismidir.
        /// </summary>
        public bool Veritabani_olustur(string sunucu, string kullanan, string parola, string veritabani)
        {
            MySqlConnection bagla = new MySqlConnection("Server=" + sunucu + ";User='" + kullanan + "';Password='" + parola + "';AllowUserVariables=True;UseCompression=True;");
            bagla.Open();
            MySqlCommand komuta = bagla.CreateCommand();

            if (bagla.State == ConnectionState.Open)
            {
                komuta.CommandText = "CREATE DATABASE IF NOT EXISTS " + veritabani + " DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci; USE " + veritabani + ";";
                komuta.CommandTimeout = 15;
                komuta.ExecuteNonQuery();
                bagla.Close();
                return true;
            }
            bagla.Close();
            return false;
        }

        /// <summary>
        ///MySQL veritabanına olan bağlantıyı sonlandırır. Bağlantı kapatılmışsa true, eğer bağlantı kapatılamamışsa false döndürür.
        /// </summary>
        public bool baglantiyiKapat()
        {
            baglayici.Close();

            if (baglayici.State == ConnectionState.Closed) return true;
            return false;
        }

        /// <summary>
        ///MySQL veritabanında belirtilen isimdeki tablonun varlığını araştırır.
        ///Fonksiyon tablo bulunmuşsa TRUE değerini döndürür.
        ///Eğer tablo bulunamamışsa FALSE değerini döndürür.
        /// </summary>
        public bool tabloVarmi(string dbName, string tablo_ismi)
        {
            baglantiyiKapat();
            if (baglan())
            {
                komut.CommandText = "SHOW TABLES FROM " + dbName;
                veriOkuyucu = komut.ExecuteReader();

                while (veriOkuyucu.Read())
                {
                    if (Equals(veriOkuyucu.GetString(0), tablo_ismi))
                    {
                        baglantiyiKapat();
                        return true;
                    }
                }
            }
            baglantiyiKapat();
            return false;
        }

        public bool ECT__Oto(string sunucu, string kullanan, string parola, string veritabani)
        {
            MySqlConnection bagla = new MySqlConnection("Server=" + sunucu + ";User='root';Password='';AllowUserVariables=True;UseCompression=True;");
            bagla.Open();
            MySqlCommand komuta = bagla.CreateCommand();

            if (bagla.State == ConnectionState.Open)
            {
                komuta.CommandText = "CREATE DATABASE IF NOT EXISTS " + veritabani + " DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci; USE " + veritabani + ";";
                komuta.CommandTimeout = 15;
                komuta.ExecuteNonQuery();
                bagla.Close();
                return true;
            }
            bagla.Close();
            return false;
        }

        public bool tablolariOlustur()
        {
            if (baglan())
            {
                komut.CommandText = "CREATE TABLE IF NOT EXISTS `arac_markasi` (" +
                "`mrk_ID` int(4) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                "`mrk_name` VARCHAR(20) NOT NULL," +
                "`tip_ID` int(4) NOT NULL," +
                "PRIMARY KEY(`mrk_ID`)" +
                ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                if (komut.ExecuteNonQuery() > -1)
                {
                    komut.CommandText = "INSERT INTO `arac_markasi` (`mrk_name`, `tip_ID`) VALUES" +
                    "('Aion', '1')," +
                    "('Alfa Romeo', '1')," +
                    "('Aston Martin', '1')," +
                    "('Audi', '1')," +
                    "('Bentley', '1')," +
                    "('BMW', '1')," +
                    "('Cadillac', '1')," +
                    "('Chery', '1')," +
                    "('Chevrolet', '1')," +
                    "('Chrysler', '1')," +
                    "('Citroën', '1')," +
                    "('Cupra', '1')," +
                    "('Dacia', '1')," +
                    "('Daewoo', '1')," +
                    "('Daihatsu', '1')," +
                    "('DFM', '1')," +
                    "('DFSK', '1')," +
                    "('Dodge', '1')," +
                    "('DS Automobiles', '1')," +
                    "('Fiat', '1')," +
                    "('Ford', '1')," +
                    "('GMC', '1')," +
                    "('Honda', '1')," +
                    "('Hummer', '1')," +
                    "('Hyundai', '1')," +
                    "('Infiniti', '1')," +
                    "('Isuzu', '1')," +
                    "('Jaguar', '1')," +
                    "('Jeep', '1')," +
                    "('Kia', '1')," +
                    "('Lada', '1')," +
                    "('Lamborghini', '1')," +
                    "('Land Rover', '1')," +
                    "('Lexus', '1')," +
                    "('Lincoln', '1')," +
                    "('Mahindra', '1')," +
                    "('Maserati', '1')," +
                    "('Mazda', '1')," +
                    "('Mercedes - Benz', '1')," +
                    "('Mercury', '1')," +
                    "('Mini', '1')," +
                    "('Mitsubishi', '1')," +
                    "('Nissan', '1')," +
                    "('Opel', '1')," +
                    "('Peugeot', '1')," +
                    "('Porsche', '1')," +
                    "('Poyraz', '1')," +
                    "('Renault', '1')," +
                    "('Rolls-Royce', '1')," +
                    "('Seat', '1')," +
                    "('Skoda', '1')," +
                    "('SsangYong', '1')," +
                    "('Subaru', '1')," +
                    "('Suzuki', '1')," +
                    "('Tata', '1')," +
                    "('Toyota', '1')," +
                    "('Volkswagen', '1')," +
                    "('Volvo', '1')," +
                    "('Acura', '2')," +
                    "('Aion', '2')," +
                    "('Alfa Romeo', '2')," +
                    "('Anadol', '2')," +
                    "('Aston Martin', '2')," +
                    "('Audi', '2')," +
                    "('Bentley', '2')," +
                    "('BMW', '2')," +
                    "('Bugatti', '2')," +
                    "('Buick', '2')," +
                    "('Cadillac', '2')," +
                    "('Chery', '2')," +
                    "('Chevrolet', '2')," +
                    "('Chrysler', '2')," +
                    "('Citroën', '2')," +
                    "('Dacia', '2')," +
                    "('Daewoo', '2')," +
                    "('Daihatsu', '2')," +
                    "('Dodge', '2')," +
                    "('DS Automobiles', '2')," +
                    "('Eagle', '2')," +
                    "('Ferrari', '2')," +
                    "('Fiat', '2')," +
                    "('Fisker', '2')," +
                    "('Ford', '2')," +
                    "('Geely', '2')," +
                    "('Geo', '2')," +
                    "('Honda', '2')," +
                    "('Hyundai', '2')," +
                    "('Ikco', '2')," +
                    "('Infiniti', '2')," +
                    "('Isuzu', '2')," +
                    "('Jaguar', '2')," +
                    "('Kia', '2')," +
                    "('Lada', '2')," +
                    "('Lamborghini', '2')," +
                    "('Lancia', '2')," +
                    "('Lexus', '2')," +
                    "('Lincoln', '2')," +
                    "('Lotus', '2')," +
                    "('Marcos', '2')," +
                    "('Maserati', '2')," +
                    "('Mazda', '2')," +
                    "('McLaren', '2')," +
                    "('Mercedes - Benz', '2')," +
                    "('Mercury', '2')," +
                    "('MG', '2')," +
                    "('Mini', '2')," +
                    "('Mitsubishi', '2')," +
                    "('Moskwitsch', '2')," +
                    "('Nissan', '2')," +
                    "('Opel', '2')," +
                    "('Peugeot', '2')," +
                    "('Pontiac', '2')," +
                    "('Porsche', '2')," +
                    "('Proton', '2')," +
                    "('Renault', '2')," +
                    "('Rolls-Royce', '2')," +
                    "('Rover', '2')," +
                    "('Saab', '2')," +
                    "('Seat', '2')," +
                    "('Skoda', '2')," +
                    "('Smart', '2')," +
                    "('Subaru', '2')," +
                    "('Suzuki', '2')," +
                    "('Tata', '2')," +
                    "('Tesla', '2')," +
                    "('Tofaş', '2')," +
                    "('Toyota', '2')," +
                    "('Volkswagen', '2')," +
                    "('Volvo', '2');";

                    if (komut.ExecuteNonQuery() > -1)
                    {
                        komut.CommandText = "CREATE TABLE IF NOT EXISTS `arac_modeli` (" +
                        "`md_ID` int(4) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                        "`md_name` VARCHAR(20) NOT NULL," +
                        "`mrk_ID` int(4) UNSIGNED NOT NULL," +
                        "PRIMARY KEY(`md_ID`)" +
                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                        if (komut.ExecuteNonQuery() > -1)
                        {
                            komut.CommandText = "INSERT INTO `arac_modeli` (`md_name`, `mrk_ID`) VALUES" +
                            "('Integra', '59')," +
                            "('EGARAJ GAC AİON V', '1')," +
                            "('S', '60')," +
                            "('Stelvio 2', '2')," +
                            "('Giulia', '61')," +
                            "('Giulietta', '61')," +
                            "('145', '61')," +
                            "('146', '61')," +
                            "('147', '61')," +
                            "('155', '61')," +
                            "('156', '61')," +
                            "('159', '61')," +
                            "('164', '61')," +
                            "('166', '61')," +
                            "('33', '61')," +
                            "('4C', '61')," +
                            "('75', '61')," +
                            "('Brera', '61')," +
                            "('GT', '61')," +
                            "('GTV', '61')," +
                            "('MiTo', '61')," +
                            "('Spider', '61')," +
                            "('DBX', '3')," +
                            "('A', '62')," +
                            "('SV', '62')," +
                            "('DB11', '63')," +
                            "('DB7', '63')," +
                            "('DB9', '63')," +
                            "('DBS', '63')," +
                            "('Rapide', '63')," +
                            "('Vanquish', '63')," +
                            "('Vantage', '63')," +
                            "('Virage', '63')," +
                            "('E-Tron', '4')," +
                            "('E-Tron GT', '64')," +
                            "('Q2', '4')," +
                            "('Q3', '4')," +
                            "('Q5', '4')," +
                            "('Q7', '4')," +
                            "('Q8', '4')," +
                            "('RS Q8', '4')," +
                            "('A1', '64')," +
                            "('A3', '64')," +
                            "('A4', '64')," +
                            "('A5', '64')," +
                            "('A6', '64')," +
                            "('A7', '64')," +
                            "('A8', '64')," +
                            "('R8', '64')," +
                            "('RS', '64')," +
                            "('S Serisi', '64')," +
                            "('TT', '64')," +
                            "('80 Serisi', '64')," +
                            "('90 Serisi', '64')," +
                            "('3.0', '5')," +
                            "('4.0 Diesel', '5')," +
                            "('4.0 V8', '5')," +
                            "('6.0', '5')," +
                            "('Continental', '65')," +
                            "('Flying Spur', '65')," +
                            "('Brooklands', '65')," +
                            "('Mulsanne', '65')," +
                            "('iX3', '6')," +
                            "('X1', '6')," +
                            "('X2', '6')," +
                            "('X3', '6')," +
                            "('X4', '6')," +
                            "('X5', '6')," +
                            "('X6', '6')," +
                            "('1 Serisi', '66')," +
                            "('2 Serisi', '66')," +
                            "('3 Serisi', '66')," +
                            "('4 Serisi', '66')," +
                            "('5 Serisi', '66')," +
                            "('6 Serisi', '66')," +
                            "('7 Serisi', '66')," +
                            "('8 Serisi', '66')," +
                            "('i Serisi', '66')," +
                            "('M Serisi', '66')," +
                            "('Z Serisi', '66')," +
                            "('Chiron', '67')," +
                            "('Century', '68')," +
                            "('Le Sabre', '68')," +
                            "('Park Avenue', '68')," +
                            "('Regal', '68')," +
                            "('Riviera', '68')," +
                            "('Escalade', '7')," +
                            "('SRX', '7')," +
                            "('CTS', '69')," +
                            "('BLS', '69')," +
                            "('Brougham', '69')," +
                            "('DeVille', '69')," +
                            "('Eldorado', '69')," +
                            "('Fleetwood', '69')," +
                            "('Seville', '69')," +
                            "('STS', '69')," +
                            "('Tiggo', '8')," +
                            "('1.6', '8')," +
                            "('2.0', '8')," +
                            "('Alia', '70')," +
                            "('Chance', '70')," +
                            "('Kimo', '70')," +
                            "('Niche', '70')," +
                            "('Avalanche', '9')," +
                            "('Blazer', '9')," +
                            "('Captiva', '9')," +
                            "('Equinox', '9')," +
                            "('Silverado', '9')," +
                            "('Suburban', '9')," +
                            "('Tahoe', '9')," +
                            "('Trax', '9')," +
                            "('Traverse', '9')," +
                            "('Aveo', '71')," +
                            "('Beretta', '71')," +
                            "('Camaro', '71')," +
                            "('Caprice', '71')," +
                            "('Cavalier', '71')," +
                            "('Celebrity', '71')," +
                            "('Corvette', '71')," +
                            "('Cruze', '71')," +
                            "('Epica', '71')," +
                            "('Evanda', '71')," +
                            "('Impala', '71')," +
                            "('Kalos', '71')," +
                            "('Lacetti', '71')," +
                            "('Lumina', '71')," +
                            "('Malibu', '71')," +
                            "('Monte Carlo', '71')," +
                            "('Pacifica', '10')," +
                            "('3.5 L', '10')," +
                            "('300 C', '72')," +
                            "('300 M', '72')," +
                            "('Concorde', '72')," +
                            "('Crossfire', '72')," +
                            "('Le Baron', '72')," +
                            "('LHS', '72')," +
                            "('Neon', '72')," +
                            "('PT Cruiser', '72')," +
                            "('Sebring', '72')," +
                            "('Stratus', '72')," +
                            "('C3 AirCross', '11')," +
                            "('C4 Cactus', '11')," +
                            "('C4 SUV', '11')," +
                            "('C5 AirCross', '11')," +
                            "('C1', '73')," +
                            "('C2', '73')," +
                            "('C3', '73')," +
                            "('C3 Picasso', '73')," +
                            "('C4', '73')," +
                            "('C4 Grand Picasso', '73')," +
                            "('C4 Picasso', '73')," +
                            "('C5', '73')," +
                            "('C8', '73')," +
                            "('C-Elysée', '73')," +
                            "('Saxo', '73')," +
                            "('Xsara', '73')," +
                            "('BX', '73')," +
                            "('Evasion', '73')," +
                            "('Formentor', '12')," +
                            "('1.5 TSI', '12')," +
                            "('Duster', '13')," +
                            "('1.0 Tce', '13')," +
                            "('1.2 Tce', '13')," +
                            "('1.3 Tce', '13')," +
                            "('1.5 BlueDCI', '13')," +
                            "('1.5 dCi', '13')," +
                            "('1.6', '13')," +
                            "('1.6 Sce', '13')," +
                            "('Lodgy', '74')," +
                            "('Logan', '74')," +
                            "('Sandero', '74')," +
                            "('Nova', '74')," +
                            "('Solenza', '74')," +
                            "('Korando', '14')," +
                            "('Musso', '14')," +
                            "('Nexia', '75')," +
                            "('Nubira', '75')," +
                            "('Espero', '75')," +
                            "('Lanos', '75')," +
                            "('Leganza', '75')," +
                            "('Matiz', '75')," +
                            "('Racer', '75')," +
                            "('Super Saloon', '75')," +
                            "('Tico', '75')," +
                            "('Feroza', '15')," +
                            "('Terios', '15')," +
                            "('Cuore', '76')," +
                            "('Materia', '76')," +
                            "('Move', '76')," +
                            "('Sirion', '76')," +
                            "('Applause', '76')," +
                            "('Charade', '76')," +
                            "('Copen', '76')," +
                            "('YRV', '76')," +
                            "('Rich', '16')," +
                            "('2.5', '16')," +
                            "('Seres 3', '17')," +
                            "('Durango', '18')," +
                            "('Journey', '18')," +
                            "('Ram', '18')," +
                            "('Caliber', '18')," +
                            "('Dakota', '18')," +
                            "('Nitro', '18')," +
                            "('Avenger', '77')," +
                            "('Challenger', '77')," +
                            "('Neon', '77')," +
                            "('Viper', '77')," +
                            "('Charger', '77')," +
                            "('Magnum', '77')," +
                            "('Stealth', '77')," +
                            "('DS3 Crossback', '19')," +
                            "('Crossback', '19')," +
                            "('DS 3', '78')," +
                            "('DS 4', '78')," +
                            "('DS 4 Crossback', '78')," +
                            "('DS 5', '78')," +
                            "('Talon', '79')," +
                            "('360', '80')," +
                            "('430', '80')," +
                            "('458', '80')," +
                            "('488', '80')," +
                            "('512', '80')," +
                            "('550', '80')," +
                            "('575', '80')," +
                            "('599', '80')," +
                            "('612', '80')," +
                            "('812', '80')," +
                            "('California', '80')," +
                            "('F12', '80')," +
                            "('F355', '80')," +
                            "('F8', '80')," +
                            "('FF', '80')," +
                            "('Portofino', '80')," +
                            "('Roma', '80')," +
                            "('SF90', '80')," +
                            "('500 X', '20')," +
                            "('Fullback', '20')," +
                            "('Freemont', '20')," +
                            "('124 Spider', '81')," +
                            "('126 Bis', '81')," +
                            "('500 Ailesi', '81')," +
                            "('Albea', '81')," +
                            "('Brava', '81')," +
                            "('Bravo', '81')," +
                            "('Coupe', '81')," +
                            "('Croma', '81')," +
                            "('Egea', '81')," +
                            "('Idea', '81')," +
                            "('Linea', '81')," +
                            "('Marea', '81')," +
                            "('Mirafiori', '81')," +
                            "('Palio', '81')," +
                            "('Panda', '81')," +
                            "('Punto', '81')," +
                            "('Sedici', '81')," +
                            "('Seicento', '81')," +
                            "('Siena', '81')," +
                            "('Stilo', '81')," +
                            "('Tempra', '81')," +
                            "('Tipo', '81')," +
                            "('Karma', '82')," +
                            "('EcoSport', '21')," +
                            "('Edge', '21')," +
                            "('Expedition', '21')," +
                            "('Explorer', '21')," +
                            "('F', '21')," +
                            "('Flex', '21')," +
                            "('Kuga', '21')," +
                            "('Mustang Mach-E', '21')," +
                            "('Puma', '21')," +
                            "('Ranger', '21')," +
                            "('Ranger Raptor', '21')," +
                            "('Bronco', '21')," +
                            "('Escape', '21')," +
                            "('B-Max', '83')," +
                            "('C-Max', '83')," +
                            "('Escort', '83')," +
                            "('Fiesta', '83')," +
                            "('Focus', '83')," +
                            "('Fusion', '83')," +
                            "('Galaxy', '83')," +
                            "('Grand C-Max', '83')," +
                            "('Ka', '83')," +
                            "('Mondeo', '83')," +
                            "('Mustang', '83')," +
                            "('S-Max', '83')," +
                            "('Taurus', '83')," +
                            "('Cougar', '83')," +
                            "('Festiva', '83')," +
                            "('Granada', '83')," +
                            "('Orion', '83')," +
                            "('Probe', '83')," +
                            "('Scorpio', '83')," +
                            "('Sierra', '83')," +
                            "('Echo', '84')," +
                            "('Emgrand', '84')," +
                            "('Familia', '84')," +
                            "('FC', '84')," +
                            "('Prizm', '85')," +
                            "('Envoy', '22')," +
                            "('Jimmy', '22')," +
                            "('Sierra', '22')," +
                            "('Sonoma', '22')," +
                            "('Typhoon', '22')," +
                            "('Yukon', '22')," +
                            "('CR-V', '23')," +
                            "('HR-V', '23')," +
                            "('Element', '23')," +
                            "('Pilot', '23')," +
                            "('Accord', '86')," +
                            "('City', '86')," +
                            "('Civic', '86')," +
                            "('CRX', '86')," +
                            "('CR-Z', '86')," +
                            "('E', '86')," +
                            "('Integra', '86')," +
                            "('Jazz', '86')," +
                            "('Legend', '86')," +
                            "('Prelude', '86')," +
                            "('S2000', '86')," +
                            "('Shuttle', '86')," +
                            "('Stream', '86')," +
                            "('H1', '24')," +
                            "('H2', '24')," +
                            "('H3', '24')," +
                            "('Bayon', '25')," +
                            "('ix35', '25')," +
                            "('ix55', '25')," +
                            "('Kona', '25')," +
                            "('Santa Fe', '25')," +
                            "('Tucson', '25')," +
                            "('Galloper', '25')," +
                            "('Terracan', '25')," +
                            "('Accent', '87')," +
                            "('Accent Blue', '87')," +
                            "('Accent Era', '87')," +
                            "('Atos', '87')," +
                            "('Centennial', '87')," +
                            "('Coupe', '87')," +
                            "('Elantra', '87')," +
                            "('Excel', '87')," +
                            "('Genesis', '87')," +
                            "('Getz', '87')," +
                            "('Grandeur', '87')," +
                            "('Ioniq', '87')," +
                            "('i10', '87')," +
                            "('i20', '87')," +
                            "('i20 Active', '87')," +
                            "('i20 Troy', '87')," +
                            "('i30', '87')," +
                            "('i40', '87')," +
                            "('iX20', '87')," +
                            "('Matrix', '87')," +
                            "('S-Coupe', '87')," +
                            "('Sonata', '87')," +
                            "('Trajet', '87')," +
                            "('Samand', '88')," +
                            "('1.6', '88')," +
                            "('1.6 LX', '88')," +
                            "('FX', '26')," +
                            "('QX', '26')," +
                            "('EX', '26')," +
                            "('Q30', '89')," +
                            "('Q50', '89')," +
                            "('Q60', '89')," +
                            "('G', '89')," +
                            "('I30', '89')," +
                            "('M', '89')," +
                            "('D-Max', '27')," +
                            "('Trooper', '27')," +
                            "('Gemini', '90')," +
                            "('E-Pace', '28')," +
                            "('F-Pace', '28')," +
                            "('I-Pace', '28')," +
                            "('Daimler', '91')," +
                            "('F-Type', '91')," +
                            "('Sovereign', '91')," +
                            "('S-Type', '91')," +
                            "('XE', '91')," +
                            "('XF', '91')," +
                            "('XJ', '91')," +
                            "('XJR', '91')," +
                            "('XJS', '91')," +
                            "('XK8', '91')," +
                            "('XKR', '91')," +
                            "('X-Type', '91')," +
                            "('Cherokee', '29')," +
                            "('Commander', '29')," +
                            "('Compass', '29')," +
                            "('Gladiator', '29')," +
                            "('Grand Cherokee', '29')," +
                            "('Patriot', '29')," +
                            "('Renegade', '29')," +
                            "('Wrangler', '29')," +
                            "('CJ', '29')," +
                            "('Niro', '30')," +
                            "('Sorento', '30')," +
                            "('Soul', '30')," +
                            "('Sportage', '30')," +
                            "('Stonic', '30')," +
                            "('XCeed', '30')," +
                            "('Capital', '92')," +
                            "('Carens', '92')," +
                            "('Carnival', '92')," +
                            "('Ceed', '92')," +
                            "('Cerato', '92')," +
                            "('Clarus', '92')," +
                            "('Magentis', '92')," +
                            "('Opirus', '92')," +
                            "('Optima', '92')," +
                            "('Picanto', '92')," +
                            "('Pride', '92')," +
                            "('Pro Ceed', '92')," +
                            "('Rio', '92')," +
                            "('Sephia', '92')," +
                            "('Shuma', '92')," +
                            "('Stinger', '92')," +
                            "('Venga', '92')," +
                            "('Niva', '31')," +
                            "('Kalina', '93')," +
                            "('Nova', '93')," +
                            "('Samara', '93')," +
                            "('VAZ', '93')," +
                            "('Vega', '93')," +
                            "('Urus 4.0', '32')," +
                            "('Aventador', '94')," +
                            "('Gallardo', '94')," +
                            "('Huracan', '94')," +
                            "('Delta', '95')," +
                            "('Thema', '95')," +
                            "('Y (Ypsilon)', '95')," +
                            "('Dedra', '95')," +
                            "('Phedra', '95')," +
                            "('Defender', '33')," +
                            "('Discovery', '33')," +
                            "('Discovery Sport', '33')," +
                            "('Range Rover', '33')," +
                            "('Range Rover Evoque', '33')," +
                            "('Range Rover Sport', '33')," +
                            "('Range Rov', '33')," +
                            "('LX', '34')," +
                            "('NX', '34')," +
                            "('RX', '34')," +
                            "('RX L', '34')," +
                            "('CT', '96')," +
                            "('ES', '96')," +
                            "('GS', '96')," +
                            "('IS', '96')," +
                            "('LC', '96')," +
                            "('LS', '96')," +
                            "('RC', '96')," +
                            "('SC', '96')," +
                            "('Aviator', '35')," +
                            "('MKT', '35')," +
                            "('Nautilus', '35')," +
                            "('Navigator', '35')," +
                            "('MKS', '97')," +
                            "('Continental', '97')," +
                            "('LS', '97')," +
                            "('Town Car', '97')," +
                            "('Elise', '98')," +
                            "('Evora', '98')," +
                            "('Exige', '98')," +
                            "('Esprit', '98')," +
                            "('Goa', '36')," +
                            "('Pick-up', '36')," +
                            "('Mantis', '99')," +
                            "('Levante', '37')," +
                            "('4 Serisi', '100')," +
                            "('Ghibli', '100')," +
                            "('GranCabrio', '100')," +
                            "('GranTurismo', '100')," +
                            "('GT', '100')," +
                            "('Quattroporte', '100')," +
                            "('CX-3', '38')," +
                            "('CX-5', '38')," +
                            "('CX-9', '38')," +
                            "('B Serisi', '38')," +
                            "('2', '101')," +
                            "('3', '101')," +
                            "('5', '101')," +
                            "('6', '101')," +
                            "('MPV', '101')," +
                            "('MX', '101')," +
                            "('Premacy', '101')," +
                            "('121', '101')," +
                            "('323', '101')," +
                            "('626', '101')," +
                            "('929', '101')," +
                            "('Lantis', '101')," +
                            "('RX', '101')," +
                            "('Xedos', '101')," +
                            "('650S Coupe', '102')," +
                            "('720S', '102')," +
                            "('EQC', '39')," +
                            "('GL', '39')," +
                            "('GLA', '39')," +
                            "('GLB', '39')," +
                            "('GLC', '39')," +
                            "('GLE', '39')," +
                            "('GLK', '39')," +
                            "('GLS', '39')," +
                            "('G Serisi', '39')," +
                            "('ML', '39')," +
                            "('X', '39')," +
                            "('AMG GT', '103')," +
                            "('A Serisi', '103')," +
                            "('B Serisi', '103')," +
                            "('CL', '103')," +
                            "('CLA', '103')," +
                            "('CLC', '103')," +
                            "('CLK', '103')," +
                            "('CLS', '103')," +
                            "('C Serisi', '103')," +
                            "('E Serisi', '103')," +
                            "('Maybach S', '103')," +
                            "('R Serisi', '103')," +
                            "('SL', '103')," +
                            "('SLC', '103')," +
                            "('SLK', '103')," +
                            "('SLS AMG', '103')," +
                            "('S Serisi', '103')," +
                            "('190', '103')," +
                            "('200', '103')," +
                            "('220', '103')," +
                            "('230', '103')," +
                            "('240', '103')," +
                            "('250', '103')," +
                            "('260', '103')," +
                            "('280', '103')," +
                            "('300', '103')," +
                            "('320', '103')," +
                            "('380', '103')," +
                            "('420', '103')," +
                            "('500', '103')," +
                            "('560', '103')," +
                            "('600', '103')," +
                            "('Mariner', '40')," +
                            "('Milan', '104')," +
                            "('Grand Marquis', '104')," +
                            "('F', '105')," +
                            "('ZR', '105')," +
                            "('ZT', '105')," +
                            "('Cooper Countryman', '41')," +
                            "('Cooper', '106')," +
                            "('Cooper Clubman', '106')," +
                            "('Cooper Electric', '106')," +
                            "('John Cooper', '106')," +
                            "('One', '106')," +
                            "('Cooper S', '106')," +
                            "('ASX', '42')," +
                            "('Eclipse Cross', '42')," +
                            "('L 200', '42')," +
                            "('Outlander', '42')," +
                            "('Pajero', '42')," +
                            "('Attrage', '107')," +
                            "('Colt', '107')," +
                            "('Galant', '107')," +
                            "('Lancer', '107')," +
                            "('Lancer Evolution', '107')," +
                            "('3000GT', '107')," +
                            "('Carisma', '107')," +
                            "('Chariot', '107')," +
                            "('Eclipse', '107')," +
                            "('Sigma', '107')," +
                            "('Space Star', '107')," +
                            "('Space Wagon', '107')," +
                            "('1500 SL', '108')," +
                            "('Aleko', '108')," +
                            "('Juke', '43')," +
                            "('Navara', '43')," +
                            "('Pathfinder', '43')," +
                            "('Patrol', '43')," +
                            "('Qashqai', '43')," +
                            "('Qashqai+2', '43')," +
                            "('X-Trail', '43')," +
                            "('Country', '43')," +
                            "('Murano', '43')," +
                            "('Rally Raid', '43')," +
                            "('Skystar', '43')," +
                            "('Terrano', '43')," +
                            "('200 SX', '109')," +
                            "('300 ZX', '109')," +
                            "('350 Z', '109')," +
                            "('Almera', '109')," +
                            "('Altima', '109')," +
                            "('Bluebird', '109')," +
                            "('Cedric', '109')," +
                            "('GT-R', '109')," +
                            "('Laurel Altima', '109')," +
                            "('Maxima', '109')," +
                            "('Micra', '109')," +
                            "('Note', '109')," +
                            "('NX Coupe', '109')," +
                            "('Primera', '109')," +
                            "('Pulsar', '109')," +
                            "('Sunny', '109')," +
                            "('Teana', '109')," +
                            "('Antara', '44')," +
                            "('Crossland', '44')," +
                            "('Crossland X', '44')," +
                            "('Grandland X', '44')," +
                            "('Mokka', '44')," +
                            "('Mokka X', '44')," +
                            "('Frontera', '44')," +
                            "('Adam', '110')," +
                            "('Agila', '110')," +
                            "('Ampera', '110')," +
                            "('Ascona', '110')," +
                            "('Astra', '110')," +
                            "('Calibra', '110')," +
                            "('Cascada', '110')," +
                            "('Corsa', '110')," +
                            "('GT (Roadster)', '110')," +
                            "('Insignia', '110')," +
                            "('Kadett', '110')," +
                            "('Manta', '110')," +
                            "('Meriva', '110')," +
                            "('Omega', '110')," +
                            "('Rekord', '110')," +
                            "('Senator', '110')," +
                            "('Signum', '110')," +
                            "('Tigra', '110')," +
                            "('Vectra', '110')," +
                            "('Zafira', '110')," +
                            "('2008', '45')," +
                            "('3008', '45')," +
                            "('4007', '45')," +
                            "('5008', '45')," +
                            "('106', '111')," +
                            "('107', '111')," +
                            "('205', '111')," +
                            "('206', '111')," +
                            "('206 +', '111')," +
                            "('207', '111')," +
                            "('208', '111')," +
                            "('301', '111')," +
                            "('305', '111')," +
                            "('306', '111')," +
                            "('307', '111')," +
                            "('308', '111')," +
                            "('405', '111')," +
                            "('406', '111')," +
                            "('407', '111')," +
                            "('508', '111')," +
                            "('605', '111')," +
                            "('607', '111')," +
                            "('806', '111')," +
                            "('807', '111')," +
                            "('RCZ', '111')," +
                            "('1007', '111')," +
                            "('Firebird', '112')," +
                            "('Sunbird', '112')," +
                            "('Cayenne', '46')," +
                            "('Macan', '46')," +
                            "('718', '113')," +
                            "('911', '113')," +
                            "('924', '113')," +
                            "('928', '113')," +
                            "('968', '113')," +
                            "('Boxster', '113')," +
                            "('Cayman', '113')," +
                            "('Panamera', '113')," +
                            "('Taycan', '113')," +
                            "('2.4', '47')," +
                            "('Gen-2', '114')," +
                            "('Saga', '114')," +
                            "('Savvy', '114')," +
                            "('Waja', '114')," +
                            "('218', '114')," +
                            "('315', '114')," +
                            "('316', '114')," +
                            "('413', '114')," +
                            "('415', '114')," +
                            "('416', '114')," +
                            "('418', '114')," +
                            "('420', '114')," +
                            "('Perdana', '114')," +
                            "('Persona', '114')," +
                            "('Captur', '48')," +
                            "('Kadjar', '48')," +
                            "('Koleos', '48')," +
                            "('Scenic RX4', '48')," +
                            "('Clio', '115')," +
                            "('Espace', '115')," +
                            "('Fluence', '115')," +
                            "('Fluence Z.E.', '115')," +
                            "('Grand Scenic', '115')," +
                            "('Laguna', '115')," +
                            "('Latitude', '115')," +
                            "('Megane', '115')," +
                            "('Modus', '115')," +
                            "('Safrane', '115')," +
                            "('Scenic', '115')," +
                            "('Symbol', '115')," +
                            "('Taliant', '115')," +
                            "('Talisman', '115')," +
                            "('Twingo', '115')," +
                            "('Twizy', '115')," +
                            "('Vel Satis', '115')," +
                            "('ZOE', '115')," +
                            "('R 5', '115')," +
                            "('R 9', '115')," +
                            "('R 11', '115')," +
                            "('R 12', '115')," +
                            "('R 19', '115')," +
                            "('R 21', '115')," +
                            "('R 25', '115')," +
                            "('Cullinan', '49')," +
                            "('Dawn', '116')," +
                            "('Ghost', '116')," +
                            "('Phantom', '116')," +
                            "('Wraith', '116')," +
                            "('Silver', '116')," +
                            "('25', '117')," +
                            "('45', '117')," +
                            "('75', '117')," +
                            "('111', '117')," +
                            "('200', '117')," +
                            "('214', '117')," +
                            "('216', '117')," +
                            "('218', '117')," +
                            "('220', '117')," +
                            "('400', '117')," +
                            "('414', '117')," +
                            "('416', '117')," +
                            "('420', '117')," +
                            "('620', '117')," +
                            "('623', '117')," +
                            "('820', '117')," +
                            "('Streetwise', '117')," +
                            "('9-3', '118')," +
                            "('9-5', '118')," +
                            "('900', '118')," +
                            "('9000', '118')," +
                            "('Arona', '50')," +
                            "('Ateca', '50')," +
                            "('Alhambra', '119')," +
                            "('Altea', '119')," +
                            "('Arosa', '119')," +
                            "('Cordoba', '119')," +
                            "('Exeo', '119')," +
                            "('Ibiza', '119')," +
                            "('Leon', '119')," +
                            "('Marbella', '119')," +
                            "('Toledo', '119')," +
                            "('Kamiq', '51')," +
                            "('Karoq', '51')," +
                            "('Kodiaq', '51')," +
                            "('Yeti', '51')," +
                            "('Citigo', '120')," +
                            "('Fabia', '120')," +
                            "('Favorit', '120')," +
                            "('Felicia', '120')," +
                            "('Forman', '120')," +
                            "('Octavia', '120')," +
                            "('Rapid', '120')," +
                            "('Roomster', '120')," +
                            "('Scala', '120')," +
                            "('Superb', '120')," +
                            "('Fortwo', '121')," +
                            "('Forfour', '121')," +
                            "('Roadster', '121')," +
                            "('Actyon', '52')," +
                            "('Actyon Sports', '52')," +
                            "('Korando', '52')," +
                            "('Korando Sports', '52')," +
                            "('Kyron', '52')," +
                            "('Musso', '52')," +
                            "('Musso Grand', '52')," +
                            "('Rexton', '52')," +
                            "('Tivoli', '52')," +
                            "('XLV', '52')," +
                            "('Rodius', '52')," +
                            "('Forester', '53')," +
                            "('Outback', '53')," +
                            "('XV', '53')," +
                            "('Tribeca', '53')," +
                            "('BRZ', '122')," +
                            "('Impreza', '122')," +
                            "('Legacy', '122')," +
                            "('Levorg', '122')," +
                            "('Justy', '122')," +
                            "('Vivio', '122')," +
                            "('Grand Vitara', '54')," +
                            "('Jimny', '54')," +
                            "('SJ', '54')," +
                            "('SX4 S-Cross', '54')," +
                            "('Vitara', '54')," +
                            "('X-90', '54')," +
                            "('Alto', '123')," +
                            "('Baleno', '123')," +
                            "('Splash', '123')," +
                            "('Swift', '123')," +
                            "('SX4', '123')," +
                            "('Wagon R', '123')," +
                            "('Liana', '123')," +
                            "('Maruti', '123')," +
                            "('Telcoline', '55')," +
                            "('Xenon', '55')," +
                            "('Indica', '124')," +
                            "('Indigo', '124')," +
                            "('Marina', '124')," +
                            "('Vista', '124')," +
                            "('Manza', '124')," +
                            "('Model 3', '125')," +
                            "('Model S', '125')," +
                            "('Model X', '125')," +
                            "('Doğan', '126')," +
                            "('Kartal', '126')," +
                            "('Murat', '126')," +
                            "('Serçe', '126')," +
                            "('Şahin', '126')," +
                            "('C-HR', '56')," +
                            "('FJ Cruiser', '56')," +
                            "('Hilux', '56')," +
                            "('Land Cruiser', '56')," +
                            "('RAV4', '56')," +
                            "('4Runner', '56')," +
                            "('Fortuner', '56')," +
                            "('Tacoma', '56')," +
                            "('Auris', '127')," +
                            "('Avensis', '127')," +
                            "('Camry', '127')," +
                            "('Carina', '127')," +
                            "('Celica', '127')," +
                            "('Corolla', '127')," +
                            "('Corona', '127')," +
                            "('Cressida', '127')," +
                            "('Estima', '127')," +
                            "('GT86', '127')," +
                            "('Mark 2', '127')," +
                            "('MR2', '127')," +
                            "('Paseo', '127')," +
                            "('Picnic', '127')," +
                            "('Previa', '127')," +
                            "('Prius', '127')," +
                            "('Starlet', '127')," +
                            "('Supra', '127')," +
                            "('Tercel', '127')," +
                            "('Urban Cruiser', '127')," +
                            "('Verso', '127')," +
                            "('Yaris', '127')," +
                            "('Amarok', '57')," +
                            "('Tiguan', '57')," +
                            "('Tiguan AllSpace', '57')," +
                            "('Touareg', '57')," +
                            "('T-Roc', '57')," +
                            "('Arteon', '128')," +
                            "('Beetle', '128')," +
                            "('Bora', '128')," +
                            "('EOS', '128')," +
                            "('Fox', '128')," +
                            "('Golf', '128')," +
                            "('ID.3', '128')," +
                            "('Jetta', '128')," +
                            "('Lupo', '128')," +
                            "('Passat', '128')," +
                            "('Passat Variant', '128')," +
                            "('Phaeton', '128')," +
                            "('Polo', '128')," +
                            "('Santana', '128')," +
                            "('Scirocco', '128')," +
                            "('Sharan', '128')," +
                            "('Touran', '128')," +
                            "('Up Club', '128')," +
                            "('Vento', '128')," +
                            "('VW CC', '128')," +
                            "('XC40', '58')," +
                            "('XC60', '58')," +
                            "('XC70', '58')," +
                            "('XC90', '58')," +
                            "('C30', '129')," +
                            "('C70', '129')," +
                            "('S40', '129')," +
                            "('S60', '129')," +
                            "('S70', '129')," +
                            "('S80', '129')," +
                            "('S90', '129')," +
                            "('V40', '129')," +
                            "('V40 Cross Country', '129')," +
                            "('V50', '129')," +
                            "('V60', '129')," +
                            "('V60 Cross Country', '129')," +
                            "('V70', '129')," +
                            "('V90', '129')," +
                            "('V90 Cross Country', '129')," +
                            "('240', '129')," +
                            "('245', '129')," +
                            "('440', '129')," +
                            "('740', '129')," +
                            "('850', '129')," +
                            "('940', '129')," +
                            "('960', '129');";

                            if (komut.ExecuteNonQuery() > -1)
                            {
                                komut.CommandText = "CREATE TABLE IF NOT EXISTS `arac_tipi` (" +
                                "`tip_ID` int(4) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                "`tip_name` VARCHAR(20) NOT NULL," +
                                "PRIMARY KEY(`tip_ID`)" +
                                ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                if (komut.ExecuteNonQuery() > -1)
                                {
                                    komut.CommandText = "INSERT INTO `arac_tipi` (`tip_name`) VALUES" +
                                    "('Arazi SUV')," +
                                    "('Otomobil');";

                                    if (komut.ExecuteNonQuery() > -1)
                                    {
                                        komut.CommandText = "CREATE TABLE IF NOT EXISTS `arac_yili` (" +
                                        "`yil_ID` int(3) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                        "`yil_name` VARCHAR(4) NOT NULL," +
                                        "PRIMARY KEY(`yil_ID`)" +
                                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                        if (komut.ExecuteNonQuery() > -1)
                                        {
                                            komut.CommandText = "INSERT INTO `arac_yili` (`yil_name`) VALUES" +
                                            "('1923')," +
                                            "('1924')," +
                                            "('1925')," +
                                            "('1926')," +
                                            "('1927')," +
                                            "('1928')," +
                                            "('1929')," +
                                            "('1930')," +
                                            "('1931')," +
                                            "('1932')," +
                                            "('1933')," +
                                            "('1934')," +
                                            "('1935')," +
                                            "('1936')," +
                                            "('1937')," +
                                            "('1938')," +
                                            "('1939')," +
                                            "('1940')," +
                                            "('1941')," +
                                            "('1942')," +
                                            "('1943')," +
                                            "('1944')," +
                                            "('1945')," +
                                            "('1946')," +
                                            "('1947')," +
                                            "('1948')," +
                                            "('1949')," +
                                            "('1950')," +
                                            "('1951')," +
                                            "('1952')," +
                                            "('1953')," +
                                            "('1954')," +
                                            "('1955')," +
                                            "('1956')," +
                                            "('1957')," +
                                            "('1958')," +
                                            "('1959')," +
                                            "('1960')," +
                                            "('1961')," +
                                            "('1962')," +
                                            "('1963')," +
                                            "('1964')," +
                                            "('1965')," +
                                            "('1966')," +
                                            "('1967')," +
                                            "('1968')," +
                                            "('1969')," +
                                            "('1970')," +
                                            "('1971')," +
                                            "('1972')," +
                                            "('1973')," +
                                            "('1974')," +
                                            "('1975')," +
                                            "('1976')," +
                                            "('1977')," +
                                            "('1978')," +
                                            "('1979')," +
                                            "('1980')," +
                                            "('1981')," +
                                            "('1982')," +
                                            "('1983')," +
                                            "('1984')," +
                                            "('1985')," +
                                            "('1986')," +
                                            "('1987')," +
                                            "('1988')," +
                                            "('1989')," +
                                            "('1990')," +
                                            "('1991')," +
                                            "('1992')," +
                                            "('1993')," +
                                            "('1994')," +
                                            "('1995')," +
                                            "('1996')," +
                                            "('1997')," +
                                            "('1998')," +
                                            "('1999')," +
                                            "('2000')," +
                                            "('2001')," +
                                            "('2002')," +
                                            "('2003')," +
                                            "('2004')," +
                                            "('2005')," +
                                            "('2006')," +
                                            "('2007')," +
                                            "('2008')," +
                                            "('2009')," +
                                            "('2010')," +
                                            "('2011')," +
                                            "('2012')," +
                                            "('2013')," +
                                            "('2014')," +
                                            "('2015')," +
                                            "('2016')," +
                                            "('2017')," +
                                            "('2018')," +
                                            "('2019')," +
                                            "('2020')," +
                                            "('2021')," +
                                            "('2022')," +
                                            "('2023');";

                                            if (komut.ExecuteNonQuery() > -1)
                                            {
                                                komut.CommandText = "CREATE TABLE IF NOT EXISTS `kurulum_tarihi` (" +
                                                "`zamanID` int(1) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                                "`sifre` VARCHAR(32) NOT NULL," +
                                                "`zaman` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                                                "PRIMARY KEY(`zamanID`)" +
                                                ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                                if (komut.ExecuteNonQuery() > -1)
                                                {
                                                    komut.CommandText = "INSERT INTO `kurulum_tarihi` (`sifre`) VALUES" +
                                                    "('123456');";

                                                    if (komut.ExecuteNonQuery() > -1)
                                                    {
                                                        komut.CommandText = "CREATE TABLE IF NOT EXISTS `motor_hacmi` (" +
                                                        "`mh_ID` int(2) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                                        "`mh_name` VARCHAR(8) NOT NULL," +
                                                        "PRIMARY KEY(`mh_ID`)" +
                                                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                                        if (komut.ExecuteNonQuery() > -1)
                                                        {
                                                            komut.CommandText = "INSERT INTO `motor_hacmi` (`mh_name`) VALUES" +
                                                            "('0,7')," +
                                                            "('0,9')," +
                                                            "('1,0')," +
                                                            "('1,2')," +
                                                            "('1,3')," +
                                                            "('1,4')," +
                                                            "('1,5')," +
                                                            "('1,6')," +
                                                            "('1,7')," +
                                                            "('1,8')," +
                                                            "('1,9')," +
                                                            "('2,0')," +
                                                            "('2,2')," +
                                                            "('2,5')," +
                                                            "('2,7')," +
                                                            "('2,8')," +
                                                            "('3,0')," +
                                                            "('3,5')," +
                                                            "('+3,5');";

                                                            if (komut.ExecuteNonQuery() > -1)
                                                            {
                                                                komut.CommandText = "CREATE TABLE IF NOT EXISTS `musteriler` (" +
                                                                "`ms_ID` int(4) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                                                "`ms_adi` VARCHAR(17) NOT NULL," +
                                                                "`ms_tel` VARCHAR(17) NOT NULL," +
                                                                "`ms_plaka` VARCHAR(17) NOT NULL," +
                                                                "`ms_adres` VARCHAR(84) NOT NULL," +
                                                                "`tip_ID` VARCHAR(9) NOT NULL," +
                                                                "`mrk_ID` VARCHAR(32) NOT NULL," +
                                                                "`md_ID` VARCHAR(24) NOT NULL," +
                                                                "`yil_ID` VARCHAR(4) NOT NULL," +
                                                                "`mh_ID` VARCHAR(3) NOT NULL," +
                                                                "`kilometresi` VARCHAR(8) NOT NULL," +
                                                                "`yt_ID` VARCHAR(12) NOT NULL," +
                                                                "`eklenme_tarihi` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                                                                "PRIMARY KEY(`ms_ID`)" +
                                                                ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                                                if (komut.ExecuteNonQuery() > -1)
                                                                {
                                                                    komut.CommandText = "CREATE TABLE IF NOT EXISTS `teknisyenler` (" +
                                                                    "`tk_ID` int(3) UNSIGNED NOT NULL AUTO_INCREMENT," +
                                                                    "`tk_ad` VARCHAR(17) NOT NULL," +
                                                                    "`tk_tel` VARCHAR(17) NOT NULL," +
                                                                    "`tk_adres` VARCHAR(84) NOT NULL," +
                                                                    "PRIMARY KEY(`tk_ID`)" +
                                                                    ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                                                    if (komut.ExecuteNonQuery() > -1)
                                                                    {
                                                                        komut.CommandText = "CREATE TABLE IF NOT EXISTS `yakit_turu` (" +
                                                                        "`yt_ID` int(2) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                                                        "`yt_name` VARCHAR(16) NOT NULL," +
                                                                        "PRIMARY KEY(`yt_ID`)" +
                                                                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

                                                                        if (komut.ExecuteNonQuery() > -1)
                                                                        {
                                                                            komut.CommandText = "INSERT INTO `yakit_turu` (`yt_name`) VALUES" +
                                                                            "('Benzin')," +
                                                                            "('Dizel')," +
                                                                            "('Benzin & LPG')," +
                                                                            "('Elektrikli');";

                                                                            if (komut.ExecuteNonQuery() > -1)
                                                                            {
                                                                                komut.CommandText = "CREATE TABLE IF NOT EXISTS `yapilan_islemler` (" +
                                                                                "`isl_ID` int(3) UNSIGNED NOT NULL AUTO_INCREMENT, " +
                                                                                "`ms_ID` int(4) NOT NULL," +
                                                                                "`sikayet` text," +
                                                                                "`yapilan_islem` tinytext," +
                                                                                "`adet` VARCHAR(2) CHARACTER SET utf32 NOT NULL DEFAULT '0'," +
                                                                                "`birim_fiyat` VARCHAR(8) NOT NULL DEFAULT '0'," +
                                                                                "`tk_ID` int(3) NOT NULL DEFAULT '0'," +
                                                                                "`tutar` VARCHAR(8) CHARACTER SET utf32 NOT NULL DEFAULT '0'," +
                                                                                "`tarih` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                                                                                "`teknisyen_ad` VARCHAR(17) NOT NULL," +
                                                                                "PRIMARY KEY(`isl_ID`)" +
                                                                                ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (komut.ExecuteNonQuery() > -1)
                {
                    baglantiyiKapat();
                    return true;
                }
            }
            baglantiyiKapat();
            return false;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen tabloya ait kayıtları DataTable türünde geri döndürür. 
        ///Eğer belirtilmişse yalnızca koşula uyan kayıtlar çekilir.
        ///Fonksiyon değişken sayıda parametre alabilir. İlk parametre tablo ismi olmalıdır.
        ///Tablo isminden sonraki her gönderilen parametreden birincisi kolon ismi, ikincisi koşul değeri olmalıdır. 
        ///Eğer tablo isminden sonra herhangi bir sırada NOT ifadesi parametre olarak gönderilirse 
        ///bulunduğu noktadan itibaren diğer parametreler AND NOT bağlacıyla birleştirilir.
        /// </summary>
        public DataTable genel(params string[] prms)
        {
            DataTable sonuc = new DataTable();
            byte x = 0;

            if (prms.Length == 1) komut.CommandText = "SELECT * FROM " + prms[0] + ";";
            else if (prms.Length > 1)
            {
                komut.CommandText = "SELECT * FROM " + prms[0] + " WHERE ";

                for (int i = 1; i < prms.Length - 1;)
                {
                    if (Equals(prms[i], "NOT"))
                    {
                        i++;
                        komut.CommandText += "NOT ";
                        x = 1;
                    }
                    komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";
                    i += 2;
                    if (i >= prms.Length) komut.CommandText += ";";
                    else if (x == 0)
                    {
                        komut.CommandText += " AND ";
                    }
                    else
                    {
                        komut.CommandText += " AND NOT ";
                    }
                }
            }
            veriUyarlayici = new MySqlDataAdapter(komut.CommandText, baglayici);
            veriUyarlayici.Fill(sonuc);
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki tablodan belirtilen kolonlara ait kayıtları string türünde geri döndürür.
        ///Eğer belirtilmişse yalnızca koşula uyan kayıtlar çekilir. Fonksiyon değişken sayıda parametre
        ///alabilir. İlk parametre bir dizidir. Dizinin ilk elemanı tablo ismi olmalıdır. Dizinin tablo
        ///isminden sonraki diğer elemanları tabloya ait kolon ismidir. İkinci parametre koşulların yer
        ///aldığı ayrı bir dizi olmalıdır. Koşullar dizisindeki her elemandan birincisi kolon ismi, 
        ///ikincisi koşul değeridir. Koşullar AND bağlacıyla birleştirilir. Eğer kolon isminden sonra
        ///herhangi bir sırada NOT ifadesi parametre olarak gönderilirse bulunduğu noktadan itibaren
        ///diğer parametreler AND NOT bağlacıyla birleştirilir.
        /// </summary>
        public string[] al(string[] kolonlar, params string[] kosul)
        {
            baglantiyiKapat();
            int no = kayitSayisi(kolonlar[0], kosul);
            string[] sonuc = new string[no];
            byte x = 0;

            if (kolonlar.Length == 0) return sonuc;
            if (baglan())
            {
                if (kolonlar.Length == 1) komut.CommandText = "SELECT * FROM " + kolonlar[0];
                else
                {
                    komut.CommandText = "SELECT ";

                    for (int i = 1; i < kolonlar.Length; i++)
                    {
                        if (i != kolonlar.Length - 1) komut.CommandText += kolonlar[i] + ", ";
                        else komut.CommandText += kolonlar[i] + " FROM " + kolonlar[0];
                    }
                }
                if (kosul.Length > 0)
                {
                    komut.CommandText += " WHERE ";

                    for (int i = 0; i < kosul.Length - 1;)
                    {
                        if (Equals(kosul[i], "NOT"))
                        {
                            i++;
                            komut.CommandText += "NOT ";
                            x = 1;
                        }
                        komut.CommandText += kosul[i] + "='" + kosul[i + 1] + "'";
                        i += 2;
                        if (i >= kosul.Length) komut.CommandText += ";";
                        else if (x == 0)
                        {
                            komut.CommandText += " AND ";
                        }
                        else
                        {
                            komut.CommandText += " AND NOT ";
                        }
                    }
                }
                veriOkuyucu = komut.ExecuteReader();

                int j = 0;

                while (veriOkuyucu.Read())
                {
                    sonuc[j] = veriOkuyucu.GetString(0);
                    j++;
                }
                veriOkuyucu.Close();
                baglantiyiKapat();
            }
            baglantiyiKapat();
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen tabloya ait kayıtları DataTable nesnesi olarak geri döndürür. 
        ///Eğer belirtilmişse yalnızca koşula uyan kayıtlar çekilir.
        ///İlk parametre bir dizidir. Bu dizinin ilk elemanı tablo ismi olmalıdır.
        ///Eğer tablodaki bazı kolonların seçilmesi isteniyorsa diziye eleman olarak 
        ///tablo isminden sonra istenen kolon isimleri de belirtilmelidir.
        ///Dizi isminden sonra gönderilecek parametre ya da parametreler isteğe bağlıdır ve koşul belirtmelidir. 
        ///Eğer belirtilmişse her gönderilen parametreden birincisi kolon ismi, 
        ///ikincisi ise aranan koşulu belirtmelidir. Koşullar VE bağlacıyla birleştirilir.
        /// </summary>
        public DataTable BelirliKolonlarıAl(string[] kolonlar, params string[] kosul)
        {
            DataTable sonuc = new DataTable();

            if (kolonlar.Length == 0) return null;
            if (kolonlar.Length == 1) komut.CommandText = "SELECT * FROM " + kolonlar[0];
            else
            {
                komut.CommandText = "SELECT ";

                for (int i = 1; i < kolonlar.Length; i++)
                {
                    if (i != kolonlar.Length - 1) komut.CommandText += kolonlar[i] + ", ";
                    else komut.CommandText += kolonlar[i] + " FROM " + kolonlar[0];
                }
            }
            if (kosul.Length > 0)
            {
                komut.CommandText += " WHERE ";

                for (int i = 0; i < kosul.Length - 1;)
                {
                    komut.CommandText += kosul[i] + "='" + kosul[i + 1] + "'";
                    i += 2;
                    if (i != kosul.Length) komut.CommandText += " AND ";
                }
            }
            komut.CommandText += ";";
            veriUyarlayici = new MySqlDataAdapter(komut.CommandText, baglayici);
            veriUyarlayici.Fill(sonuc);
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen tabloya ait kayıtları ya da belirli bir hücreyi getirir. 
        ///Eğer belirtilmişse yalnızca koşula uyan kayıtlar veya hücre çekilir.
        ///İlk parametre tablo ismi, ikinci parametre istenen kolon ya da tablonun tamamıdır.
        ///Üçüncü parametre koşullar ve değerlerini içeren bir dizidir. Eğer bu parametre fonksiyona gönderilirse
        ///her gönderilen parametreden birincisi kolon ismi, ikincisi koşul değeri olmalıdır. 
        ///Eğer ikinci parametreden sonra herhangi bir sırada NOT ifadesi parametre olarak gönderilirse 
        ///bulunduğu noktadan itibaren diğer parametreler AND NOT bağlacıyla birleştirilir.
        /// </summary>
        public string hucreGetir(string tablo_ismi, string istenenVeri, params string[] prms)
        {
            string sonuc = null;
            string yazi = null;
            byte x = 0;
            baglantiyiKapat();

            if (baglan())
            {
                if (prms.Length == 0) komut.CommandText = "SELECT " + istenenVeri + " FROM " + tablo_ismi + ";";
                else
                {
                    komut.CommandText = "SELECT " + istenenVeri + " FROM " + tablo_ismi + " WHERE ";

                    for (int i = 0; i < prms.Length - 1;)
                    {
                        if (Equals(prms[i], "NOT"))
                        {
                            i++;
                            komut.CommandText += "NOT ";
                            x = 1;
                        }
                        komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";
                        i += 2;
                        if (i >= prms.Length) komut.CommandText += ";";
                        else if (x == 0)
                        {
                            komut.CommandText += " AND ";
                        }
                        else
                        {
                            komut.CommandText += " AND NOT ";
                        }
                    }
                }
                veriOkuyucu = komut.ExecuteReader();

                while (veriOkuyucu.Read())
                {
                    for (int i = 0; i < veriOkuyucu.FieldCount; i++)
                    {
                        if (i == veriOkuyucu.FieldCount - 1)
                        {
                            yazi = veriOkuyucu.GetString(i);
                            yazi = Equals(yazi, "0") || Equals(yazi, "0,") || Equals(yazi, "0.") || Equals(yazi, "0,0") || Equals(yazi, "0.0") ||
                                Equals(yazi, "0,00") || Equals(yazi, "0.00") || Equals(yazi, "0,000") || Equals(yazi, "0.000") ||
                                Equals(yazi, ",0") || Equals(yazi, ".0") || Equals(yazi, ",00") || Equals(yazi, ".00") || Equals(yazi, ".00") ||
                                Equals(yazi, ",000") || Equals(yazi, ".000") ? "0" : yazi;
                            sonuc += yazi;
                        }
                        else
                            sonuc += veriOkuyucu.GetString(i) + ", ";
                    }
                }
                veriOkuyucu.Close();
                baglantiyiKapat();
            }
            baglantiyiKapat();
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen tabloya ait kayıtları DataTable türünde geri döndürür. 
        ///Eğer belirtilmişse yalnızca koşula uyan kayıtlar çekilir.
        ///Fonksiyon değişken sayıda parametre alabilir. İlk parametre tablo ismi olmalıdır.
        ///Tablo isminden sonraki her gönderilen parametreden birincisi kolon ismi, ikincisi koşul değeri olmalıdır. 
        ///Eğer tablo isminden sonra herhangi bir sırada NOT ifadesi parametre olarak gönderilirse 
        ///bulunduğu noktadan itibaren diğer parametreler AND NOT bağlacıyla birleştirilir.
        /// </summary>
        public DataTable Cek(params string[] prms)
        {
            DataTable sonuc = new DataTable();
            byte x = 0;

            if (prms.Length == 1) komut.CommandText = "SELECT * FROM " + prms[0] + ";";
            else if (prms.Length > 1)
            {
                komut.CommandText = "SELECT * FROM " + prms[0] + " WHERE ";

                for (int i = 1; i < prms.Length - 1;)
                {
                    if (Equals(prms[i], "NOT"))
                    {
                        i++;
                        komut.CommandText += "NOT ";
                        x = 1;
                    }
                    komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";
                    i += 2;
                    if (i >= prms.Length) komut.CommandText += ";";
                    else if (x == 0)
                    {
                        komut.CommandText += " AND ";
                    }
                    else
                    {
                        komut.CommandText += " AND NOT ";
                    }
                }
            }
            veriUyarlayici = new MySqlDataAdapter(komut.CommandText, baglayici);
            veriUyarlayici.Fill(sonuc);
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen iki tablodan ilkinden tüm kolonlara ait kayıtları,
        ///ikinci tablodan ise istenilen kolonlara ait kaydı birleştirerek DataTable türünde geri döndürür. 
        ///İlk parametre ilk tablonun ismi olmalıdır. İkinci parametre ikinci tablo adıdır. Üçüncü parametre
        ///ise her iki tablodaki ortak sütun adlarından biridir. Dördüncü parametre olarak değişken sayıda
        ///argüman gönderilebilir. Bu argümanlar birleştirilen tablodaki istenilen kolonların isimlerinin
        ///sırayla yer aldığı stringlerdir.
        /// </summary>
        public DataTable ikiliTumBirlesim(string tablo1, string tablo2, string ortakKolon, params string[] prms)
        {
            DataTable sonuc = new DataTable();

            komut.CommandText = "SELECT " + tablo1 + ".*";

            for (int i = 0; i < prms.Length; i++)
            {
                komut.CommandText += ", " + tablo2 + "." + prms[i];
            }
            komut.CommandText += " FROM " + tablo1 + " INNER JOIN " + tablo2 + " ON " + tablo1 + "." + ortakKolon + "=" + tablo2 + "." + ortakKolon + ";";
            veriUyarlayici = new MySqlDataAdapter(komut.CommandText, baglayici);
            veriUyarlayici.Fill(sonuc);
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanındaki görüntülenmesi istenen  tabloların ilkinden tüm kolonlara ait kayıtları,
        ///diğer tablolardan görüntülenmesi istenen birer adet kolonlara ait kaydı birleştirerek
        ///DataTable türünde geri döndürür. İlk parametre bir dizidir ve elemanları sırayla
        ///tabloların isimleri olmalıdır. İkinci parametre de bir dizidir ve elemanları sırasıyla
        ///ana tablo dışındaki diğer tablolardan birer adet olmak üzere görüntülenmesi istenen kolonların isimleridir.
        ///Üçüncü ve son parametre ise ilk tablonun diğer tablolarla ortak olan sütun adlarının
        ///sırayla yer aldığı bir dizidir.
        /// </summary>
        public DataTable cokluBirlesim(string[] tablolar, string[] kolonlar, string[] ortakKolonlar, string kosul = null)
        {
            DataTable sonuc = new DataTable();

            if (tablolar.Length > 1)
            {
                komut.CommandText = "SELECT " + tablolar[0] + ".*, ";

                for (int t = 0; t < kolonlar.Length; t++)
                {
                    komut.CommandText += tablolar[t + 1] + "." + kolonlar[t];

                    if (t != kolonlar.Length - 1) komut.CommandText += ", ";
                }
                komut.CommandText += " FROM " + tablolar[0] + " JOIN ";

                for (int k = 0; k < kolonlar.Length; k++)
                {
                    if (k > 0) komut.CommandText += " LEFT JOIN ";
                    komut.CommandText += tablolar[k + 1] + " ON " + tablolar[0] + "." + ortakKolonlar[k] + "=" + tablolar[k + 1] + "." + ortakKolonlar[k];
                }
                if (kosul != null && kosul.Length > 0)
                {
                    komut.CommandText += " " + kosul;
                }
                komut.CommandText += ";";
            }
            veriUyarlayici = new MySqlDataAdapter(komut.CommandText, baglayici);
            veriUyarlayici.Fill(sonuc);
            return sonuc;
        }

        /// <summary>
        ///MySQL veritabanında yer alan bir tabloya kayıt ekler.
        ///Fonksiyon üç adet parametre alabilir. İlk parametre tablo ismi olmalıdır.
        ///ikinci parametre eklenecek kolon isimlerinin yer aldığı bir dizi olmalıdır.
        ///Üçüncü parametre ise belirtilen kolonlara kaydedilecek değerler dizisidir.
        /// </summary>
        public bool ekle(string tablo, string[] kolonlar, string[] degerler)
        {
            baglantiyiKapat();

            if (string.IsNullOrEmpty(tablo) || kolonlar == null || degerler == null || degerler.Length % kolonlar.Length != 0) return false;
            else
            {
                if (baglan())
                {
                    komut.CommandText = "INSERT INTO `" + tablo + "` (`";

                    for (int i = 0; i < kolonlar.Length; i++)
                    {
                        if (i < kolonlar.Length - 1)
                        {
                            komut.CommandText += kolonlar[i] + "`, `";
                        }
                        else
                        {
                            komut.CommandText += kolonlar[i] + "`) VALUES (";
                        }
                    }

                    for (int i = 0; i < degerler.Length; i++)
                    {
                        komut.CommandText += "'" + degerler[i] + "'";

                        if (i < degerler.Length - 1)
                        {
                            if ((i + 1) % kolonlar.Length == 0)
                            {
                                komut.CommandText += "), (";
                            }
                            else
                            {
                                komut.CommandText += ", ";
                            }
                        }
                    }
                    komut.CommandText += ");";
                    komut.CommandType = CommandType.Text;

                    if (komut.ExecuteNonQuery() > 0)
                    {
                        baglantiyiKapat();
                    }
                }
            }
            baglantiyiKapat();
            return true;
        }

        ///<summary>
        ///MySQL veritabanında yer alan bir tablodaki satırı, belirtilen kolon isimleri ve koşula göre günceller.
        ///İlk parametre bir dizidir ve dizinin ilk elemanı tablo ismi olmalıdır. Tablo isminden sonraki her
        ///gönderilen parametreden birincisi kolon ismi, ikincisi koşul değeri olmalıdır. En az bir kolon ismi ve
        ///koşul değerinin kullanılması zorunludur. Koşul deyimleri, aralarında AND bağlacı ile birleştirilir.
        ///Fonksiyona koşul olarak NULL ifadesi de gönderilebilir. Eğer tablo isminden sonra herhangi bir sırada
        ///NOT ifadesi parametre olarak gönderilirse bulunduğu noktadan itibaren diğer parametreler AND NOT
        ///bağlacıyla birleştirilir. İkinci parametre güncellenecek kolon ve değerlerin belirtildiği dizi
        ///olmalıdır. Dizi elemanları sıra ile kolon ismi ve değer şeklinde yerleştirilmelidir.
        ///</summary>
        public bool guncelle(string[] kosul, params string[] prms)
        {
            if (kosul.Length < 1 || prms.Length < 2) return false;
            baglantiyiKapat();

            if (baglan())
            {
                byte x = 0;
                komut.CommandText = "UPDATE " + kosul[0] + " SET ";

                for (int i = 0; i < prms.Length - 1; i += 2)
                {
                    komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";

                    if (i < prms.Length - 2) komut.CommandText += ", ";
                }
                if (kosul.Length > 2) komut.CommandText += " WHERE ";

                for (int i = 1; i < kosul.Length - 1;)
                {
                    if (Equals(kosul[i], "NOT"))
                    {
                        i++;

                        if (Equals(kosul[i + 1], "null") || Equals(kosul[i + 1], "Null") || Equals(kosul[i + 1], "NULL"))
                        {
                            komut.CommandText += kosul[i] + " IS NOT NULL ";
                            i += 2;
                        }
                        else
                        {
                            komut.CommandText += "NOT ";
                        }
                        x = 1;
                    }
                    if (i < kosul.Length)
                    {
                        if (Equals(kosul[i + 1], "null") || Equals(kosul[i + 1], "Null") || Equals(kosul[i + 1], "NULL"))
                        {
                            komut.CommandText += kosul[i] + " IS NULL";
                            i += 2;
                        }
                        else
                        {
                            komut.CommandText += kosul[i] + "='" + kosul[i + 1] + "'";
                            i += 2;
                        }
                    }
                    if (i >= kosul.Length) komut.CommandText += ";";
                    else if (x == 0)
                    {
                        komut.CommandText += " AND ";
                    }
                    else
                    {
                        komut.CommandText += " AND NOT ";
                    }
                }
                if (komut.ExecuteNonQuery() > 0)
                {
                    baglantiyiKapat();
                    return true;
                }
            }
            baglantiyiKapat();
            return false;
        }

        /// <summary>
        ///MySQL veritabanında yer alan bir tablodaki satırı, belirtilen kolon isimleri ve koşula
        ///göre siler. İlk parametre tablo ismi olmalıdır. Sonraki parametrelerden ilki kolon adı,
        ///hemen sonraki koşul değeri olmalıdır. Birden fazla koşul parametre olarak geçilebilir.
        /// </summary>
        public bool sil(params string[] prms)
        {
            baglantiyiKapat();
            if (baglan())
            {
                if (prms.Length == 0) return false;
                komut.CommandText = "DELETE FROM " + prms[0] + " WHERE ";

                for (int i = 1; i < prms.Length - 1;)
                {
                    komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";
                    i += 2;
                    if (i != prms.Length) komut.CommandText += " AND ";
                }
                komut.CommandText += ";";

                if (komut.ExecuteNonQuery() > 0)
                {
                    baglantiyiKapat();
                    return true;
                }
            }
            baglantiyiKapat();
            return false;
        }

        /// <summary>
        ///MySQL veritabanındaki belirtilen tablodaki kayıt sayısını döndürür. 
        ///Eğer belirtilmişse koşula uyan kayıt sayısını döndürür.
        ///Kayıt bulunmuşsa kayıt sayısı, eğer kayıt bulunamamışsa 0 döndürür.
        ///Fonksiyonun ilk parametresi tablo ismi olmalıdır. Diğer parametreler isteğe bağlıdır.
        ///Tablo isminden sonraki her gönderilen parametreden birincisi kolon ismi, 
        ///ikincisi ise aranan koşulu belirtmelidir. Koşullar VE bağlacıyla birleştirilir.
        /// </summary>
        public int kayitSayisi(string tablo, string[] kosul = null)
        {
            byte x = 0;
            baglantiyiKapat();

            if (baglan())
            {
                int sonuc;

                if (kosul == null || kosul.Length == 0) komut.CommandText = "SELECT COUNT(*) FROM " + tablo + ";";
                else
                {
                    komut.CommandText = "SELECT COUNT(*) FROM " + tablo + " WHERE ";

                    for (int i = 0; i < kosul.Length - 1;)
                    {
                        if (Equals(kosul[i], "NOT"))
                        {
                            i++;
                            if (Equals(kosul[i + 1], "null") || Equals(kosul[i + 1], "Null") || Equals(kosul[i + 1], "NULL"))
                            {
                                komut.CommandText += kosul[i] + " IS NOT NULL ";
                                i += 2;
                            }
                            else
                            {
                                komut.CommandText += "NOT ";
                            }
                            x = 1;
                        }
                        if (i < kosul.Length)
                        {
                            if (Equals(kosul[i + 1], "null") || Equals(kosul[i + 1], "Null") || Equals(kosul[i + 1], "NULL"))
                            {
                                komut.CommandText += kosul[i] + " IS NULL";
                                i += 2;
                            }
                            else if (Equals(kosul[i + 1], "<"))
                            {
                                komut.CommandText += kosul[i] + " < '" + kosul[i + 2] + "'";
                                i += 3;
                            }
                            else if (Equals(kosul[i + 1], "<="))
                            {
                                komut.CommandText += kosul[i] + " <= '" + kosul[i + 2] + "'";
                                i += 3;
                            }
                            else if (Equals(kosul[i + 1], ">"))
                            {
                                komut.CommandText += kosul[i] + " > '" + kosul[i + 2] + "'";
                                i += 3;
                            }
                            else if (Equals(kosul[i + 1], ">="))
                            {
                                komut.CommandText += kosul[i] + " >= '" + kosul[i + 2] + "'";
                                i += 3;
                            }
                            else
                            {
                                komut.CommandText += kosul[i] + "='" + kosul[i + 1] + "'";
                                i += 2;
                            }
                        }
                        if (i >= kosul.Length) komut.CommandText += ";";
                        else if (x == 0)
                        {
                            komut.CommandText += " AND ";
                        }
                        else
                        {
                            komut.CommandText += " AND NOT ";
                        }
                    }
                }
                sonuc = Convert.ToInt32(komut.ExecuteScalar());

                if (sonuc > 0)
                {
                    baglantiyiKapat();
                    return sonuc;
                }
            }
            baglantiyiKapat();
            return 0;
        }

        /// <summary>
        ///MySQL veritabanında yer alan bir tablodaki satırı, belirtilen kolon isimleri ve koşula göre günceller.
        ///İlk parametre bir dizidir ve dizinin ilk elemanı tablo ismi olmalıdır. 
        ///Tablo isminden sonraki her gönderilen parametreden birincisi kolon ismi, ikincisi koşul değeri olmalıdır.
        ///En az bir kolon ismi ve koşul değerinin kullanılması zorunludur.
        ///Koşul deyimleri, aralarında AND bağlacı ile birleştirilir.
        ///Eğer tablo isminden sonra herhangi bir sırada NOT ifadesi parametre olarak gönderilirse 
        ///bulunduğu noktadan itibaren diğer parametreler AND NOT bağlacıyla birleştirilir.
        ///İkinci parametre güncellenecek kolon ve değerlerin belirtildiği dizi olmalıdır.
        ///Dizi elemanları sıra ile kolon ismi ve değer şeklinde yerleştirilmelidir.
        /// </summary>
        public bool degistir(string[] kosul, params string[] prms)
        {
            if (kosul.Length < 1 || prms.Length < 2) return false;
            baglantiyiKapat();

            if (baglan())
            {
                byte x = 0;
                komut.CommandText = "UPDATE " + kosul[0] + " SET ";

                for (int i = 0; i < prms.Length - 1; i += 2)
                {
                    komut.CommandText += prms[i] + "='" + prms[i + 1] + "'";

                    if (i < prms.Length - 2) komut.CommandText += ", ";
                }
                if (kosul.Length > 2) komut.CommandText += " WHERE ";

                for (int i = 1; i < kosul.Length - 1;)
                {
                    if (Equals(kosul[i], "NOT"))
                    {
                        i++;
                        komut.CommandText += "NOT ";
                        x = 1;
                    }
                    komut.CommandText += kosul[i] + "='" + kosul[i + 1] + "'";
                    i += 2;
                    if (i >= kosul.Length) komut.CommandText += ";";
                    else if (x == 0)
                    {
                        komut.CommandText += " AND ";
                    }
                    else
                    {
                        komut.CommandText += " AND NOT ";
                    }
                }
                if (komut.ExecuteNonQuery() > 0)
                {
                    baglantiyiKapat();
                    return true;
                }
            }
            baglantiyiKapat();
            return false;
        }
    }
}
