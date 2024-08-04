<h1> Kullanışlı Rehber Projesi (Asp.net Core MVC)</h1>
T.C. Çevre, Şehircilik ve İklim Değişikliği Bakanlığı adına staj dönemimde gerçekleştirdiğim bu proje, çalışanlara daha kullanışlı bir arayüz sunarak işlerini kolaylaştırmayı amaçlamaktadır. Proje sürecinde, kullanıcı deneyimini ön planda tutarak, iş verimliliğini artıran çözümler geliştirdim.<br>

Sistemin üç farklı arayüzü vardır.<br>
• Personel arayüzü <br>
• Admin arayüzü<br>
• Login arayüzü<br>

<h3>Özellikler:</h3><br>
• Bir çalışanın ad, soyad, telefon, departman , E-Posta ve yönetici bilgileri sistemde yer alır.<br>
• Personel, rehber ekranından istediği çalışanı arayarak bilgilerine ulaşabilir.<br>
• Personel, profilim ekranından kendi bilgilerini inceleyip güncelleyebilir. (E-Posta ve Kullanıcı adı bilgisini güvenlik nedeniyle güncelleyemez.)<br>
<br>
• Admin, rehber düzenle sayfasına ulaşabilir ve bu sayfadan istediği personel bilgilerini güncelleyebilir ve silebilir.<br>
<br>
• Giriş yapmadan da rehber sayfasına ulaşılabilir ve gerekli kişilerin bilgilerine bakılabilir.<br>
• Giriş işleminde kullanıcı adı,E-Posta ve windows oturum ile giriş yapabilir. ( windows oturum ile giriş yap butonuna tıklandığında otomatik kullanıcıya giriş yapar.)<br>
• Ayarlanan güvenlik sayesinde admin girişi yapılmadan admin sayfalarına ulaşılamaz. Bu sayede güvenlik sağlanmış olur.<br>

<br>
<h3>Kurulum:</h3><br>
• Projeyi bilgisayarınıza indirin veya Visual Studio ile projeyi clone a repository edin.<br>
• Projeyi açtıktan sonra gerekli kütüphaneleri yükleyin.<br>
• ssms veritabanını açın ve projeyi veritabanına bağlayın. ( appsettings.json dosyasının içindeki ConnectionStrings güncellemeniz yeterlidir.)<br>
• bir tane migration oluşturun. (Package Manager console açın ve add-migration (isim) yarak oluşturabilirsiniz.)<br>
• Update-Database komutunu kullanarak veritabanındaki tabloyu oluşturun.<br>
• Giriş işlemi için ssms açın ve users tablosuna bir kullanıcı ekleyin. (Role 1 = Admin, Role 0 = Personel)<br>
• Uygulamayı artık kullanabilirsiniz.<br>
<br><br>
Diğer projelerimi incelemek ve benimle iletişime geçmek için <a href="https://yilmazkanat.com" target="_blank">Tıklayın. (yilmazkanat.com)</a>
<br>
<h3>Uygulama Görselleri:</h3><br>

<h5>Login Sayfası</h5>
 <img src="https://github.com/ylmazkanat/IzmRehber/blob/master/Uygulama%20Aray%C3%BCz%C3%BC/login.png" alt="Login Ekranı" width="100%" ><br>
<h5>Profil Sayfası</h5>
 <img src="https://github.com/ylmazkanat/IzmRehber/blob/master/Uygulama%20Aray%C3%BCz%C3%BC/profil.png" alt="Profil Ekranı" width="100%" ><br>
<h5>Rehber Sayfası</h5>
 <img src="https://github.com/ylmazkanat/IzmRehber/blob/master/Uygulama%20Aray%C3%BCz%C3%BC/rehber.png" alt="Rehber Sayfası" width="100%" ><br>
<h5>Rehberi Düzenleme Sayfası</h5>
 <img src="https://github.com/ylmazkanat/IzmRehber/blob/master/Uygulama%20Aray%C3%BCz%C3%BC/rehberi-duzenle.png" alt="Rehberi Düzenleme Sayfası" width="100%" ><br>
