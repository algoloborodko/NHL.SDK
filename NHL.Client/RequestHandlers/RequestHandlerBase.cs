﻿using Newtonsoft.Json;
using NHL.Client.API;
using NHL.Client.Exceptions;
using NHL.Client.RequestModels;
using NHL.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace NHL.Client.RequestHandlers
{
    public abstract class RequestHandlerBase<TResult, TRequest> : IRequestHandler<TResult, TRequest>
        //where TResult : INHLModel
        where TRequest : IRequestModel
    {
        protected virtual Type ModelType { get; } = typeof(TResult);
        //protected readonly Type ModelType = typeof(TResult);
        protected abstract Uri GenerateUrl(TRequest request);
        protected IApiClient ApiClient { get; } = new ApiClient();  //TODO: add injection

        private Task<ApiResult<string>> MakeHttpRequestAsync(Uri url)
        {
            //TODO: support ApiResult and HttpCode
            return ApiClient.GetAsync<string>(url);
        }

        protected virtual TResult ParseResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response))
            {
                return default(TResult);
            }

            try
            {
                return JsonConvert.DeserializeObject<TResult>(response);
            }
            catch
            {
                throw new NHLClientInternalException("Internal error on data parsing");
            }
        }

        public async Task<TResult> ExecuteRequestAsync(TRequest request)
        {
            var url = GenerateUrl(request);
            var response = await MakeHttpRequestAsync(url);
            return ParseResponse(response.Result);
        }
    }
}