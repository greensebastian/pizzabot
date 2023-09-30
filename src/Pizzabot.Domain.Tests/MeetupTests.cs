using Pizzabot.Domain.Meetups;
using Pizzabot.Domain.Meetups.Events;
using Shouldly;

namespace Pizzabot.Domain.Tests
{
    public class MeetupTests
    {
        [Fact]
        public void Test1()
        {
            var now = DateTimeOffset.Now;
            var meetupTime = now.AddDays(1);
            var data = new MeetupCreatedData(new MeetupId(Guid.NewGuid()), new ChannelId("channelId"), meetupTime, 4);
            var @event = new Event<MeetupCreatedData>(Guid.Empty, "eventId", now, 0, "1", data);

            var actual = Meetup.Apply(@event);

            actual.ChannelId.ShouldBe(data.ChannelId);
            actual.MeetupId.ShouldBe(data.MeetupId);
            actual.Time.ShouldBe(meetupTime);
            actual.Invites.ShouldBeEmpty();
            actual.AcceptedUserIds.ShouldBeEmpty();
            actual.DeclinedUserIds.ShouldBeEmpty();
            actual.SequenceNumber.ShouldBe(0);
        }
    }
}