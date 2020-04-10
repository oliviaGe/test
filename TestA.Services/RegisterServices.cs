using MetaShare.Common.Core.CommonService;
using TestA.Services.Interfaces;

namespace TestA.Services
{
	public class RegisterServices
	{
		public static void RegisterAll()
		{
			Register(ServiceFactory.Instance, true);
		}

		public static void UnRegisterAll()
		{
			Register(ServiceFactory.Instance, false);
		}

		public static void Register(ServiceFactory factory, bool isRegister)
		{
			factory.Register(typeof(IOrganizationService), new OrganizationService(), isRegister);
		}
	}
}
