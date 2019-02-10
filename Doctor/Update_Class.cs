using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    class Update_Class
    {
        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        public void Update_Thread()
        {
            updateAppointment();
            updateVaccination();
            updatePayment();
        }

        void updateAppointment()
        {
            try
            {
                string today = DateTime.Now.ToString("dd-MMM-yyyy");
                string status = string.Empty;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("select appointmentID, appointmentdate from Table_Appointment where appointmentstatus = 'upcoming' or appointmentstatus = 'today'", con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string appointmentID = reader[0].ToString();
                    string date = reader[1].ToString();
                    using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))
                    {
                        con1.Open();
                        if (DateTime.Parse(date) == DateTime.Parse(today))
                        {
                            status = "today";
                            SqlCommand cmd1 = new SqlCommand("AppointmentStatusUpdate", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@appointmentID", appointmentID);
                            cmd1.Parameters.AddWithValue("@appointmentstatus", status);
                            cmd1.ExecuteNonQuery();
                        }

                        if (DateTime.Parse(date) < DateTime.Parse(today))
                        {
                            status = "cancelled";
                            SqlCommand cmd1 = new SqlCommand("AppointmentStatusUpdate", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@appointmentID", appointmentID);
                            cmd1.Parameters.AddWithValue("@appointmentstatus", status);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        void updateVaccination()
        {
            try
            {
                string today = DateTime.Now.ToString("dd-MMM-yyyy");
                string status = string.Empty;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("select vaccinationID, vaccinationdate from Table_Vaccination where vaccinationstatus = 'upcoming' or vaccinationstatus = 'today'", con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string vaccinationID = reader[0].ToString();
                    string date = reader[1].ToString();
                    using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))//SqlConnection con1 = new SqlConnection(Properties.Settings.Default.connectionString)
                    {
                        con1.Open();
                        if (DateTime.Parse(date) == DateTime.Parse(today))
                        {
                            status = "today";
                            SqlCommand cmd1 = new SqlCommand("VaccinationStatusUpdate", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@vaccinationID", vaccinationID);
                            cmd1.Parameters.AddWithValue("@vaccinationstatus", status);
                            cmd1.ExecuteNonQuery();
                        }

                        if (DateTime.Parse(date) < DateTime.Parse(today))
                        {
                            status = "cancelled";
                            SqlCommand cmd1 = new SqlCommand("VaccinationStatusUpdate", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@vaccinationID", vaccinationID);
                            cmd1.Parameters.AddWithValue("@vaccinationstatus", status);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        void updatePayment()
        {
            try
            {
                string today = DateTime.Now.ToString("dd-MMM-yyyy");
                string status = string.Empty;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmddate = new SqlCommand("select paymentID, duedate from Table_Payment where baldue <> 0", con);
                cmddate.ExecuteNonQuery();
                SqlDataReader reader = cmddate.ExecuteReader();
                while (reader.Read())
                {
                    string paymentID = reader[0].ToString();
                    string duedate = reader[1].ToString();

                    using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))//SqlConnection con1 = new SqlConnection(Properties.Settings.Default.connectionString)
                    {
                        con1.Open();
                        if (DateTime.Parse(duedate) == DateTime.Parse(today))
                        {
                            status = "today";
                            SqlCommand cmd1 = new SqlCommand("PaymentStatusUpdate", con1);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@mode", "today");
                            cmd1.Parameters.AddWithValue("@paymentID", paymentID);
                            cmd1.Parameters.AddWithValue("@paymentstatus", status);
                            cmd1.ExecuteNonQuery();
                        }

                        if (DateTime.Parse(duedate) < DateTime.Parse(today))
                        {
                            status = "overdue";
                            SqlCommand cmd = new SqlCommand("PaymentStatusUpdate", con1);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mode", "overdue");
                            cmd.Parameters.AddWithValue("@paymentID", paymentID);
                            cmd.Parameters.AddWithValue("@paymentstatus", status);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
