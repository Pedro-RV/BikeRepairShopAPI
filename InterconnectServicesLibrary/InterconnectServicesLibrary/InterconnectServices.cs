using System;
using System.Collections.Generic;
using System.Data.Services;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterconnectServicesLibrary
{
    public static class InterconnectServices
    {
        public static T SendGet<T>(string url, Dictionary<string, string> queryParams, object urlParam) where T : class
        {
            using (var client = new HttpClient())
            {
                T result = null;
                string addUrl = "";
                bool firstTaken = false;  

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("userAuthentication", "pedro");
                client.DefaultRequestHeaders.Add("pwdAuthentication", "0123");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (urlParam != null)
                {
                    addUrl = urlParam.ToString();
                }
                else
                {
                    foreach (KeyValuePair<string, string> kvp in queryParams)
                    {
                        if(firstTaken == false)
                        {
                            addUrl += "?" + kvp.Key + "=" + kvp.Value;
                            firstTaken = true;
                        }
                        else
                        {
                            addUrl += "&" + kvp.Key + "=" + kvp.Value;
                        }

                    }
                }

                HttpResponseMessage response = client.GetAsync(addUrl).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
                }

                return result;
            }
        }

        public static string SendPost(string url, Dictionary<string, string> queryParams, object urlParam, object insert)
        {
            using (var client = new HttpClient())
            {
                string result = "";
                string addUrl = "";
                bool firstTaken = false;

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("userAuthentication", "pedro");
                client.DefaultRequestHeaders.Add("pwdAuthentication", "0123");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (urlParam != null)
                {
                    addUrl = urlParam.ToString();
                }
                else
                {
                    foreach (KeyValuePair<string, string> kvp in queryParams)
                    {
                        if (firstTaken == false)
                        {
                            addUrl += "?" + kvp.Key + "=" + kvp.Value;
                            firstTaken = true;
                        }
                        else
                        {
                            addUrl += "&" + kvp.Key + "=" + kvp.Value;
                        }

                    }
                }

                HttpResponseMessage response = client.PostAsJsonAsync(addUrl, insert).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return result;
            }
        }

        public static string SendPut(string url, Dictionary<string, string> queryParams, object urlParam, object insert)
        {
            using (var client = new HttpClient())
            {
                string result = "";
                string addUrl = "";
                bool firstTaken = false;

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("userAuthentication", "pedro");
                client.DefaultRequestHeaders.Add("pwdAuthentication", "0123");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (urlParam != null)
                {
                    addUrl = urlParam.ToString();
                }
                else
                {
                    foreach (KeyValuePair<string, string> kvp in queryParams)
                    {
                        if (firstTaken == false)
                        {
                            addUrl += "?" + kvp.Key + "=" + kvp.Value;
                            firstTaken = true;
                        }
                        else
                        {
                            addUrl += "&" + kvp.Key + "=" + kvp.Value;
                        }

                    }
                }

                HttpResponseMessage response = client.PutAsJsonAsync(addUrl, insert).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return result;
            }
        }

        public static string SendDelete(string url, Dictionary<string, string> queryParams, object urlParam)
        {
            using (var client = new HttpClient())
            {
                string result = "";
                string addUrl = "";
                bool firstTaken = false;

                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("userAuthentication", "pedro");
                client.DefaultRequestHeaders.Add("pwdAuthentication", "0123");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (urlParam != null)
                {
                    addUrl = urlParam.ToString();
                }
                else
                {
                    foreach (KeyValuePair<string, string> kvp in queryParams)
                    {
                        if (firstTaken == false)
                        {
                            addUrl += "?" + kvp.Key + "=" + kvp.Value;
                            firstTaken = true;
                        }
                        else
                        {
                            addUrl += "&" + kvp.Key + "=" + kvp.Value;
                        }

                    }
                }

                HttpResponseMessage response = client.DeleteAsync(addUrl).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return result;
            }
        }
    }
}
