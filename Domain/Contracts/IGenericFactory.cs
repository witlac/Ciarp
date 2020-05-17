using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts
{
    public interface IGenericFactory<T> where T : BaseEntity
    {
        T CreateEntity(String tipo);

    }
}
