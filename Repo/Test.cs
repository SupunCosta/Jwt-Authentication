using System.Text.RegularExpressions;

namespace JwtAuthentication.Repo
{
    public class Test
    {
        public bool DateConflict(string mc)
        {

            var s1 = "PM";
            var s2 = mc;
            var containsBothValues = false;

            if (mc == null)
            {
                return containsBothValues;
            }

            var pattern = "[" + Regex.Escape(s1.ToLower()) + "]";
            var result = Regex.Replace(s2.ToLower(), pattern, "");

            containsBothValues = result.Length == s2.Length - s1.Length;


            return containsBothValues;


        }
    }
}
