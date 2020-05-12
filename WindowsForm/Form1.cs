using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using GraphsLibrery;

namespace WindowsForm
{
    public partial class FormGlobal : Form
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;

        int selected1;
        int selected2;

        public FormGlobal()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(ImageBox.Width, ImageBox.Height);
            E = new List<Edge>();
            ImageBox.Image = G.GetBitmap();
            ToolTip t = new ToolTip();
            t.SetToolTip(drawVertexButton, "Намалювати вершину");
            t.SetToolTip(drawEdgeButton, "Провести ребро");
            t.SetToolTip(selectButtonFloyd, "Знайти найкоротший шлях за алгоритмом Флойда-Воршелла\nІ вивести матрицю найкоротших шляхів");
            t.SetToolTip(selectButtonFord, "Знайти найкоротший шлях за алгоритмом Форда-Беллмана\nІ показати цей шлях на малюнку");
            t.SetToolTip(deleteButton, "Видалити один елемент");
            t.SetToolTip(deleteALLButton, "Видалити граф");
            t.SetToolTip(saveButton, "Зберегти зображення графу");

        }

        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButtonFloyd.Enabled = true;
            selectButtonFord.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearImage();
            G.drawALLGraph(V, E);
            ImageBox.Image = G.GetBitmap();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = true;
            selectButtonFloyd.Enabled = true;
            selectButtonFord.Enabled = true;
            drawEdgeButton.Enabled = false;
            deleteButton.Enabled = true;
            G.clearImage();
            G.drawALLGraph(V, E);
            ImageBox.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        private void selectButtonFloyd_Click(object sender, EventArgs e)
        {
            selectButtonFloyd.Enabled = false;
            drawVertexButton.Enabled = true;
            selectButtonFord.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            selected1 = -1;
            selected2 = -1;

        }

        private void selectButtonFord_Click(object sender, EventArgs e)
        {
            selectButtonFord.Enabled = false;
            selectButtonFloyd.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            selected1 = -1;
            selected2 = -1;
        }

        private void ImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (selectButtonFord.Enabled == false)
            {
                double otv = 0;
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.clearImage();
                                G.drawALLGraph(V, E);
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                ImageBox.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                if (selected1 != i)
                                {
                                    selected2 = i;
                                    double time;
                                    otv = G.originalFordBelman(V, E, selected1, selected2,out time);
                                    ImageBox.Image = G.GetBitmap();
                                    selected1 = -1;
                                    selected2 = -1;
                                    textBoxTime.Text = time.ToString("F7");
                                    if (otv == int.MaxValue)
                                    {
                                        const string message = "Шляху між вершинами не інсує!";
                                        const string caption = "Помилка";
                                        var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        G.clearImage();
                                        G.drawALLGraph(V, E);
                                        ImageBox.Image = G.GetBitmap();
                                    }
                                    else
                                    {
                                        string specifier = "F";
                                        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
                                        textBox.Text = otv.ToString(specifier, culture);
                                    }
                                    
                                }
                                else
                                {
                                    const string message = "Початкові та кінцеві координати однакові. Спробуйте знову.";
                                    const string caption = "Помилка";
                                    var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                break;

                            }
                        }
                    }
                }
            }

            if (selectButtonFloyd.Enabled == false)
            {
                double[,] otv;
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.clearImage();
                                G.drawALLGraph(V, E);
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                ImageBox.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                if (selected1 != i)
                                {
                                    selected2 = i;
                                    double time;
                                    otv = G.originalFloydWarshall(V, E, selected1, selected2,out time);
                                    G.clearImage();
                                    G.drawALLGraph(V, E);
                                    ImageBox.Image = G.GetBitmap();
                                    drowMatrixFloyd(otv);
                                    textBoxTime.Text = time.ToString("F7");
                                    if (otv[selected1, selected2] == int.MaxValue || otv[selected1, selected2] == 0)
                                    {
                                        const string message = "Шляху між вершинами не інсує!";
                                        const string caption = "Помилка";
                                        var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        G.clearImage();
                                        G.drawALLGraph(V, E);
                                        ImageBox.Image = G.GetBitmap();
                                    }
                                    else
                                    {
                                        string specifier = "F";
                                        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-CA");
                                        textBox.Text = otv[selected1, selected2].ToString(specifier, culture);
                                    }
                                    selected1 = -1;
                                    selected2 = -1;
                                }
                                else
                                {
                                    const string message = "Початкові та кінцеві координати однакові. Спробуйте знову.";
                                    const string caption = "Помилка";
                                    var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                break;
                                
                            }
                        }
                    }
                }
            }

            if (drawVertexButton.Enabled == false)
            {
                bool f = false;
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= 2*G.R * G.R)
                    { f = true;
                        const string message = "Тут вже є вершина.";
                        const string caption = "Помилка";
                        var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        f = true;
                    } else
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= 4 * G.R * G.R)
                    { f = true;
                        const string message = "Не ставте вершини близько одна до одно.";
                        const string caption = "Помилка";
                        var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                if (f == false)
                {
                    V.Add(new Vertex(e.X, e.Y));
                    G.drawVertex(e.X, e.Y, V.Count.ToString());
                    ImageBox.Image = G.GetBitmap();
                    drowMatrix();
                }

            }

            if (drawEdgeButton.Enabled == false)
            {
                
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                ImageBox.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                if (selected1 != i) 
                                {
                                    G.drawSelectedVertex(V[i].x, V[i].y);
                                    selected2 = i;
                                    E.Add(new Edge(selected1, selected2, V[selected1].x, V[selected1].y, V[selected2].x, V[selected2].y));
                                    G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                    selected1 = -1;
                                    selected2 = -1;
                                    ImageBox.Image = G.GetBitmap();
                                } else
                                {
                                    const string message = "Початкові та кінцеві координати однакові. Спробуйте знову.";
                                    const string caption = "Помилка";
                                    var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                    break;
                                
                            }
                        }
                    }
                }
                drowMatrix();
            }
           
            if (deleteButton.Enabled == false)
            {
                drowMatrix();
                bool flag = false; 

                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                    }
                }
               
                if (flag)
                {
                    drowMatrix();
                    G.clearImage();
                    G.drawALLGraph(V, E);
                    ImageBox.Image = G.GetBitmap();
                }
            }
        }

        public void drowMatrix()
        {
            double[,] mas = G.Matrix(V, E);

            dataGridView.RowCount = V.Count;
            dataGridView.ColumnCount = V.Count;

            for (int j = 0; j < mas.GetLength(0); j++)
            {
                dataGridView.Rows[j].HeaderCell.Value = (j+1).ToString();
                for (int i = 0; i < mas.GetLength(1); i++)
                {
                    if (mas[j,i] == 0) dataGridView[i, j].ReadOnly = true;
                    dataGridView[i, j].Value = mas[j, i];
                    dataGridView.Columns[i].HeaderText = (i+1).ToString();
                    if (mas[j, i] != 0) dataGridView[i, j].ReadOnly = false;
                }
            }
            foreach (DataGridViewColumn item in dataGridView.Columns) item.Width = 50;
        }

        public void drowMatrixFloyd(double [,] mas)
        {
            FormFloyd f = new FormFloyd(this);
            f.Show();
            f.DrawMatrix(mas, V.Count);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButtonFloyd.Enabled = true;
            selectButtonFord.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearImage();
            G.drawALLGraph(V, E);
            ImageBox.Image = G.GetBitmap();
        }

        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButtonFloyd.Enabled = true;
            selectButtonFord.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Ви дійсно повністю хочете видалити грав?";
            const string caption = "Видалення";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearImage();
                ImageBox.Image = G.GetBitmap();
            }
            drowMatrix();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ImageBox.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Зберегти зображення як...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Неможливо зберегти зображення", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var valueMatrix = dataGridView[e.ColumnIndex, e.RowIndex].Value?.ToString();
            if (valueMatrix == null)
            {
                dataGridView[e.ColumnIndex, e.RowIndex].Value = 0;
                return;
            }
            double.TryParse(dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString(), out double value);
            if (value != 0)
            {
                var edgeToChange = E.Find(item => item.v1 == e.ColumnIndex && item.v2 == e.RowIndex || item.v2 == e.ColumnIndex && item.v1 == e.RowIndex);
                edgeToChange.redEdge(value);
            }
                drowMatrix();
                G.clearImage();
                G.drawALLGraph(V, E);
                ImageBox.Image = G.GetBitmap();
            
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }
    }
}
