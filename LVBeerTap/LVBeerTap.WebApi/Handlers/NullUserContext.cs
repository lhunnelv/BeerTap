using System;

namespace LVBeerTap.WebApi.Handlers
{
    public class NullUserContext : IDisposable
    {
        public void Dispose() { }
    }
}