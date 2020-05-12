using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using static System.Math;

namespace GraphsLibrery
{
    public class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Edge
    {
        public int v1, v2;
        public double ELength;

        public Edge(int v1, int v2, int x, int y, int x2, int y2)
        {
            this.v1 = v1;
            this.v2 = v2;
            ELength = Math.Sqrt(Math.Pow((x - x2), 2) + Math.Pow((y - y2), 2));
        }

        public void redEdge(double elength)
        {
            this.ELength = elength;
        }
    }

    public class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo, fotxt;
        Brush br, brtxt;
        PointF point;
        public int R = 20;

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearImage();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.Gray);
            darkGoldPen.Width = 2;
            fo = new Font("Arial", 12);
            fotxt = new Font("Arial", 10);
            br = Brushes.Black;
            brtxt = Brushes.Blue;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearImage()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {

            gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
            float x = (V1.x + V2.x) / 2;
            float y = (V1.y + V2.y) / 2;
            var length = Round(E.ELength,2);
            this.DrawString( x, y, (float)Angle(V1,V2), length.ToString());
            drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
        }



        public void DrawString(float x, float y, float angle, string text)
        {
            Matrix matrix = this.gr.Transform.Clone();
            this.gr.TranslateTransform(x,y);
            this.gr.RotateTransform(angle);
            gr.DrawString(text, fotxt, brtxt,0f,0F);
            this.gr.Transform = matrix;
        }

        private double Angle(Vertex v1, Vertex v2)
        {
            double num = Sqrt(Pow((v2.x - v1.x), 2.0) + Pow(v2.y - v1.y, 2.0));
            double num2 = (Acos((v2.x - v1.x) / num) / PI) * 180.0;

            if ((v2.x - v1.x) < 0)
                num2 += 180.0;

            if ((v2.y - v1.y) < 0)
                num2 = -num2;

            return num2;
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            for (int i = 0; i < E.Count; i++)
            {
                drawEdge(V[E[i].v1], V[E[i].v2], E[i], i);
            }

            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }

        public double[,] Matrix(List<Vertex> V, List<Edge> E)
        {
            int size = V.Count;
            double[,] mas = new double[size, size];

            for (int i = 1; i <= E.Count; i++)
            {
                mas[E[i - 1].v1, E[i - 1].v2] = E[i - 1].ELength;
                mas[E[i - 1].v2, E[i - 1].v1] = E[i - 1].ELength;
            }

            return mas;

        }

        public double min(double a, double b)
        {
            if (a < b) return a;
            else return b;
        }

        public double[,] originalFloydWarshall(List<Vertex> V, List<Edge> E, int start, int finish,out double time)
        {
            double[,] matrix = Matrix(V, E);
            int[,] matr = new int[V.Count,V.Count];
            int[] mas = new int[V.Count];

            Stopwatch StartTime = new Stopwatch();
            StartTime.Start();
            for (int i = 0; i < V.Count; i++)
                for (int j = 0; j < V.Count; j++)
                    if (matrix[i, j] == 0) matrix[i, j] = int.MaxValue;

            for (int k = 0; k < V.Count; k++)
                for (int i = 0; i < V.Count; i++)
                    for (int j = 0; j < V.Count; j++)
                        if (matrix[i, k] < int.MaxValue && matrix[k, j] < int.MaxValue)
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                        }

            StartTime.Stop();
            time = StartTime.Elapsed.TotalSeconds;

            return matrix;
        }

        public double originalFordBelman(List<Vertex> V, List<Edge> E, int start, int finish, out double time)
        {
            double[] Len = new double[V.Count + 1];
            int[] mas = new int[V.Count];
            int[] force;


            for (int i = 0; i < V.Count; i++) Len[i] = int.MaxValue;
            Len[start] = 0;
            Stopwatch StartTime = new Stopwatch();
            StartTime.Start();
            for (int i = 1; i <= V.Count; i++)
                for (int j = 0; j < E.Count; j++)
                {
                    if (Len[E[j].v2] > Len[E[j].v1] + E[j].ELength)
                    {
                        Len[E[j].v2] = Len[E[j].v1] + E[j].ELength;
                        mas[E[j].v2] = E[j].v1;
                    }
                    if (Len[E[j].v1] > Len[E[j].v2] + E[j].ELength)
                    {
                        Len[E[j].v1] = Len[E[j].v2] + E[j].ELength;
                        mas[E[j].v1] = E[j].v2;
                    }
                }
            StartTime.Stop();
            time = StartTime.Elapsed.TotalSeconds;
            int f;
            if (Len[finish] != int.MaxValue)
            {
                force = TakePath(mas, start, finish, out f);
                DrawPath(force, f, E, V);
            }
                return Len[finish];
        }

        public int[] TakePath(int[] mas, int start, int finish, out int f)
        {
            int[] force = new int[mas.Length];
            int k = finish;
            f = 0;
            for (; ; )
            {
                force[f] = k;
                f++;
                k = mas[k];
                if (k == start)
                {
                    force[f] = start;
                    break;
                }
            }
            return force;
        } 

        public void DrawPath(int[] force, int f, List<Edge> E, List<Vertex> V)
        {
            darkGoldPen = new Pen(Color.Gold);
            darkGoldPen.Width = 4;
            blackPen = new Pen(Color.Gold);
            blackPen.Width = 4;
            for (int i = 0; i < f; i++)

                for (int j = 0; j < E.Count; j++)
                {
                    if (force[i] == E[j].v1 && force[i + 1] == E[j].v2)
                    {
                        drawEdge(V[force[i]], V[force[i + 1]], E[j], j);
                        break;
                    }
                    if (force[i] == E[j].v2 && force[i + 1] == E[j].v1)
                    {
                        drawEdge(V[force[i+1]], V[force[i]], E[j], j);
                        break;
                    }


                }
            darkGoldPen = new Pen(Color.Gray);
            darkGoldPen.Width = 2;
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
        }
    }
}

