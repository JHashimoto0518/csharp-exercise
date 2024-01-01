using PropsEnumSample;
using BenchmarkDotNet.Running;
using PropsEnumSample.Enums;

//var summary = BenchmarkRunner.Run<EnumBenchmark>();

// SubscriptionPlan.Student.IsBillingPromotionFeatureEnabled()
Console.WriteLine("SubscriptionPlan.Student.IsBillingPromotionFeatureEnabled:" + SubscriptionPlan.Student.IsBillingPromotionFeatureEnabled());  
// SubscriptionPlan.Student.IsLimitedContentAccessible()
Console.WriteLine("SubscriptionPlan.Student.IsLimitedContentAccessible:" + SubscriptionPlan.Student.IsLimitedContentAccessible());

// SubscriptionPlanUsingCache.Student.IsBillingPromotionFeatureEnabled()
Console.WriteLine("SubscriptionPlanUsingCache.Student.IsBillingPromotionFeatureEnabled:" + SubscriptionPlanUsingCache.Student.IsBillingPromotionFeatureEnabled());
// SubscriptionPlanUsingCache.Student.IsLimitedContentAccessible()
Console.WriteLine("SubscriptionPlanUsingCache.Student.IsLimitedContentAccessible:" + SubscriptionPlanUsingCache.Student.IsLimitedContentAccessible());
