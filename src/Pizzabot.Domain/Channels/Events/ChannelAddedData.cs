namespace Pizzabot.Domain.Channels.Events
{
    public record ChannelAddedData(ChannelId ChannelId) : EventData;
}
