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
    public class HorseRepository : IHorse
    {

        public int Add(Horse obj)
        {
            int result = -1;
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {con.Open();
                string sql = "INSERT INTO [dbo].[Horse]([ID],[Name],[Age])VALUES(" + obj.Id + ",'" + obj.Name + "'," + obj.Age + ")";
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
                string sql = "DELETE FROM [dbo].[Horse] WHERE id=" + id;
                con.Open();
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

        public Horse Get(int id)
        {
            Horse result = new Horse();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name],[Age]FROM [dbo].[Horse] where id=" + id;
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    result.Id = Convert.ToInt32(dr[0].ToString());
                    result.Name = dr[1].ToString();
                    result.Age = Convert.ToInt32(dr[2].ToString());

                }


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

        public List<Horse> GetAll()
        {
            List<Horse> result = new List<Horse>();
            SqlConnection con = new SqlConnection(Helper.ConnectionString);
            try
            {
                string sql = "SELECT  [ID],[Name],[Age]FROM [dbo].[Horse]";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Horse obj = new Horse();
                    obj.Id = Convert.ToInt32(dr[0].ToString());
                    obj.Name = dr[1].ToString();
                    obj.Age = Convert.ToInt32(dr[2].ToString());
                    result.Add(obj);
                }


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
    

        public int Update(Horse obj)
        {
            throw new NotImplementedException();
        }

        //public void create(Horse horse)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"Insert into horse (age,name,samuraiId) " +
        //        $"values ({horse.Age},'{horse.Name}',{horse.SamuraiId})",con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        //public void createHardcoded()
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Insert into horse values ('beauty')",con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        ///// <summary>
        ///// 1) Minimum 1 Insert
        ///// 2) Minimum 2 Select
        ///// 3) Hvordan var det nu vi beskyttede os mod dem? Er der mere end en mulighed??
        ///// </summary>
        ///// <param name="horse"></param>
        //public void createWithInjection(Horse horse)
        //{
        //    string horsename = "'); truncate table test; --";
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"Insert into horse (age, samuraiId, name) values (1, 1,'{horsename}' )", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public void createWithInjectionVer2(Horse horse)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"Insert into horse (age, samuraiId, name) " +
        //        $"values (1, 1,'{horse.Name}' )", con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public void createAvoid(Horse horse)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"Insert into horse values (@age, @name, @id)", con);
        //    cmd.Parameters.AddWithValue("@age", horse.Age);
        //    cmd.Parameters.AddWithValue("@name", horse.Name+"'");
        //    cmd.Parameters.AddWithValue("@id", horse.SamuraiId); // foreign key
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public void delete(int horseId)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"delete from horse where id = {horseId}",con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        //public List<Horse> getAllHorses()
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("select * from horse",con);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    List<Horse> horses = new List<Horse>();
        //    while (reader.Read())
        //    {
        //        Horse horse = new Horse();
        //        horse.Name = reader["Name"].ToString();
        //        horse.Id = Convert.ToInt32(reader["Id"]);
        //        horse.Age = Convert.ToInt32(reader["Age"]);
        //        horse.SamuraiId = Convert.ToInt32(reader["SamuraiId"]);
        //        horses.Add(horse);
        //    }
        //    con.Close();
        //    return horses;
        //}

        //public Horse getHorse(int horseid)
        //{
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"select * from horse where id = {horseid}",con);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    if(reader.Read())
        //    {
        //        Horse horse = new Horse();
        //        horse.Name = reader["Name"].ToString();
        //        horse.Id = Convert.ToInt32(reader["Id"]);
        //        con.Close();
        //        return horse;
        //    }
        //    con.Close();
        //    return new Horse(); // snakke med palle om det...
        //}

        //public void update(Horse horse)
        //{
        //    Horse temp = getHorse(horse.Id);
        //    if (temp == null) return;
        //    SqlConnection con = new SqlConnection(Helper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand($"update horse set Name = '{horse.Name}' where Id= {horse.Id}",con);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

    }
}
