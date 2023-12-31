using PropsEnumSample;

var subscriptionPlan = SubscriptionPlan.Free;

if (subscriptionPlan.IsBillingPromotionFeatureEnabled()) {
    Console.WriteLine("Billing promotion feature is enabled.");
} else {
    Console.WriteLine("Billing promotion feature is disabled.");
}