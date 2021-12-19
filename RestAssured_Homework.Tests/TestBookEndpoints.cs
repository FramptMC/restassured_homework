using Newtonsoft.Json;
using NUnit.Framework;
using RestAssured_Homework.Tests.Models;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RestAssured_Homework.Tests
{
    public class TestBookEndpoints
    {
        private RestApiHelper _restApiHelper = null;
        private RestClient _restClient = new RestClient();
        private readonly string _baseUrl = "https://demoqa.com/BookStore/v1/";
        private readonly string _getAllBooksPath = "books";
        private readonly string _getBookDetailsPath = "book";
        private readonly string _isbnParameterName = "ISBN";

        [SetUp]
        public void Setup()
        {
            _restApiHelper = new RestApiHelper(_baseUrl);
            _restClient = _restApiHelper.GetClient();
        }

        [Test]
        public async Task TestBooksStore()
        {
            RestRequest getAllBooksRequest = _restApiHelper.BuildRequest(_getAllBooksPath, Method.GET, DataFormat.Json);
            IRestResponse getBooksResponse = _restClient.Get(getAllBooksRequest);

            Assert.IsTrue(getBooksResponse.IsSuccessful);
            Assert.AreEqual(getBooksResponse.StatusCode, HttpStatusCode.OK);

            GetBooksResponeData getBooksResponseData = DeserializeResponse<GetBooksResponeData>(getBooksResponse.Content);

            Assert.IsNotNull(getBooksResponseData);
            Assert.IsNotNull(getBooksResponseData.Books);

            string testIsbn = getBooksResponseData.Books.FirstOrDefault()?.ISBN;

            IRestRequest getBookRequest = _restApiHelper.BuildRequest(_getBookDetailsPath, Method.GET, DataFormat.Json)
                .AddParameter(new Parameter("ISBN", testIsbn, ParameterType.QueryString));

            IRestResponse getBookResponse = _restClient.Get(getBookRequest);

            Assert.IsTrue(getBookResponse.IsSuccessful);
            Assert.AreEqual(getBookResponse.StatusCode, HttpStatusCode.OK);

            Book getBookResponseData = DeserializeResponse<Book>(getBookResponse.Content);

            Assert.IsNotEmpty(getBookResponseData.Publisher);
            Assert.IsTrue(getBookResponseData.Pages > 0);
        }

        private T DeserializeResponse<T>(string jsonString)
            => JsonConvert.DeserializeObject<T>(jsonString);
    }
}