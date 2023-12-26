namespace WebApi008.Logs
{
    public sealed class NullScope:IDisposable
    {
        public static NullScope Instance { get; }= new NullScope();

        private NullScope() { }

        public void Dispose() { }
    }
}
