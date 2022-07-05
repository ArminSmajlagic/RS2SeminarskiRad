namespace winforms.trading.UserControls.Administration
{
    partial class OrderBookControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.valutaNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kreirana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTip = new System.Windows.Forms.ComboBox();
            this.tbKorisnik = new System.Windows.Forms.TextBox();
            this.tbValuta = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.dgvOrders, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1240, 697);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvOrders
            // 
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valutaNaziv,
            this.kolicina,
            this.cijena,
            this.userIme,
            this.kreirana,
            this.state,
            this.Column1});
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(189, 142);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 29;
            this.dgvOrders.Size = new System.Drawing.Size(862, 481);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // valutaNaziv
            // 
            this.valutaNaziv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valutaNaziv.DataPropertyName = "valutaNaziv";
            this.valutaNaziv.HeaderText = "Valuta";
            this.valutaNaziv.MinimumWidth = 6;
            this.valutaNaziv.Name = "valutaNaziv";
            // 
            // kolicina
            // 
            this.kolicina.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kolicina.DataPropertyName = "kolicina";
            this.kolicina.HeaderText = "Kolicina";
            this.kolicina.MinimumWidth = 6;
            this.kolicina.Name = "kolicina";
            // 
            // cijena
            // 
            this.cijena.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cijena.DataPropertyName = "cijena";
            this.cijena.HeaderText = "Cijena";
            this.cijena.MinimumWidth = 6;
            this.cijena.Name = "cijena";
            // 
            // userIme
            // 
            this.userIme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userIme.DataPropertyName = "userIme";
            this.userIme.HeaderText = "Korisnik";
            this.userIme.MinimumWidth = 6;
            this.userIme.Name = "userIme";
            // 
            // kreirana
            // 
            this.kreirana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kreirana.DataPropertyName = "kreirana";
            this.kreirana.HeaderText = "Vrijeme";
            this.kreirana.MinimumWidth = 6;
            this.kreirana.Name = "kreirana";
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "Stanje";
            this.state.MinimumWidth = 6;
            this.state.Name = "state";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column1.HeaderText = "Promjeni Stanje";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Text = "Odbij";
            this.Column1.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbTip);
            this.panel1.Controls.Add(this.tbKorisnik);
            this.panel1.Controls.Add(this.tbValuta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(189, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 133);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(641, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tip narudžbe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(339, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Naziv korisnika:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv valute:";
            // 
            // cbTip
            // 
            this.cbTip.FormattingEnabled = true;
            this.cbTip.Items.AddRange(new object[] {
            "Kupovina",
            "Prodaja"});
            this.cbTip.Location = new System.Drawing.Point(641, 92);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(200, 28);
            this.cbTip.TabIndex = 2;
            this.cbTip.SelectedIndexChanged += new System.EventHandler(this.cbTip_SelectedIndexChanged);
            // 
            // tbKorisnik
            // 
            this.tbKorisnik.Location = new System.Drawing.Point(339, 92);
            this.tbKorisnik.Name = "tbKorisnik";
            this.tbKorisnik.Size = new System.Drawing.Size(279, 27);
            this.tbKorisnik.TabIndex = 1;
            this.tbKorisnik.TextChanged += new System.EventHandler(this.korisnikChanged);
            // 
            // tbValuta
            // 
            this.tbValuta.Location = new System.Drawing.Point(30, 92);
            this.tbValuta.Name = "tbValuta";
            this.tbValuta.Size = new System.Drawing.Size(283, 27);
            this.tbValuta.TabIndex = 0;
            this.tbValuta.TextChanged += new System.EventHandler(this.valutaChanged);
            // 
            // OrderBookControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrderBookControl";
            this.Size = new System.Drawing.Size(1240, 697);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvOrders;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbTip;
        private TextBox tbKorisnik;
        private TextBox tbValuta;
        private DataGridViewTextBoxColumn valutaNaziv;
        private DataGridViewTextBoxColumn kolicina;
        private DataGridViewTextBoxColumn cijena;
        private DataGridViewTextBoxColumn userIme;
        private DataGridViewTextBoxColumn kreirana;
        private DataGridViewTextBoxColumn state;
        private DataGridViewButtonColumn Column1;
    }
}
