using NurBilgi.Domain.Common.Events;

namespace NurBilgi.Domain.DomainEvents;

public record UserRegisteredDomainEvent : IDomainEvent
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }

    public UserRegisteredDomainEvent(long id, string email, string fullName)
    {
        Id = id;
        Email = email;
        FullName = fullName;
    }
}