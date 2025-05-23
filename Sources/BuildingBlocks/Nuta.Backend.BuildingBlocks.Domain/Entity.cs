﻿namespace Nuta.Backend.BuildingBlocks.Domain;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
            throw new BusinessRuleValidationException(rule);
    }
}