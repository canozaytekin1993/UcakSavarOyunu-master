using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavarOyunu.Lib
{
    public class Ucak :OyunBase, IHareketEdebilir
    {
        private Point konum;
        public Ucak(Point konum)
        {
            this.konum = konum;
            this.ResimKutusu = new PictureBox();
            ResimKutusu.Size = new Size(52, 44);
            ResimKutusu.Image = Properties.Resources.ucak;
            ResimKutusu.SizeMode = PictureBoxSizeMode.StretchImage;
            ResimKutusu.Location = konum;
        }
        public void HareketEt(Yonler yon)
        {
            if (yon == Yonler.Asagi)
            {
                Point point = new Point()
                {
                    X = ResimKutusu.Location.X,
                    Y = ResimKutusu.Location.Y + 5
                };
                ResimKutusu.Location = point;
            }
        }
    }
}
