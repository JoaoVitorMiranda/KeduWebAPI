using System;

namespace Infrastructure.Domain.Entities.Interfaces.Standard
{
    public interface IAuditoria : IIdentityEntity
    {
        DateTime InseridoEm { get; set; }

        DateTime? AlteradoEm { get; set; }

        string InseridoPor { get; set; }

        string AlteradoPor { get; set; }
    }
}
