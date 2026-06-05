# 🏠 Real Estate Dapper Project

> **Elasoft Yazılım** bünyesinde gerçekleştirilen staj sürecinde geliştirilmiş, ASP.NET Core 8 tabanlı tam kapsamlı gayrimenkul yönetim sistemi.

![Banner](https://github.com/user-attachments/assets/2d6dc83e-862e-4ab9-a351-543ccffd7e8a)

---

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Mimari Yapı](#-mimari-yapı)
- [Özellikler](#-özellikler)
- [Teknoloji Stack'i](#-teknoloji-stacki)
- [API Endpoint'leri](#-api-endpointleri)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [Proje Yapısı](#-proje-yapısı)

---

## 🎯 Proje Hakkında

Bu proje, **Elasoft Yazılım** şirketinde gerçekleştirilen staj döneminde geliştirilmiş, kapsamlı bir gayrimenkul (emlak) yönetim platformudur. Proje; ilan yönetimi, kullanıcı kimlik doğrulama, estate agent paneli ve gerçek zamanlı istatistikler gibi temel emlak uygulaması bileşenlerini içermektedir.

Uygulama, **API** ve **UI** olmak üzere iki ayrı katmandan oluşmaktadır ve aralarında RESTful HTTP iletişimi sağlanmaktadır.

---

## 🏗️ Mimari Yapı

Proje, **N-Tier (Çok Katmanlı)** mimari prensiplerine uygun olarak tasarlanmıştır:

```
┌─────────────────────────────────────────────────────┐
│              RealEstate_Dapper_UI (MVC)              │
│         ASP.NET Core MVC • JWT Auth • Views          │
└───────────────────────┬─────────────────────────────┘
                        │ HTTP / REST
┌───────────────────────▼─────────────────────────────┐
│             RealEstate_Dapper_Api (API)               │
│      ASP.NET Core Web API • Swagger • SignalR        │
└───────────────────────┬─────────────────────────────┘
                        │ Dapper ORM
┌───────────────────────▼─────────────────────────────┐
│              Microsoft SQL Server (MSSQL)             │
└─────────────────────────────────────────────────────┘
```

### Katmanlar

| Katman | Proje | Açıklama |
|--------|-------|----------|
| **Sunum Katmanı** | `RealEstate_Dapper_UI` | ASP.NET Core MVC, Razor Views, JWT tabanlı oturum yönetimi |
| **API Katmanı** | `RealEstate_Dapper_Api` | RESTful Web API, Swagger dokümantasyonu, SignalR |
| **Veri Erişim Katmanı** | Repository Pattern | Dapper ORM ile SQL Server bağlantısı |

---

## ✨ Özellikler

### 🔐 Kimlik Doğrulama & Yetkilendirme
- JWT (JSON Web Token) tabanlı kullanıcı kimlik doğrulama
- Kullanıcı rollerine göre yetkilendirme (Admin, Estate Agent)
- Cookie tabanlı güvenli oturum yönetimi (HttpOnly, SameSite=Strict)
- Alan (Area) bazlı erişim kontrolü

### 🏘️ İlan (Ürün) Yönetimi
- Emlak ilanı oluşturma, düzenleme ve silme (CRUD)
- Kategori bazlı filtreleme
- Şehir ve anahtar kelime bazlı arama
- "Günün Fırsatı" özelliği (Deal of the Day) için durum değiştirme
- İlan aktif/pasif durumu yönetimi
- Son 5, son 3 ve en son ilan listeleme
- İlan detay sayfası (resimler, özellikler, olanaklar)

### 🗺️ Popüler Konumlar
- Popüler şehir/konum yönetimi
- Konum bazlı ilan listeleme

### 👨‍💼 Estate Agent Paneli (Broker Paneli)
- Özel `/EstateAgent` area ile izole panel
- Broker'a ait ilanların yönetimi (aktif/pasif)
- To-Do List (yapılacaklar listesi)
- Mesajlaşma sistemi
- Dashboard istatistikleri
- Grafikler (Chart)

### 📊 İstatistik & Raporlama
- Aktif/pasif kategori sayısı
- Toplam ilan sayısı
- Kiralık ve satılık ilan ortalama fiyatları
- Ortalama oda sayısı
- En fazla ilanı olan kategori
- En fazla ilanı olan şehir
- En fazla ilanı olan çalışan
- En eski/en yeni bina yılı
- Farklı şehir sayısı
- Gerçek zamanlı istatistik güncellemeleri (SignalR)

### 🖼️ İçerik Yönetimi (CMS)
- **About Us** bölümü yönetimi (AboutUs, Section, WhyUs)
- **Hizmetler** (Services) yönetimi
- **Referanslar** (Testimonial) yönetimi
- **Alt Izgara** (Bottom Grid) içerik yönetimi
- **Kim Biz** (Who We Are) bölümü
- **İletişim** (Contact Us) formu ve yönetimi

### ⚡ Gerçek Zamanlı Özellikler (SignalR)
- Dashboard'da canlı kategori sayısı güncellemesi
- İstatistiklerin anlık yenilenmesi

---

## 🛠️ Teknoloji Stack'i

### Backend (API)
| Teknoloji | Sürüm | Kullanım Amacı |
|-----------|-------|----------------|
| ASP.NET Core | 8.0 | Web API framework |
| **Dapper** | 2.1.35 | Micro-ORM, SQL sorguları |
| Microsoft.Data.SqlClient | 5.2.1 | SQL Server bağlantısı |
| Swashbuckle (Swagger) | 6.4.0 | API dokümantasyonu |
| SignalR | Built-in | Gerçek zamanlı iletişim |

### Frontend (UI)
| Teknoloji | Sürüm | Kullanım Amacı |
|-----------|-------|----------------|
| ASP.NET Core MVC | 8.0 | Web UI framework |
| Microsoft.AspNetCore.Authentication.JwtBearer | 7.0.3 | JWT doğrulama |
| System.IdentityModel.Tokens.Jwt | 6.35.0 | JWT token işlemleri |
| Razor Views | - | Sunucu taraflı HTML render |
| HttpClient | - | API iletişimi |

### Veritabanı
- **Microsoft SQL Server** — İlişkisel veritabanı
- **Dapper** — Hafif ve hızlı ORM (Entity Framework yerine tercih edildi)

### Tasarım Desenleri
- **Repository Pattern** — Veri erişim soyutlaması
- **Interface Segregation** — Her repository için ayrı interface
- **Dependency Injection** — Tüm servisler IoC container'a kayıtlı
- **Area Pattern** — Estate Agent modülü için MVC Area yapısı
- **DTO (Data Transfer Object)** — API katmanında veri transferi

---

## 🔌 API Endpoint'leri

### Ürünler (İlanlar)
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| `GET` | `/api/Products` | Tüm ilanları listele |
| `GET` | `/api/Products/{id}` | ID'ye göre ilan getir |
| `GET` | `/api/Products/ProductListWithCategory` | Kategori bilgisiyle ilanlar |
| `GET` | `/api/Products/ResultProductWithSearchList` | Arama filtresi |
| `GET` | `/api/Products/Last5Product` | Son 5 ilan |
| `GET` | `/api/Products/GetLastProduct` | En son ilan |
| `GET` | `/api/Products/GetProductByDealOfTheDayTrueCategoryAsync` | Günün fırsatları |
| `GET` | `/api/Products/ResultLast3ProductWithCategory` | Son 3 ilan |
| `GET` | `/api/Products/ProductStatusChangeToTrue/{id}` | İlanı aktifleştir |
| `GET` | `/api/Products/ProductStatusAsPassive/{id}` | İlanı pasifleştir |
| `GET` | `/api/Products/ProductDealOfTheDayChangeToTrue/{id}` | Günün fırsatına ekle |
| `GET` | `/api/Products/ProductDealOfTheDayChangeToFalse/{id}` | Günün fırsatından çıkar |
| `POST` | `/api/Products` | Yeni ilan oluştur |
| `PUT` | `/api/Products` | İlan güncelle |
| `DELETE` | `/api/Products/{id}` | İlan sil |

### İstatistikler
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| `GET` | `/api/StatisticsApi` | Aktif kategori sayısı |
| `GET` | `/api/StatisticsApi/ProductCount` | Toplam ilan sayısı |
| `GET` | `/api/StatisticsApi/RentProductAvgPrice` | Kiralık ort. fiyat |
| `GET` | `/api/StatisticsApi/SaleProductAvgPrice` | Satılık ort. fiyat |
| `GET` | `/api/StatisticsApi/CategoryNameByMaxProduct` | En çok ilanı olan kategori |
| `GET` | `/api/StatisticsApi/CityNameByMaxProduct` | En çok ilanı olan şehir |
| `GET` | `/api/StatisticsApi/EmployeeNameByMaxProduct` | En çok ilanı olan çalışan |
| `GET` | `/api/StatisticsApi/DifferentCityCount` | Farklı şehir sayısı |
| `GET` | `/api/StatisticsApi/OldestBuildingYear` | En eski bina yılı |
| `GET` | `/api/StatisticsApi/NewestBuildingYear` | En yeni bina yılı |

### Kimlik Doğrulama
| Method | Endpoint | Açıklama |
|--------|----------|----------|
| `POST` | `/api/LoginApi` | Giriş yap, JWT token al |

### SignalR Hub
| Hub | Endpoint | Açıklama |
|-----|----------|----------|
| `SignalRHub` | `/signalrhub` | Gerçek zamanlı iletişim |
| `SendCategoryCount` | — | Canlı kategori sayısı yayını |

> 📖 Tüm API endpoint'lerini keşfetmek için Swagger UI'ı kullanabilirsiniz: `https://localhost:{port}/swagger`

---

## 🚀 Kurulum

### Gereksinimler
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Microsoft SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads) (LocalDB veya Express yeterlidir)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya VS Code

### Adım 1: Repository'i Klonlayın
```bash
git clone <repository-url>
cd Real_Estate_Project
```

### Adım 2: Veritabanı Bağlantısını Ayarlayın

`RealEstate_Dapper_Api/appsettings.json` dosyasını düzenleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=RealEstateDb;Trusted_Connection=True;"
  }
}
```

### Adım 3: API Adresini UI'ya Tanıtın

`RealEstate_Dapper_UI/appsettings.json` dosyasını düzenleyin:
```json
{
  "ApiSettingsKey": {
    "BaseUrl": "https://localhost:44382/"
  }
}
```

### Adım 4: Projeyi Çalıştırın

**Önce API'yi başlatın:**
```bash
cd RealEstate_Dapper_Api
dotnet run
```

**Ardından UI'ı başlatın:**
```bash
cd RealEstate_Dapper_UI
dotnet run
```

> ⚠️ Her iki projenin de **aynı anda** çalışması gerekmektedir. API olmadan UI çalışmaz.

### Visual Studio ile Çalıştırma
1. `RealEstate_Dapper_Api.sln` dosyasını açın
2. Solution Explorer'da her iki projeye sağ tıklayın
3. **"Set as Startup Projects"** → Multiple startup projects seçin
4. Her iki projeyi **Start** olarak ayarlayın
5. **F5** ile çalıştırın

---

## 📖 Kullanım

### Admin Girişi
- UI uygulamasına gidin: `https://localhost:{ui-port}/Login`
- Kullanıcı adı ve şifrenizle giriş yapın
- JWT token otomatik olarak Cookie'ye kaydedilir

### Estate Agent Paneli
- Giriş yaptıktan sonra `/EstateAgent` alanına erişin
- Kendi ilanlarınızı yönetin (aktif/pasif)
- To-Do list ve mesajlarınızı görüntüleyin
- Dashboard'da istatistiklerinizi takip edin

### Swagger UI (API Dokümantasyonu)
- API çalışırken: `https://localhost:{api-port}/swagger`
- Tüm endpoint'leri interaktif olarak test edebilirsiniz

---

## 📁 Proje Yapısı

```
Real_Estate_Project/
│
├── RealEstate_Dapper_Api/          # Web API Katmanı
│   ├── Containers/                  # Dependency Injection tanımları
│   │   └── Extensions.cs            # Servis kayıtları
│   ├── Controllers/                 # API Controller'lar (27 adet)
│   │   ├── ProductsController.cs
│   │   ├── StatisticsApiController.cs
│   │   ├── LoginApiController.cs
│   │   ├── CategoriesController.cs
│   │   └── ...
│   ├── Dtos/                        # Data Transfer Object'ler
│   ├── Hubs/                        # SignalR Hub'ları
│   │   └── SignalRHub.cs
│   ├── Models/
│   │   └── DapperContext/           # Dapper veritabanı bağlantı contexti
│   ├── Repositories/                # Repository Pattern implementasyonları (22 adet)
│   │   ├── ProductRepository/
│   │   ├── CategoryRepository/
│   │   ├── EstateAgentRepositories/
│   │   │   └── DashBoardRepositories/
│   │   └── ...
│   ├── Tools/                       # JWT Token üretici ve yardımcı araçlar
│   └── Program.cs
│
├── RealEstate_Dapper_UI/           # MVC UI Katmanı
│   ├── Areas/                       # MVC Area'ları
│   │   ├── EstateAgent/             # Estate Agent (Broker) Paneli
│   │   ├── ContactUs/               # İletişim Formu Area
│   │   └── AboutUs/                 # Hakkımızda Area
│   ├── Controllers/                 # UI Controller'lar (16 adet)
│   │   ├── ProductController.cs
│   │   ├── PropertyController.cs
│   │   ├── LoginController.cs
│   │   ├── StatisticsUiController.cs
│   │   └── ...
│   ├── Dtos/                        # UI katmanı DTO'ları
│   ├── Models/                      # View Model'ler
│   ├── Services/                    # Servis katmanı
│   │   ├── ILoginService.cs
│   │   └── LoginService.cs
│   ├── ViewComponents/              # Yeniden kullanılabilir View bileşenleri
│   ├── Views/                       # Razor View dosyaları (17 klasör)
│   │   ├── Property/
│   │   ├── Product/
│   │   ├── DashBoard/
│   │   └── ...
│   └── Program.cs
│
└── RealEstate_Dapper_Api.sln       # Visual Studio Solution dosyası
```

---

## 🎓 Staj Bilgileri

Bu proje, **Elasoft Yazılım** şirketinde gerçekleştirilen yazılım geliştirme stajı kapsamında hazırlanmıştır.

| Bilgi | Detay |
|-------|-------|
| **Şirket** | Elasoft Yazılım |
| **Proje Türü** | Staj Projesi |
| **Geliştirme Süreci** | Staj dönemi boyunca aktif geliştirildi |

### Stajda Kazanılan Deneyimler
- ✅ ASP.NET Core 8 Web API geliştirme
- ✅ Dapper ORM ile veritabanı yönetimi (Entity Framework'e alternatif)
- ✅ Repository Pattern ve Dependency Injection
- ✅ JWT tabanlı kimlik doğrulama ve yetkilendirme
- ✅ MVC Area yapısı ile modüler uygulama tasarımı
- ✅ SignalR ile gerçek zamanlı web uygulaması geliştirme
- ✅ RESTful API tasarım prensipleri
- ✅ Çok katmanlı (N-Tier) mimari uygulaması
- ✅ Swagger ile API dokümantasyonu

---

## 📄 Lisans

Bu proje **Elasoft Yazılım** staj programı kapsamında eğitim amaçlı geliştirilmiştir.

---

<div align="center">
  <sub>🏢 Elasoft Yazılım Staj Projesi | ASP.NET Core 8 & Dapper</sub>
</div>
