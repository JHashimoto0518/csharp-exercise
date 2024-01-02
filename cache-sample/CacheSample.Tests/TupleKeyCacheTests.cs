namespace CacheSample.Tests {
    public class TupleKeyCacheTests {
        private readonly TupleKeyCache _cache;

        public TupleKeyCacheTests() {
            _cache = new TupleKeyCache();
        }

        [Fact]
        public void GetTest1() {
            _cache.Add(key1:"key1", key2:1, value:true);
            var actual = _cache.Get("key1", 1);
            var expected = true;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTest2() {
            _cache.Add(key1: "key1", key2: 2, value: false);
            var actual = _cache.Get("key1", 2);
            var expected = false;
            Assert.Equal(expected, actual);
        }
    }
}