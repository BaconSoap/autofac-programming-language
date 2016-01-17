namespace AutofacProgrammingLanguage.ValueProviders
{
    public class ConcatValueProvider<TValueProvider1, TValueProvider2>: IValueProvider
        where TValueProvider1: IValueProvider
        where TValueProvider2: IValueProvider
    {
        private readonly TValueProvider1 _provider1;
        private readonly TValueProvider2 _provider2;

        public ConcatValueProvider(TValueProvider1 provider1, TValueProvider2 provider2)
        {
            _provider1 = provider1;
            _provider2 = provider2;
        }

        public string Provide()
        {
            return _provider1.Provide() + _provider2.Provide();
        }
    }
}