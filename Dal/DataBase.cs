using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;


namespace Dal
{
    public class DataBase
    {
        public DataBase()
        {

        }
        /// <summary>
        ///  返回数据库连接
        /// </summary>

        private SqlConnection Con()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            return con;
        }

        /// <summary>
        /// 执行无返回值的sql语句，如果成功返回 1 ，否则失败 
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteSql(string sql)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 执行无返回值的sql语句，如果成功返回 1，否则失败 ，带参数
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteSql(string sql, SqlParameter[] p)
        {
            SqlConnection con = Con();

            SqlCommand com = new SqlCommand(sql, con);
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }

        }

        /// <summary>
        /// 执行多条无返回值的sql语句，如果成功返回 1，否则失败 
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回1成功</returns> 
        public int ExecuteSqls(string[] sql)
        {
            SqlConnection con = Con();

            SqlCommand com = new SqlCommand();
            int i = sql.Length;
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                com.Connection = con;
                com.Transaction = tran;
                foreach (string str in sql)
                {
                    com.CommandText = str;
                    com.ExecuteNonQuery();
                }
                tran.Commit();
                return 1;
            }
            catch (SqlException e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
        }

        /// <summary>
        /// 执行多条无返回值的sql语句，如果成功返回 影响条数，否则失败返回-1，带参数
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteSqls(string[] sql, SqlParameter[] p)
        {
            SqlConnection con = Con();

            SqlCommand com = new SqlCommand();
            int i = sql.Length;
            int j = p.Length;
            for (int k = 0; k < j; k++)
            {
                com.Parameters.Add(p[k]);
            }
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                com.Connection = con;
                com.Transaction = tran;
                foreach (string str in sql)
                {
                    com.CommandText = str;
                    com.ExecuteNonQuery();

                }
                tran.Commit();
                return 1;
            }
            catch (SqlException e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
            }
        }

        /// <summary>
        /// 执行无返回值的 存储过程，如果成功返回 影响条数，否则失败返回-1
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteProc(string proc)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(proc, con);

            com.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 执行无返回值的 存储过程，如果成功返回 影响条数，否则失败返回-1，带参数
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteProc(string proc, SqlParameter[] p)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(proc, con);
            com.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                com.Parameters.Clear();
                com.Dispose();//释放资源
            }
        }

        /// <summary>
        /// 执行多条无返回值的存储过程，如果成功返回 1，否则失败 
        /// </summary>
        /// <param name="sql">不带参数存储过程组</param>
        /// <returns>返回1成功</returns> 
        public int ExecuteProces(string[] procs)
        {
            SqlConnection con = Con();

            SqlCommand com = new SqlCommand();
            int i = procs.Length;
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                com.Connection = con;
                com.Transaction = tran;
                foreach (string str in procs)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = str;
                    com.ExecuteNonQuery();
                }
                tran.Commit();
                return 1;
            }
            catch (SqlException e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
        }

        /// <summary>
        /// 执行多条无返回值的sql语句，如果成功返回 影响条数，否则失败返回-1，带参数
        /// </summary>
        /// <param name="sql">带集聚函数SQl语句</param>
        /// <returns>返回-1失败</returns> 
        public int ExecuteProces(string[] procs, SqlParameter[] p)
        {
            SqlConnection con = Con();

            SqlCommand com = new SqlCommand();
            int i = procs.Length;
            int j = p.Length;
            for (int k = 0; k < j; k++)
            {
                com.Parameters.Add(p[k]);
            }
            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            try
            {
                com.Connection = con;
                com.Transaction = tran;
                foreach (string str in procs)
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandText = str;
                    com.ExecuteNonQuery();

                }
                tran.Commit();
                return 1;
            }
            catch (SqlException e)
            {
                tran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();
                con.Close();
            }
        }

        /// <summary>
        /// 无参数利用SQL语句获得数据表
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, Con());
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// 无参数利用存储过程获得数据表
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableproc(string proc)
        {
            DataTable dt = new DataTable();
            {
                SqlDataAdapter da = new SqlDataAdapter(proc, Con());
                da.Fill(dt);
            }
            return dt;
        }




        /// <summary>
        /// 有参数利用SQL语句获得数据表
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(string sql, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = Con();
            SqlCommand cmd = new SqlCommand(sql, conn);
            for (int i = 0; i < param.Length; i++)
            {
                cmd.Parameters.Add(param[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Parameters.Clear();
            return dt;
        }

        /// <summary>
        /// 有参数利用存储过程获得数据表
        /// </summary>
        /// <param name="proc">存储过程</param>
        /// <param name="param">参数数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableproc(string proc, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = Con();
            SqlCommand cmd = new SqlCommand(proc, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < param.Length; i++)
            {
                cmd.Parameters.Add(param[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        ///ExecuteValue(string sql) 是为基类的 一个方法 可以提供sql命令执行并  成功 返回非空值
        /// </summary>

        public string ExecuteValue(string sql)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);

            try
            {
                con.Open();
                object ob = com.ExecuteScalar();
                if (ob != null)
                    return ob.ToString();
                else
                    return null;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }

        }

        /// <summary>
        ///ExecuteValue(string sql) 带参数重载
        /// </summary>

        public string ExecuteValue(string sql, SqlParameter[] p)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);

            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                object ob = com.ExecuteScalar();
                if (ob != null)
                    return ob.ToString();
                else
                    return null;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }

        }

        /// <summary>
        ///ExecuteValue(string sql) 是为基类的 一个方法  存储过程 命令执行并  成功 返回非空值
        /// </summary>

        public string ExecuteValueProc(string sql)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                object ob = com.ExecuteScalar();
                if (ob != null)
                    return ob.ToString();
                else
                    return null;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }

        }

        /// <summary>
        ///ExecuteValue(string sql) 带参数重载
        /// </summary>

        public string ExecuteValueProc(string sql, SqlParameter[] p)
        {
            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                object ob = com.ExecuteScalar();
                if (ob != null)
                    return ob.ToString();
                else
                    return null;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }

        }


        /// <summary>
        /// 邦定数据到 控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">GridView控件或datalist</param>



        public void BindProc(string sql, GridView gv)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        public void BindProc(string sql, GridView gv, SqlParameter[] p)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();

                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }


        /// <summary>
        /// 邦定数据到 控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">GridView控件或datalist</param>



        public void Bind(string sql, GridView gv)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        public void Bind(string sql, GridView gv, SqlParameter[] p)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();

                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 邦定数据到 控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">GridView控件或datalist</param>



        public void Bind(string sql, DataList gv)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        public void Bind(string sql, DataList gv, SqlParameter[] p)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();

                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }




        /// <summary>
        /// 邦定数据到分页控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">GridView控件</param>
        /// <param name="anp">分页控件</param>


        public void BindAspNetPager(string sql, int count, GridView gv, AspNetPager anp)
        {

            SqlConnection con = Con();
            sql = string.Format(sql, (anp.CurrentPageIndex - 1) * anp.PageSize, (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize);//, query);
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }



        public void BindAspNetPager(string sql, int count, GridView gv, AspNetPager anp, SqlParameter[] p)
        {

            SqlConnection con = Con();
            sql = string.Format(sql, (anp.CurrentPageIndex - 1) * anp.PageSize, (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize);//, query);
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 邦定数据到分页控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">Datalist控件</param>
        /// <param name="anp">分页控件</param>


        public void BindAspNetPager(string sql, int count, System.Web.UI.WebControls.DataList gv, AspNetPager anp)
        {

            SqlConnection con = Con();
            sql = string.Format(sql, (anp.CurrentPageIndex - 1) * anp.PageSize, (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize);//, query);
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }



        public void BindAspNetPager(string sql, int count, DataList gv, AspNetPager anp, SqlParameter[] p)
        {

            SqlConnection con = Con();
            sql = string.Format(sql, (anp.CurrentPageIndex - 1) * anp.PageSize, (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize);//, query);
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 邦定数据到分页控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">GridView控件</param>
        /// <param name="anp">分页控件</param>


        public void BindAspNetPagerProc(string sql, int count, GridView gv, AspNetPager anp)
        {

            SqlConnection con = Con();
            SqlParameter[] p1 = new SqlParameter[2];


            p1[0] = new SqlParameter("@page1", SqlDbType.Int);
            p1[0].Value = (anp.CurrentPageIndex - 1) * anp.PageSize;

            p1[1] = new SqlParameter("@page2", SqlDbType.Int);
            p1[1].Value = (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize;

            SqlCommand com = new SqlCommand(sql, con);
            for (int i = 0; i < p1.Length; i++)
            {
                com.Parameters.Add(p1[i]);
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        public void BindAspNetPagerProc(string sql, int count, GridView gv, AspNetPager anp, SqlParameter[] p)
        {

            SqlConnection con = Con();
            SqlParameter[] p1 = new SqlParameter[2];


            p1[0] = new SqlParameter("@page1", SqlDbType.Int);
            p1[0].Value = (anp.CurrentPageIndex - 1) * anp.PageSize;

            p1[1] = new SqlParameter("@page2", SqlDbType.Int);
            p1[1].Value = (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize;

            SqlCommand com = new SqlCommand(sql, con);
            for (int i = 0; i < p1.Length; i++)
            {
                com.Parameters.Add(p1[i]);
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 邦定数据到分页控件上
        /// </summary>
        /// <param name="str">根据条件的查询字符串</param>
        /// <param name="strCount">根据条件查询记录出总数的语句</param>
        /// <param name="gv">Datalist控件</param>
        /// <param name="anp">分页控件</param>


        public void BindAspNetPagerProc(string sql, int count, System.Web.UI.WebControls.DataList gv, AspNetPager anp)
        {

            SqlConnection con = Con();
            SqlParameter[] p1 = new SqlParameter[2];


            p1[0] = new SqlParameter("@page1", SqlDbType.Int);
            p1[0].Value = (anp.CurrentPageIndex - 1) * anp.PageSize;

            p1[1] = new SqlParameter("@page2", SqlDbType.Int);
            p1[1].Value = (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize;
            SqlCommand com = new SqlCommand(sql, con);
            for (int i = 0; i < p1.Length; i++)
            {
                com.Parameters.Add(p1[i]);
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }



        public void BindAspNetPagerProc(string sql, int count, DataList gv, AspNetPager anp, SqlParameter[] p)
        {

            SqlConnection con = Con();
            SqlParameter[] p1 = new SqlParameter[2];


            p1[0] = new SqlParameter("@page1", SqlDbType.Int);
            p1[0].Value = (anp.CurrentPageIndex - 1) * anp.PageSize;

            p1[1] = new SqlParameter("@page2", SqlDbType.Int);
            p1[1].Value = (anp.CurrentPageIndex - 1) * anp.PageSize + anp.PageSize;

            SqlCommand com = new SqlCommand(sql, con);
            for (int i = 0; i < p1.Length; i++)
            {
                com.Parameters.Add(p1[i]);
            }
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            for (int i = 0; i < p.Length; i++)
            {
                com.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                anp.RecordCount = count;
                da.Fill(ds, "anp");
                gv.DataSource = ds.Tables["anp"];
                gv.DataBind();//邦定数据到gridview中
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Parameters.Clear();
                com.Dispose();//释放资源
                con.Close();
            }
        }

        public void IsOverDue()
        {
            ExecuteProc("IsOverDue");
        }

        #region
        /// <summary>
        /// 作者：袁希望
        /// Dropdownlist绑定方法
        /// </summary>
        /// <param name="procs">dropdownlist的存储过程</param>
        /// <param name="drop">Dropdownlist</param>
        /// <param name="feildText">DataTextField</param>
        /// <param name="feildValue">DataValueField</param>
        public void DropBind(string procs, DropDownList drop, string feildText, string feildValue)
        {

            SqlConnection con = Con();
            SqlCommand com = new SqlCommand(procs, con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds, "anp");
                drop.DataSource = ds.Tables["anp"];
                drop.DataTextField = feildText;
                drop.DataValueField = feildValue;
                drop.DataBind();//邦定数据到datalist中

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                com.Dispose();//释放资源
                con.Close();
            }
        }

        /// <summary>
        /// 执行一个sql语句返回一个阅读器
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderProc(string sql)
        {
            SqlConnection con = Con();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr;

                }
                else
                {
                    return null;
                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {

                cmd.Dispose();
            }
        }
        /// <summary>
        /// 执行一个带参数的存储过程返回一个阅读器
        /// </summary>
        /// <param name="procs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderProc(string procs, SqlParameter[] p)
        {
            SqlConnection con = Con();
            SqlCommand cmd = new SqlCommand(procs, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < p.Length; i++)
            {
                cmd.Parameters.Add(p[i]);
            }
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr;

                }
                else
                {
                    return null;
                }

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {

                cmd.Dispose();
            }
        }
        #endregion
    }
}
