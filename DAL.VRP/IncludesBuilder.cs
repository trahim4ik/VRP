using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;

namespace VRP.DAL {
    public static class IncludesBuilder {

        public static bool TryParsePath(Expression expression, out string path) {
            path = null;
            var withoutConvert = expression.RemoveConvert();
            var memberExpression = withoutConvert as MemberExpression;
            var callExpression = withoutConvert as MethodCallExpression;

            if (memberExpression != null) {

                var thisPart = memberExpression.Member.Name;
                if (!TryParsePath(memberExpression.Expression, out var parentPart)) {
                    return false;
                }
                path = parentPart == null ? thisPart : (parentPart + "." + thisPart);

            } else if (callExpression != null) {

                if (callExpression.Method.Name != "Select" || callExpression.Arguments.Count != 2) return false;

                if (!TryParsePath(callExpression.Arguments[0], out var parentPart)) {
                    return false;
                }

                if (parentPart == null) return false;

                if (!(callExpression.Arguments[1] is LambdaExpression subExpression)) return false;

                if (!TryParsePath(subExpression.Body, out var thisPart)) {
                    return false;
                }

                if (thisPart == null) return false;

                path = parentPart + "." + thisPart;
                return true;
            }

            return true;
        }

    }
}
