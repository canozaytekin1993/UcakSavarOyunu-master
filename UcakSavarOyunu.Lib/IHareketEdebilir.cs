﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakSavarOyunu.Lib
{
    public interface IHareketEdebilir
    {
        void HareketEt(Yonler yon);
    }
    public enum Yonler
    {
        Yukari,
        Asagi,
        Sola,
        Saga
    }
}
