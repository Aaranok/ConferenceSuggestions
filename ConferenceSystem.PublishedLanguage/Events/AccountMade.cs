using MediatR;

namespace RatingSystem.PublishedLanguage.Events
{
    public class AccountMade: INotification
    {
        public string Name { get; set; }
    }
}
