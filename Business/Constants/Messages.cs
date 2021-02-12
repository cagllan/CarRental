using System;
using System.Collections.Generic;
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

    }
}
