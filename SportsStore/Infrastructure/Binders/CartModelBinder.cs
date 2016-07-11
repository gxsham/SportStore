using System;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Infrastructure.Binders
{
	//public class CartModelBinder : IModelBinder
	//{
	//	private const string sessionKey = "Cart";
	//	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
	//	{
	//		// get the Cart from the session
	//		Cart cart = null;
	//		if (controllerContext.HttpContext.Session != null)
	//		{
	//			cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
	//		}	
	//		// create the Cart if there wasn't one in the session data
	//		if (cart == null)
	//		{
	//			cart = new Cart();
	//			if (controllerContext.HttpContext.Session != null)
	//			{
	//				controllerContext.HttpContext.Session[sessionKey] = cart;
	//			}
	//		}
	//		// return the cart
	//		return cart;
	//	}
	//}

	public class AutoBinder<T> : IModelBinder where T : class
	{
		private readonly string sessionKey = nameof(T);
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			// get the Cart from the session
			T cart = null;
			if (controllerContext.HttpContext.Session != null)
			{
				cart = (T)controllerContext.HttpContext.Session[sessionKey];
			}
			// create the Cart if there wasn't one in the session data
			if (cart == null)
			{
				cart = Activator.CreateInstance<T>();
				if (controllerContext.HttpContext.Session != null)
				{
					controllerContext.HttpContext.Session[sessionKey] = cart;
				}
			}
			// return the cart
			return cart;
		}
	}
	//public class DelegateBinder<T> : IModelBinder
	//{
	//	private Func<ControllerContext, ModelBindingContext, T> _delegate;

	//	public DelegateBinder(Func<ControllerContext, ModelBindingContext, T> func)
	//	{
	//		_delegate = func;
	//	}

	//	public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
	//	{
	//		return _delegate(controllerContext, bindingContext);
	//	}
	//}
} 