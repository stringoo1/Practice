using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace StoreSystem.Database
{
    public abstract class AccessorBase : IDisposable
    {
        // SQLコネクション
        private SqlConnection con;

        // コンストラクタ
        protected AccessorBase()
        {
            var conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user01\source\repos\Practice\StoreSystem\Database1.mdf;Integrated Security=True";
            this.con = new SqlConnection(conString);
            this.con.Open();
        }

        // SQLコマンドを生成する(パラメータなし)
        private SqlCommand CreateCommand(string sqlQuery, List<SqlParameter> parameters)
        {
            var cmd = this.con.CreateCommand();
            cmd.CommandText = sqlQuery;

            if (parameters != null && parameters.Count != 0)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                }
            }

            return cmd;
        }

        // 結果をリスト形式で返す
        protected List<T> ExecuteReader<T>(string sqlQuery, List<SqlParameter> parameters, Func<SqlDataReader, T> func)
        {
            var cmd = this.CreateCommand(sqlQuery, parameters);
            var reader = cmd.ExecuteReader();

            List<T> result = new List<T>();

            while (reader.Read())
            {
                result.Add(func(reader));
            }

            return result;
        }

        // 影響を受けた件数を返す
        protected int ExecuteNonQuery(string sqlQuery, List<SqlParameter> parameters)
        {
            return this.CreateCommand(sqlQuery, parameters).ExecuteNonQuery();
        }

        public void Dispose()
        {
            con.Close();
        }
    }
}
