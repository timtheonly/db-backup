using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using DropNet;
//using IniParser;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private  string output;
        private string bkuploc, zipfileName;
        private bool newUser;
        private DropNetClient dbclient;
        public Form1()
        {
            InitializeComponent();
            //set default backup location
            bkuploc = "U:\\";
            output = "Click backup to begin.....";
            outputlabel.Text = output;
            dbclient = new DropNetClient("************", "**********");
            newUser = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            output += "\nBackup initiated (This may take a while).... \n backing up:"+ bkuploc +" ... \n";
            bkpbtn.Enabled = false;
            choosedirbtn.Enabled = false;
            outputlabel.Text = output;
            zipUp();
            output += "\nZip completed, now attepmting to send backup to Dropbox...";
            outputlabel.Text = output;
            auththenicateWithDropbox();
            sendBackuptodb();
            output += "\nComplete; backup sent to Dropbox...";
            outputlabel.Text = output;
            cleanup();
            output += "\nYou can now close this window....";
            outputlabel.Text = output;
        }
        
        private void choosedirbtn_Click(object sender, EventArgs e)
        {
            if (choosefolderDialog.ShowDialog() == DialogResult.OK)
            {
                bkuploc = choosefolderDialog.SelectedPath;
            }

        }

        private void zipUp()
        {
            try
            {
                ZipFile myzip = new ZipFile();
                myzip.AddDirectory(bkuploc);
                zipfileName= "Backup-" + System.DateTime.Now.ToString("d-M-yy--HH-m-s") + ".zip";
                myzip.Save(zipfileName);   
            }
            catch (System.Exception except1)
            {
                output += "\n" + except1.Message;
                outputlabel.Text = output;
            }
        }
        
        private void auththenicateWithDropbox()
        {
            string user_token ="", user_secret="";
            /*if user has run a backup before read the access token from config.ini
             otherwise get the access token and then save it to config.ini*/
            if (File.Exists("config.ini"))
            {
                StreamReader str = new StreamReader("config.ini");
                user_token = str.ReadLine();
                user_secret = str.ReadLine();
                str.Close();
            }
            else
            {
                newUser = true;
                string url = dbclient.GetTokenAndBuildUrl();
                System.Diagnostics.Process.Start(url);
                //wait for the user to accept the app on dropbox
                MessageBox.Show("click ok when you have authenicated with dropbox","Authtenticate with dropbox");

                var accesstoken = dbclient.GetAccessToken();
                //save the access token for future use
                StreamWriter stw = new StreamWriter("config.ini");
                stw.WriteLine(accesstoken.Token);
                stw.WriteLine(accesstoken.Secret);
                stw.Close();
            }
            dbclient.UserLogin = new DropNet.Models.UserLogin {Token = user_token, Secret = user_secret};
        }

        private void sendBackuptodb()
        {
            try
            {
                if (newUser)
                {
                    //create a sub dir called backups to store the zip files
                    dbclient.CreateFolder("/backups");
                }
                byte[] bytes = File.ReadAllBytes(zipfileName);
                var uploaded = dbclient.UploadFilePUT("/backups/" + zipfileName, zipfileName, bytes);
            }
            catch (DropNet.Exceptions.DropboxException dbexcept1)
            {
                output += "Error sending backup to dropbox:\n" + dbexcept1.Message;
                outputlabel.Text = output;
            }
        }

        private void cleanup()
        {
            try
            {
                File.Delete(zipfileName);
            }
            catch (System.SystemException except2)
            {
                //not fatal but looks bad
                output += "Error deleteing temporary zip archive:\n" + except2.Message.ToString();
            }
        }
        

    }
}
