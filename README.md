# MyG PC Timer Control

<p align="center">
  <strong>Windows çalışma saatlerini izleyen arka plan uygulaması</strong><br>
  Çalışma zaman aralıklarını kontrol eder, gerektiğinde ekran kaplama uyarısı ve bitiş geri sayımı gösterir.
</p>

<p align="center">
  <img alt=".NET" src="https://img.shields.io/badge/.NET-8.0%20Windows-512BD4?logo=dotnet&logoColor=white">
  <img alt="UI" src="https://img.shields.io/badge/UI-WPF-0078D4?logo=windows&logoColor=white">
  <img alt="Platform" src="https://img.shields.io/badge/platform-Windows-blue?logo=windows&logoColor=white">
</p>

---

## Genel Bakış

MyG PC Timer Control, Windows üzerinde arka planda çalışan bir çalışma saati takip aracıdır. Kaynak kodda sistem tepsisi simgesi, uzaktan alınan JSON çalışma saatleri, ek süre desteği, çalışma saati dışında gösterilen overlay penceresi ve süre bitimine yakın geri sayım ekranı bulunur. Ayrıca GitHub deposundaki ZIP paketlerini kontrol eden bir güncelleme akışı tanımlıdır.

## Özellikler

- ⏰ Belirlenen saat aralıklarını saniyelik kontrol etme
- 🕒 Süre bitimine yakın geri sayım penceresi
- 🪟 Çalışma aralığı dışında ekran kaplama penceresi
- 🧩 Sistem tepsisinden uygulamaya erişim ve çıkış
- ☁️ JSON uç noktasından çalışma saatlerini ve ek süre ayarlarını yükleme
- 🔄 GitHub deposundaki paketler üzerinden güncelleme kontrolü

## Teknolojiler

- C# / .NET 8 for Windows
- WPF ve Windows Forms sistem tepsisi bileşenleri
- HttpClient ve System.Text.Json
- ZIP dosyalarıyla güncelleme akışı

## Derleme

1. Windows üzerinde .NET 8 SDK kurun.
2. Visual Studio ile MyGPcTimerControl.sln dosyasını açın.
3. NuGet geri yüklemesini yapıp x64/uygun Windows hedefinde derleyin.
4. Çalışma saatleri JSON verisini ve güncelleme kaynağını kendi kullanımınıza göre yapılandırın.

Komut satırı:

- dotnet restore .\\MyGPcTimerControl.sln
- dotnet build .\\MyGPcTimerControl.sln -c Release

## Yapılandırma ve Güvenlik

- Çalışma saatleri için kullanılan JSON adresi uygulama kodunda tanımlıdır. Kendi uç noktanızı kullanacaksanız yapılandırmayı kaynak koddan ayırın.
- Güncelleme indirmeden önce sürüm ve dosya kaynağını güvenilir şekilde doğrulayın; ZIP dosyalarını doğrulamadan çalıştırmayın.
- Çalışma saati dışındaki overlay davranışının kullanıcı ihtiyaçlarına uygun olduğunu test edin.
- Uygulama güncelleme akışını ve başarısız ağ bağlantısı senaryolarını test edin.

## Durum

Bu README mevcut kaynak kodun davranışını özetler; güncelleme kaynağının güvenliği ve farklı Windows sürümlerindeki davranış ayrıca doğrulanmalıdır.
