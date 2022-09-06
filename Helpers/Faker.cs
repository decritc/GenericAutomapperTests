using Bogus;
using TestBed;

namespace TestBed.Helpers
{
    public class Faker
    {
        public static Faker<U> FromAnonymousType<U>(U obj) where U : class
        {
            int FindConstructorLength()
            {
                return typeof(U).GetConstructors().First().GetParameters().Length;
            }

            var count = FindConstructorLength();

            var args = new object[count];

            var anonBinder = new AnonBinder();

            return new Faker<U>(binder: anonBinder)
               .CustomInstantiator(_ =>
                  Activator.CreateInstance(typeof(U), args: args) as U);
        }
    }
}
