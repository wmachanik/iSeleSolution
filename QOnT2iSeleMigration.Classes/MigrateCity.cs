using iSele.Models.General;
using iSele.Repository.Interfaces;
using iSele.Services.Tools;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace QOnT2iSeleMigration.Classes
{
    public class MigrateCity
    {
        public ILoggerManager Logger { get; }
        private IFancyGenericRepository<City> CityRepository { get; set; }
        private IFancyGenericRepository<Area> AreaRepository { get; set; }
        private IFancyGenericRepository<AreaDaySetting> AreaDaySettingRepository { get; set; }

        public MigrateCity(ILoggerManager logger,
            IFancyGenericRepository<City> cityRepository,
                            IFancyGenericRepository<Area> areaRepository,
                            IFancyGenericRepository<AreaDaySetting> areaDaySettingRepository)
        {
            this.Logger = logger;
            this.CityRepository = cityRepository;
            this.AreaRepository = areaRepository;
            this.AreaDaySettingRepository = areaDaySettingRepository;
        }

        //public async Task<bool> 
        public bool AddOrUpdateArea(int ID, Area area)
        {
            Area _Area = AreaRepository.GetById(ID);

            if (_Area == null)
            {
                //await 
                Logger.LogInfo($"  *Inserting Area with id: {ID} and name {area.AreaName}");
                AreaRepository.AddWithIDOn(area, "iSele.Areas");

                //    new Area
                //{
                //    AreaID = cityID,
                //    AreaName = area.AreaName,
                //    EstimatedDeliveryDelay = area.EstimatedDeliveryDelay,
                //    NextDispatchDay = area.NextDispatchDay,
                //    NextManufacturingDay = area.NextManufacturingDay,
                //    Note = string.Format("Migrated from QOnT.City {0:d}", DateTime.Now.Date)
                //},
                //"iSele.Areas");
                return true;
            }
            else
            {
                if (area != _Area)
                {
                    //await 
                    Logger.LogInfo($"  *Updating Area with id: {ID} and name {area.AreaName}");
                    AreaRepository.Update(area);
                }
                return false;
            }
        }

        //public async Task<bool> 
        public bool AddOrUpdateAreaDays(int areaDaySettingID, AreaDaySetting areaDaySetting)
        {
            AreaDaySetting _AreaDaySetting = AreaDaySettingRepository.GetById(areaDaySettingID);
            if (_AreaDaySetting == null)
            {
                //await 
                Logger.LogInfo($"  *Inserting AreaDays with id: {areaDaySettingID} and area id {areaDaySetting.AreaID}");
                AreaDaySettingRepository.AddWithIDOn(areaDaySetting, "iSele.AreaDaySettings");
                return true;
            }
            else
            {
                Logger.LogInfo($"  *Updating AreaDays with id: {areaDaySettingID} and area id {areaDaySetting.AreaID}");
                AreaDaySettingRepository.Update(areaDaySetting);
                return false;
            }
        }

        public bool AddOrUpdateCity(int cityID, City city)
        {
            City _City = CityRepository.GetById(cityID);
            if (_City == null)
            {
                Logger.LogInfo($"  *Inserting city with cityID: {cityID} and city name {city.CityName}");

                CityRepository.AddWithIDOn(city, "iSele.Cities");
                //await CityRepository.AddWithIDOnAsync(new City
                //{
                //    CityID = cityID,
                //    CityName = city.CityName,
                //    AreaID = city.CityID,
                //    CountryCode = "ZAF",
                //    Notes = String.Format("Update {0:d}", DateTime.UtcNow.Date)
                //},
                //    "iSele.Cities");
                return true;
            }
            else
            {
                Logger.LogInfo($"  *Updating city with cityID: {cityID} and city name {city.CityName}");
                CityRepository.UpdateAsync(city);
                return false;
            }
        }


    }
}
