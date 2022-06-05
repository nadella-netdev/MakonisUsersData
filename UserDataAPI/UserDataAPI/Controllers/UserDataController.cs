using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UserDataAPI.Model;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace UserDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };

        public UserDataController() {

        }

        [HttpPost]
        public async void AddUser(UserDataModel userData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "UserData.json";
                    string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

                    var jsonString = await System.IO.File.ReadAllTextAsync(path);
                    jsonString = "[" + jsonString + "]";
                    jsonString = jsonString.Replace("}", "},");

                    var userList = JsonConvert.DeserializeObject<List<UserDataModel>>(jsonString);

                    var newUser = new UserDataModel();
                    newUser.FirstName = userData.FirstName;
                    newUser.LastName = userData.LastName;
                    userList.Add(newUser);

                    var updatedUserData = JsonConvert.SerializeObject(userList);
                    updatedUserData = updatedUserData.Replace('[', ' ').Replace(']', ' ').Replace("},", "}");
                 
                    await System.IO.File.WriteAllTextAsync(path, updatedUserData);
                }
            }
            catch (Exception ex) { Problem(ex.Message); }
        }

    }
}
