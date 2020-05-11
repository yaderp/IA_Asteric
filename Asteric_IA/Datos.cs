using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteric_IA
{
    public class Datos
    {
        public int ID { set; get; }
        public int disFin { set; get; }
        public int disIni { set; get; }
        public int x { set; get; }
        public int y { set; get; }
        public int suma { set; get; }
        public bool abierto { set; get; }
        public bool cerrado { set; get; }
        public int tipo { set; get; } // 0 libre 1 obstaculo 2 inicio 3 final
        public Datos padre { set; get; }
        public Datos() {
            this.padre = null;
            this.disFin =0;
            this.disIni = 0;
            this.suma = 0;
            this.abierto = false;
            this.cerrado = false;
            this.x = 10;
            this.y = 10;
            this.tipo = 0;
        }




    }
}
