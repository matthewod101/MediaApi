using System;

namespace MediaApi.Helpers
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
}