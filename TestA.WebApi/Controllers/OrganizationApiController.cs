using System;
using System.Web.Http;
using System.Collections.Generic;
using TestA.Entities;
using TestA.Services.Interfaces;
using TestA.WebApi.Models;

namespace TestA.WebApi.Controllers
{
	public class OrganizationApiController : CommonApiController<Organization, IOrganizationService>
	{


	}
}
