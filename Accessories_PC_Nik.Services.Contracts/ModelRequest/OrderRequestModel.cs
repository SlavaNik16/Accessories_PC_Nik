﻿namespace Accessories_PC_Nik.Services.Contracts.ModelRequest
{
    public class OrderRequestModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Номер пользователя товара
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Выбранная услуга
        /// </summary>
        public Guid? ServiceId { get; set; }

        /// <summary>
        /// Выбранный товар 
        /// </summary>
        public Guid? ComponentId { get; set; }


        /// <summary>
        /// Время заказа
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// Доставка
        /// </summary>
        public Guid? DeliveryId { get; set; }

        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string? Comment { get; set; } = string.Empty;
    }
}
