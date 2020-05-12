namespace WindowsForm
{
    partial class FormGlobal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGlobal));
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.selectButtonFloyd = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBox = new System.Windows.Forms.TextBox();
            this.LabelLenght = new System.Windows.Forms.Label();
            this.selectButtonFord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(582, 15);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(827, 546);
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            this.ImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageBox_MouseClick);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.drawEdgeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawEdgeButton.BackgroundImage")));
            this.drawEdgeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawEdgeButton.Location = new System.Drawing.Point(482, 90);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(64, 52);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.UseVisualStyleBackColor = false;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // selectButtonFloyd
            // 
            this.selectButtonFloyd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.selectButtonFloyd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectButtonFloyd.BackgroundImage")));
            this.selectButtonFloyd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectButtonFloyd.Location = new System.Drawing.Point(482, 165);
            this.selectButtonFloyd.Name = "selectButtonFloyd";
            this.selectButtonFloyd.Size = new System.Drawing.Size(64, 57);
            this.selectButtonFloyd.TabIndex = 3;
            this.selectButtonFloyd.UseVisualStyleBackColor = false;
            this.selectButtonFloyd.Click += new System.EventHandler(this.selectButtonFloyd_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteButton.Location = new System.Drawing.Point(482, 321);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(64, 55);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.deleteALLButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteALLButton.BackgroundImage")));
            this.deleteALLButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteALLButton.Location = new System.Drawing.Point(482, 399);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(64, 59);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.UseVisualStyleBackColor = false;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.BackColor = System.Drawing.Color.White;
            this.drawVertexButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawVertexButton.BackgroundImage")));
            this.drawVertexButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.drawVertexButton.Location = new System.Drawing.Point(482, 15);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(64, 56);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = false;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(20, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.RowTemplate.Height = 20;
            this.dataGridView.Size = new System.Drawing.Size(439, 385);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(313, 461);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(146, 31);
            this.textBox.TabIndex = 8;
            // 
            // LabelLenght
            // 
            this.LabelLenght.AutoSize = true;
            this.LabelLenght.BackColor = System.Drawing.Color.GhostWhite;
            this.LabelLenght.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLenght.Location = new System.Drawing.Point(25, 464);
            this.LabelLenght.Name = "LabelLenght";
            this.LabelLenght.Size = new System.Drawing.Size(272, 23);
            this.LabelLenght.TabIndex = 9;
            this.LabelLenght.Text = "Довжина найкоротшого шляху:";
            // 
            // selectButtonFord
            // 
            this.selectButtonFord.BackColor = System.Drawing.Color.WhiteSmoke;
            this.selectButtonFord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectButtonFord.BackgroundImage")));
            this.selectButtonFord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectButtonFord.Location = new System.Drawing.Point(482, 241);
            this.selectButtonFord.Name = "selectButtonFord";
            this.selectButtonFord.Size = new System.Drawing.Size(64, 57);
            this.selectButtonFord.TabIndex = 10;
            this.selectButtonFord.UseVisualStyleBackColor = false;
            this.selectButtonFord.Click += new System.EventHandler(this.selectButtonFord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Матриця суміжності";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.GhostWhite;
            this.labelTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(38, 511);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(259, 23);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "Час роботи алгоритму (сек.):";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(313, 508);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(146, 31);
            this.textBoxTime.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveButton.BackgroundImage")));
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveButton.Font = new System.Drawing.Font("Elephant", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(482, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(64, 59);
            this.saveButton.TabIndex = 6;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FormGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1432, 583);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectButtonFord);
            this.Controls.Add(this.LabelLenght);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectButtonFloyd);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.ImageBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1450, 630);
            this.MinimumSize = new System.Drawing.Size(1450, 630);
            this.Name = "FormGlobal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The shortest way";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button selectButtonFloyd;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label LabelLenght;
        private System.Windows.Forms.Button selectButtonFord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Button saveButton;
    }
}

