using ECommerce.Base.BaseModel;

namespace ECommerce.Payment.Domain;

public class Payment :BaseModel
{
    //public int PaymentCode { get; set; }    
    public string PaymentStatus { get; set; }
    public string PaymentType { get; set; } 
    public double PaymentAmount { get; set; }
    public DateTime PaymentDate{ get; set; }



    }


