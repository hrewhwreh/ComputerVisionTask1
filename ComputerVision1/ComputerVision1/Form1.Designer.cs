
namespace ComputerVision1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.полутоновоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перевестиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улчшениеКонтрастаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.улучшитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выделениеУгловыхТочекToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.distanceTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.meanFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сделатьToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1421, 695);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.полутоновоеToolStripMenuItem,
            this.улчшениеКонтрастаToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.выделениеУгловыхТочекToolStripMenuItem,
            this.distanceTransformToolStripMenuItem,
            this.meanFilterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // полутоновоеToolStripMenuItem
            // 
            this.полутоновоеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перевестиToolStripMenuItem});
            this.полутоновоеToolStripMenuItem.Name = "полутоновоеToolStripMenuItem";
            this.полутоновоеToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.полутоновоеToolStripMenuItem.Text = "Полутоновое";
            // 
            // перевестиToolStripMenuItem
            // 
            this.перевестиToolStripMenuItem.Name = "перевестиToolStripMenuItem";
            this.перевестиToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.перевестиToolStripMenuItem.Text = "Перевести";
            this.перевестиToolStripMenuItem.Click += new System.EventHandler(this.перевестиToolStripMenuItem_Click);
            // 
            // улчшениеКонтрастаToolStripMenuItem
            // 
            this.улчшениеКонтрастаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.улучшитьToolStripMenuItem});
            this.улчшениеКонтрастаToolStripMenuItem.Name = "улчшениеКонтрастаToolStripMenuItem";
            this.улчшениеКонтрастаToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.улчшениеКонтрастаToolStripMenuItem.Text = "Улчшение контраста";
            // 
            // улучшитьToolStripMenuItem
            // 
            this.улучшитьToolStripMenuItem.Name = "улучшитьToolStripMenuItem";
            this.улучшитьToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.улучшитьToolStripMenuItem.Text = "Улучшить";
            this.улучшитьToolStripMenuItem.Click += new System.EventHandler(this.улучшитьToolStripMenuItem_Click);
            // 
            // cannyToolStripMenuItem
            // 
            this.cannyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьToolStripMenuItem});
            this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
            this.cannyToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.cannyToolStripMenuItem.Text = "Canny";
            // 
            // сделатьToolStripMenuItem
            // 
            this.сделатьToolStripMenuItem.Name = "сделатьToolStripMenuItem";
            this.сделатьToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.сделатьToolStripMenuItem.Text = "Сделать";
            this.сделатьToolStripMenuItem.Click += new System.EventHandler(this.сделатьToolStripMenuItem_Click);
            // 
            // выделениеУгловыхТочекToolStripMenuItem
            // 
            this.выделениеУгловыхТочекToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьToolStripMenuItem1});
            this.выделениеУгловыхТочекToolStripMenuItem.Name = "выделениеУгловыхТочекToolStripMenuItem";
            this.выделениеУгловыхТочекToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.выделениеУгловыхТочекToolStripMenuItem.Text = "Выделение угловых точек";
            // 
            // сделатьToolStripMenuItem1
            // 
            this.сделатьToolStripMenuItem1.Name = "сделатьToolStripMenuItem1";
            this.сделатьToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.сделатьToolStripMenuItem1.Text = "Сделать";
            this.сделатьToolStripMenuItem1.Click += new System.EventHandler(this.сделатьToolStripMenuItem1_Click);
            // 
            // distanceTransformToolStripMenuItem
            // 
            this.distanceTransformToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьToolStripMenuItem2});
            this.distanceTransformToolStripMenuItem.Name = "distanceTransformToolStripMenuItem";
            this.distanceTransformToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.distanceTransformToolStripMenuItem.Text = "Distance Transform";
            // 
            // сделатьToolStripMenuItem2
            // 
            this.сделатьToolStripMenuItem2.Name = "сделатьToolStripMenuItem2";
            this.сделатьToolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
            this.сделатьToolStripMenuItem2.Text = "Сделать";
            this.сделатьToolStripMenuItem2.Click += new System.EventHandler(this.сделатьToolStripMenuItem2_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(104, 779);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1200, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1310, 779);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // meanFilterToolStripMenuItem
            // 
            this.meanFilterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьToolStripMenuItem3});
            this.meanFilterToolStripMenuItem.Name = "meanFilterToolStripMenuItem";
            this.meanFilterToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.meanFilterToolStripMenuItem.Text = "MeanFilter";
            // 
            // сделатьToolStripMenuItem3
            // 
            this.сделатьToolStripMenuItem3.Name = "сделатьToolStripMenuItem3";
            this.сделатьToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.сделатьToolStripMenuItem3.Text = "Сделать";
            this.сделатьToolStripMenuItem3.Click += new System.EventHandler(this.сделатьToolStripMenuItem3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 760);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time Mean Filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 760);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 814);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ComputerVisionTask1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem полутоновоеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перевестиToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem улчшениеКонтрастаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem улучшитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выделениеУгловыхТочекToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem distanceTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem meanFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сделатьToolStripMenuItem3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

