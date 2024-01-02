namespace CacheSample {
    public class TupleKeyCache {
        private static Dictionary<(string key1, int key2), bool> _cache = new();

        public bool Exists(string key1, int key2) {
            return _cache.ContainsKey((key1, key2));
        }

        public void Add(string key1, int key2, bool value) {
            _cache.Add((key1, key2), value);
        }

        public bool Get(string key1, int key2) {
            return _cache[(key1, key2)];
        }
    }
}
