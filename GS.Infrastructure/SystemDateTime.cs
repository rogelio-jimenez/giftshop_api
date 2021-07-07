using GS.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Infrastructure
{
    public sealed class SystemDateTime : IDateTime
    {
        private readonly TimeZoneInfo _timeZoneInfo;

        public DateTime Now { get { return DateTime.UtcNow; } }
        public DateTime Today
        {
            get
            {
                return FromUtc(DateTime.UtcNow).Date;
            }
        }

        public DateTime FromUtc(DateTime date)
        {
            var local = TimeZoneInfo.ConvertTimeFromUtc(date, _timeZoneInfo);
            return local;
        }

        public SystemDateTime(TimeZoneInfo localTimeZoneInfo)
        {
            _timeZoneInfo = localTimeZoneInfo ?? throw new ArgumentNullException(nameof(localTimeZoneInfo));
        }

        public SystemDateTime() : this(TimeZoneInfo.Local)
        {
        }

        public SystemDateTime(string localTimeZone)
        {
            if(localTimeZone is null)
            {
                throw new ArgumentNullException(nameof(localTimeZone));
            }

            _timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(localTimeZone);
        }
    }
}
