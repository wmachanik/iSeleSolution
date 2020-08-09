using iSele.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iSele.Services.EntityConfigs.System
{
    internal class PartyModelConfig : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> partyBuilder)
        {
            partyBuilder.HasIndex(p => p.PartysName)
                .IsUnique();
            partyBuilder.HasIndex(p => p.Abbreviation)
                .IsUnique();
            partyBuilder.HasOne(p => p.NormalDeliveryDoW)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}