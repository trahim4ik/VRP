using System;
using System.Linq.Expressions;

namespace VRP.Core.Extensions {
    public static class Predicate {
        public static Func<bool> And(this Func<bool> left, Func<bool> right) {
            return () => left() && right();
        }

        public static Func<T, bool> And<T>(this Func<T, bool> left, Func<T, bool> right) {
            return a => left(a) && right(a);
        }

        public static Func<T, T2, bool> And<T, T2>(this Func<T, T2, bool> left, Func<T, T2, bool> right) {
            return (a, b) => left(a, b) && right(a, b);
        }

        public static Expression<Func<bool>> And(this Expression<Func<bool>> left, Expression<Func<bool>> right) {
            return Expression.Lambda<Func<bool>>(Expression.AndAlso(left.Body, right.Body));
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, right.WithParametersOf(left).Body), left.Parameters);
        }

        public static Expression<Func<T, T2, bool>> And<T, T2>(this Expression<Func<T, T2, bool>> left, Expression<Func<T, T2, bool>> right) {
            return Expression.Lambda<Func<T, T2, bool>>(Expression.AndAlso(left.Body, right.WithParametersOf(left).Body), left.Parameters);
        }

        public static Expression<Func<bool>> Or(this Expression<Func<bool>> left, Expression<Func<bool>> right) {
            return Expression.Lambda<Func<bool>>(Expression.OrElse(left.Body, right.Body));
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right) {
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, right.WithParametersOf(left).Body), left.Parameters);
        }

        public static Expression<Func<T, T2, bool>> Or<T, T2>(this Expression<Func<T, T2, bool>> left, Expression<Func<T, T2, bool>> right) {
            return Expression.Lambda<Func<T, T2, bool>>(Expression.OrElse(left.Body, right.WithParametersOf(left).Body), left.Parameters);
        }

        private static Expression<Func<TResult>> WithParametersOf<T, TResult>(this Expression<Func<T, TResult>> left, Expression<Func<T, TResult>> right) {
            return new ReplaceParameterVisitor<Func<TResult>>(left.Parameters[0], right.Parameters[0]).Visit(left);
        }

        private static Expression<Func<TResult>> WithParametersOf<T, T2, TResult>(this Expression<Func<T, T2, TResult>> left, Expression<Func<T, T2, TResult>> right) {
            var replaced = new ReplaceParameterVisitor<Func<T, TResult>>(left.Parameters[1], right.Parameters[1]).Visit(left);
            return new ReplaceParameterVisitor<Func<TResult>>(replaced.Parameters[0], right.Parameters[0]).Visit(replaced);
        }
    }
}
