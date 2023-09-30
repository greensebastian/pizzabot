namespace Pizzabot.Domain.Meetups.Events
{
    public record MeetupCreatedData(MeetupId MeetupId, ChannelId ChannelId, DateTimeOffset MeetupTime, int TargetParticipantCount): EventData;
}
