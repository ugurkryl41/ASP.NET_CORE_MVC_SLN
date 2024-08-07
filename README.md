# ASP.NET CORE MVC

## Proje Açıklaması

### Bu proje, ASP.NET Core MVC ile geliştirilmiş bir web uygulamasıdır ve çeşitli modern yazılım teknolojileri ve mimarileri kullanılarak oluşturulmuştur. Aşağıda, projede kullanılan ana bileşenler ve yapılar detaylı olarak açıklanmaktadır.

## Kullanılan Teknolojiler

  * ASP.NET Core MVC: Bu proje, Model-View-Controller (MVC) desenini kullanarak ASP.NET Core üzerinde inşa edilmiştir.
  * Entity Framework Core: Veritabanı işlemleri için Entity Framework Core kullanılmıştır.
  * AutoMapper: Nesne yönlendirmesi ve veri dönüştürmeleri için AutoMapper kullanılmıştır.
  * Bootstrap: Kullanıcı arayüzünü oluşturmak için Bootstrap kütüphanesi kullanılmıştır.

## Mimariler ve Yapılar
* Katmanlı Mimari: Proje, katmanlı mimari prensiplerine göre yapılandırılmıştır.
    * Presentation Layer: Kullanıcı arayüzünü ve MVC kontrolörlerini içerir.
    * Business Logic Layer: İş kurallarını ve uygulama mantığını içerir.
    * Data Access Layer: Veritabanı erişim katmanını içerir ve Entity Framework Core kullanılarak gerçekleştirilmiştir.

## Özellikler ve Yapılar
* Dependency Injection: Projede bağımlılık enjeksiyonu (DI) kullanılmıştır.
* Tag Helpers: ASP.NET Core MVC Tag Helpers kullanılarak HTML elemanları ve Razor bileşenleri genişletilmiştir.
* Middleware: Özel middleware bileşenleri ile HTTP istekleri ve yanıtları işlenmiştir.
* Otomatik Mapping: AutoMapper kullanılarak veri modelleri arasında dönüşümler yapılmıştır.

## Veritabanı Migrations  
* Code-First Migrations: Entity Framework Core kullanılarak Code-First yaklaşımı ile veritabanı şeması oluşturulmuş ve yönetilmiştir.

## Kullanıcı Yönetimi
* Session Management: Kullanıcı oturum yönetimi ve kimlik doğrulama işlemleri gerçekleştirilmiştir.
* Role-Based Authorization: Kullanıcı rolleri ve yetkilendirme işlemleri yönetilmiştir.

## Kullanıcı Arayüzü
* Responsive Design: Bootstrap kullanılarak duyarlı ve kullanıcı dostu bir arayüz tasarımı gerçekleştirilmiştir.

## Design Patterns (Tasarım Kalıpları)
* Repository Pattern: Veri erişim katmanında Repository deseni kullanılarak veri erişim işlemleri soyutlanmıştır. Bu, veritabanı işlemlerinin merkezi bir yerden yönetilmesini sağlar.
* Unit of Work: Birimler arası işlemlerin tutarlı ve bir bütün olarak yönetilmesini sağlar. Bu desen, özellikle veri tabanı işlemlerinde kullanılmıştır.
* Dependency Injection (DI): Bağımlılıkların yönetimi için DI deseni kullanılmıştır. Bu, uygulama bileşenlerinin daha kolay test edilmesini ve yönetilmesini sağlar.
* Factory Pattern: Nesne oluşturma sürecini soyutlamak için fabrika desenleri kullanılmıştır. Bu, nesne oluşturma işlemlerinin daha esnek ve modüler olmasını sağlar.

# Yazılım Metodolojileri ve Tasarım Prensipleri
## SOLID Prensipleri
* Single Responsibility Principle (SRP): Her sınıfın sadece bir sorumluluğu olmalıdır. Örneğin, ServiceExtension.cs dosyası sadece servislerin DI konteynerine eklenmesi işlemini yönetir.
* Open/Closed Principle (OCP): Sınıflar genişlemeye açık, ancak değişime kapalı olmalıdır. Projede, yeni özellikler eklerken mevcut kodu değiştirmeden genişletmek için arayüzler ve soyut sınıflar kullanılmıştır.
* Liskov Substitution Principle (LSP): Türeyen sınıflar, türedikleri sınıfın yerine kullanılabilmelidir. Bu prensip, özellikle veri modelleri ve AutoMapper ile yapılan dönüşümlerde göz önünde bulundurulmuştur.
* Interface Segregation Principle (ISP): Kullanıcıları gereksiz metodlarla zorlamadan, spesifik arayüzler oluşturulmalıdır. Projede, her bir işlevsellik için spesifik arayüzler tanımlanmıştır.
* Dependency Inversion Principle (DIP): Yüksek seviyeli modüller düşük seviyeli modüllere bağımlı olmamalıdır. Abstraksiyonlar kullanılarak bağımlılıklar yönetilmiştir.

## Clean Code
* Anlaşılabilirlik: Kodun okunabilir ve anlaşılabilir olması sağlanmıştır. Anlamlı değişken isimleri ve açıkça tanımlanmış metodlar kullanılmıştır.
* Yeniden Kullanılabilirlik: Kod, tekrar kullanılabilir bileşenler halinde yazılmıştır. Bu, kodun sürdürülebilirliğini ve genişletilebilirliğini artırır.
* Test Edilebilirlik: Bağımlılık enjeksiyonu ve soyutlamalar kullanılarak kodun birim testleri kolaylaştırılmıştır.

## DRY (Don't Repeat Yourself)
* Aynı kod veya mantık tekrarından kaçınılmıştır. Örneğin, veri dönüşümleri AutoMapper ile merkezi bir şekilde yönetilmiştir. Bu, kodun daha az hata ile daha hızlı geliştirilmesini sağlar.

## KISS (Keep It Simple, Stupid)
* Kodun olabildiğince basit ve anlaşılır tutulması sağlanmıştır. Karmaşık yapılar yerine, basit ve etkili çözümler tercih edilmiştir. Bu, bakım maliyetlerini azaltır ve yeni geliştiricilerin projeyi hızlıca anlamasına yardımcı olur.

## YAGNI (You Aren't Gonna Need It)
* Gereksiz özellikler eklemekten kaçınılmıştır. Yalnızca projenin mevcut gereksinimlerini karşılamak için gerekli olan bileşenler eklenmiştir. Bu, geliştirme sürecini hızlandırır ve kod tabanını temiz tutar.  
