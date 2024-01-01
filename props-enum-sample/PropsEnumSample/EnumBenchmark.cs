using BenchmarkDotNet.Attributes;
using PropsEnumSample.Enums;

namespace PropsEnumSample {
    public class EnumBenchmark {

        [Benchmark]
        public bool IsEnabled() => SubscriptionPlan.Free.IsBillingPromotionFeatureEnabled();

        [Benchmark]
        public bool IsEnabledUsingCache() => SubscriptionPlanUsingCache.Free.IsBillingPromotionFeatureEnabled();
    }
}
