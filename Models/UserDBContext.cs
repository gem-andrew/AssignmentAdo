using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data; 

namespace AssignmentAdo.Models
{
    public class UserDBContext
    {
        //cs stands for connection string
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
          
        //method to fetch employees
        public List<User> GetUsers() //will return list of users
        {
            List<User> UserList = new List<User>(); //after getting all the datafrom table  we will store in UserList and we will return this list too
            SqlConnection con = new SqlConnection(cs); //maintain connection with db
            SqlCommand cmd = new SqlCommand("spGetUsers",con); // we already have a stored procedure spGetUsers
            //now we have to tell that this is a stored procedure
            cmd.CommandType = CommandType.StoredProcedure; //we are telling that the query in cmd is stored procedure 
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); //creating object if sql data reader, executereader used when working with select
            while(dr.Read())
            {
                //create object of user class
                User us = new User();
                //all our user data is in dr and now we have to put all of it in our object
                us.id = Convert.ToInt32(dr.GetValue(0).ToString());
                us.firstName = dr.GetValue(1).ToString();
                us.lastName= dr.GetValue(2).ToString();
                us.dateOfBirth = Convert.ToDateTime(dr.GetValue(3).ToString());
                us.gender= dr.GetValue(4).ToString();
                us.email= dr.GetValue(5).ToString();
                UserList.Add(us); //adding rows in userlist
            }
            con.Close();

            return UserList;
        }

        public bool AddUser(User us)
        {
            SqlConnection con = new SqlConnection(cs); //maintain connection with db
            SqlCommand cmd = new SqlCommand("spAddUser", con); // we already have a stored procedure spGetUsers
            //now we have to tell that this is a stored procedure
            cmd.CommandType = CommandType.StoredProcedure; //we are telling that the query in cmd is stored procedure 
            //this stored procedure takes values
            cmd.Parameters.AddWithValue("@firstName", us.firstName);
            cmd.Parameters.AddWithValue("@lastName", us.lastName);
            cmd.Parameters.AddWithValue("@dob", us.dateOfBirth);
            cmd.Parameters.AddWithValue("@gender", us.gender);
            cmd.Parameters.AddWithValue("@email", us.email);
            con.Open();
            int i = cmd.ExecuteNonQuery();//returns an integer 1 if successful else 0
            if(i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool UpdateUser(User us)
        {
            SqlConnection con = new SqlConnection(cs); //maintain connection with db
            SqlCommand cmd = new SqlCommand("spUpdateUser", con); // we already have a stored procedure spGetUsers
            //now we have to tell that this is a stored procedure
            cmd.CommandType = CommandType.StoredProcedure; //we are telling that the query in cmd is stored procedure 
            //this stored procedure takes values
            cmd.Parameters.AddWithValue("@id", us.id);
            cmd.Parameters.AddWithValue("@firstName", us.firstName);
            cmd.Parameters.AddWithValue("@lastName", us.lastName);
            cmd.Parameters.AddWithValue("@dob", us.dateOfBirth);
            cmd.Parameters.AddWithValue("@gender", us.gender);
            cmd.Parameters.AddWithValue("@email", us.email);
            con.Open();
            int i = cmd.ExecuteNonQuery();//returns an integer 1 if successful else 0
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteUser(int id)
        {
            SqlConnection con = new SqlConnection(cs); //maintain connection with db
            SqlCommand cmd = new SqlCommand("spDeleteUser", con); // we already have a stored procedure spGetUsers
            //now we have to tell that this is a stored procedure
            cmd.CommandType = CommandType.StoredProcedure; //we are telling that the query in cmd is stored procedure 
            //this stored procedure takes values
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();//returns an integer 1 if successful else 0
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}