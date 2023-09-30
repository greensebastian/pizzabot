using Pizzabot.Domain.Channels.Events;
using Pizzabot.Domain.Meetups.Events;
using Shouldly;

namespace Pizzabot.Domain.Tests
{
    public class ChannelTests
    {
        [Fact]
        public void Test1()
        {
            var now = DateTimeOffset.Now;
            var channelAddedData = new ChannelAddedData(new ChannelId("channelId"));
            var channelAddedEvent = new Event<ChannelAddedData>(Guid.Empty, "eventId", now, 0, "1", channelAddedData);

            var sut = Channel.Apply(channelAddedEvent);
            var events = sut.CreateMeetup(now);
            var actual = events.Single();

            actual.Data.ShouldBeOfType(typeof(MeetupCreatedData));
            var actualData = (MeetupCreatedData)actual.Data;
            actualData.ChannelId.ShouldBe(channelAddedData.ChannelId);
            actualData.MeetupTime.ShouldBeGreaterThan(now);
            actualData.MeetupTime.ShouldBeLessThan(now.AddDays(28));
        }
    }
}