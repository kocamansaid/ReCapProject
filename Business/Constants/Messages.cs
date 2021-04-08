using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MakeSuccess = "İşleminiz Başarılı oldu";
        public static string NotMakeSucces = "İşlem Başarısız oldu";
        public static string UnAvaliableCar = "Araba Müsait değil";

        public static string CarImageAdded = "Araba görseli eklendi";
        public static string CarImageDeleted = "Araba görseli silindi";
        public static string CarImagesListed = "Araba görselleri listelendi";
        public static string CarCheckImageLimited = "Araba görseli limitine ulaşıldı.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
        public static string PasswordError = "Hatalı parola.";
        public static string UserNotFound = "Kullaıcıı bulunamadı.";
        public static string UserRegistered = "Kullanıcı giriş yaptı.";
        public static string UserListed = "Kullanıcılar Listelendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserAlreadyExists = "Kullanıcı zaten oluşturulmuş.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
