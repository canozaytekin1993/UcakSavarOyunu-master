using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavarOyunu.Lib
{
    public abstract class OyunBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public PictureBox ResimKutusu { get; set; }
        protected ContainerControl tasiyici;

    }
}
