namespace StockTrackingAPI.JWT
{
    public class APIUserList
    {
        public static List<APIUser> Users { get; set; } = new()
        {
            new APIUser {ID=1,KullaniciAdi="Ali",Sifre="123456",Rol="Yönetici"},
            new APIUser {ID=2,KullaniciAdi="Hamza",Sifre="123456",Rol="Kullanici"}
        };
    }
}
