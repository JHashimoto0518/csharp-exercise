namespace PropsEnumSample {
    [AttributeUsage(AttributeTargets.Field)]
    abstract internal class EnumEnableAttributeBase(bool enabled) : Attribute {
        public bool Enabled { get; } = enabled;
    }
}
