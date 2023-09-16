using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bağıl_liste
{
    public partial class Form1 : Form
    {
        public class dugum
        {
            // hocam kendi çalışan kodumu yazamadığım için sizin kodunuz üzerinden
            // anladıklarımı yanlarına yazarak ilerledim.

            public string ad;           
            public string soyad;        //tanımlamalar burası
            public int no;
            public dugum sonraki;
        }
        dugum ilk = null;
        dugum son = null;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            dugum yeni = new dugum();     //yeni adında değişken ürettik.
            yeni.ad = textBox1.Text;      //yenin "ad" ismindeki parametresi
            yeni.soyad = textBox2.Text;   //yenin "soyad" ismindeki parametresi
            yeni.no = Convert.ToInt32(textBox3.Text);  //stringi int'e çevirdik.
            if(ilk==null)    //ilk null ise daha önce veri tanımlanmamış demektir.
            {
                ilk = yeni;       // ilk yeni veri
                son = ilk;            // son aynı zamanda ilk oluyor
                ilk.sonraki = son;        //ilkin sonraki sondur
                son.sonraki = null;       //sondaki null

            }
            else
            {
                son.sonraki = yeni;     //son eklenen yenidir
                son = yeni;             //yeni düğüm oluştu sonuncu yeni olmuş oldu
                son.sonraki = null;   //sondaki null
            }
        }
        private void listeyiYazdir(dugum ilk)   //listeye veriyi yazdırma
        {
            textBox4.Text = null;

            while(ilk!=null)    // ilk sayı null a denk gelmiyorsa
            {
                textBox4.Text += ilk.ad + "  " + ilk.soyad + " : " + ilk.no.ToString(); //listeye ilki yazırdık.
                textBox4.Text += "-->";   
                ilk = ilk.sonraki;    // ilk veri ilkin sonrakisi oluyor.
            }
            textBox4.Text += "null";   // döngüden çıkınca bunu yazdır
        }
            
        private void button3_Click(object sender, EventArgs e)
        {
            listeyiYazdir(ilk);          //listeye yazdir diye bir fonksiyon yazıp,listenin ilk
                                         //düğümünü gönderdi.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dugum yeni = new dugum();      //yeni adında değişken ürettik.
            yeni.ad = textBox1.Text;       //yenin "ad" ismindeki parametresi 
            yeni.soyad = textBox2.Text;      //yenin "soyad" ismindeki parametresi
            yeni.no = Convert.ToInt32(textBox3.Text);     //no parametresi,stringi int'e çevirdik.
            dugum aranan = new dugum();     //aranan adında değişken ürettik
            aranan = ilk;      //arananı ilke atadık
            if(ilk != null)    //eğer ilk ,null 'a eşit değilse
            {
                while (aranan.no<yeni.no)   //yeni numara , aranan numaradan büyükse döngüye gir
                {
                    if(aranan.sonraki.no>yeni.no)   //aranan sonraki numara, yeni numaradan büyükse gir 
                    {
                        break;  //çık
                    }
                    aranan= aranan.sonraki;  //aranan yani bir önceki numaradan sonraki numaraya geç
                }
                yeni.sonraki = aranan.sonraki;  // yeni numara sonraki aranan numara yerine geçer
                aranan.sonraki = yeni;  //aranan numara yeni olur
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox3.Text);   //stringi int'e çevirdik
            dugum silinecek = new dugum();   //silinecek adında değişken ürettik
            dugum onceki = new dugum();    //onceki adında değişken ürettik
            silinecek = ilk;  //silineceği ilk'e atadık.
            
            if (ilk.no == no)    //ilk no , no'ya eşitse
            {
                ilk = ilk.sonraki;  //ilk veri ilkin sonrakisindaki olur
            }
            else   
            {
                while (silinecek.no!= no)    //silinecek no, girdiğimiz no'ya eşit değilse içeriye gir.
                {
                    onceki = silinecek;        //önceki silinecek olur
                    silinecek = silinecek.sonraki;     //silinecek veri sonraki olur
                }
                onceki.sonraki = silinecek.sonraki; //önceki veriden sonraki , silinen veriden sonraki veri olur.
            }
        }
    }
}
