using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PropsEnumSample {
    enum SubscriptionPlan {
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

    // SubscriptionPlanの拡張メソッドを定義する
    static class SubscriptionPlanExtensions {

        public static bool IsBillingPromotionFeatureEnabled(this SubscriptionPlan self) {
            return IsEnabled<BillingPromotionFeatureEnabledAttribute>(self);
        }

        public static bool IsLimitedContentAccessible(this SubscriptionPlan self) {
            return IsEnabled<LimitedContentAccessibleAttribute>(self);
        }

        public static bool IsDiscountPromotionEnabled(this SubscriptionPlan self) {
            return IsEnabled<DiscountPromotionEnabledAttribute>(self);
        }

        public static bool IsStudentVerificationRequired(this SubscriptionPlan self) {
            return IsEnabled<StudentVerificationRequiredAttribute>(self);
        }
        private static bool IsEnabled<T>(SubscriptionPlan self) where T : EnumEnableAttributeBase {
            var planName = Enum.GetName(typeof(SubscriptionPlan), self)!;
            var plan = self.GetType().GetField(planName)!;

            T attr = plan.GetCustomAttributes(typeof(T), inherit: false).Cast<T>().FirstOrDefault() ??
                throw new InvalidOperationException($"Attribute {typeof(T).Name} is not defined for {planName}.");

            return attr.Enabled;
        }

    }
}
