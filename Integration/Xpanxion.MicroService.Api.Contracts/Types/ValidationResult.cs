using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.Integration.Contracts.Types
{
    public sealed class ValidationResult
    {
        public ApiError Error;

        public bool IsValid
        {
            get
            {
                return this.Error == null;
            }
        }
    }
}
