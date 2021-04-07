namespace Csoft.EnoviaAtmIntegration.Domain {
    public class CacheItem {
        internal string Id { get; }
        internal string Guid { get; }
        public CacheItem(string id, string guid) {
            Id = id;
            Guid = guid;
        }
    }
}
