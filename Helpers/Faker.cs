using Bogus;

namespace GenericAutomapperTests.Helpers
{
    public static class Faker
    {
        public static Faker<T> FromAnonymousType<T>(T obj) where T : class
        {
            int FindConstructorLength()
            {
                return typeof(T).GetConstructors().First().GetParameters().Length;
            }

            var count = FindConstructorLength();

            var args = new object[count];

            var anonBinder = new AnonymousBinder();

            return new Faker<T>(binder: anonBinder)
               .CustomInstantiator(_ =>
                  Activator.CreateInstance(typeof(T), args: args) as T ?? throw new ArgumentNullException());
        }
    }
}
