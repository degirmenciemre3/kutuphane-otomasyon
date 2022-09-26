Setup kurulurken veritabanını C diskine kaydettiğimiz için, veritabanına kurulu uygulama üzerinden ulaşmak için yönetici iznine ihtiyacımız vardı.
Bu yüzden uygulamayı başlatırken yönetici olarak çalıştırmamız gerekiyor C diskine kaydedilen veritabanına ulaşmak için.
Bunu da app.manifest dosyası içerisinde yazmış olduğum kod ile sağladım.

Access'in sürümüne bağlı olarak hata alınabilir zira ben bu projeyi geliştirirken Microsoft.ACE.OLEDB.12.0 versiyonunu kullandım diğer sürümleri kullanıyorsanız,
DatabaseLayer katmanında DatabaseConnection.cs sınıfında bağlantı adresini değiştirerek programı çalıştırabilirsiniz.
