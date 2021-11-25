using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekhnelogosInterviewProject.Entity.DTOs;

namespace TekhnelogosInterviewProject.WebUI.Helpers
{
    public class HelperRestApi<T> where T : class
    {
       
        public List<T> GetConnectRestApiForList(string address, string token)
        {   
            var resultFromResponse = JsonConvert.DeserializeObject<IEnumerable<T>>(BaseCodeWithToken(address, token, null,(int)ApiMethod.Get).Content);
            return resultFromResponse.ToList();
        }

        public T GetConnectRestApi(string address, string token)
        {  
            var resultFromResponse = JsonConvert.DeserializeObject<T>(BaseCodeWithToken(address, token, null, (int)ApiMethod.Get).Content);
            return resultFromResponse;
        }

        public T PostConnectRestApi(string address, string token, T item)
        {  
            var resultFromResponse = JsonConvert.DeserializeObject<T>(BaseCodeWithToken(address, token, item, (int)ApiMethod.Post).Content);
            return resultFromResponse;
        }

        public T PutConnectRestApi(string address, string token, T item)
        { 
            var resultFromResponse = JsonConvert.DeserializeObject<T>(BaseCodeWithToken(address, token, item, (int)ApiMethod.Put).Content);
            return resultFromResponse;
        }

        public T DeleteConnectRestApi(string address, string token)
        {
            var resultFromResponse = JsonConvert.DeserializeObject<T>(BaseCodeWithToken(address, token, null, (int)ApiMethod.Delete).Content);
            return resultFromResponse;
        }

        public T AuthConnectRestApi(string address,LoginDto item)
        { 
            var resultFromResponse = JsonConvert.DeserializeObject<T>(BaseCodeWithoutToken(address, item).Content);
            return resultFromResponse;
        }
        public IRestResponse BaseCodeWithoutToken(string address, LoginDto item)
        {
            var client = new RestClient(address);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(new { username = item.UserName, userpassword = item.UserPassword });
            IRestResponse response = client.Execute(request);

            return response;
        }
        public IRestResponse BaseCodeWithToken(string address, string token, T? item, int process)
        {
            var client = new RestClient(address);
            var request = new RestRequest( process == (int)ApiMethod.Get ? Method.GET : (process == (int)ApiMethod.Post ? Method.POST : (process == (int)ApiMethod.Put ? Method.PUT : Method.DELETE)));
            request.AddHeader("authorization", $"Bearer {token}");
            if (item != null)
            {
                var content = JsonConvert.SerializeObject(item);
                request.AddJsonBody(content);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }
    }

    enum ApiMethod
    {
        Get = 1,
        Post = 2,
        Put = 3,
        Delete = 4

    }
}
