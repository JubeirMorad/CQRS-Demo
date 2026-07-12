using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class NotFoundException (string entity , Guid id) : Exception($"The {entity} with id {id} was not found.")
    {
        
    }
}