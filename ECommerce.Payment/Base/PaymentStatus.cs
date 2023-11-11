namespace ECommerce.Payment.Base;
public enum PaymentStatus
{
    Pending = 1 ,

    OnHold = 2,
    Cancelled= 3,

    NotApproved =4 ,
    Approved=5 
}