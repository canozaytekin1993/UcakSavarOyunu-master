using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavarOyunu.Lib
{
    public class UcakOyunu
    {
        private Timer tmrUretici, tmrMermi, tmrKontrol, tmrUcak;
        public bool OyunDurduMu { get; set; } = false;
        public int Skor { get; set; }
        public Ucaksavar Ucaksavar { get; set; }
        public List<Ucak> Ucaklar { get; set; } = new List<Ucak>();
        private ContainerControl tasiyici;

        public UcakOyunu(ContainerControl tasiyici)
        {
            this.tasiyici = tasiyici;
            this.Ucaksavar = new Ucaksavar(tasiyici);

            tmrMermi = new Timer();
            tmrMermi.Interval = 30;
            tmrMermi.Tick += TmrMermi_Tick;
            tmrMermi.Start();

            tmrUretici = new Timer();
            tmrUretici.Interval = 1200;
            tmrUretici.Tick += TmrUretici_Tick;
            tmrUretici.Start();

            tmrUcak = new Timer();
            tmrUcak.Interval = 120;
            tmrUcak.Tick += TmrUcak_Tick;
            tmrUcak.Start();

            tmrKontrol = new Timer();
            tmrKontrol.Interval = 10;
            tmrKontrol.Tick += TmrKontrol_Tick;
            tmrKontrol.Start();
        }

        Random rnd = new Random();

        private void TmrUcak_Tick(object sender, EventArgs e)
        {
            foreach (var item in Ucaklar)
            {
                item.HareketEt(Yonler.Asagi);
            }
        }

        private void TmrKontrol_Tick(object sender, EventArgs e)
        {
            bool vurduMu = false;
            
            foreach (var ucak in Ucaklar)
            {
                if (ucak.ResimKutusu.Location.Y + ucak.ResimKutusu.Height > tasiyici.Height - 70)
                {
                    OyunDurduMu = true;
                    tmrKontrol.Stop();
                    tmrMermi.Stop();
                    tmrUcak.Stop();
                    tmrUretici.Stop();
                }
                foreach (var roket in Ucaksavar.Roketler)
                {
                    if (
                        (ucak.ResimKutusu.Location.X + ucak.ResimKutusu.Size.Width >= roket.ResimKutusu.Location.X &&
                        ucak.ResimKutusu.Location.X < roket.ResimKutusu.Location.X ||
                        roket.ResimKutusu.Location.X + roket.ResimKutusu.Size.Width >= ucak.ResimKutusu.Location.X &&
                        roket.ResimKutusu.Location.X + roket.ResimKutusu.Size.Width < ucak.ResimKutusu.Location.X + ucak.ResimKutusu.Size.Width) && 
                        (ucak.ResimKutusu.Location.Y + ucak.ResimKutusu.Size.Height >= roket.ResimKutusu.Location.Y && 
                        ucak.ResimKutusu.Location.Y < roket.ResimKutusu.Location.Y ||
                        roket.ResimKutusu.Location.Y + roket.ResimKutusu.Size.Height >= ucak.ResimKutusu.Location.Y && 
                        roket.ResimKutusu.Location.Y + roket.ResimKutusu.Size.Height < ucak.ResimKutusu.Location.Y + ucak.ResimKutusu.Size.Height)
                        )
                    {
                        tasiyici.Controls.Remove(ucak.ResimKutusu);
                        tasiyici.Controls.Remove(roket.ResimKutusu);
                        Ucaklar.Remove(ucak);
                        Ucaksavar.Roketler.Remove(roket);
                        Skor++;

                        if (Skor % 10 == 0 && Skor > 1 && tmrUretici.Interval > 2)
                            tmrUretici.Interval -= 50;

                        vurduMu = true;
                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.bomb_small);
                        soundPlayer.Play();

                        if (roket.ResimKutusu.Location.Y < 0)
                        {
                            this.Ucaksavar.Roketler.Remove(roket);
                            tasiyici.Controls.Remove(roket.ResimKutusu);
                        }

                        break;
                    }

                }
                if (vurduMu) break;
                    
            }
        }

        private void TmrUretici_Tick(object sender, EventArgs e)
        {
            Point point = new Point()
            {
                X = rnd.Next(60, tasiyici.Width - 60),
                Y = 0
            };
            Ucak ucak = new Ucak(point);
            Ucaklar.Add(ucak);
            tasiyici.Controls.Add(ucak.ResimKutusu);
        }

        private void TmrMermi_Tick(object sender, EventArgs e)
        {
            foreach (var item in this.Ucaksavar.Roketler)
            {
                item.HareketEt(Yonler.Yukari);
            }
        }
    }
}
