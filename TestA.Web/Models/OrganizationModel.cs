using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestA.Entities;

namespace TestA.Web.Models
{
	public class OrganizationModel: CommonModel<Organization>
	{
		public string Phone {get; set;}

		public override void PopulateFrom(Organization entity)
		{
			if (entity == null) return;
			base.PopulateFrom(entity);

			this.Phone = entity.Phone;
		}

		public override void PopulateTo(Organization entity)
		{
			if (entity == null) return;
			base.PopulateTo(entity);

			entity.Phone = this.Phone;

		}
	}
}
