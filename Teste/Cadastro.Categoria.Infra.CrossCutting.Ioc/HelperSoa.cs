using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.CrossCutting
{
    /// <summary>
    /// DTO Return
    /// </summary>
    public class HelperSOAResponse
    {
        /// <summary>
        /// HttpStatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// JSon return.
        /// </summary>
        public string Response { get; set; }
    }

    /// <summary>
    /// Métodos de para SOA.
    /// </summary>
    public class HelperSOA
    {
        /// <summary>
        /// <para>Retorna o JSON serializado do Request consumido.</para>
        /// <para>Quando uma API consumir outra API, utilizar o Overload (string Http, string TipoRequest, string param, HttpWebRequest request)</para>
        /// </summary>
        /// <param name="Http">Endereço da API a ser consumida</param>
        /// <param name="TipoRequest">Tipo da Requisição (GET / POST)</param>
        /// <param name="param">JSON serializado com o Objeto de entrada da API</param>
        /// <param name="appToken">Gateway Token do Usuário consumidor da API</param>
        /// <param name="clientId">Gateway Token do Sistema consumidor da API</param>
        /// <param name="timeout">Tempo de timeout em milisegundos</param>
        /// <returns>JSON de retorno da API serializado.</returns>
        public static HelperSOAResponse CallApi(string Http, string TipoRequest, string param, string appToken, string clientId = null, int? timeout = null)
        {
            return _call(Http, TipoRequest, param, appToken, clientId, timeout);
        }

        /// <summary>
        /// <para>Retorna o JSON serializado do Request consumido.</para>
        /// <para>Utilizar quando uma API consumir outra API.</para>
        /// </summary>
        /// <param name="Http">Endereço da API a ser consumida</param>
        /// <param name="TipoRequest">Tipo da Requisição (GET / POST / PUT)</param>
        /// <param name="param">JSON serializado com o Objeto de entrada da API</param>
        /// <param name="request">Requisição de origem</param>
        /// <param name="timeout">Tempo de timeout em milisegundos</param>
        /// <returns>JSON de retorno da API serializado.</returns>
        public static HelperSOAResponse CallApi(string Http, string TipoRequest, string param, HttpRequestMessage request, int? timeout = null)
        {
            string appToken = null;
            string clientId = null;
            var header = request.Headers;

            if (header.Contains("app_token"))
                appToken = header.GetValues("app_token").First();
            if (header.Contains("client_id"))
                clientId = header.GetValues("client_id").First();

            return _call(Http, TipoRequest, param, appToken, clientId, timeout);
        }

        /// <summary>
        /// Exec.
        /// </summary>
        /// <param name="Http"></param>
        /// <param name="TipoRequest"></param>
        /// <param name="param"></param>
        /// <param name="appToken"></param>
        /// <param name="clientId"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private static HelperSOAResponse _call(string Http, string TipoRequest, string param, string appToken, string clientId, int? timeout)
        {
            var request = System.Net.WebRequest.Create(Http) as System.Net.HttpWebRequest;
            request.KeepAlive = true;
            request.Method = TipoRequest;
            request.ContentType = "application/json";
            request.ContentLength = 0;
            request.Headers.Add("client_id", clientId);
            request.Headers.Add("app_token", appToken);
    

            if (timeout.HasValue)
                request.Timeout = timeout.Value;

            var r = new HelperSOAResponse();
            try
            {
                if (request.Method != WebRequestMethods.Http.Get)
                {
                    if (param != null)
                    {
                        byte[] postSender = Encoding.UTF8.GetBytes(param);
                        request.ContentLength = postSender.Length;
                        using (var dataStream = request.GetRequestStream())
                        {
                            dataStream.Write(postSender, 0, postSender.Length);
                        }
                    }
                }

                using (var response = request.GetResponse() as System.Net.HttpWebResponse)
                {
                    if (response != null)
                    {
                        var result = String.Empty;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            result = reader.ReadToEnd();
                        }

                        if (response.StatusCode != HttpStatusCode.OK
                            && response.StatusCode != HttpStatusCode.Created)
                            throw new APIException(result, response.StatusCode);

                        r.Response = result;
                        r.StatusCode = response.StatusCode;
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            var error = reader.ReadToEnd();
                            r.Response = error;
                            r.StatusCode = HttpStatusCode.InternalServerError;
                        }
                    }
            }
            catch (APIException e)
            {
                r.Response = e.Message;
                r.StatusCode = e.StatusCode;
            }
            catch (Exception ex)
            {
                r.Response = ex.Message;
                r.StatusCode = HttpStatusCode.InternalServerError;
            }

            return r;
        }
    }

    internal class APIException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public APIException(string message, HttpStatusCode status) : base(message)
        {
            StatusCode = status;
        }
    }
}
