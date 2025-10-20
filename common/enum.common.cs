namespace EcommerceWebApi.Common.Model
{
    public enum PaymentStatus
    {
        pending,
        paid,
        failed,
        Refunded,
    }

    public enum OrderStatus
    {
        pending,
        paid,
        failed,
        Refunded,
    }

    public enum RoleEnum
    {
        Admin,
        User,
        Guest,
    }
}
