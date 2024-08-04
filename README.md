<h1> Kullanışlı Rehber Projesi</h1>
T.C. Çevre, Şehircilik ve İklim Değişikliği Bakanlığı adına staj dönemimde gerçekleştirdiğim bu proje, çalışanlara daha kullanışlı bir arayüz sunarak işlerini kolaylaştırmayı amaçlamaktadır. Proje sürecinde, kullanıcı deneyimini ön planda tutarak, iş verimliliğini artıran çözümler geliştirdim.

Sistemin üç farklı arayüzü vardır.
• Personel arayüzü
• Admin arayüzü
• Login arayüzü

<h3>Özellikler:</h3>
• Bir çalışanın ad, soyad, telefon, departman , E-Posta ve yönetici bilgileri sistemde yer alır.
• Personel, rehber ekranından istediği çalışanı arayarak bilgilerine ulaşabilir.
• Personel, profilim ekranından kendi bilgilerini inceleyip güncelleyebilir. (E-Posta ve Kullanıcı adı bilgisini güvenlik nedeniyle güncelleyemez.)

• Admin, rehber düzenle sayfasına ulaşabilir ve bu sayfadan istediği personel bilgilerini güncelleyebilir ve silebilir.

• Giriş yapmadan da rehber sayfasına ulaşılabilir ve gerekli kişilerin bilgilerine bakılabilir.
• Giriş işleminde kullanıcı adı,E-Posta ve windows oturum ile giriş yapabilir. ( windows oturum ile giriş yap butonuna tıklandığında otomatik kullanıcıya giriş yapar.)
• Ayarlanan güvenlik sayesinde admin girişi yapılmadan admin sayfalarına ulaşılamaz. Bu sayede güvenlik sağlanmış olur.


<h3>Kurulum:</h3>
• Projeyi bilgisayarınıza indirin veya Visual Studio ile projeyi clone a repository edin.
• Projeyi açtıktan sonra gerekli kütüphaneleri yükleyin.
• ssms veritabanını açın ve projeyi veritabanına bağlayın. ( appsettings.json dosyasının içindeki ConnectionStrings güncellemeniz yeterlidir.)
• bir tane migration oluşturun. (Package Manager console açın ve add-migration (isim) yarak oluşturabilirsiniz.)
• Update-Database komutunu kullanarak veritabanındaki tabloyu oluşturun.
• Giriş işlemi için ssms açın ve users tablosuna bir kullanıcı ekleyin. (Role 1 = Admin, Role 0 = Personel)
• Uygulamayı artık kullanabilirsiniz.
