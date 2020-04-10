using System;
using System.Data;
using MetaShare.Common.Core.Daos;
using TestA.Daos.Interfaces;
using TestA.Entities;

namespace TestA.Daos
{
	public class OrganizationDao : CommonObjectDao<Organization>, IOrganizationDao
	{
		public class OrganizationSqlBuilder : ObjectSqlBuilder
		{
			public OrganizationSqlBuilder(SqlDialect sqlDialect) : base(sqlDialect,"Organization")
			{
				this.SqlInsert = "INSERT INTO Organization (Phone," + this.SqlBaseFieldInsertFront + ") VALUES (@Phone," + this.SqlBaseFieldInsertBack + ")";
				this.SqlUpdate = "UPDATE Organization SET Phone=@Phone," + this.SqlBaseFieldUpdate + " WHERE Id=@Id";
			}
		}

		public class OrganizationResultHandler : CommonObjectResultHandler<Organization>
		{
			public override void GetColumnValues(IDataReader reader, Organization item)
			{
				base.GetColumnValues(reader, item);
				int ordinalPhone = reader.GetOrdinal("Phone");
				item.Phone = reader.IsDBNull(ordinalPhone) ? null : reader.GetString(ordinalPhone);
			}

			public override void AddInsertParameters(IContext context, IDbCommand command, Organization item)
			{
				base.AddInsertParameters(context, command, item);
				context.AddParameter(command, "Phone", item.Phone ?? (object) DBNull.Value);
			}
		}

		public OrganizationDao(SqlDialect sqlDialect) : base(new OrganizationSqlBuilder(sqlDialect), new OrganizationResultHandler())
		{
		}

		public OrganizationDao(SqlDialect sqlDialect, string schemaConnectionString) : base(new OrganizationSqlBuilder(sqlDialect), new OrganizationResultHandler(), schemaConnectionString)
		{
		}
	}
}
