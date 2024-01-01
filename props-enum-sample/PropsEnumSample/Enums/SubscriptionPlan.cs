using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftAntimalwareEngine;
using PropsEnumSample.Attributes;

namespace PropsEnumSample.Enums
{
    enum SubscriptionPlan
    {
        [BillingPromotionFeatureEnabled(false)]
        [LimitedContentAccessible(false)]
        [DiscountPromotionEnabled(false)]
        [StudentVerificationRequired(false)]
        Free,
        [BillingPromotionFeatureEnabled(true)]
        [LimitedContentAccessible(true)]
        [DiscountPromotionEnabled(true)]
        [StudentVerificationRequired(false)]
        Monthly,
        [BillingPromotionFeatureEnabled(true)]
        [LimitedContentAccessible(true)]
        [DiscountPromotionEnabled(false)]
        [StudentVerificationRequired(false)]
        Yearly,
        [BillingPromotionFeatureEnabled(true)]
        [LimitedContentAccessible(false)]
        [DiscountPromotionEnabled(false)]
        [StudentVerificationRequired(true)]
        Student
    }

    static class SubscriptionPlanExtensions
    {

        public static bool IsBillingPromotionFeatureEnabled(this SubscriptionPlan self)
        {
            return IsTrue<BillingPromotionFeatureEnabledAttribute>(self);
        }

        public static bool IsLimitedContentAccessible(this SubscriptionPlan self)
        {
            return IsTrue<LimitedContentAccessibleAttribute>(self);
        }

        public static bool IsDiscountPromotionEnabled(this SubscriptionPlan self)
        {
            return IsTrue<DiscountPromotionEnabledAttribute>(self);
        }

        public static bool IsStudentVerificationRequired(this SubscriptionPlan self)
        {
            return IsTrue<StudentVerificationRequiredAttribute>(self);
        }
        private static bool IsTrue<T>(SubscriptionPlan self) where T : EnumBooleanAttributeBase
        {
            var planName = self.ToString();
            var plan = self.GetType().GetField(planName)!;

            T attr = plan.GetCustomAttributes(typeof(T), inherit: false).Cast<T>().FirstOrDefault() ??
                throw new InvalidOperationException($"Attribute {typeof(T).Name} is not defined for {planName}.");

            return attr.Value;
        }
    }
}
