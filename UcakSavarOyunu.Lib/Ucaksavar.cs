using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavarOyunu.Lib
{
    public class Ucaksavar : OyunBase, IHareketEdebilir, IAtesEdebilen, IFareileHareketEdebilir
    {
        private const int ucaksavarbirim = 10;
        public List<Roket> Roketler { get; set; } = new List<Roket>();
        public Ucaksavar(ContainerControl tasiyici)
        {
            this.tasiyici = tasiyici;
            this.ResimKutusu = new PictureBox();
            ResimKutusu.SizeMode = PictureBoxSizeMode.StretchImage;
            ResimKutusu.Size = new Size(83, 83);
            ResimKutusu.Image = Properties.Resources.ucaksavar;
            tasiyici.Controls.Add(ResimKutusu);
            ResimKutusu.Location = new Point(new Random().Next(90, tasiyici.Width - 90), tasiyici.Height - 125);
        }
        public void HareketEt(Yonler yon)
        {
            switch (yon)
            {
                case Yonler.Sola:
                    if (ResimKutusu.Location.X > 20)
                        ResimKutusu.Location = new Point(ResimKutusu.Location.X - ucaksavarbirim, ResimKutusu.Location.Y);
                    break;
                case Yonler.Saga:
                    if (ResimKutusu.Location.X < tasiyici.Width - 120)
                        ResimKutusu.Location = new Point(ResimKutusu.Location.X + ucaksavarbirim, ResimKutusu.Location.Y);
                    break;
                default:
                    throw new Exception("Uçaksavar sadece sola veya sağa hareket edebilir");
            }
        }

        public void AtesEt()
        {
            Point point = new Point()
            {
                X = ResimKutusu.Location.X + 30,
                Y = ResimKutusu.Location.Y - 30
            };
            Roket roket = new Roket(point);
            Roketler.Add(roket);
            tasiyici.Controls.Add(roket.ResimKutusu);
        }

        public void HareketEt(Point konum)
        {
            if (konum.X < 50 || konum.X > tasiyici.Width - 50) return;
            Point point = new Point()
            {
                X = konum.X - (ResimKutusu.Width / 2),
                Y = ResimKutusu.Location.Y
            };
            ResimKutusu.Location = point;
        }
    }
}
