namespace Pizzabot.Domain.Meetups.Events
{
    public record InviteCreatedData(MeetupId MeetupId, UserId UserId) : EventData;
}
