using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace BID_DLC.Models
{
    public class Employee
    {

        public int Employee_ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string DisplayName
        {
            get
            {
                return FirstName + ' ' + Surname;
            }
        }

        public int TotalHoursApril { get; set; }
        public int TotalHoursMay { get; set; }


        public List<Employee> GetEmployees()
        {

            List<Employee> employees = new List<Employee>();
            string strConnection = ConfigurationManager.ConnectionStrings["BID"].ConnectionString;

            using (SqlConnection oConnection = new SqlConnection(strConnection))
            {

                StringBuilder sbSQL = new StringBuilder();

                sbSQL.Append("SELECT E.[Employee_ID], E.[FirstName], E.[Surname], ");
                sbSQL.Append("SUM(ISNULL(APR.[Hour],0)) AS 'HoursAPR', SUM(ISNULL(MAY.[Hour],0)) AS 'HoursMAY' ");
                sbSQL.Append("FROM [BID_Test].[dbo].[Employee] E ");
                sbSQL.Append("LEFT JOIN (");
                sbSQL.Append("SELECT DATEDIFF(HOUR, Shift_Start, Shift_End) AS Hour, Employee_ID FROM Shifts S INNER JOIN Employee_Works_Shift EWS ON S.Shift_ID = EWS.Shift_ID ");
                sbSQL.Append("WHERE MONTH(Shift_Start) = 4 ) APR ON E.Employee_ID = APR.Employee_ID ");
                sbSQL.Append("LEFT JOIN (");
                sbSQL.Append("SELECT DATEDIFF(HOUR, Shift_Start, Shift_End) AS Hour, Employee_ID FROM Shifts S INNER JOIN Employee_Works_Shift EWS ON S.Shift_ID = EWS.Shift_ID ");
                sbSQL.Append("WHERE MONTH(Shift_Start) = 5 ) MAY ON E.Employee_ID = MAY.Employee_ID ");
                sbSQL.Append("GROUP BY E.Employee_ID, E.FirstName, E.Surname ");


                SqlCommand oCommand = new SqlCommand(sbSQL.ToString(), oConnection);
                oCommand.CommandType = CommandType.Text;
                oConnection.Open();

                SqlDataReader oReader = oCommand.ExecuteReader();

                while (oReader.Read())
                {

                    var oEmployee = new Employee()
                    {
                        Employee_ID = Convert.ToInt32(oReader["Employee_ID"]),
                        FirstName = oReader["FirstName"].ToString(),
                        Surname = oReader["Surname"].ToString(),
                        TotalHoursApril = Convert.ToInt16(oReader["HoursAPR"].ToString()),
                        TotalHoursMay = Convert.ToInt16(oReader["HoursMAY"].ToString())
                    };

                    employees.Add(oEmployee);

                }

                return employees;

            }

        }

        public List<Employee> GetEmployees(int id)
        {

            List<Employee> employees = new List<Employee>();
            string strConnection = ConfigurationManager.ConnectionStrings["BID"].ConnectionString;

            using (SqlConnection oConnection = new SqlConnection(strConnection))
            {

                StringBuilder sbSQL = new StringBuilder();

                sbSQL.Append("SELECT E.[Employee_ID], E.[FirstName], E.[Surname], ");
                sbSQL.Append("SUM(ISNULL(APR.[Hour],0)) AS 'HoursAPR', SUM(ISNULL(MAY.[Hour],0)) AS 'HoursMAY' ");
                sbSQL.Append("FROM [BID_Test].[dbo].[Employee] E ");
                sbSQL.Append("LEFT JOIN (");
                sbSQL.Append("SELECT DATEDIFF(HOUR, Shift_Start, Shift_End) AS Hour, Employee_ID FROM Shifts S INNER JOIN Employee_Works_Shift EWS ON S.Shift_ID = EWS.Shift_ID ");
                sbSQL.Append("WHERE MONTH(Shift_Start) = 4 ) APR ON E.Employee_ID = APR.Employee_ID ");
                sbSQL.Append("LEFT JOIN (");
                sbSQL.Append("SELECT DATEDIFF(HOUR, Shift_Start, Shift_End) AS Hour, Employee_ID FROM Shifts S INNER JOIN Employee_Works_Shift EWS ON S.Shift_ID = EWS.Shift_ID ");
                sbSQL.Append("WHERE MONTH(Shift_Start) = 5 ) MAY ON E.Employee_ID = MAY.Employee_ID ");
                sbSQL.AppendFormat("WHERE E.Employee_ID = {0}", id);
                sbSQL.Append("GROUP BY E.Employee_ID, E.FirstName, E.Surname ");


                SqlCommand oCommand = new SqlCommand(sbSQL.ToString(), oConnection);
                oCommand.CommandType = CommandType.Text;
                oConnection.Open();

                SqlDataReader oReader = oCommand.ExecuteReader();

                while (oReader.Read())
                {

                    var oEmployee = new Employee()
                    {
                        Employee_ID = Convert.ToInt32(oReader["Employee_ID"]),
                        FirstName = oReader["FirstName"].ToString(),
                        Surname = oReader["Surname"].ToString(),
                        TotalHoursApril = Convert.ToInt16(oReader["HoursAPR"].ToString()),
                        TotalHoursMay = Convert.ToInt16(oReader["HoursMAY"].ToString())
                    };

                    employees.Add(oEmployee);

                }

                return employees;

            }

        }

    }
}