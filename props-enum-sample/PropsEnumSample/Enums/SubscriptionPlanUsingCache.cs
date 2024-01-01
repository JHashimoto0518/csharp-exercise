using PropsEnumSample.Attributes;

namespace PropsEnumSample.Enums
{
    enum SubscriptionPlanUsingCache
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

    static class SubscriptionPlanUsingCacheExtensions
    {

        public static bool IsBillingPromotionFeatureEnabled(this SubscriptionPlanUsingCache self)
        {
            return IsTrue<BillingPromotionFeatureEnabledAttribute>(self);
        }

        public static bool IsLimitedContentAccessible(this SubscriptionPlanUsingCache self)
        {
            return IsTrue<LimitedContentAccessibleAttribute>(self);
        }

        public static bool IsDiscountPromotionEnabled(this SubscriptionPlanUsingCache self)
        {
            return IsTrue<DiscountPromotionEnabledAttribute>(self);
        }

        public static bool IsStudentVerificationRequired(this SubscriptionPlanUsingCache self)
        {
            return IsTrue<StudentVerificationRequiredAttribute>(self);
        }


        private static bool IsTrue<T>(SubscriptionPlanUsingCache self) where T : EnumBooleanAttributeBase
        {
            var planName = Enum.GetName(typeof(SubscriptionPlan), self)!;
            var plan = self.GetType().GetField(planName)!;

            T attr = plan.GetCustomAttributes(typeof(T), inherit: false).Cast<T>().FirstOrDefault() ??
                throw new InvalidOperationException($"Attribute {typeof(T).Name} is not defined for {planName}.");

            return attr.Value;
        }
    }
}
