using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestA.Entities;
using TestA.TestData;
using TestA.Services.Tests.Common;
using TestA.Services.Interfaces;
namespace TestA.Services.Tests
{

	[TestFixture]
	public class OrganizationServiceTest : CommonServiceTest<Organization, IOrganizationService>
	{
		[TestCase]
		public void SelectAllTest()
		{
			List<Organization> items = this.Service.SelectAll();
			Assert.AreEqual(OrganizationTestData.OrganizationCount, items.Count);
		}

		[TestCase]
		public void SelectByTest()
		{
			Organization itemTest = OrganizationTestData.CreateOrganization1();

			List<Organization> find = this.Service.SelectBy(new Organization {Phone = itemTest.Phone}, new List<string> {"Phone"});
			Assert.IsNotNull(find);

			foreach (Organization item in find)
			{
				Assert.AreEqual(itemTest.Phone, item.Phone);
			}
		}

		[TestCase]
		public void SelectByIdTest()
		{
			Organization itemTest = OrganizationTestData.CreateOrganization1();

			Organization find = this.Service.SelectById(new Organization {Id = itemTest.Id});
			Assert.IsNotNull(find);

			OrganizationTestData.AssertAreEqual(itemTest, find);
		}

		[TestCase]
		public void DeleteTest()
		{
			Organization itemTest = OrganizationTestData.CreateOrganization2();
			int affectedRows = this.Service.Delete(itemTest, true);

			List<Organization> items = this.Service.SelectAll();
			Assert.AreEqual(items.Count, OrganizationTestData.OrganizationCount - 1);
			Assert.AreEqual(-1, affectedRows);
		}

		[TestCase]
		public void InsertTest()
		{
			Organization itemTest = new Organization
			{
				Phone = string.Empty, 
				Description = string.Empty, 
				Name = string.Empty, 
			};

			int affectedRows = this.Service.Insert(itemTest, true);

			List<Organization> items = this.Service.SelectAll();
			Assert.AreEqual(items.Count, OrganizationTestData.OrganizationCount + 1);
			Assert.AreEqual(1, affectedRows);
		}

		[TestCase]
		public void UpdateTest()
		{
			Organization itemTest = OrganizationTestData.CreateOrganization1();

			Organization beforeUpdate = this.Service.SelectById(new Organization {Id = itemTest.Id});
			beforeUpdate.Phone = string.Empty ;
			this.Service.Update(beforeUpdate, true);

			Organization afterUpdate = this.Service.SelectById(new Organization {Id = itemTest.Id});
			OrganizationTestData.AssertAreEqual(beforeUpdate, afterUpdate);
		}
	}

}
