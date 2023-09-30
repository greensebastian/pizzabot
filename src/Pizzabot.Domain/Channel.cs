using Pizzabot.Domain.Channels.Events;
using Pizzabot.Domain.Meetups.Events;

namespace Pizzabot.Domain
{
    public class Channel
    {
        private Channel(){}
        public required ChannelId Id { get; init; }

        public static Channel Apply(Event<ChannelAddedData> @event) => new()
        {
            Id = @event.Data.ChannelId
        };

        public IEnumerable<Event<EventData>> CreateMeetup(DateTimeOffset currentTime)
        {
            yield return new Event<MeetupCreatedData>(Guid.NewGuid(), nameof(Channel), currentTime, 0, "1",
                new MeetupCreatedData(new MeetupId(Guid.NewGuid()), Id, GetMeetupTime(currentTime), 4)).Generic;
        }

        private static DateTimeOffset GetMeetupTime(DateTimeOffset currentTime)
        {
            var threeWeeksOut = currentTime.AddDays(21);
            var monday = threeWeeksOut.AddDays(-(int)threeWeeksOut.DayOfWeek + 1);
            var mondayMorning = monday.Subtract(monday.TimeOfDay);
            var meetupDay = mondayMorning.AddDays(new Random().Next(4));
            var meetupTime = meetupDay.AddHours(17);
            return meetupTime;
        }
    }
}
