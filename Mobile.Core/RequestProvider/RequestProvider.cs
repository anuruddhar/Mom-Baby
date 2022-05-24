
#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
    System      -   Mom & Baby
    Client      -   Cardiff Metropolitan University           
    Module      -   Mobile.Core
    Sub_Module  -   

    Copyright   -  Cardiff Metropolitan University 
 
 Modification History:
 ==================================================================================================================================================
 Date              Version      Modify by              Description
 --------------------------------------------------------------------------------------------------------------------------------------------------
19/02/2022          1.0      Anuruddha.Rajapaksha          Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion


#region Namespace
using Mobile.Core.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#endregion	

namespace Mobile.Core.RequestProvider {


    public class RequestProvider : IRequestProvider {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider() {
            _serializerSettings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "") {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                using (HttpResponseMessage response = await getHttpResponse(httpClient, uri)) { // await httpClient.GetAsync(uri)
                    await HandleResponse(response);
                    string serialized = await response.Content.ReadAsStringAsync();

                    TResult result = await Task.Run(() =>
                        JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

                    return result;
                }
            }
        }

        private async Task<HttpResponseMessage> getHttpResponse(HttpClient httpClient, string uri) {
            var responseMessage = await Policy
                // All HttpExceptions will be handled here
                .Handle<HttpRequestException>(ex => {
                    //Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                // If failed retry 5 times, For eg: 2 seconds, then 4,6,8 and 10 seconds later
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.GetAsync(uri));

            return responseMessage;
        }

        public async Task<TResult> GetStreamAsync<TResult>(string uri, string token = "") {
            Uri url = new Uri(uri);
            /*var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new Windows.Web.Http.Headers.HttpMediaTypeWithQualityHeaderValue("text/event-stream"));

            Task task = httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).AsTask().ContinueWith(t => {
                t.Result.Content.ReadAsInputStreamAsync().AsTask().ContinueWith(async t1 => {
                    IInputStream istr = await t1;
                    Stream s = istr.AsStreamForRead();

                    byte[] buffer = new byte[1024 * 8];
                    int bytesRead = await s.ReadAsync(buffer, 0, buffer.Length);

                    string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    System.Diagnostics.Debug.WriteLine(content);
                });
            });*/


            using (HttpClient client = new HttpClient()) {
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                StringBuilder stringBuilder = new StringBuilder();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)) {
                    using (var body = await response.Content.ReadAsStreamAsync()) {
                        using (var reader = new StreamReader(body)) {
                            while (!reader.EndOfStream) {
                                stringBuilder.Append(reader.ReadLine());
                            }
                        }
                    }

                    TResult result = await Task.Run(() =>
                        JsonConvert.DeserializeObject<TResult>("[" + stringBuilder.ToString() + "]", _serializerSettings));

                    return result;
                }
            }

        }


        public async Task<TResult> PostAsync<TData, TResult>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null) {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                if (headers != null) {
                    AddHeaderParameter(httpClient, headers);
                }

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                /*try {
                    HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                } catch (Exception ex) {
                    throw ex;
                }*/
                using (HttpResponseMessage response = await postHttpResponse(httpClient, uri, content)) { // await httpClient.PostAsync(uri, content)
                    await HandleResponse(response);
                    string serialized = await response.Content.ReadAsStringAsync();

                    TResult result = await Task.Run(() =>
                        JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

                    return result;
                }
            }
        }

        private async Task<HttpResponseMessage> postHttpResponse(HttpClient httpClient, string uri, StringContent content) {
            var responseMessage = await Policy
                // All HttpExceptions will be handled here
                .Handle<HttpRequestException>(ex => {
                    //Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
                    return true;
                })
                // If failed retry 5 times, For eg: 2 seconds, then 4,6,8 and 10 seconds later
                .WaitAndRetryAsync
                (
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

            return responseMessage;
        }

        public async Task<TResult> PutAsync<TData, TResult>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null) {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                if (headers != null) {
                    AddHeaderParameter(httpClient, headers);
                }

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage response = await httpClient.PutAsync(uri, content)) {
                    await HandleResponse(response);
                    string serialized = await response.Content.ReadAsStringAsync();

                    TResult result = await Task.Run(() =>
                        JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

                    return result;
                }
            }
        }


        public async Task PutNoContentAsync<TResult>(string uri, TResult data, string token = "", List<KeyValuePair<string, string>> headers = null) {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                if (headers != null) {
                    AddHeaderParameter(httpClient, headers);
                }

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using (HttpResponseMessage response = await httpClient.PutAsync(uri, content)) {
                    await HandleResponse(response);
                }
            }
        }


        public async Task<int> PatchAsync<TData>(string uri, TData data, string token = "", List<KeyValuePair<string, string>> headers = null) {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                if (headers != null) {
                    AddHeaderParameter(httpClient, headers);
                }

                var method = new HttpMethod("PATCH");
                var objJson = JsonConvert.SerializeObject(data);
                var content = new StringContent(objJson, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(method, uri) {
                    Content = content
                };

                using (HttpResponseMessage response = await httpClient.SendAsync(request)) {
                    await HandleResponse(response);
                    if (response.StatusCode == HttpStatusCode.NoContent) {
                        return 1;
                    }
                    return 0;
                }
            }
        }


        public async Task DeleteAsync(string uri, string token = "", List<KeyValuePair<string, string>> headers = null) {
            using (HttpClient httpClient = CreateHttpClient(token)) {
                if (headers != null) {
                    AddHeaderParameter(httpClient, headers);
                }
                await httpClient.DeleteAsync(uri);
            }
        }

        private HttpClient CreateHttpClient(string token = "") {
            // HTTPS ignore certificate
            // https://forums.xamarin.com/discussion/28272/problems-with-http-request, Must create a handler.
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            // https://developercommunity.visualstudio.com/content/problem/756800/latest-update-with-vs2019-servercertificatevalidat.html
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Add("Workstation", GlobalSettings);

            if (!string.IsNullOrEmpty(token)) {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }

        private void AddHeaderParameter(HttpClient httpClient, List<KeyValuePair<string, string>> headers = null) {
            if (httpClient == null)
                return;

            if (headers == null)
                return;

            foreach (var item in headers) {
                httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
            }

        }


        private async Task HandleResponse(HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized) {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestExceptionEx(response.StatusCode, content);
            }
        }
    }
}
