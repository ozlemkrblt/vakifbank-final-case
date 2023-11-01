
using ECommerce.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Domain
{
    public class Retailer : User
    {
        public string RetailerName { get; set; }

        public string ReceiptInfo { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>(); // one seller can order many times

       // Özel Fiyatlandırma(Kar marjı, anlaşmalı fiyatlar vb.)
//Açık Hesap Limiti

        public override void Login()
        {
            throw new NotImplementedException();
        }
    }
}

public class ReceiptInfo
{
   // Faturayı düzenleyen kişi/firmanın unvanı, adresi,
   //public Address RetailerAddress { get; set; }
//Faturayı düzenleyen kişi / firmanın vergi numarası, mersis numarası



//Fatura kime kesiliyorsa bahse konu müşterinin unvanı, adresi,
//Faturanın kesildiği müşterinin vergi dairesi numarası


}

public class RetailerConfiguration : IEntityTypeConfiguration<Retailer>
{
    public void Configure(EntityTypeBuilder<Retailer> builder)
    { }
}
