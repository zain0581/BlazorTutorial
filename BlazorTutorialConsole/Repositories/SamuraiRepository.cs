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
    public class SamuraiRepository : ISamurai
    {
        public int Add(Samurai obj)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                con.Open();
                string sql = "INSERT INTO [dbo].[Samurai]([ID],[Name],[Age])VALUES(" + obj.ID + ",'" + obj.Name + "'," + obj.Age + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                result = cmd.ExecuteNonQuery();
                cmd = null;
                

            }
            catch (Exception )
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
                string sql = "DELETE FROM [dbo].[Horse] WHERE id=" + id;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                result = cmd.ExecuteNonQuery();
                cmd = null;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }



            return result;
        }

        public Samurai Get(int id)
        {
            
            Samurai result = new Samurai();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name],[Age]FROM [dbo].[Horse] where id=" + id;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    result.ID = Convert.ToInt32(dr[0].ToString());
                    result.Name = dr[1].ToString();
                    result.Age = Convert.ToInt32(dr[2].ToString());

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

        public List<Samurai> GetAll()
        {
            List<Samurai> result = new List<Samurai>();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name],[Age]FROM [dbo].[Horse]";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Samurai obj = new Samurai();
                    obj.ID = Convert.ToInt32(dr[0].ToString());
                    obj.Name = dr[1].ToString();
                    obj.Age = Convert.ToInt32(dr[2].ToString());
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

        public int Update(Samurai obj)
        {
            throw new NotImplementedException();
        }
        //public void create(Samurai samurai)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"Insert into Samurai (ID,Name,Age) " +
        //        $"values ({samurai.ID},'{samurai.Name}',{samurai.Age})", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public void delete(int samuraiId)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"delete from Samurai where id = {samuraiId}", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public List<Samurai> getAllSamurais()
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("select * from  Samurai", con);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    List<Samurai> samurais = new List<Samurai>();
        //    while (reader.Read())
        //    {
        //        Samurai samurai = new Samurai();
        //        samurai.ID = Convert.ToInt32( reader["ID"].ToString());
        //        samurai.Name =  reader["Name"].ToString() ;
        //        samurai.Age = Convert.ToInt32(reader["Age"]);

        //        samurais.Add(samurai);
        //    }
        //    con.Close();
        //    return samurais;
        //}

    }
}
