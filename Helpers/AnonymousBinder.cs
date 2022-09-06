using System.Reflection;

namespace GenericAutomapperTests.Helpers
{
    public class AnonymousBinder : Bogus.Binder
    {
        public override Dictionary<string, MemberInfo> GetMembers(Type type)
        {
            var group = type.GetMembers(BindingFlags)
                  .Where(member =>
                    {
                        if (member is FieldInfo fieldInfo)
                        {
                            return fieldInfo.IsPrivate;
                        }

                        return false;
                    })
                  .GroupBy(memberInfo =>
                     {
                         return memberInfo.Name
                       .Replace("i__Field", "")
                       .Replace('<', ' ')
                       .Replace('>', ' ')
                       .Trim();
                     });

            return group.ToDictionary(k => k.Key, info => info.First());
        }
    }
}
