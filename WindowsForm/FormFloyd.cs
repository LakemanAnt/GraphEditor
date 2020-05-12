using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class FormFloyd : Form
    {
        private FormGlobal _parent;

        public FormFloyd(FormGlobal parent)
        {
            _parent = parent;
            InitializeComponent();

        }

        public void DrawMatrix(double[,] mas,int size)
        {

            dataGridViewFloyd.RowCount = size;
            dataGridViewFloyd.ColumnCount = size;

            for (int j = 0; j < mas.GetLength(0); j++)
            {
                dataGridViewFloyd.Rows[j].HeaderCell.Value = (j + 1).ToString();
                for (int i = 0; i < mas.GetLength(1); i++)
                {
                    if (i == j || mas[j, i] == int.MaxValue)
                    {
                        mas[i, j] = 0; mas[j, i] = 0;
                    }
                    dataGridViewFloyd[i, j].Value = mas[j, i];
                    dataGridViewFloyd.Columns[i].HeaderText = (i + 1).ToString();
                }
            }

            foreach (DataGridViewColumn item in dataGridViewFloyd.Columns) item.Width = 50;

        }
        private Label label2;
        private DataGridView dataGridViewFloyd;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFloyd));
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewFloyd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFloyd)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Britannic Bold", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 37);
            this.label2.TabIndex = 17;
            this.label2.Text = "Результат роботи алгоритму";
            // 
            // dataGridViewFloyd
            // 
            this.dataGridViewFloyd.AllowUserToAddRows = false;
            this.dataGridViewFloyd.AllowUserToDeleteRows = false;
            this.dataGridViewFloyd.AllowUserToResizeColumns = false;
            this.dataGridViewFloyd.AllowUserToResizeRows = false;
            this.dataGridViewFloyd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFloyd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFloyd.Location = new System.Drawing.Point(12, 124);
            this.dataGridViewFloyd.Name = "dataGridViewFloyd";
            this.dataGridViewFloyd.ReadOnly = true;
            this.dataGridViewFloyd.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewFloyd.RowTemplate.Height = 20;
            this.dataGridViewFloyd.Size = new System.Drawing.Size(445, 339);
            this.dataGridViewFloyd.TabIndex = 16;
            this.dataGridViewFloyd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFloyd_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Флойда-Воршелла";
            // 
            // FormFloyd
            // 
            this.ClientSize = new System.Drawing.Size(469, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewFloyd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(487, 522);
            this.MinimumSize = new System.Drawing.Size(487, 522);
            this.Name = "FormFloyd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Matrix Floyd";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFloyd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridViewFloyd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Label label1;
    }
}
