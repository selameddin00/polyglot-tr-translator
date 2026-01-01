namespace DilCeviriAsistani;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.cmbDiller = new System.Windows.Forms.ComboBox();
        this.txtKaynak = new System.Windows.Forms.RichTextBox();
        this.txtHedef = new System.Windows.Forms.RichTextBox();
        this.btnCevir = new System.Windows.Forms.Button();
        this.lblTdkBilgi = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        this.cmbDiller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbDiller.Location = new System.Drawing.Point(12, 12);
        this.cmbDiller.Name = "cmbDiller";
        this.cmbDiller.Size = new System.Drawing.Size(776, 28);
        this.cmbDiller.TabIndex = 0;
        this.cmbDiller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        
        this.txtKaynak.Location = new System.Drawing.Point(12, 50);
        this.txtKaynak.Name = "txtKaynak";
        this.txtKaynak.Size = new System.Drawing.Size(386, 340);
        this.txtKaynak.TabIndex = 1;
        this.txtKaynak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
        
        this.txtHedef.Location = new System.Drawing.Point(404, 50);
        this.txtHedef.Name = "txtHedef";
        this.txtHedef.ReadOnly = true;
        this.txtHedef.Size = new System.Drawing.Size(384, 340);
        this.txtHedef.TabIndex = 2;
        this.txtHedef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        
        this.btnCevir.Location = new System.Drawing.Point(12, 396);
        this.btnCevir.Name = "btnCevir";
        this.btnCevir.Size = new System.Drawing.Size(776, 35);
        this.btnCevir.TabIndex = 3;
        this.btnCevir.Text = "Çevir";
        this.btnCevir.UseVisualStyleBackColor = true;
        this.btnCevir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        
        this.lblTdkBilgi.AutoSize = false;
        this.lblTdkBilgi.ForeColor = System.Drawing.Color.Gray;
        this.lblTdkBilgi.Location = new System.Drawing.Point(12, 437);
        this.lblTdkBilgi.Name = "lblTdkBilgi";
        this.lblTdkBilgi.Size = new System.Drawing.Size(776, 20);
        this.lblTdkBilgi.TabIndex = 4;
        this.lblTdkBilgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
        
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 470);
        this.Controls.Add(this.lblTdkBilgi);
        this.Controls.Add(this.btnCevir);
        this.Controls.Add(this.txtHedef);
        this.Controls.Add(this.txtKaynak);
        this.Controls.Add(this.cmbDiller);
        this.MinimumSize = new System.Drawing.Size(600, 400);
        this.Name = "Form1";
        this.Text = "Dil Ceviri Asistani";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.Resize += new System.EventHandler(this.Form1_Resize);
        this.btnCevir.Click += new System.EventHandler(this.btnCevir_Click);
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.ComboBox cmbDiller;
    private System.Windows.Forms.RichTextBox txtKaynak;
    private System.Windows.Forms.RichTextBox txtHedef;
    private System.Windows.Forms.Button btnCevir;
    private System.Windows.Forms.Label lblTdkBilgi;
}
