namespace GS.Domain.Models
{
    public enum EnabledStatus
    {
        Enabled,
        Disabled,
        Deleted
    }

    public static class EnabledStatusExtensions
    {
        public static bool ToBolean(this EnabledStatus status)
        {
            return status == EnabledStatus.Enabled;
        }

        public static EnabledStatus ToEnabledStatus(this bool enabled)
        {
            return enabled ? EnabledStatus.Enabled : EnabledStatus.Disabled;
        }
    }
}
