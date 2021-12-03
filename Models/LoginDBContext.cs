using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace AssignmentAdo.Models
{
    public class LoginDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public bool CheckLogin(Login lp)
        {
            SqlConnection con = new SqlConnection(cs); //maintain connection with db

            SqlCommand cmd = new SqlCommand("spCheckValidUser", con); // we already have a stored procedure spGetUsers
            //now we have to tell that this is a stored procedure
            cmd.CommandType = CommandType.StoredProcedure; //we are telling that the query in cmd is stored procedure 
            cmd.Parameters.AddWithValue("@email", lp.email);
            cmd.Parameters.AddWithValue("@pass", lp.pass);
            //cmd.Parameters.AddWithValue("@cnfpass", ps.confirmPass);
            con.Open();
            SqlDataReader sd = cmd.ExecuteReader();
            
            if (sd.Read())
            {
                return true;
            }
            else {
                return false;
            }
            con.Close();
        }
    }
    }