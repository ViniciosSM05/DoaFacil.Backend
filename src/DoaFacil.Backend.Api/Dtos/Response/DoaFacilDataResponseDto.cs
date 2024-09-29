﻿using Newtonsoft.Json;

namespace DoaFacil.Backend.Api.Dtos.Response
{
    public class DoaFacilDataResponseDto<TData> : DoaFacilResponseDto
    {
        [JsonProperty("data")]
        public TData Data { get; private set; }

        public void SetData(TData data)
        {
            Data = data;
        }
    }
}
