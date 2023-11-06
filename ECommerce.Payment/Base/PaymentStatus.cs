namespace ECommerce.Payment.Base;
public enum PaymentStatus
{
    WaitingforPayment = 1 ,

    OnHold = 2,
    Cancelled= 3,

    NotApproved =4 ,
    Approved=5 
}