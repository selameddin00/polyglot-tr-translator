using GTranslate.Translators;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DilCeviriAsistani;

public partial class Form1 : Form
{
    private readonly AggregateTranslator _translator;
    private static readonly HttpClient _httpClient = new HttpClient();
    private Button? btnTemizle;

    public Form1()
    {
        InitializeComponent();
        ApplyModernStyles();
        _translator = new AggregateTranslator();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        cmbDiller.Items.AddRange(new string[]
        {
            "Ingilizce",
            "Almanca",
            "Fransizca",
            "Rusca",
            "Italyanca",
            "Ispanyolca",
            "Cince"
        });
        cmbDiller.SelectedIndex = 0;
        
        OlusturTemizleButonu();
        RichTextBoxGenislikleriniAyarla();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        RichTextBoxGenislikleriniAyarla();
    }

    private void RichTextBoxGenislikleriniAyarla()
    {
        int formGenislik = this.ClientSize.Width;
        int margin = 12;
        int ortaBosluk = 6;
        int kullanilabilirGenislik = formGenislik - (margin * 2) - ortaBosluk;
        int herBirGenislik = kullanilabilirGenislik / 2;
        
        int cmbDillerAlt = cmbDiller.Bottom + 8;
        int lblTdkBilgiUst = lblTdkBilgi.Top - 8;
        int btnCevirYukseklik = btnCevir.Height;
        int btnCevirUst = lblTdkBilgiUst - btnCevirYukseklik - 8;
        int kullanilabilirYukseklik = btnCevirUst - cmbDillerAlt;
        
        txtKaynak.Width = herBirGenislik;
        txtKaynak.Height = kullanilabilirYukseklik;
        txtKaynak.Top = cmbDillerAlt;
        
        txtHedef.Width = herBirGenislik;
        txtHedef.Height = kullanilabilirYukseklik;
        txtHedef.Left = txtKaynak.Right + ortaBosluk;
        txtHedef.Top = cmbDillerAlt;
        
        btnCevir.Top = btnCevirUst;
        
        if (btnTemizle != null)
        {
            int butonAraligi = 8;
            int btnTemizleGenislik = 120;
            btnTemizle.Left = btnCevir.Left;
            btnTemizle.Top = btnCevir.Bottom + butonAraligi;
            btnTemizle.Width = btnTemizleGenislik;
            btnTemizle.Height = btnCevirYukseklik;
        }
    }

    private async void btnCevir_Click(object sender, EventArgs e)
    {
        Cursor.Current = Cursors.WaitCursor;
        btnCevir.Enabled = false;
        btnCevir.Text = "Cevriliyor...";
        
        try
        {
            string metin = txtKaynak.Text?.Trim() ?? string.Empty;
            
            if (!string.IsNullOrWhiteSpace(metin))
            {
                if (cmbDiller.SelectedItem != null)
                {
                    string seciliDil = cmbDiller.SelectedItem.ToString() ?? string.Empty;
                    string hedefDil = seciliDil switch
                    {
                        "Ingilizce" => "en",
                        "Almanca" => "de",
                        "Fransizca" => "fr",
                        "Rusca" => "ru",
                        "Italyanca" => "it",
                        "Ispanyolca" => "es",
                        "Cince" => "zh-CN",
                        _ => "en"
                    };

                    var sonuc = await _translator.TranslateAsync(metin, hedefDil, "tr");
                    txtHedef.Text = sonuc.Translation;

                    // Tek kelime kontrolu - TDK API sadece tek kelime icin calisir
                    if (!txtKaynak.Text.Trim().Contains(" "))
                    {
                        await GetTdkDetails(txtKaynak.Text.Trim());
                    }
                    else
                    {
                        if (InvokeRequired)
                        {
                            BeginInvoke(new Action(() => lblTdkBilgi.Text = ""));
                        }
                        else
                        {
                            lblTdkBilgi.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lutfen bir dil secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ceviri basarisiz: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor.Current = Cursors.Default;
            btnCevir.Enabled = true;
            btnCevir.Text = "Cevir";
        }
    }

    private async Task GetTdkDetails(string kelime)
    {
        try
        {
            // UI guncellemesi - ana thread uzerinde
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => lblTdkBilgi.Text = "Kelime kokeni ve anlami araniyor..."));
            }
            else
            {
                lblTdkBilgi.Text = "Kelime kokeni ve anlami araniyor...";
            }

            // HTTP istegi
            string url = $"https://sozluk.gov.tr/gts?ara={kelime}";
            string response = await _httpClient.GetStringAsync(url);

            // Response kontrolu
            if (string.IsNullOrWhiteSpace(response))
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => lblTdkBilgi.Text = "TDK'da kayit bulunamadi."));
                }
                else
                {
                    lblTdkBilgi.Text = "TDK'da kayit bulunamadi.";
                }
                return;
            }

            // JSON parsing
            JArray jArray = JArray.Parse(response);

            // JSON kontrolu
            if (jArray == null || jArray.Count == 0)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new Action(() => lblTdkBilgi.Text = "TDK'da kayit bulunamadi."));
                }
                else
                {
                    lblTdkBilgi.Text = "TDK'da kayit bulunamadi.";
                }
                return;
            }

            // Ilk elemani al
            var firstItem = jArray[0];

            // Koken (lisan) okuma
            string koken = "Koken belirtilmemis";
            if (firstItem["lisan"] != null && !string.IsNullOrWhiteSpace(firstItem["lisan"].ToString()))
            {
                koken = firstItem["lisan"].ToString();
            }

            // Anlam okuma
            string anlam = "Anlam bulunamadi";
            if (firstItem["anlamlarListe"] != null && firstItem["anlamlarListe"] is JArray anlamlarListe && anlamlarListe.Count > 0)
            {
                var ilkAnlam = anlamlarListe[0];
                if (ilkAnlam["anlam"] != null && !string.IsNullOrWhiteSpace(ilkAnlam["anlam"].ToString()))
                {
                    anlam = ilkAnlam["anlam"].ToString();
                }
            }

            // Label formatlama
            string sonuc = $"Koken: {koken} | Anlam: {anlam}";

            // UI guncellemesi - ana thread uzerinde
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => lblTdkBilgi.Text = sonuc));
            }
            else
            {
                lblTdkBilgi.Text = sonuc;
            }
        }
        catch (Exception)
        {
            // Hata durumunda sadece label guncelle
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => lblTdkBilgi.Text = "Sozluk baglanti hatasi."));
            }
            else
            {
                lblTdkBilgi.Text = "Sozluk baglanti hatasi.";
            }
        }
    }

    private void ApplyModernStyles()
    {
        // Form ayarlari
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.WhiteSmoke;
        this.Text = "PolyGlot Ceviri Asistani";

        // btnCevir butonu stilleri
        btnCevir.FlatStyle = FlatStyle.Flat;
        btnCevir.FlatAppearance.BorderSize = 0;
        btnCevir.BackColor = Color.DodgerBlue;
        btnCevir.ForeColor = Color.White;
        btnCevir.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        // RichTextBox ve ComboBox font ayarlari
        Font segoeFont = new Font("Segoe UI", 10);
        txtKaynak.Font = segoeFont;
        txtHedef.Font = segoeFont;
        cmbDiller.Font = segoeFont;
    }

    private void OlusturTemizleButonu()
    {
        if (btnTemizle == null)
        {
            btnTemizle = new Button();
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Text = "Temizle";
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.FlatAppearance.BorderSize = 0;
            btnTemizle.BackColor = Color.LightGray;
            btnTemizle.ForeColor = Color.Black;
            btnTemizle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            btnTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTemizle.Click += btnTemizle_Click;
            this.Controls.Add(btnTemizle);
        }
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        txtKaynak.Clear();
        txtHedef.Clear();
        lblTdkBilgi.Text = string.Empty;
    }
}
