using PropsEnumSample.Attributes;

namespace PropsEnumSample {
    enum SubscriptionPlanUsingCache {
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

    static class SubscriptionPlanUsingCacheExtensions {

        public static bool IsBillingPromotionFeatureEnabled(this SubscriptionPlanUsingCache self) {
            return IsTrue<BillingPromotionFeatureEnabledAttribute>(self);
        }

        public static bool IsLimitedContentAccessible(this SubscriptionPlanUsingCache self) {
            return IsTrue<LimitedContentAccessibleAttribute>(self);
        }

        public static bool IsDiscountPromotionEnabled(this SubscriptionPlanUsingCache self) {
            return IsTrue<DiscountPromotionEnabledAttribute>(self);
        }

        public static bool IsStudentVerificationRequired(this SubscriptionPlanUsingCache self) {
            return IsTrue<StudentVerificationRequiredAttribute>(self);
        }

        private static Dictionary<SubscriptionPlanUsingCache, bool> _cache = new Dictionary<SubscriptionPlanUsingCache, bool>();

        private static bool IsTrue<T>(SubscriptionPlanUsingCache self) where T : EnumBooleanAttributeBase {
            // If the value is already in the cache, return it.
            if (_cache.ContainsKey(self))
            {
                return _cache[self];
            }

            var planName = Enum.GetName(typeof(SubscriptionPlan), self)!;
            var plan = self.GetType().GetField(planName)!;

            T attr = plan.GetCustomAttributes(typeof(T), inherit: false).Cast<T>().FirstOrDefault() ??
                throw new InvalidOperationException($"Attribute {typeof(T).Name} is not defined for {planName}.");

            _cache[self] = attr.Value;

            return attr.Value;
        }
    }
}
