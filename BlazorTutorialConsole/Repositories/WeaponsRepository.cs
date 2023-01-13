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
    public class WeaponsRepository : IWeapons
    {
        public int Add(Weapons obj)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "INSERT INTO [dbo].[Weapons]([ID],[Name])VALUES(" + obj.ID + ",'" + obj.Name + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                result = cmd.ExecuteNonQuery();
                cmd = null;
                con.Open();

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
                string sql = "DELETE FROM [dbo].[Weapons] WHERE id=" + id;
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

        public Weapons Get(int id)
        {

            Weapons result = new Weapons();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name] FROM [dbo].[Weapons] where id=" + id;
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

        public List<Weapons> GetAll()
        {
            List<Weapons> result = new List<Weapons>();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name], FROM [dbo].[Weapons]";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Weapons obj = new Weapons();
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

        public int Update(Weapons obj)
        {
            throw new NotImplementedException();
        }
    }
}
