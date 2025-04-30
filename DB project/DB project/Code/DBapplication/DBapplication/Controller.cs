using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public string ValidateUser(string username, string password)
        {
            string userQuery = "SELECT COUNT(*) FROM Users WHERE username = '" + username + "' AND password = '" + password + "';";
            string coachQuery = "SELECT COUNT(*) FROM Coach WHERE username = '" + username + "' AND password = '" + password + "';";
            string nutritionistQuery = "SELECT COUNT(*) FROM Nutritionist WHERE username = '" + username + "' AND password = '" + password + "';";

            DBManager dbMan = new DBManager();

            // Check the Users table
            int userCount = (int)dbMan.ExecuteScalar(userQuery);
            if (userCount > 0)
            {
                dbMan.CloseConnection();
                return "User"; // Found in Users table
            }

            // Check the Coaches table
            int coachCount = (int)dbMan.ExecuteScalar(coachQuery);
            if (coachCount > 0)
            {
                dbMan.CloseConnection();
                return "Coach"; // Found in Coaches table
            }

            // Check the Nutritionists table
            int nutritionistCount = (int)dbMan.ExecuteScalar(nutritionistQuery);
            if (nutritionistCount > 0)
            {
                dbMan.CloseConnection();
                return "Nutritionist"; // Found in Nutritionists table
            }

            dbMan.CloseConnection();
            return null; // No match found
        }

        public int InsertUser(string username, string password, string name , string email , int age , string gender)
        {
            string query = "INSERT INTO Users (username, password , Name , email , age , gender ) " +
                            "Values ('" + username + "','" + password + "','" + name + "' , '"+ email +"' , "+age+" , '"+gender+"');";

            return dbMan.ExecuteNonQuery(query);

        }

        public int InsertCoach(string username, string password, string name, string email, int exp_years, int phone)
        {
            string query = "INSERT INTO Coach (username, password , Name , email , experience_years , phone ) " +
                            "Values ('" + username + "','" + password + "','" + name + "' , '" + email + "' , " + exp_years + " , " + phone + ");";

            return dbMan.ExecuteNonQuery(query);

        }

        public int InsertNutritionist(string username, string password, string name, string email, int exp_years, int phone)
        {
            string query = "INSERT INTO Nutritionist (username, password , Name , email , experience_years , phone ) " +
                            "Values ('" + username + "','" + password + "','" + name + "' , '" + email + "' , " + exp_years + " , " + phone + ");";

            return dbMan.ExecuteNonQuery(query);

        }


    }
}
