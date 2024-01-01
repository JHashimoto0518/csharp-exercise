namespace PropsEnumSample.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    abstract internal class EnumBooleanAttributeBase(bool value) : Attribute
    {
        public bool Value { get; } = value;
    }
}
