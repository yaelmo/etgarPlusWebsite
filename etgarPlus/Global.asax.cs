﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Configuration;
using System.Diagnostics;
=======
>>>>>>> parent of e6cc75b... cloudinary
=======
>>>>>>> parent of e6cc75b... cloudinary
=======
>>>>>>> parent of e6cc75b... cloudinary

namespace etgarPlus
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        internal static void sendEmail(string subject, string body, string emailTo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            //string emailFrom = "brachafab@gmail.com";
            string emailFrom = System.Configuration.ConfigurationManager.AppSettings["Email"];
            //string emailpassword = "0503389483";
            string emailpassword = System.Configuration.ConfigurationManager.AppSettings["Password"];
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, emailpassword);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        internal static String uploadImage(String filePath, String publicId) 
        {

            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("hmtca4hsp", "551419468127826", "6CRKqZzHmHxqCvpLaObNj2Hmsis");


            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            CloudinaryDotNet.Actions.ImageUploadParams uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
            {
                File = new CloudinaryDotNet.Actions.FileDescription(filePath),//@"C:\Users\David\Downloads\etgarPlusWebsite-master\etgarPlusWebsite\etgarPlus\images\1.png"),
                PublicId = "4" //publicId
            };



            String url = cloudinary.Api.UrlImgUp.BuildUrl(publicId + filePath.Substring(filePath.LastIndexOf(".")));
            Debug.WriteLine(url);
            return url;
        }
       
=======
>>>>>>> parent of e6cc75b... cloudinary
=======
>>>>>>> parent of e6cc75b... cloudinary
=======
>>>>>>> parent of e6cc75b... cloudinary
    }
}