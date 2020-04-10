using MetaShare.Common.Core.Daos;
using TestA.Entities;
using TestA.Daos.Interfaces;
using TestA.TestData;

namespace TestA.Daos.Mocks
{
	public class OrganizationDaoMock : MockDao<Organization>, IOrganizationDao
	{
		public OrganizationDaoMock() : base(OrganizationTestData.CreateOrganization())
		{
		}
	}
}
