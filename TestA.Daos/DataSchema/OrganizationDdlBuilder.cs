using MetaShare.Common.Core.DataSchema;

namespace TestA.Daos.DataSchema
{
	public class OrganizationDdlBuilder : DdlBuilder
	{
		public override string GetSqlCreateTable()
		{
			return @"CREATE TABLE Organization(Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,Phone nvarchar(255),Description nvarchar(255),Name nvarchar(255),Description nvarchar(255),Owner_Id int,Entity_Status int)";
		}

		public override string GetSqlDropTable()
		{
			return @"DROP TABLE Organization";
		}

		public override string GetSqlExistTable()
		{
			return @"SELECT COUNT(*) FROM Information_Schema.COLUMNS WHERE TABLE_NAME = 'Organization'";
		}
	}
}
