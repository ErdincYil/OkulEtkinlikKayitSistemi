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
                            Console.WriteLine("Etkinliğimiz Bulunmamaktadır.");
                        }
                        for(int i=0;i<etkinlikAdları.Count;i++)
                        {
                            int no = i + 1;
                            string ad = (string)etkinlikAdları[i];
                            DateTime tarih = (DateTime)etkinlikTarihleri[i];
                            int kontenjan = (int)kontenjanlar[i];
                            int kayit = (int)kayitSayiları[i];
                            decimal ucret = (decimal)ucretler[i];
                            bool aktifMi = (bool)etkinlikAktifMi[i];

                            string durum = aktifMi ? "Aktif" : "İptal";
                            if(aktifMi && tarih<DateTime.Today)
                            {
                                durum="Tarihi Geçti";
                            }
                            Console.WriteLine("Etkinlik No:"+no);
                            Console.WriteLine("Etkinlik Adı:"+ad);
                            Console.WriteLine("Etkinlik Tarihi:"+tarih);
                            Console.WriteLine("Kontenjan"+kontenjan);
                            Console.WriteLine("Kalan Kontenjan:"+(kontenjan-kayit));
                            Console.WriteLine("Ücret:"+ucret+"TL");
                            Console.WriteLine("Durum"+durum);

                            Console.WriteLine("Devam Etmek İçin Bir Tuşa Basın");
                            Console.ReadKey(true);
                            break;
                        }
                    }
                    else if (anaMenuSecim == 2)
                    {
                        Console.WriteLine("Aranacak Etkinlik Adı:");
                        string aranankelime = (Console.ReadLine() ?? "").Trim().ToLower();

                        if(aranankelime.Length==0)
                        {
                            Console.WriteLine("Boş Bırakmayın");
                        }
                        else
                        {
                            bool bulundu = false;
                            for(int i=0;i<etkinlikAdları.Count;i++)
                            {
                                string etkinlikAdi = (string)etkinlikAdları[i];

                                if (etkinlikAdi.ToLower().Contains(aranankelime))
                                {
                                    bulundu = true;
                                    DateTime tarih = (DateTime)etkinlikTarihleri[i];
                                    int kalan = (int)kontenjanlar[i] - (int)kayitSayiları[i];
                                    decimal ucret = (decimal)ucretler[i];
                                    bool aktifMi = (bool)etkinlikAktifMi[i];

                                    Console.WriteLine("Etkinlik Adı:" + etkinlikAdi);
                                    Console.WriteLine("Etkinlik Tarihi:" + tarih);
                                    Console.WriteLine("Ücret:"+ucret);
                                    Console.WriteLine("Kalan Kontenjan:"+kalan);
                                    Console.WriteLine("Durum:"+aktifMi);
                                }
                            }
                        }
                    }
                    else if (anaMenuSecim == 3)
                    {

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
