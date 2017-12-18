namespace Byndyusoft.Extensions.Dapper.DbTypes
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using global::Dapper;
    using Microsoft.SqlServer.Server;

    public class Int16IdsList : SqlMapper.ICustomQueryParameter
    {
        private readonly IEnumerable<short> _ids;

        public Int16IdsList(IEnumerable<short> ids)
        {
            _ids = ids;
        }

        public void AddParameter(IDbCommand command, string name)
        {
            var sqlCommand = (SqlCommand) command;
            sqlCommand.Parameters.Add(GetParameter(name));
        }

        private SqlParameter GetParameter(string name)
        {
            var numberList = new List<SqlDataRecord>();

            var tvpDefinition = new[] {new SqlMetaData("id", SqlDbType.SmallInt)};

            foreach (var id in _ids)
            {
                var rec = new SqlDataRecord(tvpDefinition);
                rec.SetInt16(0, id);
                numberList.Add(rec);
            }

            return new SqlParameter
                   {
                       ParameterName = name,
                       SqlDbType = SqlDbType.Structured,
                       Direction = ParameterDirection.Input,
                       TypeName = "Int16IdsList",
                       Value = numberList
                   };
        }
    }
}