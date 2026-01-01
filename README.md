# 🚀 PolyGlot Çeviri Asistanı

<div align="center">

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Modern, hızlı ve kullanıcı dostu çoklu dil çeviri uygulaması**

[Özellikler](#-özellikler) • [Kurulum](#️-kurulum-ve-kullanım) • [Ekran Görüntüleri](#-ekran-görüntüleri) • [Geliştirme](#-geliştirme)

</div>

---

## 📖 Hakkında

**PolyGlot Çeviri Asistanı**, Türkçe metinleri 7 farklı dile çeviren ve tek kelime girişlerinde TDK Sözlük API'si üzerinden kelime kökeni ve anlam bilgisi sağlayan modern bir Windows Forms uygulamasıdır.

Uygulama, asenkron çeviri işlemleri sayesinde donmayan bir arayüz sunar ve kullanıcılarına profesyonel bir deneyim yaşatır.

### 🎯 Temel Özellikler

- ✅ **7 Dil Desteği:** İngilizce, Almanca, Fransızca, Rusça, İtalyanca, İspanyolca, Çince
- ✅ **TDK Sözlük Entegrasyonu:** Tek kelime girişlerinde otomatik köken ve anlam bilgisi
- ✅ **Asenkron İşlemler:** UI donmadan hızlı çeviri
- ✅ **Modern Arayüz:** Flat tasarım ve profesyonel görünüm
- ✅ **Responsive Tasarım:** Form boyutuna göre dinamik yerleşim

---

## 🛠 Teknolojiler

### Framework & Platform
- **.NET 8.0** - Modern C# framework
- **Windows Forms** - Native Windows uygulaması
- **C# 12** - En son C# özellikleri

### NuGet Paketleri
- **GTranslate** (v2.3.1) - Çoklu çeviri servisi desteği
- **Newtonsoft.Json** (v13.0.4) - JSON veri işleme

### API Entegrasyonları
- **GTranslate API** - Çeviri işlemleri
- **TDK Sözlük API** - Kelime kökeni ve anlam bilgisi

---

## ✨ Özellikler

### 🔄 Asenkron (Donmayan) Arayüz
- `async/await` yapısı ile UI thread bloklanmıyor
- Çeviri işlemi sırasında "Çevriliyor..." geri bildirimi
- Bekleme imleci ile görsel geri bildirim

### 🌍 7 Dil Desteği (Switch Expression)
Modern C# `switch expression` yapısı ile dil kodlarına dönüşüm:

```csharp
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
```

### 📚 Akıllı TDK Entegrasyonu
- **Sadece tek kelimede çalışır** - Cümle girişlerinde API çağrılmaz
- Otomatik köken (lisan) bilgisi
- İlk anlam gösterimi
- Hata durumlarında kullanıcı dostu mesajlar

### 🎨 Modern & Flat UI Tasarımı
- **Segoe UI** font ailesi ile modern tipografi
- Flat buton tasarımı (kenarlık yok)
- DodgerBlue ana buton rengi
- WhiteSmoke arka plan
- Merkezi form konumlandırma

### 🧹 Hızlı Temizleme
- Tek tıkla tüm alanları temizleme
- Kaynak metin, hedef metin ve TDK bilgisi temizlenir

---

## 📸 Ekran Görüntüleri

![Uygulama Görüntüsü](EkranGoruntusu.png)

> 💡 **Not:** Ekran görüntüsü eklemek için proje kök dizinine `EkranGoruntusu.png` dosyasını yerleştirin.

---

## ⚙️ Kurulum ve Kullanım

### Gereksinimler
- **Visual Studio 2022** (veya üzeri)
- **.NET 8.0 SDK**
- **Windows 10/11** (Windows Forms gereksinimi)

### Kurulum Adımları

1. **Repoyu klonlayın:**
```bash
git clone https://github.com/kullaniciadi/translatorAPP.git
cd translatorAPP
```

2. **Visual Studio ile açın:**
   - `DilCeviriAsistani.sln` dosyasını Visual Studio 2022 ile açın

3. **NuGet paketlerini restore edin:**
   - Visual Studio otomatik olarak restore edecektir
   - Manuel restore için: `Tools` → `NuGet Package Manager` → `Restore NuGet Packages`

4. **Projeyi çalıştırın:**
   - `F5` tuşuna basın veya `Debug` → `Start Debugging`

### Kullanım

1. **Metin girin:** Sol taraftaki metin kutusuna Türkçe metin yazın
2. **Dil seçin:** Üst kısımdaki dropdown'dan hedef dili seçin
3. **Çevir:** "Çevir" butonuna tıklayın
4. **Sonuç:** Sağ tarafta çeviri görüntülenecektir
5. **TDK Bilgisi:** Tek kelime girişlerinde otomatik olarak köken ve anlam bilgisi gösterilir
6. **Temizle:** "Temizle" butonu ile tüm alanları temizleyebilirsiniz

---

## 🏗️ Proje Yapısı

```
translatorAPP/
├── DilCeviriAsistani/
│   ├── Form1.cs              # Ana form mantık kodu
│   ├── Form1.Designer.cs    # Form tasarım kodu
│   ├── Program.cs            # Uygulama giriş noktası
│   └── DilCeviriAsistani.csproj
├── DilCeviriAsistani.sln
├── README.md
└── GELISTIRME_SURECI.md
```

---

## 🔧 Teknik Detaylar

### Async/Await Yapısı
Tüm API çağrıları asenkron olarak yapılır, UI thread bloklanmaz:

```csharp
private async void btnCevir_Click(object sender, EventArgs e)
{
    // UI güncellemeleri
    Cursor.Current = Cursors.WaitCursor;
    btnCevir.Enabled = false;
    
    try
    {
        var sonuc = await _translator.TranslateAsync(metin, hedefDil, "tr");
        txtHedef.Text = sonuc.Translation;
    }
    finally
    {
        // Garantili temizlik
        Cursor.Current = Cursors.Default;
        btnCevir.Enabled = true;
    }
}
```

### TDK API Entegrasyonu
Tek kelime kontrolü ile akıllı API çağrısı:

```csharp
// Tek kelime kontrolu - TDK API sadece tek kelime icin calisir
if (!txtKaynak.Text.Trim().Contains(" "))
{
    await GetTdkDetails(txtKaynak.Text.Trim());
}
```

### UI Thread Yönetimi
Cross-thread güvenliği için `InvokeRequired` kontrolü:

```csharp
if (InvokeRequired)
{
    BeginInvoke(new Action(() => lblTdkBilgi.Text = sonuc));
}
else
{
    lblTdkBilgi.Text = sonuc;
}
```

---

## 📊 Geliştirme Süreci

Projenin tüm geliştirme aşamaları için detaylı rapor:

📄 **[GELISTIRME_SURECI.md](GELISTIRME_SURECI.md)**

### Sprint Özeti
- **Sprint 1:** Temel altyapı ve UI tasarımı
- **Sprint 2:** GTranslate entegrasyonu ve çeviri işlevi
- **Sprint 3:** TDK API entegrasyonu
- **Final:** UI/UX iyileştirmeleri

---

## 🐛 Bilinen Sorunlar

Şu anda bilinen bir sorun bulunmamaktadır.

---

## 🚧 Gelecek Özellikler

- [ ] Daha fazla dil desteği
- [ ] Çeviri geçmişi
- [ ] Favori çeviriler
- [ ] Karanlık tema desteği
- [ ] Sesli çeviri

---

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

---

## 👨‍💻 Geliştirici

**Geliştirici**

---

## 🙏 Teşekkürler

- **GTranslate** - Çeviri servisi desteği için
- **TDK** - Sözlük API'si için
- **.NET Community** - Harika framework için

---

<div align="center">

**⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!**

Made with ❤️ using C# and .NET 8.0

</div>

