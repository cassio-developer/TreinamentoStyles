using System;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace Treinamento.ViewModels.Base
{
	public abstract class ExtendedBindableObject : BindableObject
	{

		#region Protected Methods

		protected void RaisePropertyChanged<T>(Expression<Func<T>> property)
		{
			var name = GetMemberInfo(property).Name;
			OnPropertyChanged(name);
		}

		#endregion Protected Methods

		#region Private Methods

		private MemberInfo GetMemberInfo(Expression expression)
		{
			MemberExpression operand;
			LambdaExpression lambdaExpression = (LambdaExpression)expression;
			if (lambdaExpression.Body is UnaryExpression body)
			{
				operand = (MemberExpression)body.Operand;
			}
			else
			{
				operand = (MemberExpression)lambdaExpression.Body;
			}
			return operand.Member;
		}

		#endregion Private Methods
	}
}
