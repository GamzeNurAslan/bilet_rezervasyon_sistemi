![Bilet_rezervasyon_sistemi](https://github.com/GamzeNurAslan/bilet_rezervasyon_sistemi/blob/main/video/Form1-2025-06-12-18-10-29.gif)

# 🚌 GiBilet - Otobüs Bilet Rezervasyon Sistemi

**GiBilet**, Windows Forms (C#) kullanılarak geliştirilen basit bir otobüs bileti rezervasyon sistemidir.  
Kullanıcılar, şehir içi veya şehirlerarası seferler için bilet oluşturabilir, koltuk seçebilir ve rezervasyonlarını yönetebilir.

---

## 🌼 Özellikler

- 🔄 Şehir içi / şehir dışı sefer ayrımı  
- 📅 Sefer oluşturma (nereden, nereye, tarih)  
- 🧍 Yolcu bilgisi girme (ad, soyad)  
- 💺 Koltuk seçimi ve dolu/boş kontrolü  
- 🧾 Bilet bilgilerini ekranda (`ListBox2`) gösterme  
- ❗ Uyarı mesajları ile kullanıcı yönlendirmesi (MessageBox)

---

## 🛠️ Kullanılan Teknolojiler

- `C# (.NET Framework)`
- `Windows Forms`
- OOP (Nesne Tabanlı Programlama)

---

## 🧠 OOP Kavramları

- **Kalıtım:**  
  `Sefer` sınıfı, `Sehirici` ve `Sehirlerarasi` sınıfları tarafından miras alınır.

- **Kompozisyon:**  
  Her `Sefer`, bir `Otobus` nesnesi içerir. `Otobus`, `Koltuk[]` yapısıyla koltukları tutar.

- **Arayüz (Interface):**  
  `IRezervasyon` arayüzü, tüm sefer sınıflarının `RezervasyonYap()` ve `KoltukDurumlariniGoster()` gibi işlemleri gerçekleştirmesini garanti eder.
