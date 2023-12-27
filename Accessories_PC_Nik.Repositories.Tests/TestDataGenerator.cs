﻿using Accessories_PC_Nik.Context.Contracts.Enums;
using Accessories_PC_Nik.Context.Contracts.Models;

namespace Accessories_PC_Nik.Repositories.Tests
{
    static internal class TestDataGenerator
    {
        static internal Client Client(Action<Client>? settings = null)
        {
            var result = new Client
            {
                Id = Guid.NewGuid(),
                Surname = $"Surname{Guid.NewGuid():N}",
                Name = $"Name{Guid.NewGuid():N}",
                Phone = $"Phone{Guid.NewGuid():N}",
                Email = $"Email{Guid.NewGuid():N}@gmail.com",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }
        static internal Worker Worker(Action<Worker>? settings = null)
        {
            var result = new Worker
            {
                Id = Guid.NewGuid(),
                Number = $"Number{Guid.NewGuid():N}",
                Series = $"Series{Guid.NewGuid():N}",
                IssuedBy = $"IssuedBy{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static internal Component Component(Action<Component>? settings = null)
        {
            var result = new Component
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static internal Service Service(Action<Service>? settings = null)
        {
            var result = new Service
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Duration = Random.Shared.Next(2, 6),
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }
        static internal Delivery Delivery(Action<Delivery>? settings = null)
        {
            var result = new Delivery
            {
                Id = Guid.NewGuid(),
                From = $"From{Guid.NewGuid():N}",
                To = $"To{Guid.NewGuid():N}",
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static internal Order Order(Action<Order>? settings = null)
        {
            var result = new Order
            {
                Id = Guid.NewGuid(),
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }

        static internal AccessKey AccessKey(Action<AccessKey>? settings = null)
        {
            var result = new AccessKey
            {
                Id = Guid.NewGuid(),
                Key = Guid.NewGuid(),
                Types = AccessLevelTypes.Assistant,
            };

            result.BaseAuditEntity();

            settings?.Invoke(result);
            return result;
        }


        private static void BaseAuditEntity<TEntity>(this TEntity entity) where TEntity : BaseAuditEntity
        {
            entity.CreatedAt = DateTimeOffset.UtcNow;
            entity.CreatedBy = $"CreatedBy{Guid.NewGuid():N}";
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            entity.UpdatedBy = $"UpdatedBy{Guid.NewGuid():N}";
        }
    }
}
