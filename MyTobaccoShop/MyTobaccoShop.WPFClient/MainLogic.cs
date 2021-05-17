// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPFClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Main Logic Class.
    /// </summary>
    public class MainLogic : IMainLogic
    {
        private string url = "http://localhost:53349/UsersApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// </summary>
        public MainLogic()
        {
        }

        /// <summary>
        /// Api Get Users Method.
        /// </summary>
        /// <returns>List Of Users.</returns>
        public IList<UserVM> ApiGetUsers()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<UserVM>>(json, this.jsonOptions);
            return list;
        }

        /// <summary>
        /// Delete a User.
        /// </summary>
        /// <param name="user">User.</param>
        public void ApiDelUser(UserVM user)
        {
            bool success = false;
            if (user != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + user.UserId.ToString(CultureInfo.CurrentCulture)).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement
                    .EnumerateObject()
                    .First()
                    .Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <summary>
        /// Edit User.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="editorFunc">Editor Function.</param>
        public void EditUser(UserVM user, Func<UserVM, bool> editorFunc)
        {
            UserVM clone = new UserVM();
            if (user != null)
            {
                clone.CopyFrom(user);
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (user != null)
                {
                    success = this.ApiEditUser(clone, true);
                }
                else
                {
                    success = this.ApiEditUser(clone, false);
                }
            }

            this.SendMessage(success == true);
        }

        /// <summary>
        /// Edit User.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="isEditing">IsEditing mode.</param>
        /// <returns>True or False.</returns>
        private bool ApiEditUser(UserVM user, bool isEditing)
        {
            if (user == null)
            {
                return false;
            }

            string myUrl = this.url + (isEditing ? "mod" : "add");

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("userId", user.UserId.ToString(CultureInfo.CurrentCulture));
            }

            postData.Add("userFullName", user.UserFullName);
            postData.Add("userEmail", user.UserEmail);
            postData.Add("userUsername", user.UserUserName);
            postData.Add("userPassword", user.UserPassword);
            postData.Add("userType", user.UserType);

            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(
                postData)).Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement
                   .EnumerateObject()
                   .First()
                   .Value.GetRawText() == "true";
        }

        /// <summary>
        /// Send Message Method.
        /// </summary>
        /// <param name="success">boolean var.</param>
        private void SendMessage(bool success)
        {
            string msg = success ? "Operation Completed Successfully" : "Operation Failed";
            Messenger.Default.Send(msg, "UserResult");
        }
    }
}
