using System;
using System.Data.SqlClient;
using System.Data;

namespace SQLManager
{
    public class DataToDB
    {
        private SqlConnection conn;
        private SqlConnectionStringBuilder builder;

        public DataToDB(string connectionString)
        {
            builder = new SqlConnectionStringBuilder(connectionString);
            builder.ApplicationName = "BatchInsert";
            builder.Pooling = false;
            builder.LoadBalanceTimeout = 0;
            conn = new SqlConnection(builder.ToString());
        }

        public void OperationManager(string tableName, Up2DataSpreadsheetStruct data)
        {
            try
            {
                bool dataExist = Select(tableName, data);

                if (dataExist)
                    Update(tableName, data);
                else
                    Insert(tableName, data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Insert(string tableName, Up2DataSpreadsheetStruct data)
        {
            string SQL_query = $"INSERT INTO {tableName} ";
            SQL_query += $"(ACAO,EMPRESA,NCONTATOS,QUANTIDADE,VALOR,TAXA_D_Min,TAXA_D,TAXA_D_Max,TAXA_T_Min,TAXA_T,TAXA_T_max,DATA_ARQUIVO,DATA_ENTRADA,MERCADO_NOME) ";
            SQL_query += $"values (@acao,@empresa,@ncontratos,@qtde,@valor,@d_min,@d,@d_max,@t_min,@t,@t_max,@data_arq,@data_ent,@mercado)";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_query, conn);

                cmd.Parameters.Add("@acao", SqlDbType.VarChar);
                cmd.Parameters.Add("@empresa", SqlDbType.VarChar);
                cmd.Parameters.Add("@ncontratos", SqlDbType.Float);
                cmd.Parameters.Add("@qtde", SqlDbType.Float);
                cmd.Parameters.Add("@valor", SqlDbType.Float);
                cmd.Parameters.Add("@d_min", SqlDbType.Float);
                cmd.Parameters.Add("@d", SqlDbType.Float);
                cmd.Parameters.Add("@d_max", SqlDbType.Float);
                cmd.Parameters.Add("@t_min", SqlDbType.Float);
                cmd.Parameters.Add("@t", SqlDbType.Float);
                cmd.Parameters.Add("@t_max", SqlDbType.Float);
                cmd.Parameters.Add("@data_arq", SqlDbType.DateTime);
                cmd.Parameters.Add("@data_ent", SqlDbType.DateTime);
                cmd.Parameters.Add("@mercado", SqlDbType.VarChar);

                cmd.Parameters["@acao"].Value = data.ACAO;
                cmd.Parameters["@empresa"].Value = data.EMPRESA;
                cmd.Parameters["@ncontratos"].Value = data.NCONTATOS;
                cmd.Parameters["@qtde"].Value = data.QUANTIDADE;
                cmd.Parameters["@valor"].Value = data.VALOR;
                cmd.Parameters["@d_min"].Value = data.TAXA_D_Min;
                cmd.Parameters["@d"].Value = data.TAXA_D;
                cmd.Parameters["@d_max"].Value = data.TAXA_D_Max;
                cmd.Parameters["@t_min"].Value = data.TAXA_T_Min;
                cmd.Parameters["@t"].Value = data.TAXA_T;
                cmd.Parameters["@t_max"].Value = data.TAXA_T_max;
                cmd.Parameters["@data_arq"].Value = data.DATA_ARQUIVO;
                cmd.Parameters["@data_ent"].Value = data.DATA_ENTRADA;
                cmd.Parameters["@mercado"].Value = data.MERCADO_NOME;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Error:" + ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        private void Update(string tableName, Up2DataSpreadsheetStruct data)
        {
            string SQL_query = $"UPDATE {tableName} SET " +
                "EMPRESA=@empresa," + "NCONTATOS=@ncontratos," +
                "QUANTIDADE=@qtde," + "VALOR=@valor," +
                "TAXA_D_Min=@d_min," + "TAXA_D=@d," +
                "TAXA_D_Max=@d_max," + "TAXA_T_Min=@t_min," +
                "TAXA_T=@t," + "TAXA_T_max=@t_max," +
                "DATA_ENTRADA=@data_ent" +
                " WHERE ACAO=@acao AND MERCADO_NOME=@mercado AND DATA_ARQUIVO=@data_arq";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_query, conn);

                cmd.Parameters.Add("@acao", SqlDbType.VarChar);
                cmd.Parameters.Add("@empresa", SqlDbType.VarChar);
                cmd.Parameters.Add("@ncontratos", SqlDbType.Float);
                cmd.Parameters.Add("@qtde", SqlDbType.Float);
                cmd.Parameters.Add("@valor", SqlDbType.Float);
                cmd.Parameters.Add("@d_min", SqlDbType.Float);
                cmd.Parameters.Add("@d", SqlDbType.Float);
                cmd.Parameters.Add("@d_max", SqlDbType.Float);
                cmd.Parameters.Add("@t_min", SqlDbType.Float);
                cmd.Parameters.Add("@t", SqlDbType.Float);
                cmd.Parameters.Add("@t_max", SqlDbType.Float);
                cmd.Parameters.Add("@data_arq", SqlDbType.DateTime);
                cmd.Parameters.Add("@data_ent", SqlDbType.DateTime);
                cmd.Parameters.Add("@mercado", SqlDbType.VarChar);

                cmd.Parameters["@acao"].Value = data.ACAO;
                cmd.Parameters["@empresa"].Value = data.EMPRESA;
                cmd.Parameters["@ncontratos"].Value = data.NCONTATOS;
                cmd.Parameters["@qtde"].Value = data.QUANTIDADE;
                cmd.Parameters["@valor"].Value = data.VALOR;
                cmd.Parameters["@d_min"].Value = data.TAXA_D_Min;
                cmd.Parameters["@d"].Value = data.TAXA_D;
                cmd.Parameters["@d_max"].Value = data.TAXA_D_Max;
                cmd.Parameters["@t_min"].Value = data.TAXA_T_Min;
                cmd.Parameters["@t"].Value = data.TAXA_T;
                cmd.Parameters["@t_max"].Value = data.TAXA_T_max;
                cmd.Parameters["@data_arq"].Value = data.DATA_ARQUIVO;
                cmd.Parameters["@data_ent"].Value = data.DATA_ENTRADA;
                cmd.Parameters["@mercado"].Value = data.MERCADO_NOME;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Error:" + ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }

        private bool Select(string tableName, Up2DataSpreadsheetStruct data)
        {
            bool existDataInDb = false;

            string SQL_query = $"SELECT ACAO FROM {tableName} WHERE ACAO=@acao AND MERCADO_NOME=@mercado AND DATA_ARQUIVO=@data_arq";

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_query, conn);

                cmd.Parameters.Add("@acao", SqlDbType.VarChar);
                cmd.Parameters.Add("@data_arq", SqlDbType.DateTime);
                cmd.Parameters.Add("@mercado", SqlDbType.VarChar);

                cmd.Parameters["@acao"].Value = data.ACAO;
                cmd.Parameters["@data_arq"].Value = data.DATA_ARQUIVO;
                cmd.Parameters["@mercado"].Value = data.MERCADO_NOME;

                //cmd.ExecuteNonQuery();                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        existDataInDb = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insert Error:" + ex.Message);

            }
            finally
            {
                conn.Close();
            }

            return existDataInDb;
        }
    }
}
