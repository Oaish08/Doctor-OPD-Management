using Firebase.Auth;
using Firebase.Database;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class Update_Form : Form
    {
        public string firebaseApiKey = Properties.Settings.Default.firebaseapikey;
        public string FirebaseAppUri = Properties.Settings.Default.firebaseuri;
        string source = AppDomain.CurrentDomain.BaseDirectory + @"\Doctor.exe";
        string dest = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor\Doctor.exe";
        string downloadpath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor\Updates\";

        bool update_download = false;

        static Stopwatch sw = new Stopwatch();

        PrivateFontCollection pfc = new PrivateFontCollection();

        MaterialSkinManager skinManager;

        public Update_Form()
        {
            Thread splash = new Thread(new ThreadStart(StartForm));
            splash.Start();
            Thread.Sleep(2000);
            splash.Abort();
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.ColorScheme = new ColorScheme(Primary.Cyan600, Primary.Brown900, Primary.Cyan700, Accent.Cyan700, TextShade.WHITE);


            int fontLength = Properties.Resources.timeburnerbold.Length;

            byte[] fontdata = Properties.Resources.timeburnerbold;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            this.Size = new Size(280, 440);

            lbchecking.Font = new Font(pfc.Families[0], 10);
            lbstatus.Font = new Font(pfc.Families[0], 10);
            lbupdating.Font = new Font(pfc.Families[0], 10);

            if (!Directory.Exists(@"C:\Users\" + Environment.UserName + @"\AppData\Local\Doctor"))
                Directory.CreateDirectory(@"C: \Users\" + Environment.UserName + @"\AppData\Local\Doctor");
            if (!Directory.Exists(downloadpath))
                Directory.CreateDirectory(downloadpath);
        }

        public void StartForm()
        {
            Application.Run(new Splash_Form());
        }

        private void pbclose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pbclose_MouseHover(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources.colorclose;
        }

        private void pbclose_MouseLeave(object sender, EventArgs e)
        {
            pbclose.Image = Properties.Resources._close;
        }

        private void pbminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbminimize_MouseHover(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources.colorminize;
        }

        private void pbminimize_MouseLeave(object sender, EventArgs e)
        {
            pbminimize.Image = Properties.Resources._minimize;
        }

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

        private void Update_Form_Load(object sender, EventArgs e)
        {
            timer_tochange.Start();
            pbdownloadbar.Minimum = 0;
        }

        private void timer_tochange_Tick(object sender, EventArgs e)
        {
            timer_tochange.Interval = 5;
            if (update_download == true)
            {
                updates();
            }
            else
            {
                reg();
            }
        }

        //slide panel
        int move_speed = 20;
        void reg()
        {
            if (panel_checkingupdates.Left > 0)
            {
                panel_flash.Left -= move_speed;
                panel_checkingupdates.Left -= move_speed;
                if (panel_checkingupdates.Left == 0)
                {
                    timer_tochange.Stop();
                    if (tcpsocket() == true)
                        get_Updates();
                    else
                        Open_Main();
                }
            }
        }

        void updates()
        {
            if (panel_downloadingupdates.Left > 0)
            {
                panel_downloadingupdates.Left -= move_speed;
                if (panel_downloadingupdates.Left == 0)
                {
                    timer_tochange.Stop();
                }
            }
        }

        public async Task get_Updates()
        {
            string downloadUrl = string.Empty;
            Version newVersion = null;

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
                var file = await firebase
                    .Child("SoftwareUpdate")
                    .OnceAsync<update_Software_Class>();
                foreach (var i in file)
                {
                    downloadUrl = i.Object.update;
                    newVersion = i.Object.version;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Open_Main();
            }

            try
            {
                Version applicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                if (applicationVersion.CompareTo(newVersion) < 0)
                {
                    timer_tochange.Start();
                    update_download = true;
                    download(downloadUrl);
                }
                else
                {
                    Open_Main();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Open_Main();
            }
        }

        public void download(string download_link)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += DownloadProgressChanged;
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    sw.Start();
                    try
                    {
                        if (!Directory.Exists(downloadpath))
                            Directory.CreateDirectory(downloadpath);
                        client.DownloadFileAsync(new Uri(download_link), downloadpath + "Doctor.exe");
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        Open_Main();
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Open_Main();
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = (receive / total) * 100;
                lbstatus.Text = $"Downloaded {string.Format("{0:0}", percentage)} %";
                pbdownloadbar.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Reset();
            if (e.Cancelled == true)
            {
                MessageBox.Show("Cancel");
            }
            else
            {
                File.Move(source, dest);
                File.Move(downloadpath + "Doctor.exe", source);
                Process.Start(source);
                this.Close();
                File.Delete(dest);
                Environment.Exit(0);
            }
        }

        public void Open_Main()
        {
            this.Hide();
            if (Properties.Settings.Default.authentication == false)
            {
                Authentication_Form authentication_Form = new Authentication_Form();
                authentication_Form.Show();
            }
            else
            {
                Password_Form password_Form = new Password_Form();
                password_Form.Show();
            }
        }
    }
}