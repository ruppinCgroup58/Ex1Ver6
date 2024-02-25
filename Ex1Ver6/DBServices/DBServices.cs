﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Ex1Ver6.BL;

    public class DBServices
    {
        public DBServices() { }
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
            string cStr = configuration.GetConnectionString("myProjDB");
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

    /// <summary>
    /// This method reads flats from the flats table.
    /// </summary>
    /// <returns>List of all the flats from the database.</returns>
    public List<Flat> Read()
        {

            SqlConnection con;
            SqlCommand cmd;
            List<Flat> flatsList = new List<Flat>();

            try
            {
                con = connect("myProjDB"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            cmd = CreateCommandWithStoredProcedureWithoutParameters("spReadStudent", con);             // create the command

            try
            {
                SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dataReader.Read())
                {
                    Flat f = new Flat();
                    f.Id = dataReader["id"].ToString();
                    f.City = dataReader["city"].ToString();
                    f.Address = dataReader["address"].ToString();
                    f.Price = Convert.ToDouble(dataReader["price"]);
                    f.NumberOfRooms = Convert.ToInt32(dataReader["numOfRooms"]);
                    flatsList.Add(f);
                }
                return flatsList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
    
    /// <summary>
    /// This methos inserts a flat to the flats table.
    /// </summary>
    /// <param name="flat"></param>
    /// <returns>Number of rows affected.</returns>
    public int Insert(Flat flat)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFlatInsertCommandWithStoredProcedure("sp_insertFlat", con, flat);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    private SqlCommand CreateFlatInsertCommandWithStoredProcedure(String spName, SqlConnection con, Flat flat)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

            cmd.Parameters.AddWithValue("@id", flat.Id);

            cmd.Parameters.AddWithValue("@city", flat.City);

            cmd.Parameters.AddWithValue("@address", flat.Address);
            cmd.Parameters.AddWithValue("@price", flat.Price);
            cmd.Parameters.AddWithValue("@numOfRooms", flat.NumberOfRooms);


            return cmd;
        }

        private SqlCommand CreateCommandWithStoredProcedureWithoutParameters(String spName, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = spName;      // can be Select, Insert, Update, Delete

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

            return cmd;
        }

    }
