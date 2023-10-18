using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Handlers
{
    public class WalmartApiHandler  {

        AppSettings appSettings;
        public WalmartApiHandler(IAppSettingsLoader appSettingsLoader)
        {
            appSettings = appSettingsLoader.GetSettings();
        }

        public async Task<WalmartProductSearchResponse> Handle(WalmartProductSearchRequest request, CancellationToken cancellationToken){
            WalmartProductSearchResponse response = new WalmartProductSearchResponse();
           
            if(request == null)
            {
                throw new ArgumentNullException();
            }

            var validationErrors = RequestValidator.Validate<WalmartProductSearchRequest>(request);
            
            if(validationErrors.Count > 0) {
                response.ValidationErrors = validationErrors;
                return response;
            }

            string url = $"http://api.walmartlabs.com/v1/search?apiKey={appSettings.WalmartApiKey}&query={request.Query}&facet=on";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serializer = new DataContractJsonSerializer(typeof(WalmartProductSearchApiResponse));
            var streamTask = httpClient.GetStreamAsync(url);
            var walmartProductSearchApiResponse = serializer.ReadObject(await streamTask) as WalmartProductSearchApiResponse;
            if (walmartProductSearchApiResponse == null)
            {
                response.Code = ResponseCode.Error;
                response.Message = "walmartProductSearchApiResponse is null.";
                return response;
            }

            if (walmartProductSearchApiResponse.Items == null)
            {
                response.Code = ResponseCode.Error;
                response.Message = "walmartProductSearchApiResponse.Items is null.";
                return response;
            }

            response.Records = new List<WalmartProductSearchItem>();
            
            foreach(var item in walmartProductSearchApiResponse.Items)
            {
                var walmartProductSearchItem = new WalmartProductSearchItem
                {
                    CategoryPath = item.CategoryPath,
                    Name = item.Name,
                    SalePrice = item.SalePrice,
                    ShortDescription = item.ShortDescription,
                    ProductUrl = item.ProductUrl,
                    ThumbnailImage = item.ThumbnailImage
                };

                response.Records.Add(walmartProductSearchItem);
            }

            response.Records = response.Records.OrderBy(r => r.Name).ToList();

            response.Code = ResponseCode.Success;

            return response;
        }
    }
}