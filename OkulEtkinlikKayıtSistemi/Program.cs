using System.Collections;
using System.Collections.Specialized;

namespace OkulEtkinlikKayıtSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList etkinlikAdları = new ArrayList();
            ArrayList etkinlikTarihleri = new ArrayList();
            ArrayList kontenjanlar = new ArrayList();
            ArrayList kayitSayiları = new ArrayList();
            ArrayList ucretler = new ArrayList();
            ArrayList etkinlikAktifMi = new ArrayList();

            etkinlikAdları.Add("Yazılım Semineri");
            etkinlikTarihleri.Add(DateTime.Today.AddDays(10));
            kontenjanlar.Add(50);
            kayitSayiları.Add(0);
            ucretler.Add(0m);
            etkinlikAktifMi.Add(true);

            etkinlikAdları.Add("Müze Gezisi");
            etkinlikTarihleri.Add(DateTime.Today.AddDays(15));
            kontenjanlar.Add(25);
            kayitSayiları.Add(0);
            ucretler.Add(150m);
            etkinlikAktifMi.Add(true);

            etkinlikAdları.Add("Satranç Turnuvası");
            etkinlikTarihleri.Add(DateTime.Today.AddDays(20));
            kontenjanlar.Add(32);
            kayitSayiları.Add(0);
            ucretler.Add(50m);
            etkinlikAktifMi.Add(true);

            etkinlikAdları.Add("Bahar Konseri");
            etkinlikTarihleri.Add(DateTime.Today.AddDays(30));
            kontenjanlar.Add(80);
            kayitSayiları.Add(0);
            ucretler.Add(200m);
            etkinlikAktifMi.Add(true);



            ArrayList ogrenciNumaraları = new ArrayList();
            ArrayList ogrenciAdlari = new ArrayList();
            ArrayList kayitliEtkinlikIndexleri = new ArrayList();
            ArrayList kayıtTarihleri = new ArrayList();


            while (true)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("=======OKUL ETKİNLİK KAYIT SİSTEMİ=======");
                Console.WriteLine("=========================================");
                Console.WriteLine("1 - Etkinlikleri Listele");
                Console.WriteLine("2 - Etkinlik Ara");
                Console.WriteLine("3 - Etkinliğe Kayıt Ol");
                Console.WriteLine("4 - Kaydı İptal Et");
                Console.WriteLine("5 - Öğrencinin Kayıtlarını Göster");
                Console.WriteLine("6 - Yönetici Paneli");
                Console.WriteLine("7 - Raporlar");
                Console.WriteLine("0 - Çıkış");

                try
                {
                    Console.WriteLine("Lütfen Seçiminizi Girin");
                    int anaMenuSecim = Convert.ToInt32(Console.ReadLine());

                    if (anaMenuSecim == 1)
                    {
                        if(etkinlikAdları.Count==0)
                        {
                            Console.WriteLine("Güncel Etkinlik Bulunmamaktadır.");
                        }
                        for(int i=0;i<etkinlikAdları.Count;i++)
                        {
                            int no = (i + 1);
                            string ad = (string)etkinlikAdları[i];
                            DateTime tarih = (DateTime)etkinlikTarihleri[i];
                            decimal ucret = (decimal)ucretler[i];
                            int kontenjan = (int)kontenjanlar[i];
                            int kayit = (int)kayitSayiları[i];
                            bool aktifMi = (bool)etkinlikAktifMi[i];

                            string durum = aktifMi ? "Aktif" : "İptal";
                            if(aktifMi && tarih<DateTime.Today)
                            {
                                Console.WriteLine("Etkinlik Tarihi Geçmiştir.");
                            }

                            Console.WriteLine("Etkinlik No:"+(i+1));
                            Console.WriteLine("Etkinlik Adı:"+ad);
                            Console.WriteLine("Tarih"+tarih);
                            Console.WriteLine("Ücret:"+ucret+"TL");
                            Console.WriteLine("Kalan Kontenjan:"+(kontenjan-kayit));
                            Console.WriteLine("Durum:"+durum);

                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Devam Etmak İçin Bir Tuşa Basın");
                            Console.WriteLine("-------------------------------");
                            Console.ReadKey(true);
                        }
                    }
                    else if (anaMenuSecim == 2)
                    {
                        Console.WriteLine("Lütfen Aramak İstediğiniz Etkinliği Girin");
                        string aranan = Console.ReadLine();

                        if(aranan.Length==0)
                        {
                            Console.WriteLine("Eksik veya Hatalı İsim");
                        }
                        else
                        {
                            bool bulundu = false;

                            for(int i=0;i<etkinlikAdları.Count;i++)
                            {
                                string etkinlikAdi = (string)etkinlikAdları[i];

                                if(etkinlikAdi.ToLower().Contains(aranan))
                                {
                                    bulundu = true;
                                    DateTime tarih = (DateTime)etkinlikTarihleri[i];
                                    int kalan = (int)kontenjanlar[i] - (int)kayitSayiları[i];
                                    decimal ucret = (decimal)ucretler[i];
                                    bool aktifMi = (bool)etkinlikAktifMi[i];

                                    Console.WriteLine((i+1)+"-"+etkinlikAdi);
                                    Console.WriteLine("Tarih:"+tarih);
                                    Console.WriteLine("Ücret:"+ucret);
                                    Console.WriteLine("Kalan Kontenjan:"+kalan);
                                    Console.WriteLine("Durum:"+(aktifMi ?"Aktif":"İptal"));

                                    Console.WriteLine("-------------------------------");
                                    Console.WriteLine("Devam Etmak İçin Bir Tuşa Basın");
                                    Console.WriteLine("-------------------------------");
                                    Console.ReadKey(true);
                                }
                            }
                            if(!bulundu)
                            {
                                Console.WriteLine("Hatalı İsim");
                            }
                        }
                        
                    }
                    else if (anaMenuSecim == 3)
                    {
                        Console.WriteLine("Etkinliğe Kayıt Alanı");
                        bool uygunetkinlik = false;
                        for(int i=0;i<etkinlikAdları.Count;i++)
                        {
                            DateTime tarih = (DateTime)etkinlikTarihleri[i];
                            int kontenjan = (int)kontenjanlar[i];
                            int kayit = (int)kayitSayiları[i];
                            bool aktifMi = (bool)etkinlikAktifMi[i];

                            if(aktifMi && tarih.Date>=DateTime.Today && kayit<kontenjan)
                            {
                                uygunetkinlik = true;
                                Console.WriteLine((i + 1) + "-" + etkinlikAdları[i] + "-" + tarih + "-" + ucretler[i]+"TL"+"Kalan:"+(kontenjan-kayit));
                            }
                        }
                        if(!uygunetkinlik)
                        {
                            Console.WriteLine("Kayıt Olabilecek Etkinlik Bulunmamaktadır");
                            Console.ReadKey(true);
                        }
                        Console.WriteLine("Öğrenci Numaranız:");
                        string ogrenciNo = (Console.ReadLine() ?? "").Trim();
                        Console.WriteLine("Öğrenci Adı-Soyadı:");
                        string ogrenciAd = (Console.ReadLine() ?? "").Trim();
                        Console.WriteLine("Etkinlik Numarası:");


                    }
                    else if (anaMenuSecim == 4)
                    {

                    }
                    else if (anaMenuSecim == 5)
                    {

                    }
                    else if (anaMenuSecim == 6)
                    {

                    }
                    else if (anaMenuSecim == 7)
                    {

                    }
                    else if (anaMenuSecim == 0)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Lütfen Geçerli Bir Seçim Yapınız");
                    }
                }
                catch
                {
                    Console.WriteLine("Hata");
                }
            }
        }
    }
}
