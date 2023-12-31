﻿namespace Accessories_PC_Nik.Api.ModelsRequest.Service
{
    /// <summary>
    /// Модель запроса изменение услуги 
    /// </summary>
    public class EditServiceRequest : CreateServiceRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
