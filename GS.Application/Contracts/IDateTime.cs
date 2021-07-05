using System;

namespace GS.Application.Contracts
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
        DateTime FromUtc(DateTime date);
    }
}
