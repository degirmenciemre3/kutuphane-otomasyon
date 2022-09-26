
namespace KutuphaneOtomasyon.Kitap
{
    partial class KitapGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitapGuncelle));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.txt_kitapad = new System.Windows.Forms.TextBox();
            this.txt_yayinevi = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_kitapid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_yazar = new System.Windows.Forms.ComboBox();
            this.cmb_tur = new System.Windows.Forms.ComboBox();
            this.cmb_raf = new System.Windows.Forms.ComboBox();
            this.txt_sayfasayisi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1230, 50);
            this.panel3.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(431, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kitap Guncelle";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1198, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(987, 509);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Guncellemek İstediğiniz Kitap Bilgilerine Tıklayın";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(825, 76);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 19);
            this.textBox1.TabIndex = 18;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button2.Location = new System.Drawing.Point(1008, 574);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 30);
            this.button2.TabIndex = 20;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button4.Location = new System.Drawing.Point(1008, 538);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 30);
            this.button4.TabIndex = 20;
            this.button4.Text = "Listele";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_isbn
            // 
            this.txt_isbn.Location = new System.Drawing.Point(1112, 135);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(106, 20);
            this.txt_isbn.TabIndex = 21;
            // 
            // txt_kitapad
            // 
            this.txt_kitapad.Location = new System.Drawing.Point(1112, 161);
            this.txt_kitapad.Name = "txt_kitapad";
            this.txt_kitapad.Size = new System.Drawing.Size(106, 20);
            this.txt_kitapad.TabIndex = 21;
            // 
            // txt_yayinevi
            // 
            this.txt_yayinevi.Location = new System.Drawing.Point(1112, 294);
            this.txt_yayinevi.Name = "txt_yayinevi";
            this.txt_yayinevi.Size = new System.Drawing.Size(106, 20);
            this.txt_yayinevi.TabIndex = 21;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Nirmala UI", 9.75F);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button5.Location = new System.Drawing.Point(1008, 320);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(210, 30);
            this.button5.TabIndex = 20;
            this.button5.Text = "Güncelle";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(1030, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "isbn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label4.Location = new System.Drawing.Point(1005, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Kitap Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label5.Location = new System.Drawing.Point(1027, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Yazar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label6.Location = new System.Drawing.Point(1031, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tür";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label7.Location = new System.Drawing.Point(1030, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Raf";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label8.Location = new System.Drawing.Point(1003, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Yayın Evi";
            // 
            // txt_kitapid
            // 
            this.txt_kitapid.Enabled = false;
            this.txt_kitapid.Location = new System.Drawing.Point(1112, 109);
            this.txt_kitapid.Name = "txt_kitapid";
            this.txt_kitapid.Size = new System.Drawing.Size(106, 20);
            this.txt_kitapid.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label9.Location = new System.Drawing.Point(1015, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Kitap Id";
            // 
            // cmb_yazar
            // 
            this.cmb_yazar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_yazar.FormattingEnabled = true;
            this.cmb_yazar.Location = new System.Drawing.Point(1112, 187);
            this.cmb_yazar.Name = "cmb_yazar";
            this.cmb_yazar.Size = new System.Drawing.Size(106, 21);
            this.cmb_yazar.TabIndex = 22;
            // 
            // cmb_tur
            // 
            this.cmb_tur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tur.FormattingEnabled = true;
            this.cmb_tur.Location = new System.Drawing.Point(1112, 214);
            this.cmb_tur.Name = "cmb_tur";
            this.cmb_tur.Size = new System.Drawing.Size(106, 21);
            this.cmb_tur.TabIndex = 22;
            // 
            // cmb_raf
            // 
            this.cmb_raf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_raf.FormattingEnabled = true;
            this.cmb_raf.Location = new System.Drawing.Point(1112, 241);
            this.cmb_raf.Name = "cmb_raf";
            this.cmb_raf.Size = new System.Drawing.Size(106, 21);
            this.cmb_raf.TabIndex = 22;
            // 
            // txt_sayfasayisi
            // 
            this.txt_sayfasayisi.Location = new System.Drawing.Point(1112, 268);
            this.txt_sayfasayisi.Name = "txt_sayfasayisi";
            this.txt_sayfasayisi.Size = new System.Drawing.Size(106, 20);
            this.txt_sayfasayisi.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label10.Location = new System.Drawing.Point(1005, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Sayfa Sayısı";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.label11.Location = new System.Drawing.Point(615, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "İsbn Barkoduna Göre Listele";
            // 
            // KitapGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1230, 622);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmb_raf);
            this.Controls.Add(this.cmb_tur);
            this.Controls.Add(this.cmb_yazar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_sayfasayisi);
            this.Controls.Add(this.txt_yayinevi);
            this.Controls.Add(this.txt_kitapad);
            this.Controls.Add(this.txt_kitapid);
            this.Controls.Add(this.txt_isbn);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitapGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KitapGuncelle";
            this.Load += new System.EventHandler(this.KitapGuncelle_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.TextBox txt_kitapad;
        private System.Windows.Forms.TextBox txt_yayinevi;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_kitapid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_yazar;
        private System.Windows.Forms.ComboBox cmb_tur;
        private System.Windows.Forms.ComboBox cmb_raf;
        private System.Windows.Forms.TextBox txt_sayfasayisi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}