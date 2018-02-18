#region Using

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Users.Common.Models;

#endregion

namespace Users.Common.RestClients
{
    public class UsersClient
    {
        #region Fields

        private HttpClient httpClient;

        #endregion

        #region Constructor

        public UsersClient()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://jsonplaceholder.typicode.com/users/")
            };
        }

        #endregion

        #region Methods (Public)

        public async Task<IEnumerable<User>> GetAll()
        {
            var response = await httpClient.GetAsync(string.Empty);

            CheckStatusCode(response.StatusCode);

            return await DeserializeResponse<IEnumerable<User>>(response);
        }

        #endregion

        #region Methods (Private)

        private async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private static void CheckStatusCode(HttpStatusCode statusCode)
        {
            if (statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unexpected status code: {statusCode}");
            }
        }

        #endregion
    }
}