using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi 3 karakterden kısa olamaz.";
        public static string CarPriceInvalid = "Araba fiyatı 0 veya 0 dan küçük olamaz.";
        public static string CarUpdated = "Araba bilgileri güncellendi.";
        public static string CarErrorUpdated = "Bir sorun oluştu araba bilgileri güncellenemedi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarErrorDeleted = "Bir sorun oluştu araba bilgileri silinemedi.";
        public static string CarsListed = "Araba bilgileri listelendi.";
        public static string ErrorMessage = "Bir sorun oluştu işlem gerçekleştirilemedi.";

        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserView = "Kullanı görüntülendi.";
        public static string UsersListed = "Kullanıcılar Listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerView = "Müşteri görüntülendi.";
        public static string CustomersListed = "Müşteriler Listelendi.";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi.";
        public static string RentalDeleted = "Kiralama sonlandırıldı.";
        public static string RentalView = "Kiralama detayı görüntülendi.";
        public static string RentalsListed = "Kiralama bilgileri listelendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        public static string BrandNameExists = "Model ismi kayıtlı.";
        public static string DataIsNull = "Veri boş olamaz";
        public static string MinBrandNameLength = "model ismi en az 2 karakter olmalı";
        public static string MaxBrandNameLength = "model ismi 15 karakterden küçük olmalı";

        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
