// See https://aka.ms/new-console-template for more information
using PropsEnumSample;

//Console.WriteLine($"Free plan is billing enabled: {SubscriptionPlan.Free.IsBillingPromotionFeatureEnabled()}");
//Console.WriteLine($"Monthly plan is billing enabled: {SubscriptionPlan.Monthly.IsBillingPromotionFeatureEnabled()}");
//Console.WriteLine($"Yearly plan is billing enabled: {SubscriptionPlan.Yearly.IsBillingPromotionFeatureEnabled()}");
//Console.WriteLine($"Student plan is billing enabled: {SubscriptionPlan.Student.IsBillingPromotionFeatureEnabled()}");

//Console.WriteLine($"Free plan is content accessible: {SubscriptionPlan.Free.IsLimitedContentAccessible()}");
//Console.WriteLine($"Monthly plan is content accessible: {SubscriptionPlan.Monthly.IsLimitedContentAccessible()}");
//Console.WriteLine($"Yearly plan is content accessible: {SubscriptionPlan.Yearly.IsLimitedContentAccessible()}");
//Console.WriteLine($"Student plan is content accessible: {SubscriptionPlan.Student.IsLimitedContentAccessible()}");

//Console.WriteLine($"Free plan is discount promotion enabled: {SubscriptionPlan.Free.IsDiscountPromotionEnabled()}");
//Console.WriteLine($"Monthly plan is discount promotion enabled: {SubscriptionPlan.Monthly.IsDiscountPromotionEnabled()}");
//Console.WriteLine($"Yearly plan is discount promotion enabled: {SubscriptionPlan.Yearly.IsDiscountPromotionEnabled()}");
//Console.WriteLine($"Student plan is discount promotion enabled: {SubscriptionPlan.Student.IsDiscountPromotionEnabled()}");

//Console.WriteLine($"Free plan is student verification required: {SubscriptionPlan.Free.IsStudentVerificationRequired()}");
//Console.WriteLine($"Monthly plan is student verification required: {SubscriptionPlan.Monthly.IsStudentVerificationRequired()}");
//Console.WriteLine($"Yearly plan is student verification required: {SubscriptionPlan.Yearly.IsStudentVerificationRequired()}");
//Console.WriteLine($"Student plan is student verification required: {SubscriptionPlan.Student.IsStudentVerificationRequired()}");

var subscriptionPlan = SubscriptionPlan.Free;

if (subscriptionPlan.IsBillingPromotionFeatureEnabled()) {
    Console.WriteLine("Billing promotion feature is enabled.");
} else {
    Console.WriteLine("Billing promotion feature is disabled.");
}