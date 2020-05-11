using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteric_IA
{
    public partial class Inicio : Form
    {
        int COLUMNAS = Variables.COLUMNAS;
        int FILAS = Variables.FILAS;

        List<Datos> ListaDatos;
        int xfinal;
        int yfinal;
        int PesoHV = 10;
        int PesoD = 14;
        int dim = Variables.DIM;
        Pen lapiz = new Pen(Color.FromArgb(37, 56, 125));
        SolidBrush pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
        Graphics dibujo;
        int tiempo = 5;

        bool hallado = false;
        List<Datos> ListaCamino;
        int contador = 0;
        int IndexFinal = -1;
        int IndexInicial = -1;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        #region Valor Inicial
        private void LLenarMatriz()
        { 
            try
            {
                ListaDatos = new List<Datos>();
                lapiz = new Pen(Color.FromArgb(37, 56, 125));
                string rutaCompleta = @"matriz.txt";
                string linea = "";

                using (StreamReader file = new StreamReader(rutaCompleta))
                {
                    dibujo = panelCuadro.CreateGraphics();

                    for (int j = 0; j < FILAS; j++)
                    {
                        linea = file.ReadLine();

                        if (linea != null)
                        {
                            string Palabra = linea;
                            string[] letra;
                            letra = Palabra.Split(',');

                            for (int i = 0; i < COLUMNAS; i++)
                            {
                                Datos temp = new Datos();
                                temp.tipo = Convert.ToInt32(letra[i]);                                
                                temp.ID = j * COLUMNAS + i;
                                temp.x = i;
                                temp.y = j;
                                this.ListaDatos.Add(temp);
                                //DibujarMapa(temp);
                                
                            }
                        }
                    }

                    linea = file.ReadToEnd();
                    file.Close();
                }

            }
            catch
            {
                MessageBox.Show("Por favor, intentar más tarde.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        private void Recorrido(int Index) {            
            ListaDatos[Index].cerrado = true;
            Vecino(Index);

        }
        void Vecino(int Index)
        {
            int auxIndex = Verifica(Index);

            if (hallado)
                return;

            if (auxIndex >= 0)
            {
                ListaDatos[auxIndex].cerrado = true;
                ListaDatos[auxIndex].abierto = false;
                DibujarRecorrido(ListaDatos[auxIndex]);
                ListaDatos[auxIndex].tipo = 10;
                Vecino(auxIndex);
            }
        }
        private bool movimiento(int tipo, int posy, int posx, int Index)
        {
            if (posx >= 0 && posx < COLUMNAS && posy >= 0 && posy < FILAS) {
                int mov = posy * COLUMNAS + posx;

                if (ListaDatos[mov].tipo == 0) {
                    // izquierda arriba
                    if (tipo == 1)
                    {
                        var abajo = ListaDatos[Index - 1].tipo;
                        var arriba = ListaDatos[mov + 1].tipo;
                        if (abajo == 0 && arriba == 0)
                            return true;
                    }

                    // izquierda abajo
                    if (tipo == 2)
                    {
                        var abajo = ListaDatos[mov + 1].tipo;
                        var arriba = ListaDatos[Index - 1].tipo;
                        if (abajo == 0 && arriba == 0)
                            return true;
                    }

                    // derecha arriba
                    if (tipo == 3)
                    {
                        var abajo = ListaDatos[Index + 1].tipo;
                        var arriba = ListaDatos[mov - 1].tipo;
                        if (abajo == 0 && arriba == 0)
                            return true;
                    }
                    // derecha abajo

                    if (tipo == 4)
                    {
                        var abajo = ListaDatos[mov - 1].tipo;
                        var arriba = ListaDatos[Index + 1].tipo;
                        if (abajo == 0 && arriba == 0)
                            return true;
                    }
                }
                
            }

            return false;
        }

        private int Verifica(int Index)
        {
            int y = ListaDatos[Index].y;
            int x = ListaDatos[Index].x;

            //Vertical horizaontales
            VerificaVecinos(y, x - 1, PesoHV, Index); //Izquierda
            VerificaVecinos(y, x + 1, PesoHV, Index);//derecha
            VerificaVecinos(y - 1, x, PesoHV, Index);//arriba
            VerificaVecinos(y + 1, x, PesoHV, Index);//abajo

            // diagonales

            // arriba izquierda
            if (movimiento(1, y - 1, x - 1,Index))
                VerificaVecinos(y - 1, x - 1, PesoD, Index);

            // arriba derecha
            if (movimiento(2, y - 1, x + 1,Index))
                VerificaVecinos(y - 1, x + 1, PesoD, Index);

            //abajo izquierda
            if (movimiento(3, y + 1, x - 1,Index))
                VerificaVecinos(y + 1, x - 1, PesoD, Index);

            //abajo derecha
            if (movimiento(4, y + 1, x + 1,Index))
                VerificaVecinos(y + 1, x + 1, PesoD, Index);


            List<Datos> lstaAbierto = new List<Datos>();


            for (int i = 0; i < ListaDatos.Count; i++)
            {
                if (ListaDatos[i].abierto)
                {
                    lstaAbierto.Add(ListaDatos[i]);
                }
            }

            if (lstaAbierto.Count != 0)
            {
                int menor = 0;
                for (int i = 1; i < lstaAbierto.Count; i++)
                {
                    if (lstaAbierto[i].suma < lstaAbierto[menor].suma)
                    {
                        menor = i;
                    }
                }

                int auxIndex = lstaAbierto[menor].y * COLUMNAS + lstaAbierto[menor].x;

                if (lstaAbierto[menor].disFin != 0)
                {
                    return auxIndex;
                }
            }

            return -1;
        }
        
        private void VerificaVecinos(int y, int x,int distancia,int indexpadre) {

            if (x >= 0 && x < COLUMNAS && y >= 0 && y < FILAS)  {
                int Index = COLUMNAS * y + x;

                var  temp = ListaDatos[Index];

                //verifica que sea camino libre y no haya sido tomado o visitado
                if ((temp.tipo < 1 || temp.tipo > 3) && temp.cerrado == false)
                {
                    //Calcula distancia hasta el punto final
                    int aux = (Math.Abs(yfinal - y) + Math.Abs(xfinal - x)) * 10;

                    int sumita = aux + distancia + ListaDatos[indexpadre].disIni;

                    if (aux != 0)
                    {
                        if (temp.abierto == false)
                        {
                            temp.disFin = aux;
                            temp.disIni = distancia + ListaDatos[indexpadre].disIni;
                            temp.suma = sumita;
                            temp.abierto = true;
                            temp.padre = ListaDatos[indexpadre];
                            DibujarRecorrido(ListaDatos[Index]);
                        }
                        else
                        {
                            if (sumita < ListaDatos[Index].suma)
                            {
                                temp.disFin = aux;
                                temp.disIni = distancia + ListaDatos[indexpadre].disIni;
                                temp.suma = sumita;
                            }
                        }
                    }
                    else {
                        hallado = true;
                        temp.disFin = aux;
                        temp.disIni = distancia + ListaDatos[indexpadre].disIni;
                        temp.suma = sumita;
                        temp.cerrado = true;
                        temp.abierto = false;
                        temp.tipo = 5;
                        temp.padre = ListaDatos[indexpadre];
                    }
                }               
            }
        }
        
        private void mostrarPadre(Datos raizPadre ) {
            
            if (raizPadre != null) {
                raizPadre.ID = contador;
                
                ListaCamino.Add(raizPadre);
                contador++;
                //DibujarDato(raizPadre.padre);
                mostrarPadre(raizPadre.padre);                
            }
        }
        private void buttonCargar_Click(object sender, EventArgs e)
        {

            IndexFinal = -1;
            IndexInicial = -1;
            contador = 0;
            ListaCamino = new List<Datos>();
            ListaDatos = new List<Datos>();
            hallado = false;
            LLenarMatriz();
            Pinta_Mapa();
        }
              
        private void DibujarRecorrido(Datos datos) {
            
            SolidBrush letra = new SolidBrush(Color.FromArgb(37, 56, 125));
            SolidBrush letra1 = new SolidBrush(Color.Violet);

            if (datos.cerrado) {
                lapiz = new Pen(Color.Violet);
                pincel = new SolidBrush(Color.Orange);
            }

            if (datos.abierto)
            {
                lapiz = new Pen(Color.Green);
                pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
            }

            Font fuente = new Font("Arial", 5);
            Font fuente1 = new Font("Arial", 8, FontStyle.Bold);

            //dibujo.FillRectangle(pincel, new Rectangle(3 + dim * datos.x,3 + dim * datos.y, dim - 6, dim - 6));

            dibujo.DrawRectangle(lapiz, 3 + dim * datos.x, 3 + dim * datos.y, dim - 6, dim - 6);
            PausaRecorrido();
            dibujo.DrawString(datos.disIni.ToString(), fuente, letra, dim * datos.x + 5, dim * datos.y + 30);
            PausaRecorrido();
            dibujo.DrawString(datos.disFin.ToString(), fuente, letra, dim * datos.x + 5, dim * datos.y + 5);
            PausaRecorrido();
            dibujo.DrawString((datos.suma).ToString(), fuente1, letra, dim * datos.x + 10, dim * datos.y + 15);
            PausaRecorrido();
        }

        private void DibujarDato(Datos dato) {
            if (dato != null) {
                pincel = getPincel(dato.tipo);
                lapiz = new Pen(Color.FromArgb(37, 56, 125));
                Font fuente1 = new Font("Arial", 8, FontStyle.Bold);
                SolidBrush letra = new SolidBrush(Color.FromArgb(37, 56, 125));
                dibujo.FillRectangle(pincel, new Rectangle(dim * dato.x,dim * dato.y, dim, dim));
                dibujo.DrawRectangle(lapiz,dim * dato.x,dim * dato.y, dim, dim);
                dibujo.DrawString((dato.ID).ToString(), fuente1, letra,dim * dato.x + 10,dim * dato.y + 15);
                PausaRecorrido();
            }                
        }

        private void PausaRecorrido() {
            Thread.Sleep(tiempo);
        }

        private SolidBrush getPincel(int tipo) {
            pincel = new SolidBrush(Color.Violet);

            //camino libre
            if (tipo == 0)
            {
                pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
            }

            //Edificio
            if (tipo == 1)
            {
                pincel = new SolidBrush(Color.FromArgb(37, 56, 125));
            }

            //Zona Infectada
            if (tipo == 2)
            {
                pincel = new SolidBrush(Color.FromArgb(153, 0, 255));
            }

            //Muerto
            if (tipo == 3)
            {
                pincel = new SolidBrush(Color.FromArgb(102, 102, 51));
            }


            //punto Inicial
            if (tipo == 4)
            {
                pincel = new SolidBrush(Color.FromArgb(0, 195, 0));
            }

            //llegada
            if (tipo == 5)
            {
                pincel = new SolidBrush(Color.FromArgb(195, 0, 0));
            }

            return pincel;
        }
        
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if (IndexInicial >= 0 && IndexFinal >= 0)
            {
                contador = 0;
                ListaCamino = new List<Datos>();
                Recorrido(IndexInicial);
                if (!hallado)
                {
                    MessageBox.Show("No existe Camino.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else {
                MessageBox.Show("Lugar de inicio y/o final no marcados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void comboBoxVelocidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVelocidad.Text == "LENTO")
                tiempo = 200;
            if (comboBoxVelocidad.Text == "MEDIO")
                tiempo = 100;
            if (comboBoxVelocidad.Text == "RAPIDO")
                tiempo = 10;
        }
        
        private void DibujarMapa(Datos dato) {
            Bitmap imagen = new Bitmap("Imagen/mapa.png");
            Bitmap imgtransparente = new Bitmap(imagen);
            //imgtransparente.MakeTransparent(imgtransparente.GetPixel(1, 1));
            Rectangle porcionAUsar = new Rectangle(dato.tipo*40, 0, 40, 40);
            dibujo.DrawImage(imgtransparente, dato.x * Variables.DIM, dato.y * Variables.DIM, porcionAUsar, GraphicsUnit.Pixel);

            if (dato.tipo > 5) {

                if (dato.tipo == 9)
                {
                    ListaDatos[dato.ID].tipo = 0;
                }
                else {
                    ListaDatos[dato.ID].tipo = 1;
                }                
            }
        }
        
        private void Pinta_Mapa() {
            
            foreach (var item in ListaDatos)
            {
                DibujarMapa(item);
            }
        }

        private void buttonCamino_Click(object sender, EventArgs e)
        {
            mostrarPadre(ListaDatos[IndexFinal]);
            var dInicio = ListaDatos[IndexInicial];
            var dFinal = ListaDatos[IndexFinal];
            //dFinal.tipo = 5;

            LLenarMatriz();

            ListaDatos[IndexFinal] = dFinal;
            ListaDatos[IndexInicial] = dFinal;

            Pinta_Mapa();

            if (ListaCamino != null)
            {
                ListaCamino = ListaCamino.OrderByDescending(x => x.ID).ToList();

                for (int i = 1; i < ListaCamino.Count() - 1; i++) {
                    ListaCamino[i].ID = i;
                    DibujarDato(ListaCamino[i]);
                }
            }
        }

        private void panelCuadro_Click(object sender, EventArgs e)
        {

            if (IndexInicial < 0 || IndexFinal < 0) {
                Point point = panelCuadro.PointToClient(Cursor.Position);

                int posx = point.X / Variables.DIM;
                int posy = point.Y / Variables.DIM;
                int posxy = posy * COLUMNAS + posx;

                if (ListaDatos[posxy].tipo == 0)
                {
                    Datos temp = new Datos();
                    temp.x = posx;
                    temp.y = posy;
                    temp.ID = posxy;
                    if (IndexInicial < 0)
                    {
                        temp.tipo = 4;
                        IndexInicial = posxy;
                    }
                    else {
                        temp.tipo = 5;
                        IndexFinal = posxy;
                        xfinal = posx;
                        yfinal = posy;
                    }

                    DibujarMapa(temp);
                }
            }
            
        }
    }
}
