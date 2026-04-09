using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BuildingBlocks.Messaging.Events
{
    public class IntegrationEvent
    {
        public Guid EventId => Guid.NewGuid();
        public DateTime OccuredOn => DateTime.UtcNow;
        public string? EventType => GetType().AssemblyQualifiedName;
    }
}
