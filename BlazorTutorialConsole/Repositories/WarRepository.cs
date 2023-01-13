using BlazorTutorialConsole.Interfaces;
using BlazorTutorialConsole.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTutorialConsole.Repositories
{
    public class WarRepository : IWar
    {
        public int Add(War obj)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                con.Open();
                string sql = "INSERT INTO [dbo].[War]([ID],[Name])VALUES(" + obj.ID + ",'" + obj.Name +"')";
                SqlCommand cmd = new SqlCommand(sql, con);
                result = cmd.ExecuteNonQuery();
                cmd = null;
               

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }



            return result;
        }

        public int Delete(int id)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "DELETE FROM [dbo].[War] WHERE id=" + id;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                result = cmd.ExecuteNonQuery();
                cmd = null;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }



            return result;
        }

        public War Get(int id)
        {
            
                War result = new War();
                SqlConnection con = new SqlConnection(Helper.ConnectionString);
                try
                {
                    string sql = "SELECT  [ID],[Name] FROM [dbo].[War] where id=" + id;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        result.ID = Convert.ToInt32(dr[0].ToString());
                        result.Name = dr[1].ToString();
                   

                    }


                    cmd = null;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }



                return result;
        }

        public List<War> GetAll()
        {
            List<War> result = new List<War>();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name] FROM [dbo].[War]";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    War obj = new War();
                    obj.ID = Convert.ToInt32(dr[0].ToString());
                    obj.Name = dr[1].ToString();
                   
                    result.Add(obj);
                }


                cmd = null;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }



            return result;
        }

        public int Update(War obj)
        {
            throw new NotImplementedException();
        }
    }
}
