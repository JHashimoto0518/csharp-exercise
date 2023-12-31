using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropsEnumSample {
    public class EnumBenchmark {

        [Benchmark]
        public bool IsEnabled() => SubscriptionPlan.Free.IsBillingPromotionFeatureEnabled();

        [Benchmark]
        public bool IsEnabledUsingCache() => SubscriptionPlanUsingCache.Free.IsBillingPromotionFeatureEnabled();
    }
}
