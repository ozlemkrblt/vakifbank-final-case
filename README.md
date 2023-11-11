# vakifbank-final-case
<br/>
  <h3 align="center">Order Management System </h3>

  <p align="center">
    Bir şirket ve bayileri arasında sipariş akışını sağlamak için kurulmuş bir sistemdir.
    <br/>
    -- Henüz tamamlanmamış halindedir--
    <br/>


## İçerik

- [İçerik](#içerik)
- [Proje Hakkında](#proje-hakkında)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Kurulum](#kurulum)
  - [Ön Gereksinimler](#ön-gereksinimler)
- [Kullanım](#kullanım)
- [Authorization](#authorization)

## Proje Hakkında

_Vakıfbank FullStack Bootcamp_ bitirme projesi olarak, DotNet ve Angular Framework'leri kullanılarak geliştirilen, bir şirket ve bayileri arasında sipariş akışını sağlayacak full-stack bir sistem geliştirilmesi istenmiştir. Api ve Front-end olmak üzere iki kısımdan oluşmasını planladığım projeyi geliştirmekteyim.

## Kullanılan Teknolojiler

- [JavaScript](https://www.javascript.com/)
- [C#](https://vuejs.org/)
- [DotNet Core](https://dotnet.microsoft.com/en-us/download)
- [Entity Framework Core Package](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
- [MSSQL](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
  

## Başlangıç

Proje gereksinimleri ve kurulum aşamaları aşağıda bahsedilmiştir:

### Ön Gereksinimler

- [Angular Framework / Angular Cli Kurulumu](https://angular.io/cli)
- [Microsoft SQL Server] (https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)  ya da [PostgreSql](https://www.postgresql.org/) Kurulumu
- [Node modules dosyasını indirmek ve Node Package Manager'ı kullanabilmek için Node.js kurulumu önerilir.](https://nodejs.org/en)
- DotNet Core Kurulumu
  
### Kurulum

1. Yukarıdaki kurulumu yaptıktan sonra, 6 proje içinden , ECommerce Web API'ye erişmek için, ECommerceWebApi'yi başlangıç projesi olarak seçip çalıştırabilirsiniz.
2. Migration ile SeedData eklemesini SeedData.cs dosyasındaki SQL'i kullanarak yapabilirsiniz.

## Kullanım

- API Dökümantasyonu
- Front-end kısmını henüz bitirmediğimden dolayı , Angular'ın default portu https://localhost:4200 'den erişebilirsiniz. CORS Konfigürasyonu yapılmıştır.
Login ve Register sayfaları çalışmaktadır. 

## Authorization

API'da JWT Bearer Token kullanılmaktadır. 15 dakikalık süresi vardır.
Token'i, kullanıcı adı ve şifresini girerek `POST /os/api/v1/Token` enpointinden elde edebilirsiniz.

Seeddata'yı oluşturduktan sonra oluşan Admin değerlerini ya da `POST /os/api/v1/User` endpointi ile, RoleID=1 olacak şekilde yeni kullanıcı oluşturduktan sonra, onun bilgilerini girerek kullanabilirsiniz.


| Parameter | Type | Description |
| :--- | :--- | :--- |
| `username` | `string` | **Zorunlu**.|
| `password` | `string` | **Zorunlu**.|

