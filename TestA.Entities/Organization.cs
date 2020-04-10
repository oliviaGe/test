using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MetaShare.Common.Core.Entities;

namespace TestA.Entities
{
	public class Organization : MetaShare.Common.Core.Entities.Common
	{
		[DataMember]
		public string Phone {get; set;}

	}
}
