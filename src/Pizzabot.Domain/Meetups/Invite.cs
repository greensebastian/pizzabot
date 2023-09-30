namespace Pizzabot.Domain.Meetups
{
    public class Invite
    {
        public required UserId UserId { get; init; }
        public DateTimeOffset? InviteSent { get; private set; }
        public DateTimeOffset? ReminderSent { get; private set; }
        public ThreadId? ThreadId { get; private set; }
    }
}
