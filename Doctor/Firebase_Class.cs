using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doctor
{
    class Firebase_Class
    {
        public event EventHandler Firebase_Event;

        //SqlConnection con = new SqlConnection(Properties.Settings.Default.connectionString);
        SqlConnection con = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString);

        //use your own firebase credentials
        public string firebaseApiKey = Properties.Settings.Default.firebaseapikey;
        public string FirebaseAppUri = Properties.Settings.Default.firebaseuri;

        public bool tcpsocket()
        {
            try
            {
                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("www.google.co.in", 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public void Thread_prescriptions_documents()
        {
            while(true)
            {
                if(Properties.Settings.Default.firebase_upload == false)
                {
                    Thread.Sleep(600000);
                    Debug.WriteLine("Uploading Precription and documents");
                    prescriptions_documents();
                }
            }
        }

        public async Task prescriptions_documents()
        {
            if (tcpsocket() == true)
            {
                Properties.Settings.Default.firebase_upload = true;
                Properties.Settings.Default.Save();

                SqlCommand cmd;

                var auth = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));
                var token = await auth.SignInWithEmailAndPasswordAsync("oaish08kukreja@gmail.com", "ok@08may1997");

                var firebase = new FirebaseClient(
                                  FirebaseAppUri,
                                  new FirebaseOptions
                                  {
                                      AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken)
                                  });
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                        con.Open();
                    SqlCommand patient_cmd = new SqlCommand("select clinmdID from Table_Patient where transcribed = 0", con);
                    patient_cmd.ExecuteNonQuery();
                    SqlDataReader reader = patient_cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string clinmdid = reader[0].ToString();
                        using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))
                        {
                            con1.Open();

                            PrescriptionDocument prescriptionDocument;

                            cmd = new SqlCommand("PatientViewData", con1);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@type", "FirebasePrescription");
                            cmd.Parameters.AddWithValue("@clinmdid", clinmdid);

                            SqlDataReader prescription_Reader = cmd.ExecuteReader();
                            while (prescription_Reader.Read())
                            {
                                double page = 0;
                                int crm_value = 0;

                                var counter_value = await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Page Counter")
                                    .OrderByKey()
                                    .OnceAsync<PrescriptionDocument>();
                                foreach (var i in counter_value)
                                {
                                    page = Convert.ToInt64(i.Object.page);
                                }

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.page = (page + 1).ToString();
                                await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Page Counter")
                                    .Child("Counter")
                                    .PutAsync(prescriptionDocument);

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.ugcid = prescription_Reader[0].ToString();
                                prescriptionDocument.firstName = prescription_Reader[1].ToString();
                                prescriptionDocument.lastName = prescription_Reader[2].ToString();
                                prescriptionDocument.gender = prescription_Reader[3].ToString();
                                prescriptionDocument.age = prescription_Reader[4].ToString();
                                prescriptionDocument.mobile = prescription_Reader[5].ToString();
                                prescriptionDocument.page = page.ToString();
                                prescriptionDocument.date = prescription_Reader[8].ToString();
                                prescriptionDocument.diagnose = prescription_Reader[9].ToString();
                                prescriptionDocument.symptoms = prescription_Reader[10].ToString();
                                crm_value = Convert.ToInt32(prescription_Reader[11]);
                                prescriptionDocument.doctor = Properties.Settings.Default.registrationID;
                                prescriptionDocument.followUp = "NA";

                                await firebase
                               .Child("Doctors")
                               .Child(Properties.Settings.Default.registrationID)
                               .Child("Pages")
                               .Child("Page" + page)
                               .PutAsync(prescriptionDocument);

                                if(crm_value == 1)
                                {
                                    await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("CRM")
                                    .Child("Pages")
                                    .Child("Page" + page)
                                    .PutAsync(prescriptionDocument);
                                }

                                var stream = (dynamic)null;
                                if (File.Exists(prescription_Reader[7].ToString()))
                                {
                                    stream = File.Open(prescription_Reader[7].ToString(), FileMode.Open);
                                }
                                else
                                {
                                    File.Copy(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription.png", @"C:\Users\Oaish08\AppData\Local\Doctor\prescription1.png");
                                    stream = File.Open(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription1.png", FileMode.OpenOrCreate);
                                }
                                var task = new FirebaseStorage(Properties.Settings.Default.storagelink)
                                                    .Child("Doctors")
                                                    .Child(Properties.Settings.Default.registrationID)
                                                    .Child("Original Pages")
                                                    .Child(page + ".png")
                                                    .PutAsync(stream);

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.download_link = await task;
                                prescriptionDocument.page = page.ToString();
                                await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Page Downloads")
                                    .Child("Page" + page)
                                    .PutAsync(prescriptionDocument);

                                Debug.WriteLine("Page = {0}", page);

                                File.Delete(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription1.png");
                            }
                            prescription_Reader.Close();

                            cmd = new SqlCommand("PatientViewData", con1);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@type", "FirebaseDocument");
                            cmd.Parameters.AddWithValue("@clinmdid", clinmdid);

                            SqlDataReader document_Reader = cmd.ExecuteReader();
                            while (document_Reader.Read())
                            {
                                double page = 0;

                                var counter_value = await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Document Counter")
                                    .OrderByKey()
                                    .OnceAsync<PrescriptionDocument>();
                                foreach (var i in counter_value)
                                {
                                    page = Convert.ToInt64(i.Object.document);
                                }

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.document = (page + 1).ToString();
                                await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Document Counter")
                                    .Child("Counter")
                                    .PutAsync(prescriptionDocument);

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.ugcid = document_Reader[0].ToString();
                                prescriptionDocument.firstName = document_Reader[1].ToString();
                                prescriptionDocument.lastName = document_Reader[2].ToString();
                                prescriptionDocument.gender = document_Reader[3].ToString();
                                prescriptionDocument.age = document_Reader[4].ToString();
                                prescriptionDocument.mobile = document_Reader[5].ToString();
                                prescriptionDocument.page = page.ToString();
                                prescriptionDocument.date = document_Reader[8].ToString();
                                prescriptionDocument.diagnose = "NA";
                                prescriptionDocument.symptoms = "NA";
                                prescriptionDocument.doctor = Properties.Settings.Default.registrationID;
                                prescriptionDocument.followUp = "NA";

                                await firebase
                               .Child("Doctors")
                               .Child(Properties.Settings.Default.registrationID)
                               .Child("Documents")
                               .Child("Document" + page)
                               .PutAsync(prescriptionDocument);

                                var stream = (dynamic)null;
                                if (File.Exists(document_Reader[7].ToString()))
                                {
                                    stream = File.Open(document_Reader[7].ToString(), FileMode.Open);
                                }
                                else
                                {
                                    File.Copy(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription.png", @"C:\Users\Oaish08\AppData\Local\Doctor\prescription2.png");
                                    stream = File.Open(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription2.png", FileMode.OpenOrCreate);
                                }
                                var task = new FirebaseStorage(Properties.Settings.Default.storagelink)
                                                    .Child("Doctors")
                                                    .Child(Properties.Settings.Default.registrationID)
                                                    .Child("Documents")
                                                    .Child(page + ".png")
                                                    .PutAsync(stream);

                                prescriptionDocument = new PrescriptionDocument();
                                prescriptionDocument.download_link = await task;
                                prescriptionDocument.document = page.ToString();
                                await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Document Downloads")
                                    .Child("Document" + page)
                                    .PutAsync(prescriptionDocument);

                                Debug.WriteLine("Document = {0}", page);

                                File.Delete(@"C:\Users\Oaish08\AppData\Local\Doctor\prescription2.png");
                            }
                            document_Reader.Close();
                        }
                        using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))//new SqlConnection(Properties.Settings.Default.connectionString)
                        {
                            con1.Open();
                            SqlCommand Update_cmd = new SqlCommand("update Table_Patient set transcribed = 1 where clinmdID = '" + clinmdid + "'", con1);
                            Update_cmd.ExecuteNonQuery();
                        }
                    }
                    reader.Close();

                    Properties.Settings.Default.firebase_upload = false;
                    Properties.Settings.Default.Save();
                    Debug.WriteLine("Completed");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Properties.Settings.Default.firebase_upload = false;
                    Properties.Settings.Default.firebase_download = false;
                    Properties.Settings.Default.Save();
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                        con.Close();
                }
            }
            else
            {
                Properties.Settings.Default.firebase_download = false;
                Properties.Settings.Default.firebase_upload = false;
                Properties.Settings.Default.Save();
            }
        }

        public void Thread_patient()
        {
            if(tcpsocket() == true)
            {
                Properties.Settings.Default.firebase_download = true;
                Properties.Settings.Default.Save();
                delete_Data();
                patient();
            }
            else
            {
                Properties.Settings.Default.firebase_download = false;
                Properties.Settings.Default.firebase_upload = false;
                Properties.Settings.Default.Save();
            }
        }
        
        public void delete_Data()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd;
                string lastVisitDate = DateTime.Now.ToString("dd-MMM-yyyy");

                cmd = new SqlCommand("select clinmdID from Table_Patient where clinmdID like 'tempID%' and lastVisitedDate <> '" + lastVisitDate + "' and transcribed = 1", con);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string clinmdID = reader[0].ToString();
                    using (SqlConnection con1 = new SqlConnection(Properties.Settings.Default.DoctorDBConnectionString))//new SqlConnection(Properties.Settings.Default.connectionString)
                    {
                        con1.Open();
                        SqlCommand cmd1;
                        cmd1 = new SqlCommand("select location from Table_PatientPage where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();
                        SqlDataReader delete_Page = cmd1.ExecuteReader();
                        while (delete_Page.Read())
                        {
                            string path = reader[0].ToString();
                            if (File.Exists(path))
                                File.Delete(path);
                        }
                        delete_Page.Close();

                        cmd1 = new SqlCommand("select location from Table_PatientDocument where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();
                        SqlDataReader delete_Document = cmd1.ExecuteReader();
                        while (delete_Document.Read())
                        {
                            string path = reader[0].ToString();
                            if (File.Exists(path))
                                File.Delete(path);
                        }
                        delete_Document.Close();

                        cmd1 = new SqlCommand("delete from Table_LastVisitedPage where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();

                        cmd1 = new SqlCommand("delete from Table_LastVisitedDocument where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();

                        cmd1 = new SqlCommand("delete from Table_PatientPage where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();

                        cmd1 = new SqlCommand("delete from Table_PatientDocument where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();

                        cmd1 = new SqlCommand("delete from Table_Patient where clinmdID = '" + clinmdID + "'", con1);
                        cmd1.ExecuteNonQuery();
                    }
                }
                reader.Read();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Properties.Settings.Default.firebase_download = false;
                Properties.Settings.Default.firebase_upload = false;
                Properties.Settings.Default.Save();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public async Task patient()
        {
            if(tcpsocket() == true)
            {
                try
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));
                    var token = await auth.SignInWithEmailAndPasswordAsync("oaish08kukreja@gmail.com", "ok@08may1997");

                    var firebase = new FirebaseClient(
                                      FirebaseAppUri,
                                      new FirebaseOptions
                                      {
                                          AuthTokenAsyncFactory = () => Task.FromResult(token.FirebaseToken)
                                      });
                    var ids = await firebase
                        .Child("Doctors")
                        .Child(Properties.Settings.Default.registrationID)
                        .Child("Patients")
                        .Child("Patient Id")
                        .OnceAsync<PatientData>();
                    try
                    {
                        if (con.State == System.Data.ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd;

                        foreach (var i in ids)
                        {
                            string clinmdID = i.Object.ID;

                            Debug.WriteLine("ClinMdID = " + clinmdID);

                            int found = 0;
                            cmd = new SqlCommand("select clinmdID from Table_Patient where clinmdID = '" + clinmdID + "'", con);
                            cmd.ExecuteNonQuery();
                            SqlDataReader search_Reader = cmd.ExecuteReader();
                            while (search_Reader.Read())
                            {
                                found++;
                            }
                            search_Reader.Close();

                            var detailpatient = await firebase
                                        .Child("Doctors")
                                        .Child(Properties.Settings.Default.registrationID)
                                        .Child("Patients")
                                        .Child(clinmdID)
                                        .OnceAsync<PatientData>();
                            foreach (var detail in detailpatient)
                            {
                                cmd = new SqlCommand("PatientFirebase", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@clinmdID", clinmdID);
                                cmd.Parameters.AddWithValue("@ugcID", detail.Object.ugcID);
                                cmd.Parameters.AddWithValue("@firstname", detail.Object.firstName);
                                cmd.Parameters.AddWithValue("@lastname", detail.Object.lastName);
                                cmd.Parameters.AddWithValue("@gender", detail.Object.gender);
                                cmd.Parameters.AddWithValue("@age", detail.Object.age);
                                cmd.Parameters.AddWithValue("@mobile", detail.Object.mobile);
                                cmd.Parameters.AddWithValue("@transcribed", "1");
                                cmd.ExecuteNonQuery();
                                break;
                            }


                            double page_count = 0;
                            double document_count = 0;

                            if (found != 0)
                            {
                                cmd = new SqlCommand("select max(page) from Table_PatientPage where clinmdID = '" + clinmdID + "'", con);
                                page_count = Convert.ToInt64(cmd.ExecuteScalar());
                                cmd = new SqlCommand("select max(document) from Table_PatientDocument where clinmdID = '" + clinmdID + "'", con);
                                document_count = Convert.ToInt64(cmd.ExecuteScalar());
                                Debug.WriteLine("Max Page = "+ page_count +" Max Document = " + document_count);
                            }

                            double lasttimestamp = 0;

                            var pagepatient = await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Patients")
                                    .Child(clinmdID)
                                    .Child("Pages")
                                    .OnceAsync<PrescriptionDocument>();

                            foreach (var page in pagepatient)
                            {
                                if(Convert.ToInt64(page.Object.page) > page_count)
                                {
                                    Debug.WriteLine("Page Running = " + page.Object.page);

                                    string path = Properties.Settings.Default.prescriptionLocation + @"Online\";

                                    if (!Directory.Exists(path))
                                        Directory.CreateDirectory(path);

                                    var page_download = await firebase
                                        .Child("Doctors")
                                        .Child(Properties.Settings.Default.registrationID)
                                        .Child("Page Downloads")
                                        .OnceAsync<PrescriptionDocument>();
                                    foreach (var link in page_download)
                                    {
                                        if (page.Object.page == link.Object.page)
                                        {
                                            WebClient myWebClient = new WebClient();
                                            myWebClient.DownloadFile(link.Object.download_link, path + page.Object.page + ".png");
                                        }
                                    }

                                    cmd = new SqlCommand("PatientPage", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@mode", "Insert");
                                    cmd.Parameters.AddWithValue("@pageid", "0");
                                    cmd.Parameters.AddWithValue("@clinmdID", clinmdID);
                                    cmd.Parameters.AddWithValue("@page", page.Object.page);
                                    cmd.Parameters.AddWithValue("@diagnose", "NA");
                                    cmd.Parameters.AddWithValue("@symptoms", "NA");
                                    cmd.Parameters.AddWithValue("@timestamp", page.Object.timestamp);
                                    cmd.Parameters.AddWithValue("@location", path + page.Object.page + ".png");
                                    cmd.Parameters.AddWithValue("@transcribed", "1");
                                    cmd.Parameters.AddWithValue("@CRM", 0);
                                    cmd.ExecuteNonQuery();

                                    string recenttimestamp = page.Object.timestamp.ToString().Substring(0, 8);
                                    if (Convert.ToInt64(recenttimestamp) >= lasttimestamp)
                                    {
                                        if (Convert.ToInt64(recenttimestamp) > lasttimestamp)
                                        {
                                            cmd = new SqlCommand("delete from Table_LastVisitedPage where clinmdID = '" + clinmdID + "'", con);
                                            cmd.ExecuteNonQuery();
                                        }
                                        string dd = page.Object.timestamp.Substring(6, 2);
                                        int MM = Convert.ToInt32(page.Object.timestamp.Substring(4, 2));
                                        string yyyy = page.Object.timestamp.Substring(0, 4);
                                        DateTime dt = new DateTime(2000, MM, 01);
                                        string MMM = dt.ToString("MMM");
                                        string date = dd + "-" + MMM + "-" + yyyy;

                                        Debug.WriteLine("Last Visited = " + date);
                                        cmd = new SqlCommand("update Table_Patient set lastVisitedDate = '" + date + "' where clinmdID = '" + clinmdID + "'", con);
                                        cmd.ExecuteNonQuery();

                                        cmd = new SqlCommand("LastVisitedPage", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@clinmdid", clinmdID);
                                        cmd.Parameters.AddWithValue("@page", page.Object.page);
                                        cmd.ExecuteNonQuery();
                                    }

                                    lasttimestamp = Convert.ToInt64(page.Object.timestamp.ToString().Substring(0, 8));
                                }
                            }

                            lasttimestamp = 0;

                            var documentpatient = await firebase
                                    .Child("Doctors")
                                    .Child(Properties.Settings.Default.registrationID)
                                    .Child("Patients")
                                    .Child(clinmdID)
                                    .Child("Documents")
                                    .OnceAsync<PrescriptionDocument>();
                            foreach (var page in documentpatient)
                            {
                                if (Convert.ToInt64(page.Object.page) > document_count)
                                {
                                    Debug.WriteLine("Document Running " + page.Object.page);

                                    string path = Properties.Settings.Default.documentLocation + @"Online\";

                                    if (!Directory.Exists(path))
                                        Directory.CreateDirectory(path);

                                    var document_download = await firebase
                                        .Child("Doctors")
                                        .Child(Properties.Settings.Default.registrationID)
                                        .Child("Document Downloads")
                                        .OnceAsync<PrescriptionDocument>();
                                    foreach (var link in document_download)
                                    {
                                        if (link.Object.document == page.Object.page)
                                        {
                                            WebClient myWebClient = new WebClient();
                                            myWebClient.DownloadFile(link.Object.download_link, path + page.Object.page + ".png");
                                        }
                                    }

                                    cmd = new SqlCommand("PatientDocument", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@mode", "Insert");
                                    cmd.Parameters.AddWithValue("@documentid", "0");
                                    cmd.Parameters.AddWithValue("@clinmdID", clinmdID);
                                    cmd.Parameters.AddWithValue("@document", page.Object.page);
                                    cmd.Parameters.AddWithValue("@timestamp", page.Object.timestamp);
                                    cmd.Parameters.AddWithValue("@location", path + page.Object.page + ".png");
                                    cmd.Parameters.AddWithValue("@transcribed", "1");
                                    cmd.ExecuteNonQuery();

                                    string recenttimestamp = page.Object.timestamp.ToString().Substring(0, 8);
                                    if (Convert.ToInt64(recenttimestamp) >= lasttimestamp)
                                    {
                                        if (Convert.ToInt64(recenttimestamp) > lasttimestamp)
                                        {
                                            cmd = new SqlCommand("delete from Table_LastVisitedDocument where clinmdID = '" + clinmdID + "'", con);
                                            cmd.ExecuteNonQuery();
                                        }

                                        cmd = new SqlCommand("LastVisitedDocument", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@clinmdid", clinmdID);
                                        cmd.Parameters.AddWithValue("@document", page.Object.page);
                                        cmd.ExecuteNonQuery();
                                    }

                                    lasttimestamp = Convert.ToInt64(page.Object.timestamp.ToString().Substring(0, 8));
                                }
                            }

                            Debug.WriteLine("CHANGE");
                        }

                        Properties.Settings.Default.firebase_download = false;
                        Properties.Settings.Default.Save();
                        Debug.WriteLine("DONE");
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        Properties.Settings.Default.firebase_download = false;
                        Properties.Settings.Default.firebase_upload = false;
                        Properties.Settings.Default.Save();
                    }
                    finally
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                            con.Close();
                    }
                    if (Firebase_Event != null)
                    {
                        Firebase_Event(null, null);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Properties.Settings.Default.firebase_download = false;
                    Properties.Settings.Default.firebase_upload = false;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                Properties.Settings.Default.firebase_download = false;
                Properties.Settings.Default.firebase_upload = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}