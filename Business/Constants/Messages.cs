using System;
using Core.Entities.Concrete;

namespace Business.Constants
{
	public class Messages
	{
        public static string UserAdded = "Kullanıcı eklendi!";

        public static string UserRetrievedById = "Kullanıcı id ile getirildi!";

        public static string AllUsersRetrieved = "Tüm kullanıcılar getirildi!";

        public static string UserRetievedByEmail ="Kullanıcı eposta ile getirildi!";

        public static string UserRegistered = "Kullanıcı kayıt edildi!";

        public static string UserNotFound = "Bu mail ile eşleşen bir kullanıcı bulunamadı!";

        public static string PasswordError = "Girilen şifre yanlış!";

        public static string SuccessfulLogin = "Giriş başarılı!";

        public static string UserOperationClaimDeleted = "Kullanıcı yetkisi silindi!";

        public static string UserOperationClaimUpdated = "Kullanıcı yetkileri güncellendi!";

        public static string UserOperationClaimAdded = "Kullanıcıya yetki eklendi!";

        public static string OperationClaimAdded = "Operasyon yetkisi eklendi!";

        public static string OperationClaimDeleted = "Operasyon yetkisi silindi!";

        public static string OperationClaimUpdated = "Operasyon yetkisi güncellendi!";

        public static string UserAlreadyExists = "Kullanıcı zaten mevcut!";

        public static string UserDoesntExists = "Kullanıcı bulunmuyor!";

        public static string AuthorizationDenied = "Yetki reddedildi!";

        public static string AccessTokenCreated = "Access Token oluşturuldu!";

    }
}

