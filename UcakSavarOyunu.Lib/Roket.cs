using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavarOyunu.Lib
{
    public class Roket : OyunBase, IHareketEdebilir
    {
        private Point konum;
        public Roket(Point konum)
        {
            ResimKutusu = new PictureBox();
            ResimKutusu.Size = new Size(28, 36);
            ResimKutusu.Image = Properties.Resources.mermi1;
            ResimKutusu.SizeMode = PictureBoxSizeMode.StretchImage;
            ResimKutusu.Location = konum;
        }
        public void HareketEt(Yonler yon)
        {

            if (yon == Yonler.Yukari)
            {
                Point point = new Point()
                {
                    X = ResimKutusu.Location.X,
                    Y = ResimKutusu.Location.Y - 5
                };
                ResimKutusu.Location = point;
            }
        }
    }
}
