using System.Collections.Generic;
using MetaShare.Common.Core.Entities;
using TestA.Entities;
using MetaShare.Common.Core.Services;
using TestA.Daos.Interfaces;
using TestA.Services.Interfaces;


namespace TestA.Services
{
	public class OrganizationService : Service<Organization>, IOrganizationService
	{
		public OrganizationService() : base(typeof (IOrganizationDao))
		{
		}

	}
}
