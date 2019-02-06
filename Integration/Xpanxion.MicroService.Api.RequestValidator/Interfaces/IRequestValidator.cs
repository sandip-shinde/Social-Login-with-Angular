using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.Integration.Contracts.Types;

namespace Xpanxion.MicroService.Api.RequestValidator.Interfaces
{
    public interface IRequestValidator<Trequest>
    {
        ValidationResult Validate(Trequest trequest);

    }
}
