namespace Pizzabot.Domain
{
    public record Event<TData>(Guid Id, string EntityKey, DateTimeOffset Created, int SequenceNumber, string EventVersion,
        TData Data) where TData : EventData
    {
        public string EntityType { get; } = typeof(TData).Name;
        public Event<EventData> Generic => new(Id, EntityKey, Created, SequenceNumber, EventVersion, Data);
    }
}
