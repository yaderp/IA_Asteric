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
        int COLUMNAS;
        int FILAS;

        List<Datos> ListaDatos;
        int xfinal;
        int yfinal;
        int PesoHV = 10;
        int PesoD = 14;
        int px = 0;
        int py = 0;
        int dim = 40;
        Pen lapiz = new Pen(Color.FromArgb(37, 56, 125));
        SolidBrush pincel = new SolidBrush(Color.FromArgb(210, 214, 230));
        Graphics dibujo;
        int xInicial = 0;
        int yInicial = 0;

        int tiempo = 10;

        int hallado = -1;

        List<Datos> ListaCamino;
        int contador = 0;
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
                lapiz = new Pen(Color.FromArgb(37, 56, 125));
                
                ListaDatos = new List<Datos>();
                string rutaCompleta = @"matriz.txt";

                string linea = "";

                using (StreamReader file = new StreamReader(rutaCompleta))
                {
                    linea = file.ReadLine();
                    this.COLUMNAS = Convert.ToInt32(linea);
                    linea = file.ReadLine();
                    this.FILAS = Convert.ToInt32(linea);

                    panelCuadro.Width = COLUMNAS * dim + 2;
                    panelCuadro.Height = FILAS * dim + 2;
                    dibujo = panelCuadro.CreateGraphics();
                    labelMaxColumnas.Text = "Matriz :  "+(COLUMNAS).ToString()+" x "+ (FILAS).ToString();

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
                                //if (temp.tipo == 5) {
                                //    xfinal = i;
                                //    yfinal = j;
                                //}
                                //if (temp.tipo == 4)
                                //{
                                //    xInicial = i;
                                //    yInicial = j;
                                //}
                                temp.ID = j * COLUMNAS + i;
                                temp.x = i;
                                temp.y = j;
                                this.ListaDatos.Add(temp);
                                DibujarDato(temp);
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

        private void Recorrido(int y, int x) {
            int Index = COLUMNAS * y + x;
            ListaDatos[Index].cerrado = true;
            Vecino(Index);

        }
        void Vecino(int Index)
        {
            int auxIndex = Verifica(Index);

            if (hallado > 0)
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

            if (hallado > 0)
                return hallado;

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
                        hallado = Index;
                        temp.disFin = aux;
                        temp.disIni = distancia + ListaDatos[indexpadre].disIni;
                        temp.suma = sumita;
                        temp.cerrado = true;
                        temp.abierto = false;
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
            LLenarMatriz();           
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

            dibujo.FillRectangle(pincel, new Rectangle(px + 3 + dim * datos.x, py + 3 + dim * datos.y, dim - 6, dim - 6));

            dibujo.DrawRectangle(lapiz, px + 3 + dim * datos.x, py + 3 + dim * datos.y, dim - 6, dim - 6);
            PausaRecorrido();
            dibujo.DrawString(datos.disIni.ToString(), fuente, letra, px + dim * datos.x + 5, py + dim * datos.y + 30);
            PausaRecorrido();
            dibujo.DrawString(datos.disFin.ToString(), fuente, letra, px + dim * datos.x + 5, py + dim * datos.y + 5);
            PausaRecorrido();
            dibujo.DrawString((datos.suma).ToString(), fuente1, letra, px + dim * datos.x + 10, py + dim * datos.y + 15);
            PausaRecorrido();
        }

        private void DibujarDato(Datos dato) {
            if (dato != null) {
                pincel = getPincel(dato.tipo);
                lapiz = new Pen(Color.FromArgb(37, 56, 125));
                Font fuente1 = new Font("Arial", 8, FontStyle.Bold);
                SolidBrush letra = new SolidBrush(Color.FromArgb(37, 56, 125));
                dibujo.FillRectangle(pincel, new Rectangle(px + dim * dato.x, py + dim * dato.y, dim, dim));
                dibujo.DrawRectangle(lapiz, px + dim * dato.x, py + dim * dato.y, dim, dim);
                dibujo.DrawString((dato.ID).ToString(), fuente1, letra, px + dim * dato.x + 10, py + dim * dato.y + 15);
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
            var pinicio = Convert.ToInt32(textBoxInicio.Text);

            xInicial = pinicio % COLUMNAS;
            yInicial = pinicio / COLUMNAS;
            ListaDatos[pinicio].tipo = 4;

            

            var pfinal = Convert.ToInt32(textBoxFinal.Text);

            xfinal = pfinal % COLUMNAS;
            yfinal = pfinal / COLUMNAS;

            ListaDatos[pfinal].tipo = 5;

            DibujarDato(ListaDatos[pinicio]);
            DibujarDato(ListaDatos[pfinal]);

            contador = 0;
            ListaCamino = new List<Datos>();
            Recorrido(yInicial, xInicial);
            if (hallado < 0)
            {
                MessageBox.Show("No existe Camino.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            //finalizar
            hallado = -1;
            LLenarMatriz();
            Recorrido(yInicial, xInicial);
            mostrarPadre(ListaDatos[COLUMNAS * yfinal + xfinal]);
            if (hallado < 0)
            {
                MessageBox.Show("No existe Camino.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void buttonCamino_Click(object sender, EventArgs e)
        {
            mostrarPadre(ListaDatos[COLUMNAS * yfinal + xfinal]);
            
            if (ListaCamino != null) {
                var vercamino = ListaCamino.OrderByDescending(x => x.ID).ToList();
                foreach (var item in vercamino) {
                    DibujarDato(item);
                }
                
            }
        }
    }
}
