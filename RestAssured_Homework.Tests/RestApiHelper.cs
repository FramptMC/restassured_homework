using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestAssured_Homework.Tests
{
    public class RestApiHelper
    {
        private RestClient _restClient = new RestClient();

        public RestApiHelper(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public RestClient GetClient() => _restClient;
        public RestRequest BuildRequest(string resourceUrl, Method method, DataFormat format)
            => new RestRequest(resourceUrl, method, format);
    }
}
