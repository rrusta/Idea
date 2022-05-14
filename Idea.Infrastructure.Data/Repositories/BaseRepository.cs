using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Idea.Domain.Context;
using Idea.Domain.Models;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Domain.DTOs.SelectDTOs;

namespace RealEstate.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IdeaDbContext _ctx;

        public BaseRepository(IdeaDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual async Task<T> InsertAsync<T>(T entity) where T : class
        {
            await _ctx.Set<T>().AddAsync(entity);

            await _ctx.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync<T>(T t, object key) where T : class
        {
            if (t == null)
                return null;
            T exist = await _ctx.Set<T>().FindAsync(key);
            if (exist != null)
            {
                _ctx.Entry(exist).CurrentValues.SetValues(t);
                await _ctx.SaveChangesAsync();
            }
            return exist;
        }

        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            _ctx.Set<T>().Remove(entity);
            return await _ctx.SaveChangesAsync();
        }

        public async Task<int> CountAsync<T>() where T : class
        {
            return await _ctx.Set<T>().CountAsync();
        }

        public async Task<ICollection<T>> FindAllAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await _ctx.Set<T>().Where(match).ToListAsync();
        }

        public virtual async Task<T> FindAsync<T>(Expression<Func<T, bool>> match) where T : class
        {
            return await _ctx.Set<T>().SingleOrDefaultAsync(match);
        }

        public virtual async Task<ICollection<T>> GetAllAsync<T>() where T : class
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync<T>(int id) where T : class
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public virtual async Task<ICollection<T>> FindByAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _ctx.Set<T>().Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {

            IQueryable<T> queryable = GetAll<T>();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        private IQueryable<T> GetAll<T>() where T : class
        {
            return _ctx.Set<T>();
        }

        public PublicationsSelect MapToPublicationList(SqlDataReader rdr)
        {
            return new PublicationsSelect()
            {
                PublicationId = rdr["PublicationId"].ToString().ParseInt(),
                ParentPublicationId = rdr["ParentPublicationId"].ToString().ParseNullableInt(),
                Email = rdr["Email"].ToString(),
                CreatedBy = rdr["CreatedBy"].ToString(),
                CreatedAt = rdr["CreatedAt"].ToString().ParseDateTime(),
                UpdatedBy = rdr["UpdatedBy"].ToString(),
                UpdatedByUser = rdr["UpdatedByUser"].ToString(),
                LastUpdatedAt = rdr["LastUpdatedAt"].ToString().ParseNullableDateTime(),
                PublisherTypeId = rdr["PublisherTypeId"].ToString().ParseInt(),
                PublisherType = rdr["PublisherType"].ToString(),
                PublicationTypeId = rdr["PublicationTypeId"].ToString().ParseInt(),
                PublicationType = rdr["PublicationType"].ToString(),
                PublicationCategoryId = rdr["PublicationCategoryId"].ToString().ParseInt(),
                PublicationCategory = rdr["PublicationCategory"].ToString(),
                PhoneNumber = rdr["PhoneNumber"].ToString(),
                WhatsappPhoneNumber = rdr["WhatsappPhoneNumber"].ToString(),
                ViberPhoneNumber = rdr["ViberPhoneNumber"].ToString(),
                PhonePrefix = rdr["PhonePrefix"].ToString(),
                WhatsappPrefix = rdr["WhatsappPrefix"].ToString(),
                ViberPrefix = rdr["ViberPrefix"].ToString(),
                Quadrature = rdr["Quadrature"].ToString().ParseNullableDecimal(),
                QuadratureUnitId = rdr["QuadratureUnitId"].ToString().ParseNullableInt(),
                QuadratureUnit = rdr["QuadratureUnit"].ToString(),
                Area = rdr["Area"].ToString().ParseNullableDecimal(),
                AreaUnitId = rdr["AreaUnitId"].ToString().ParseNullableInt(),
                AreaUnit = rdr["AreaUnit"].ToString(),
                OriginalPrice = rdr["OriginalPrice"].ToString().ParseDecimal(),
                Price = rdr["Price"].ToString().ParseDecimal(),
                PriceUnitId = rdr["PriceUnitId"].ToString().ParseInt(),
                PriceUnit = rdr["PriceUnit"].ToString(),
                DistrictId = rdr["DistrictId"].ToString().ParseInt(),
                District = rdr["District"].ToString(),
                TownId = rdr["TownId"].ToString().ParseNullableInt(),
                Town = rdr["Town"].ToString(),
                Address = rdr["Address"].ToString(),
                AddressObject = rdr["AddressObject"].ToString(),
                AddressEntry = rdr["AddressEntry"].ToString(),
                AddressLatitude = rdr["AddressLatitude"].ToString().ParseNullableDecimal(),
                AddressLongitude = rdr["AddressLongitude"].ToString().ParseNullableDecimal(),
                KitchenRoomNumber = rdr["KitchenRoomNumber"].ToString().ParseNullableInt(),
                RoomsNumber = rdr["RoomsNumber"].ToString().ParseNullableInt(),
                KitchenNumber = rdr["KitchenNumber"].ToString().ParseNullableInt(),
                BedroomsNumber = rdr["BedroomsNumber"].ToString().ParseNullableInt(),
                WarehouseroomsNumber = rdr["WarehouseroomsNumber"].ToString().ParseNullableInt(),
                BathroomsNumber = rdr["BathroomsNumber"].ToString().ParseNullableInt(),
                Description = rdr["Description"].ToString(),
                PublicationStatusId = rdr["PublicationStatusId"].ToString().ParseInt(),
                PublicationStatus = rdr["PublicationStatus"].ToString(),
                HasElevator = rdr["HasElevator"].ToString().ParseNullableBool(),
                HasAirConditioner = rdr["HasAirConditioner"].ToString().ParseNullableBool(),
                HasCentralHeating = rdr["HasCentralHeating"].ToString().ParseNullableBool(),
                HasTV = rdr["HasTV"].ToString().ParseNullableBool(),
                HasInternet = rdr["HasInternet"].ToString().ParseNullableBool(),
                HasClothesWasher = rdr["HasClothesWasher"].ToString().ParseNullableBool(),
                HasDishWasher = rdr["HasDishWasher"].ToString().ParseNullableBool(),
                HasPrivateGarage = rdr["HasPrivateGarage"].ToString().ParseNullableBool(),
                HasPublicParking = rdr["HasPublicParking"].ToString().ParseNullableBool(),
                HasAlarm = rdr["HasAlarm"].ToString().ParseNullableBool(),
                HasSwimmingPool = rdr["HasSwimmingPool"].ToString().ParseNullableBool(),
                HasBalcony = rdr["HasBalcony"].ToString().ParseNullableBool(),
                HasTerrace = rdr["HasTerrace"].ToString().ParseNullableBool(),
                HasElectricCentralHeating = rdr["HasElectricCentralHeating"].ToString().ParseNullableBool(),
                HasRollerShutters = rdr["HasRollerShutters"].ToString().ParseNullableBool(),
                IsFavorite = rdr["IsFavorite"].ToString().ParseNullableBool(),
                Watched = rdr["Watched"].ToString().ParseNullableBool(),
                PublicationStateId = rdr["PublicationStateId"].ToString().ParseNullableInt(),
                PublicationState = rdr["PublicationState"].ToString(),
                ByAgreement = rdr["ByAgreement"].ToString().ParseNullableBool(),
                Attachments = rdr["Attachments"] == null ? new List<AttachmentsSelect>() : JsonConvert.DeserializeObject<List<AttachmentsSelect>>(rdr["Attachments"].ToString()),
                RejectionReasons = rdr["RejectionReasons"] == null ? new List<RejectionReasons>() : JsonConvert.DeserializeObject<List<RejectionReasons>>(rdr["RejectionReasons"].ToString()),
                Avatar = rdr["Avatar"].ToString()
            };
        }
    }
}
