using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//not defteri
using System.Reflection;

namespace logScada
{
    public partial class Form1 : Form
    {
        string[] arr1 = new string[56];
        string text1 = "";
        const int bitArrayBaslangicVinc = 18;//arraydeki bitlerin basladigi adres
        const int bitArrayBitisVinc = 19;//arraydaki bitlerin bittigi adres 

        const int bitArrayBaslangiciSaha = 53;//arraydeki bitlerin basladigi adres
        const int bitArrayBitisSaha = 55;//arraydaki bitlerin bittigi adres 

        const int dataGridColumnWidth = 70;

        int bitArrayBaslangic;//filtre icin arraydeki bitlerin basladigi adres
        int bitArrayBitis;//filtre icin arraydaki bitlerin bittigi adres
        int kolonNumarasi;//datagridview deki bit hücrelerini renklendirmek icin olusturuldu
        Int64 bitKarsilastir;//bit shift yapmak icin olusturuldu. Mantıksal karsilastirma yapmak icin kullanilacak
        DateTime filtreBaslangicZamani;//filtre icin baslangic zaman degeri
        DateTime filtreBitisZamani;//filtre icin bitis zaman degeri
        DateTime plcSatirZamani;//filtre icin plc deki zaman
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Columns.Count>1)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        //dataGridView1.Columns[i].Visible = false;
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }    
                dataGridView1.Rows.Clear();  
                Array.Clear(arr1, 0, arr1.Length);
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Filter = "Text Dosyaları|*.txt";
                labelDosyaAdresi.Text = "Dosya okunuyor lütfen bekleyiniz.";
                labelDosyaAdresi.BackColor = Color.DarkOrange;
                labelDosyaAdresi.Font = new Font("Arial", 11, FontStyle.Bold);
                OpenFileDialog.ShowDialog();
                classDegisken.dosyaAdresi = OpenFileDialog.FileName.ToString();

                if (!string.IsNullOrEmpty(classDegisken.dosyaAdresi))
                {
                    #region datagridView kolon ekle
                    //dataGridView1.Columns.Add("name", "Zaman");//sabit eklendi 0.kolon
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-1 Başlangıç hmi1_alan1HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-1 Bitiş hmi1_alan1HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-2 Başlangıç hmi1_alan2HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-2 Bitiş hmi1_alan2HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-3 Başlangıç hmi1_alan3HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-3 Bitiş hmi1_alan3HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-1 X hmi1_alan1X");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-2 X hmi1_alan2X");
                    dataGridView1.Columns.Add("name", "PC İst-1 Alan-3 X hmi1_alan3X");
                    dataGridView1.Columns.Add("name", "PC İst-1 Bobin-1 Genişliği hmi1_bobin1Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-1 Bobin-2 Genişliği hmi1_bobin2Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-1 Bobin-3 Genişliği hmi1_bobin3Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-1 Bobin-4 Genişliği hmi1_bobin4Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-1 Barkod-1 hmi1_barkod1");
                    dataGridView1.Columns.Add("name", "PC İst-1 Barkod-2 hmi1_barkod2");
                    dataGridView1.Columns.Add("name", "PC İst-1 Barkod-3 hmi1_barkod3");
                    dataGridView1.Columns.Add("name", "PC İst-1 Barkod-4 hmi1_barkod4");
                    dataGridView1.Columns.Add("name", "PC İst-1 Plaka hmi1_plaka");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin1koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin1koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin2koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin2koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin3koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin3koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin4koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi1_bobin4koordinat");

                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-1 Başlangıç hmi1_alan1HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-1 Bitiş hmi1_alan1HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-2 Başlangıç hmi1_alan2HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-2 Bitiş hmi1_alan2HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-3 Başlangıç hmi1_alan3HedefBas");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-3 Bitiş hmi1_alan3HedefSon");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-1 X hmi1_alan1X");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-2 X hmi1_alan2X");
                    dataGridView1.Columns.Add("name", "PC İst-2 Alan-3 X hmi1_alan3X");
                    dataGridView1.Columns.Add("name", "PC İst-2 Bobin-1 Genişliği hmi1_bobin1Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-2 Bobin-2 Genişliği hmi1_bobin2Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-2 Bobin-3 Genişliği hmi1_bobin3Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-2 Bobin-4 Genişliği hmi1_bobin4Genisligi");
                    dataGridView1.Columns.Add("name", "PC İst-2 Barkod-1 hmi1_barkod1");
                    dataGridView1.Columns.Add("name", "PC İst-2 Barkod-2 hmi1_barkod2");
                    dataGridView1.Columns.Add("name", "PC İst-2 Barkod-3 hmi1_barkod3");
                    dataGridView1.Columns.Add("name", "PC İst-2 Barkod-4 hmi1_barkod4");
                    dataGridView1.Columns.Add("name", "PC İst-2 Plaka hmi1_plaka");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin1koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin1koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin2koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin2koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin3koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin3koordinat");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin4koordinat_X");
                    dataGridView1.Columns.Add("name", "PLC hmi2_bobin4koordinat");
                    dataGridView1.Columns.Add("name", "PLC yeni eklenen");

                    dataGridView1.Columns.Add("name", "PC Tara-1 pc_ist1_tara1");//log_1_1
                    dataGridView1.Columns.Add("name", "PLC Tara-1 Başlatıldı pc_ist1_tara");
                    dataGridView1.Columns.Add("name", "PLC Servo-1 Başla servo1_tara");
                    dataGridView1.Columns.Add("name", "PLC Alan-1 Tara Başlatıldı alan1_tara");
                    dataGridView1.Columns.Add("name", "PLC Servo-1 Enabled servo1_ready");
                    dataGridView1.Columns.Add("name", "PLC Servo-1 Enable servo1_enable");
                    dataGridView1.Columns.Add("name", "PC Servo-1 Referans Al pc_ist1_ref_al");
                    dataGridView1.Columns.Add("name", "PLC Servo-1 Referans Al servo1_ref_al");

                    dataGridView1.Columns.Add("name", "PLC İst-1 Referans Alınıyor ist1_ref_alınıyor");//log_1_9
                    dataGridView1.Columns.Add("name", "PLC İst-1 Referans Alındı ist1_ref_alindi");
                    dataGridView1.Columns.Add("name", "PLC Taranıyor-1 hmi1_taraniyor");
                    dataGridView1.Columns.Add("name", "PLC LMS-1 Bağnaldı lms1_connect");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Tarama Tamamlandı ist1_tarama_ok");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Tarama Geri Gel ist1_tara_geri_gel");
                    dataGridView1.Columns.Add("name", "PC Yeniden Tara-1 hmi1_ReScan");
                    dataGridView1.Columns.Add("name", "PLC Alan-1 Tarama Başarısız alan1_tarama_basarisiz");

                    dataGridView1.Columns.Add("name", "PLC Alan-1 Tekrar Tara alan1_tekrar_tara");//log_1_17
                    dataGridView1.Columns.Add("name", "PLC Alan-1 Yeniden Tara Başarısız alan1_tara_yeniden_Dene_basarsiz");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Tarama Yarıda Kaldı xst1_taramaYaridaKaldi");
                    dataGridView1.Columns.Add("name", "PLC Servo-1 Disable servo1_tara_stop");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Tarama Tamamlandı ist1_tarama_tamamlandi");
                    dataGridView1.Columns.Add("name", "PC İst-1 Yükleme Tamamlandı pc_st1LoadkOk");
                    dataGridView1.Columns.Add("name", "PC İst-1 Havuz Bilgileri Hazır pc_St1GetData");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Yükleme Onayı ist1_yükleme_onayi");

                    dataGridView1.Columns.Add("name", "PLC İst-1 Araç Boşalt ist1_arac_bosalt");//log_1_25
                    dataGridView1.Columns.Add("name", "PC İst-1 Reset ist1_tovs_reset");
                    dataGridView1.Columns.Add("name", "PC İst-1 Reset pc_st1_Reset");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Güvenli ist1_güvenli");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Dorse Algılama ist1_dorse_algilama");//log_1_29


                    dataGridView1.Columns.Add("name", "PC Tara-2 pc_ist2_tara1");//log_1_30
                    dataGridView1.Columns.Add("name", "PLC Tara-2 Başlatıldı pc_ist2_tara");
                    dataGridView1.Columns.Add("name", "PLC Servo-2 Başla servo2_tara");
                    dataGridView1.Columns.Add("name", "PLC Alan-2 Tara Başlatıldı alan2_tara");
                    dataGridView1.Columns.Add("name", "PLC Servo-2 Enabled servo2_ready");
                    dataGridView1.Columns.Add("name", "PLC Servo-2 Enable servo2_enable");
                    dataGridView1.Columns.Add("name", "PC Servo-2 Referans Al pc_ist2_ref_al");
                    dataGridView1.Columns.Add("name", "PLC Servo-2 Referans Al servo2_ref_al");

                    dataGridView1.Columns.Add("name", "PLC İst-2 Referans Alınıyor ist2_ref_alınıyor");//log_1_38
                    dataGridView1.Columns.Add("name", "PLC İst-2 Referans Alındı ist2_ref_alindi");
                    dataGridView1.Columns.Add("name", "PLC Taranıyor-2 hmi1_taraniyor");
                    dataGridView1.Columns.Add("name", "PLC LMS-2 Bağnaldı lms2_connect");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Tarama Tamamlandı ist2_tarama_ok");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Tarama Geri Gel ist2_tara_geri_gel");
                    dataGridView1.Columns.Add("name", "PC Yeniden Tara-2 hmi2_ReScan");
                    dataGridView1.Columns.Add("name", "PLC Alan-2 Tarama Başarısız alan2_tarama_basarisiz");

                    dataGridView1.Columns.Add("name", "PLC Alan-2 Tekrar Tara alan2_tekrar_tara");//log_1_46
                    dataGridView1.Columns.Add("name", "PLC Alan-2 Yeniden Tara Başarısız alan2_tara_yeniden_Dene_basarsiz");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Tarama Yarıda Kaldı xst2_taramaYaridaKaldi");
                    dataGridView1.Columns.Add("name", "PLC Servo-2 Disable servo2_tara_stop");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Tarama Tamamlandı ist2_tarama_tamamlandi");
                    dataGridView1.Columns.Add("name", "PC İst-2 Yükleme Tamamlandı pc_st2LoadkOk");
                    dataGridView1.Columns.Add("name", "PC İst-2 Havuz Bilgileri Hazır pc_St2GetData");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Yükleme Onayı ist2_yükleme_onayi");

                    dataGridView1.Columns.Add("name", "PLC İst-2 Araç Boşalt ist2_arac_bosalt");//log_1_54
                    dataGridView1.Columns.Add("name", "PC İst-2 Reset ist2_tovs_reset");
                    dataGridView1.Columns.Add("name", "PC İst-2 Reset pc_st2_Reset");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Güvenli ist2_güvenli");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Dorse Algılama ist2_dorse_algilama");//log_1_58


                    dataGridView1.Columns.Add("name", "PC Kalmar OK pc_KalmarOK");//log_1_59
                    dataGridView1.Columns.Add("name", "PC-PLC Bakım Modu pc_bakimModu");
                    dataGridView1.Columns.Add("name", "PC Error Reset pc_errorReset");
                    dataGridView1.Columns.Add("name", "PC İst-1 Güvenli pc_st1SafetyOk");
                    dataGridView1.Columns.Add("name", "PC İst-2 Güvenli pc_st2SafetyOk");
                    dataGridView1.Columns.Add("name", "PLC Kapı-1 Kapalı kapi1_kapali");//log_1_64

                    dataGridView1.Columns.Add("name", "PLC Kapı-2 Kapalı kapi2_kapali");//log_2_1
                    dataGridView1.Columns.Add("name", "PLC Kapı-3 Kapalı kapi3_kapali");
                    dataGridView1.Columns.Add("name", "PLC Kapı-1 Kilitli kapi1_kilitli");
                    dataGridView1.Columns.Add("name", "PLC Kapı-2 Kilitli kapi2_kilitli");
                    dataGridView1.Columns.Add("name", "PLC Kapı-3 Kilitli kapi3_kilitli");
                    dataGridView1.Columns.Add("name", "PLC Bariyer-1 Açık bariyer1_acik");
                    dataGridView1.Columns.Add("name", "PLC Bariyer-1 Kapalı bariyer1_kapali");
                    dataGridView1.Columns.Add("name", "PLC Bariyer-2 Açık bariyer2_acik");

                    dataGridView1.Columns.Add("name", "PLC Bariyer-2 Kapalı bariyer2_kapali");//log_2_9
                    dataGridView1.Columns.Add("name", "PLC Bakım Modu bakim_modu");
                    dataGridView1.Columns.Add("name", "PLC Tovs Modu tovs_bakim_modu");
                    dataGridView1.Columns.Add("name", "PLC Bta Hazır bta_hazir");
                    dataGridView1.Columns.Add("name", "PLC Sql Connecting sql_connecting");
                    dataGridView1.Columns.Add("name", "PLC Sql Connected sql_connected");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Tarama Verileri Silindi ist1_DBDelete_insert");
                    dataGridView1.Columns.Add("name", "PLC HMI-1 Onay Database Update Edildi ist1_DBDelete_update");

                    dataGridView1.Columns.Add("name", "PLC İst-2 Tarama Verileri Silindi ist2_DBDelete_insert");//log_2_17
                    dataGridView1.Columns.Add("name", "PLC HMI-2 Onay Database Update Edildi ist2_DBDelete_update");
                    dataGridView1.Columns.Add("name", "PLC LMS-1 Connect Done lms1_connect_done");
                    dataGridView1.Columns.Add("name", "PLC LMS-1 Read Trigger lms1_read_trigger");
                    dataGridView1.Columns.Add("name", "PLC LMS-2 Connect Done lms2_connect_done");
                    dataGridView1.Columns.Add("name", "PLC LMS-2 Read Trigger lms2_read_trigger");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_25
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_33
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_41
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_49
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_57
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");


                    dataGridView1.Columns.Add("name", "PLC Emniyet Rolesi xAlarm1");//log_3_1
                    dataGridView1.Columns.Add("name", "PLC Select Command Error xAlarm2");
                    dataGridView1.Columns.Add("name", "PLC Alan-1 Taranamıyor xAlarm3");
                    dataGridView1.Columns.Add("name", "PLC Alan-2 Taranamıyor xAlarm4");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Güvenli Değil xAlarm5");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Güvenli Değil xAlarm6");
                    dataGridView1.Columns.Add("name", "PLC Bariyer-1 Kapatılamadı xAlarm7");
                    dataGridView1.Columns.Add("name", "PLC Bariyer-1 Açılamadı xAlarm8");

                    dataGridView1.Columns.Add("name", "PLC Bariyer-2 Kapatılamadı xAlarm9");//log_3_9
                    dataGridView1.Columns.Add("name", "PLC Bariyer 2 Açılamadı xAlarm10");
                    dataGridView1.Columns.Add("name", "PLC Alan-1 Servo xAlarm11");
                    dataGridView1.Columns.Add("name", "PLC Alan-2 Servo xAlarm12");
                    dataGridView1.Columns.Add("name", "PLC PC Bağlantı Koptu xAlarm13");
                    dataGridView1.Columns.Add("name", "PLC Kapı-1 Kilitlenemedi xAlarm14");
                    dataGridView1.Columns.Add("name", "PLC Kapı-2 Kilitlenemedi xAlarm15");
                    dataGridView1.Columns.Add("name", "PLC Kapı-3 Kilitlenemedi xAlarm16");

                    dataGridView1.Columns.Add("name", "PLC EtherCAT Hatası xAlarm17");//log_3_17
                    dataGridView1.Columns.Add("name", "PLC DataBase Hatası xAlarm18");
                    dataGridView1.Columns.Add("name", "PLC BTA Düzgün Konumlanmadı xAlarm19");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_25
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_33
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_41
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_49
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");

                    dataGridView1.Columns.Add("name", "Yedek");//log_2_57
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");



                    #endregion

                    for (int i = 0; i < 208; i++)
                    {
                        dataGridView1.Columns[i].Width = dataGridColumnWidth;
                    }

                    classTxt.oku();
                    for (int i = 0; i < classTxt.adet; i++)
                    {
                        kolonNumarasi = bitArrayBaslangiciSaha;//lint degerlerden sonraki kolon numarasi atamasi yapildi
                        if (classDegisken.ReceteTxt != null)
                        {
                            text1 = classDegisken.ReceteTxt[i];
                            arr1 = text1.Split(';');
                            for (int j = 0; j <= bitArrayBitisSaha; j++)
                            {
                                classDegisken.veriler[i, j] = arr1[j].Trim(' ');
                            }
                        }
                    }
                    verileriGoster(bitArrayBaslangiciSaha, bitArrayBitisSaha);
                    bitArrayBaslangic = bitArrayBaslangiciSaha;
                    bitArrayBitis = bitArrayBitisSaha;
                    dataGridView1.Size = panelDataGrid.Size;
                    dataGridView1.Location = panelDataGrid.Location;
                    buttonEksenHesaplama.Visible = false;
                }
                else
                {
                    labelDosyaAdresi.Text = "Dosya Yolu Seçilmedi";
                    labelDosyaAdresi.BackColor = Color.WhiteSmoke;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Dosya formatı uyumlu değil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCrane_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Columns.Count > 1)
                {
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        //dataGridView1.Columns[i].Visible = false;
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
                dataGridView1.Rows.Clear();
                Array.Clear(arr1, 0, arr1.Length);
                dataGridView1.Visible = false;
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Filter = "Text Dosyaları|*.txt";
                labelDosyaAdresi.Text = "Dosya okunuyor lütfen bekleyiniz.";
                labelDosyaAdresi.BackColor = Color.DarkOrange;
                labelDosyaAdresi.Font = new Font("Arial", 11, FontStyle.Bold);
                OpenFileDialog.ShowDialog();
                classDegisken.dosyaAdresi = OpenFileDialog.FileName.ToString();

                if (!string.IsNullOrEmpty(classDegisken.dosyaAdresi))
                {

                    #region datagridView kolon ekle
                    //dataGridView1.Columns.Add("name", "Zaman");//sabit eklendi 0.kolon
                    dataGridView1.Columns.Add("name", "PLC Vinç Lazer Köprü CraneLocationX");
                    dataGridView1.Columns.Add("name", "PLC Vinç Lazer Araba CraneLocationX ");
                    dataGridView1.Columns.Add("name", "PLC Vinç Encoder CraneLocationH");
                    dataGridView1.Columns.Add("name", "PLC Tong Genişlik Lazer CraneLocationW");
                    dataGridView1.Columns.Add("name", "PC Kat cmdPosFloor");
                    dataGridView1.Columns.Add("name", "PC X cmdPosX");
                    dataGridView1.Columns.Add("name", "PC Y cmdPosY");
                    dataGridView1.Columns.Add("name", "PC W cmdPosWidth");
                    dataGridView1.Columns.Add("name", "PC Çap cmdPosDiameter");
                    dataGridView1.Columns.Add("name", "PC Vagon Başlangıç vagonTaraBaslangicX");
                    dataGridView1.Columns.Add("name", "PC Vagon Mesafesi vagonTaraMesafesi");
                    dataGridView1.Columns.Add("name", "PLC BobinAlAdim");
                    dataGridView1.Columns.Add("name", "PLC BobinBırakAdim");//13. kolon
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırakıldı X cdCraneLocationX");//14. kolon
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırakıldı Y cdCraneLocationY");//15. kolon
                    dataGridView1.Columns.Add("name", "PLC Tong Aşağı Lazer Sağ TongYukseklik_sag");//16. kolon
                    dataGridView1.Columns.Add("name", "PLC Tong Aşağı Lazer Sol TongYukseklik_sol");//17. kolon


                    dataGridView1.Columns.Add("name", "PLC Vinç Oto Buton dpOtoBT");//log_1_1
                    dataGridView1.Columns.Add("name", "PC Vinç Aktif cmdPcVincAktif");
                    dataGridView1.Columns.Add("name", "PLC Tovs Aktif tovsActive");
                    dataGridView1.Columns.Add("name", "PC Beklet cmdBeklet");
                    dataGridView1.Columns.Add("name", "PLC Beklet xBeklet");
                    dataGridView1.Columns.Add("name", "PC İşlem Durdur cmdPcIslemDurdur");
                    dataGridView1.Columns.Add("name", "PLC işlem Durduruldu islemDurduruldu");
                    dataGridView1.Columns.Add("name", "PC Bobin Al Emri cmdPcBobinAl");

                    dataGridView1.Columns.Add("name", "PLC Bobin Al Başlatıldı cmdBobinAl");//log_1_9
                    dataGridView1.Columns.Add("name", "PLC Bobin Alınıyor pcCtGoing");
                    dataGridView1.Columns.Add("name", "PLC Bobin Alındı Mesaj pcCtMessage");
                    dataGridView1.Columns.Add("name", "PLC Bobin Al Kanca Yukarı pcCtUp");
                    dataGridView1.Columns.Add("name", "PLC Bobin Al Kanca Aşağı pcCtDown");
                    dataGridView1.Columns.Add("name", "PLC Bobin Al Tamamlandı pcCtDone");
                    dataGridView1.Columns.Add("name", "PC Bobin Bırak Emri cmdPcBobinBırak");
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırak Başlatıldı cmdBobinBırak");

                    dataGridView1.Columns.Add("name", "PLC Bobin Bırakılıyor pcCdGoing");//log_1_17
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırakıldı Mesaj pcCdMessage");
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırak Kanca Yukarı pcCdUp");
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırak Kanca Aşağı pcCdDown");
                    dataGridView1.Columns.Add("name", "PLC Bobin Bırak Tamamlandı pcCdDone");
                    dataGridView1.Columns.Add("name", "PC Pozisyona Git Emri cmdPosGit");
                    dataGridView1.Columns.Add("name", "PLC Pozisyona Gidiliyor cmdSaGoing");
                    dataGridView1.Columns.Add("name", "PLC Pozisyona Git Kanca Yukarı pozisyonaGitKancaYukarı");

                    dataGridView1.Columns.Add("name", "PLC Pozisyona Git Tamamlandı pcSaDone");//log_1_25
                    dataGridView1.Columns.Add("name", "PC Vagon Tara Emri cmdPcVagonTara");
                    dataGridView1.Columns.Add("name", "PLC Vagon Tarama Başlangıç Pozisyonuna Gidiliyor vagonTaraPos1");//log_1_27
                    dataGridView1.Columns.Add("name", "PLC Vagon Taranıyor vagonTaraKopruIleri");
                    dataGridView1.Columns.Add("name", "PLC LMS Başlatıldı vagonTaraLmsStart");
                    dataGridView1.Columns.Add("name", "PLC Vagon Tara Tamamlandı vagonTaraTamamlandi");
                    dataGridView1.Columns.Add("name", "PLC LMS Yaz Tetik lmsTrigger");
                    dataGridView1.Columns.Add("name", "PLC Limit İptal dp_limitIptal");

                    dataGridView1.Columns.Add("name", "PC Kat Bilgisi Yanlış cmdParamFFault");//log_1_33
                    dataGridView1.Columns.Add("name", "PC Köprü Bilgisi Yanlış cmdParamXFault");
                    dataGridView1.Columns.Add("name", "PC Araba Bilgisi Yanlış cmdParamYFault");
                    dataGridView1.Columns.Add("name", "PC Tong Genişlik Bİlgisi Hatası cmdParamWFault");
                    dataGridView1.Columns.Add("name", "PLC Köprü İleri Komutu dp_kopruIleri");//log_1_37
                    dataGridView1.Columns.Add("name", "PLC Köprü Geri Komutu dp_kopruGeri");
                    dataGridView1.Columns.Add("name", "PLC Siemens Köprü Çalışıyor Bilgisi KopruDurumCalisiyor");
                    dataGridView1.Columns.Add("name", "PLC Araba İleri Komutu dp_arabaIleri");

                    dataGridView1.Columns.Add("name", "PLC Araba Geri Komutu dp_arabaGeri");//log_1_41
                    dataGridView1.Columns.Add("name", "PLC Siemens Araba Çalışıyor Bilgisi adabaDurumCalisiyor");
                    dataGridView1.Columns.Add("name", "PLC Kanca Yukarı Komutu dp_kancaYukari");
                    dataGridView1.Columns.Add("name", "PLC Kanca Aşağı Komutu dp_kancaAsagi");
                    dataGridView1.Columns.Add("name", "PLC Siemens Kanca Çalışıyor Bilgisi KancaDurumCalisiyor");
                    dataGridView1.Columns.Add("name", "PLC Tong Aç Komutu dpTongAc");
                    dataGridView1.Columns.Add("name", "PLC Tong Kapat Komutu dpTongKapat");
                    dataGridView1.Columns.Add("name", "PLC Siemens Tong Çalışıyor Bilgisi tongDurumCalisiyor");

                    dataGridView1.Columns.Add("name", "PLC Tong Göbek Sensör Bilgisi tongGobekSw");//log_1_49
                    dataGridView1.Columns.Add("name", "PLC Tong Baskı Sensör Bilgisi tongBaskiSw");
                    dataGridView1.Columns.Add("name", "PLC Tong Yük Sensör Bilgisi tongYukSw");
                    dataGridView1.Columns.Add("name", "PC Offset Update Komutu cmdOffsetUpdate");//log_1_52
                    dataGridView1.Columns.Add("name", "PLC SQL Bağlı sql_connected");
                    dataGridView1.Columns.Add("name", "PLC Enkoder Bağlı encoderConnectionOk");
                    dataGridView1.Columns.Add("name", "PLC Tong Bağlı moxa tongConnectionOk");
                    dataGridView1.Columns.Add("name", "PLC Moxa Bağlı moxaConnectionOk");

                    dataGridView1.Columns.Add("name", "PLC Profibus Bağlı profibusConnectionOk");//log_1_57
                    dataGridView1.Columns.Add("name", "PLC Saha Güvenli mapVarStationInfo.safetyOk");
                    dataGridView1.Columns.Add("name", "PLC İst-1 Güvenli mapVarStationInfo.st1SafetyOk");
                    dataGridView1.Columns.Add("name", "PLC İst-2 Güvenli mapVarStationInfo.st2SafetyOk");
                    dataGridView1.Columns.Add("name", "PLC Çaprma Önleme Aktif xÇarpmaOnleme");
                    dataGridView1.Columns.Add("name", "PLC Eksen Kayması Hesaplandı xEksenKaymasiHesaplandi");
                    dataGridView1.Columns.Add("name", "Yedek");
                    dataGridView1.Columns.Add("name", "Yedek");//log_1_64

                    dataGridView1.Columns.Add("name", "PLC Vinç Acil Stop xAlarm1");//log_2_1_alarm1
                    dataGridView1.Columns.Add("name", "PLC Profibus Error xAlarm2");
                    dataGridView1.Columns.Add("name", "PLC Moxa Connection Error xAlarm3");
                    dataGridView1.Columns.Add("name", "PLC Tong Connection Error xAlarm4");
                    dataGridView1.Columns.Add("name", "PLC Encoder Connection Error xAlarm5");
                    dataGridView1.Columns.Add("name", "PLC Moxa X Hatasi xAlarm6");
                    dataGridView1.Columns.Add("name", "PLC Moxa Y Hatası xAlarm7");
                    dataGridView1.Columns.Add("name", "PLC dpKopru SFault xAlarm8");

                    dataGridView1.Columns.Add("name", "PLC dpKopru MFault xAlarm9");//log_2_9
                    dataGridView1.Columns.Add("name", "PLC araba Alarm Genel xAlarm10");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Motor2 Sıcaklık xAlarm11");//log_2_11_alarm11
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Motor2 Termik xAlarm12");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Ana Yuk Inverter Fan xAlarm13");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Ana Yuk Motor Sıcaklık xAlarm14");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Fren xAlarm15");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Inverter Fan xAlarm16");

                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Motor1 Sıcaklık xAlarm17");//log_2_17
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Araba Motor1 Termik xAlarm18");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Fren xAlarm19");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Inverter1 Fan xAlarm20");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Inverter2 Fan xAlarm21");//log_2_21_alarm21
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor1 Sıcaklık xAlarm22");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor1 Termik xAlarm23");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor2 Sıcaklık xAlarm24");

                    dataGridView1.Columns.Add("name", "PLC dpAlarm Afe Inverter xAlarm25");//_log_2_25
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Ana Yuk Fren xAlarm26");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Tong SagSol Termik xAlarm27");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor3 Termik xAlarm28");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor4 Sıcaklık xAlarm29");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor4 Termik xAlarm30");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm KST Motor Termik xAlarm31");//log_2_31_alarm30
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Panel Oda Sıcaklık xAlarm32");

                    dataGridView1.Columns.Add("name", "PLC dpAlarm Tong AcKapa Termik xAlarm33");//log_2_33
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor2 Termik xAlarm34");
                    dataGridView1.Columns.Add("name", "PLC dpAlarm Kopru Motor3 Sıcaklık xAlarm35");
                    dataGridView1.Columns.Add("name", "PLC Kanca Alarm xAlarm36");
                    dataGridView1.Columns.Add("name", "PLC X Hedefe Gidemedi xAlarm37");
                    dataGridView1.Columns.Add("name", "PLC Y Hedefe Gidemedi xAlarm38");
                    dataGridView1.Columns.Add("name", "PLC Vagon Taranamadı xAlarm39");
                    dataGridView1.Columns.Add("name", "PLC LMS Connection Error xAlarm40");//log_2_40_alarm40

                    dataGridView1.Columns.Add("name", "PLC 1. Kat Alınırken 1. Kat Yok Kayıtsız Bobin xAlarm41");//log_2_41
                    dataGridView1.Columns.Add("name", "PLC 1. Kat Alınırken 2. Kat Var Kayıtsız Bobin xAlarm42");
                    dataGridView1.Columns.Add("name", "PLC 2. Kat Alınırken 2. Kat Yok Kayıtsız Bobin xAlarm43");
                    dataGridView1.Columns.Add("name", "PLC 1. Kat Bırakılırken 1. Kat Var Kayıtsız Bobin xAlarm44");
                    dataGridView1.Columns.Add("name", "PLC 2. Kat Bırakılırken 2. Kat Var Kayıtsız Bobin xAlarm45");
                    dataGridView1.Columns.Add("name", "PLC 2. Kat Bırakılırken 1. Kat Yok Kayıtsız Bobin xAlarm46");
                    dataGridView1.Columns.Add("name", "PLC Baskı Sensörü Alarm xAlarm47");
                    dataGridView1.Columns.Add("name", "PLC Göbek Sensörü Alarm xAlarm48");

                    dataGridView1.Columns.Add("name", "PLC Yük Sensörü Alarm xAlarm49");//log_2_49
                    dataGridView1.Columns.Add("name", "PLC Yükten Kurtuldu xAlarm50");//log_2_50_alarm50
                    dataGridView1.Columns.Add("name", "PLC Kanca Durdurma Görmedi xAlarm51");
                    dataGridView1.Columns.Add("name", "PLC Tehlikeli Mesafe xAlarm52");
                    dataGridView1.Columns.Add("name", "PLC Pc Bağlantı Koptu xAlarm53");
                    dataGridView1.Columns.Add("name", "PLC Gyro Alarm xAlarm54");
                    dataGridView1.Columns.Add("name", "PLC Tong Yükeseklik Mesafe Sensör Alarm xAlarm55");
                    dataGridView1.Columns.Add("name", "PLC Tong Genişlik Mesafe Sensör Alarm xAlarm56");

                    dataGridView1.Columns.Add("name", "PLC X Ekseni Reflektörden Çıktı xAlarm57");//log_2_57
                    dataGridView1.Columns.Add("name", "PLC Y Ekseni Reflektörden Çıktı xAlarm58");
                    dataGridView1.Columns.Add("name", "PLC Lazer Offset Yok xAlarm59");
                    dataGridView1.Columns.Add("name", "PLC Vinç Hareketliyken Halat Kaçırdı xAlarm60");//log_2_60
                    dataGridView1.Columns.Add("name", "PLC Vinç Parametresi Hatalı xAlarm61");
                    dataGridView1.Columns.Add("name", "PLC Araç Yüklemede X Eksen Kayması Var xAlarm62");
                    dataGridView1.Columns.Add("name", "PLC Yedek xAlarm 63");
                    dataGridView1.Columns.Add("name", "PLC Yedek xAlarm64");//log_2_64 kolon 145                            

                    #endregion

                    for (int i = 0; i < 143; i++)
                    {
                        dataGridView1.Columns[i].Width = dataGridColumnWidth;
                    }

                    classTxt.oku();
                    for (int i = 0; i < classTxt.adet; i++)
                    {
                        kolonNumarasi = bitArrayBaslangicVinc;//lint degerlerden sonraki kolon numarasi atamasi yapildi
                        if (classDegisken.ReceteTxt != null)
                        {
                            text1 = classDegisken.ReceteTxt[i];
                            arr1 = text1.Split(';');
                            for (int j = 0; j <= bitArrayBitisVinc; j++)
                            {
                                classDegisken.veriler[i, j] = arr1[j].Trim(' ');
                            }
                        }
                    }
                    verileriGoster(bitArrayBaslangicVinc, bitArrayBitisVinc);
                    bitArrayBaslangic = bitArrayBaslangicVinc;
                    bitArrayBitis = bitArrayBitisVinc;
                    dataGridView1.Size = panelDataGrid.Size;
                    dataGridView1.Location = panelDataGrid.Location;
                    buttonEksenHesaplama.Visible = true;
                }
                else
                {
                    labelDosyaAdresi.Text = "Dosya Yolu Seçilmedi";
                    labelDosyaAdresi.BackColor = Color.WhiteSmoke;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Dosya formatı uyumlu değil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verileriGoster(int bitArrayBaslangic, int bitArrayBitis)
        {

            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < classTxt.adet; i++)
                {
                    kolonNumarasi = bitArrayBaslangic;//lint degerlerden sonraki kolon numarasi atamasi yapildi
                    filtreBaslangicZamani = Convert.ToDateTime(maskedTextBoxBaslangic.Text);
                    filtreBitisZamani = Convert.ToDateTime(maskedTextBoxBitis.Text);
                    plcSatirZamani = Convert.ToDateTime(classDegisken.veriler[i, 0]);
                    dataGridView1.Rows.Insert(i, ""); //satir ekle  
                    for (int j = 0; j <= bitArrayBitis; j++)
                    {
                        if (plcSatirZamani >= filtreBaslangicZamani & plcSatirZamani <= filtreBitisZamani)
                        {
                            if (j < bitArrayBaslangic)//bit sutununa kadar olan degerler
                            {
                                dataGridView1[j, i].Value = classDegisken.veriler[i, j];
                            }//12. sutuna kadar olan degerler

                            else if (j == bitArrayBaslangic)//1.bit sutunu
                            {
                                bitKarsilastir = 1;//bit kaydirma icin baslangic degeri belirlendi
                                kolonNumarasi = bitArrayBaslangic;
                                for (int k = 0; k < 64; k++)
                                {
                                    if ((Convert.ToInt64(classDegisken.veriler[i, j]) & bitKarsilastir) == bitKarsilastir)
                                    {
                                        dataGridView1[kolonNumarasi, i].Value = "1";//[kolon index,satır index]
                                        dataGridView1.Rows[i].Cells[kolonNumarasi].Style.BackColor = Color.LightGreen;
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    } //1
                                    else
                                    {
                                        //dataGridView1[kolonNumarasi, i].Value = "";//[kolon index,satır index]
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    }
                                    bitKarsilastir = bitKarsilastir << 1;//mantiksal karsilastirma icin 1 bit kaydirma yapildi
                                }
                            }

                            else if (j == bitArrayBaslangic + 1)//2.bit sutunu
                            {
                                bitKarsilastir = 1;//bit kaydirma icin baslangic degeri belirlendi
                                for (int k = 0; k < 64; k++)
                                {
                                    if ((Convert.ToInt64(classDegisken.veriler[i, j]) & bitKarsilastir) == bitKarsilastir)
                                    {
                                        dataGridView1[kolonNumarasi, i].Value = "1";//[kolon index,satır index]
                                        if (bitArrayBaslangic == bitArrayBaslangicVinc) dataGridView1.Rows[i].Cells[kolonNumarasi].Style.BackColor = Color.OrangeRed;
                                        else dataGridView1.Rows[i].Cells[kolonNumarasi].Style.BackColor = Color.LightGreen;
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    } //1
                                    else
                                    {
                                        //dataGridView1[kolonNumarasi, i].Value = "false";//[kolon index,satır index]
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    }
                                    bitKarsilastir = bitKarsilastir << 1;//mantiksal karsilastirma icin 1 bit kaydirma yapildi
                                }
                            }

                            else if (j == (bitArrayBaslangic + 2) && (bitArrayBaslangic == bitArrayBaslangiciSaha))//3.bit sutunu
                            {
                                bitKarsilastir = 1;//bit kaydirma icin baslangic degeri belirlendi
                                for (int k = 0; k < 64; k++)
                                {
                                    if ((Convert.ToInt64(classDegisken.veriler[i, j]) & bitKarsilastir) == bitKarsilastir)
                                    {
                                        dataGridView1[kolonNumarasi, i].Value = "1";//[kolon index,satır index]
                                        if (bitArrayBaslangic == 13) dataGridView1.Rows[i].Cells[kolonNumarasi].Style.BackColor = Color.LightGreen;
                                        else dataGridView1.Rows[i].Cells[kolonNumarasi].Style.BackColor = Color.OrangeRed;
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    } //1
                                    else
                                    {
                                        //dataGridView1[kolonNumarasi, i].Value = "false";//[kolon index,satır index]
                                        kolonNumarasi = kolonNumarasi + 1;//kolon numarasi 1 artirildi
                                    }
                                    bitKarsilastir = bitKarsilastir << 1;//mantiksal karsilastirma icin 1 bit kaydirma yapildi
                                }
                            }
                        }
                    }
                }
                dataGridView1.Visible = true;
                labelDosyaAdresi.Text = classDegisken.dosyaAdresi + " adresinden " + classTxt.adet.ToString() + " adet satır okundu";
                labelDosyaAdresi.BackColor = Color.WhiteSmoke;
                labelDosyaAdresi.Font = new Font("Arial", 9, FontStyle.Regular);
                MessageBox.Show("İşlem tamamlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Veriler işlenemedi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttonFiltre_Click(object sender, EventArgs e)
        {
            try
            {
            yld:
                foreach (DataGridViewRow item in this.dataGridView1.Rows)
                {
                    if (item.Cells["Zaman"].Value != null)
                    {
                        if (Convert.ToDateTime(item.Cells["Zaman"].Value) < Convert.ToDateTime(maskedTextBoxBaslangic.Text) || Convert.ToDateTime(item.Cells["Zaman"].Value) > Convert.ToDateTime(maskedTextBoxBitis.Text))
                        {
                            dataGridView1.Rows.RemoveAt(item.Index);
                            goto yld;//bir kez kontrol ettiği için tekrarlaması için yld ye gönderildi
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void buttonFiltreIptal_Click(object sender, EventArgs e)
        {
            maskedTextBoxBaslangic.Text = "000000";
            maskedTextBoxBitis.Text = "235959";
            dataGridView1.Rows.Clear();
            verileriGoster(bitArrayBaslangic, bitArrayBitis);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Size = panelDataGrid.Size;
            dataGridView1.Location = panelDataGrid.Location;
        }
                
        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int dataGridColumnNumber;
            dataGridColumnNumber = dataGridView1.SelectedCells[0].ColumnIndex;
            dataGridView1.Columns[dataGridColumnNumber].Width = 0;
            //dataGridView1.Columns[dataGridColumnNumber].Visible = false;
        }

        private void hepsiniGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = dataGridColumnWidth;
                //dataGridView1.Columns[i].Visible = true;
            }
        }

        private void buttonEksenHesaplama_Click(object sender, EventArgs e)
        {
            Form ar = new FormEksenHesaplama();
            ar.Show();
        }
    }
}