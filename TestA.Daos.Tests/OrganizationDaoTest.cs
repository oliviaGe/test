using System.Collections.Generic;
using NUnit.Framework;
using System;
using TestA.Daos.Interfaces;
using TestA.Daos.DataSchema;
using TestA.TestData;
using TestA.Daos.Tests.Common;
using TestA.Entities;

namespace TestA.Daos.Tests
{
	public class OrganizationDaoTest : CommonDaoTest<Organization, IOrganizationDao, OrganizationDdlBuilder>
	{
		public OrganizationDaoTest() : base(OrganizationTestData.CreateOrganization())
		{
		}

		[TestCase]
		public void SelectAllTest()
		{
			Assert.AreEqual(OrganizationTestData.OrganizationCount, this.Dao.SelectAll(this.Context).Count);
		}

		[TestCase]
		public void SelectByIdTest()
		{
			Organization item = OrganizationTestData.CreateOrganization1();
			Organization find = this.Dao.SelectById(this.Context, item);

			Assert.AreEqual(item.Id, find.Id);
			OrganizationTestData.AssertAreEqual(item, find);
		}

		[TestCase]
		public void InsertTest()
		{
			Organization item = new Organization
			{
				Phone = string.Empty, 
				Description = string.Empty, 
				Name = string.Empty, 
			};
			int affectedRows = this.Dao.Insert(this.Context, item);
			Assert.AreEqual(1, affectedRows);

			Organization find = this.Dao.SelectById(this.Context, item);
			OrganizationTestData.AssertAreEqual(item, find);

			List<Organization> items = this.Dao.SelectAll(this.Context);
			Assert.AreEqual(OrganizationTestData.OrganizationCount + 1, items.Count);
		}

		[TestCase]
		public void UpdateTest()
		{
			Organization item = OrganizationTestData.CreateOrganization1();
			Organization beforeUpdate = this.Dao.SelectById(this.Context, item);
			Assert.IsNotNull(beforeUpdate);
			beforeUpdate.Phone = string.Empty;

			this.Dao.Update(this.Context, beforeUpdate);

			Organization afterUpdate = this.Dao.SelectById(this.Context, beforeUpdate);
			OrganizationTestData.AssertAreEqual(beforeUpdate, afterUpdate);
		}

		[TestCase]
		public void DeleteTest()
		{
			Organization item = OrganizationTestData.CreateOrganization1();
			Organization beforedelete = this.Dao.SelectById(this.Context, item);
			Assert.IsNotNull(beforedelete);

			int affectedRows = this.Dao.Delete(this.Context, beforedelete);
			Assert.AreEqual(1, affectedRows);

			Organization afterDelete = this.Dao.SelectById(this.Context, beforedelete);
			Assert.IsNull(afterDelete);

			List<Organization> items = this.Dao.SelectAll(this.Context);
			Assert.AreEqual(OrganizationTestData.OrganizationCount - 1, items.Count);
		}
	}
}
