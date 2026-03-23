using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message):base(message)
        {
            
        }
        public NotFoundException(string entity, object key): base($"Entity : {entity}, Key : {key} Not Found Exception.")
        {
            
        }
    }
}
