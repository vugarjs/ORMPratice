# ORMPratice - Universitet İdarəetmə Sistemi

Entity Framework Core (.NET 10) istifadə edərək hazırlanmış Universitet
İdarəetmə Sistemi (Console Application). Proqram tələbələrin və
qrupların idarə edilməsi, One-to-Many əlaqələri və tam CRUD
əməliyyatlarını təmin edir.

------------------------------------------------------------------------

## 🚀 Əsas Xüsusiyyətlər və Həllər

-   **UTF-8 Dəstəyi:** Konsol interfeysində Azərbaycan şriftlərinin
    (`ə`, `ö`, `ğ`, `ş`, `ç`, `ı`) problemsiz göstərilməsi üçün
    `Console.OutputEncoding = System.Text.Encoding.UTF8;` istifadə
    edilib.
-   **Eager Loading (Tənbəl yükləmənin qarşısının alınması):**
    Tələbələrin aid olduğu qrup adlarının boş (`null`) gəlməməsi üçün
    LINQ sorğularında `.Include(s => s.Group)` istifadə olunub.
-   **Data Bütövlüyü (Check Constraint):** EF Core 7+ standartlarına
    uyğun olaraq qrup limiti üçün konfiqurasiya
    `builder.ToTable(t => t.HasCheckConstraint("CK_Group_Limit", "[Limit] > 0"));`
    şəklində yazılıb.
-   **Avtomatik Baza Qurulumu:** Proqram işə düşdükdə
    `context.Database.Migrate()` işləyir və miqrasiyaları avtomatik
    tətbiq edərək SQL Server-də verilənlər bazasını yaradır.

------------------------------------------------------------------------

## 🛠 Tələblər

-   **Microsoft Visual Studio IDE** (Tam versiya)
-   **.NET 10 SDK**
-   **C# 14**
-   **SQL Server**

------------------------------------------------------------------------

## ⚙️ Quraşdırma və İşə Salma

### 1. Layihəni Açın

Qovluqdakı `ORMPratice.sln` faylını **Microsoft Visual Studio**
vasitəsilə açın.

### 2. Bağlantı Ayarları (Connection String)

`Contexts/UniversityDb.cs` faylına daxil olub server adınızı təyin edin:

``` csharp
var connectionString = "Data Source=YOUR_SERVER_NAME;Database=University;Integrated Security=True;TrustServerCertificate=True;";
```

### 3. Miqrasiya Yaratmaq (Package Manager Console)

Visual Studio-da **Package Manager Console** pəncərəsində bu əmri icra
edin:

``` powershell
Add-Migration InitialCreate
```

### 4. Proqramı Başlatmaq

Klaviaturada **F5** (Start Debugging) düyməsini sıxaraq proqramı işə
salın. Proqram avtomatik olaraq `University` bazasını yaradacaq.

------------------------------------------------------------------------

## 📊 Verilənlər Bazası Arxitekturası

### Group (Qruplar)

  **Sahə**   **Tip**    **Təsvir**
  ---------- ---------- ---------------------------------------
  `Id`       `int`      Primary Key
  `Name`     `string`   Qrup adı (Max 100)
  `Limit`    `int`      Tələbə limiti (Mütləq \> 0 olmalıdır)

### Student (Tələbələr)

  **Sahə**    **Tip**    **Təsvir**
  ----------- ---------- ----------------------------------------
  `Id`        `int`      Primary Key
  `Name`      `string`   Ad (Max 50)
  `Surname`   `string`   Soyad (Max 50)
  `Email`     `string`   E-poçt (Max 100)
  `GroupId`   `int`      Foreign Key (Group cədvəlinə bağlıdır)

------------------------------------------------------------------------

## 💻 Konsol Menyuları

Proqram işə salındıqda aşağıdakı struktura uyğun menyular açılır:

### Ana Menyu

``` text
=== UNİVERSİTET İDARƏETMƏ SİSTEMİ ===
1. Qrupları idarə et
2. Tələbələri idarə et
0. Çıxış
Seçiminizi edin:
```

### Qrup Menyusu (1)

``` text
--- QRUP MENYUSU ---
1. Qrup əlavə et
2. Qrupa düzəliş et
3. Qrupu sil
4. Bütün qruplara bax
5. ID-yə görə qrup axtar
6. Ada görə qrup axtar
7. Qrupdakı tələbələrə bax
0. Ana menyuya qayıt
Seçiminizi edin:
```

### Tələbə Menyusu (2)

``` text
--- TƏLƏBƏ MENYUSU ---
1. Tələbə əlavə et
2. Tələbəyə düzəliş et
3. Tələbəni sil
4. Bütün tələbələrə bax
5. ID-yə görə tələbə axtar
6. Ada görə tələbə axtar
0. Ana menyuya qayıt
Seçiminizi edin:
```
