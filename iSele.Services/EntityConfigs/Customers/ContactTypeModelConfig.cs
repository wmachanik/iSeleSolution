using iSele.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.Customers
{
    internal class ContactTypeModelConfig : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> contactTypeBuilder)
        {
            contactTypeBuilder.HasIndex(cot => cot.ContactTypeName).IsUnique();
            contactTypeBuilder.Property(cot => cot.IsFulfillmentContact).HasDefaultValue(true);
            contactTypeBuilder.Property(cot => cot.IsAccountsContact).HasDefaultValue(false);
        }
    }
}