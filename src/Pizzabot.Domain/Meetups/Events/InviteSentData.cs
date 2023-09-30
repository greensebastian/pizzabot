namespace Pizzabot.Domain.Meetups.Events
{
    public record InviteSentData(string MeetupId, string UserId, DateTimeOffset SentAt, string ThreadId) : EventData;
}
