using Pizzabot.Domain.Collections;
using Pizzabot.Domain.Meetups.Events;

namespace Pizzabot.Domain.Meetups
{
    public class Meetup
    {
        private readonly List<Invite> _invites = new();
        private readonly ISet<UserId> _declinedUserIds = new HashSet<UserId>();
        private readonly ISet<UserId> _acceptedUserIds = new HashSet<UserId>();
        private Meetup(){}
        public int SequenceNumber { get; private set; }
        public required MeetupId MeetupId  { get; init; }
        public required ChannelId ChannelId { get; init; }
        public required DateTimeOffset Time { get; init; }
        public required int TargetParticipantCount { get; init; }

        public IReadOnlyList<Invite> Invites => _invites.AsReadOnly();

        public IReadOnlySet<UserId> DeclinedUserIds => _declinedUserIds.AsReadOnly();

        public IReadOnlySet<UserId> AcceptedUserIds => _acceptedUserIds.AsReadOnly();

        public static Meetup Apply(Event<MeetupCreatedData> @event)
        {
            if (@event.SequenceNumber != 0)
                throw new Exception($"Invalid SequenceNumber {@event.SequenceNumber}");

            return new Meetup
            {
                MeetupId = @event.Data.MeetupId,
                ChannelId = @event.Data.ChannelId,
                Time = @event.Data.MeetupTime,
                TargetParticipantCount = @event.Data.TargetParticipantCount,
            };
        }

        public void Apply(Event<InviteCreatedData> @event)
        {
            if (@event.SequenceNumber != SequenceNumber + 1)
                throw new Exception($"Invalid SequenceNumber {@event.SequenceNumber}");

            SequenceNumber = @event.SequenceNumber;
            _invites.Add(new Invite { UserId = @event.Data.UserId });
        }

        public IEnumerable<Event<EventData>> CreateInvites(IEnumerable<UserId> channelMembers, ICollection<UserId> optedOutUsers, DateTimeOffset currentTime)
        {
            foreach (var userId in channelMembers.Shuffle())
            {
                if (Invites.Count + AcceptedUserIds.Count >= TargetParticipantCount)
                    break;
                if (optedOutUsers.Contains(userId))
                    continue;
                if (Invites.Select(inv => inv.UserId).Concat(AcceptedUserIds).Concat(DeclinedUserIds).Contains(userId))
                    continue;

                var @event = new Event<InviteCreatedData>(Guid.NewGuid(), nameof(Meetup), currentTime, SequenceNumber + 1, "1",
                    new InviteCreatedData(MeetupId, userId));
                Apply(@event);
                yield return @event.Generic;
            }
        }
    }
}
