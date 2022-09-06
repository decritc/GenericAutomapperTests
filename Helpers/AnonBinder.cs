using System.Reflection;

namespace TestBed.Helpers
{
    public class AnonBinder : Bogus.Binder
    {
        public override Dictionary<string, MemberInfo> GetMembers(Type t)
        {
            var group = t.GetMembers(BindingFlags)
                  .Where(m =>
                    {
                        if (m is FieldInfo fi)
                        {
                            return fi.IsPrivate;
                        }

                        return false;
                    })
                  .GroupBy(mi =>
                     {
                         return mi.Name
                       .Replace("i__Field", "")
                       .Replace('<', ' ')
                       .Replace('>', ' ')
                       .Trim();
                     });

            return group.ToDictionary(k => k.Key, g => g.First());
        }
    }
}
