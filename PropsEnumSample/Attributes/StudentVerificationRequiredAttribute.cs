namespace PropsEnumSample.Attributes
{
    internal class StudentVerificationRequiredAttribute(bool enabled) : EnumEnableAttributeBase(enabled)
    {
    }
}
