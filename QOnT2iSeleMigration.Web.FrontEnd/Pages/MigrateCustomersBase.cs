using iSele.Models.General;
using iSele.Models.Lookups;
//using QOnT.Models;
using iSele.Repository.Interfaces;
using iSele.Services.Tools;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using QOnT2iSeleMigration.Classes;
using QOnT2iSeleMigration.Web.FrontEnd.Models;
using QOnTMSSql.Models;
using QOnTMSSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QOnT2iSeleMigration.Web.FrontEnd.Pages
{
    public partial class MigrateCustomersBase : ComponentBase
    {
        public MigrationStatusClass MigrationStati;
        private MigrationStatusClass _MigrationStati;
        public string MigrateStatusStr = "";
        Random rand = new Random();

        public ICollection<CityTbl> QonTCities = null;

        // qont repos
        #region QOnTRepos
        [Inject]
        private IQOnTFancyGenericRepository<WeekDaysTbl> QOnTWeekDaysTbl { get; set; }
        [Inject]
        private IQOnTFancyGenericRepository<CityTbl> QOnTCityTbl { get; set; }
        [Inject]
        private IQOnTFancyGenericRepository<CityPrepDaysTbl> QOnTCityPrepDaysTbl { get; set; }

        #endregion

        // isele repos
        #region iSele repos
        [Inject]
        private IFancyGenericRepository<WeekDay> iSeleWeekDay { get; set; }
        [Inject]
        private IFancyGenericRepository<City> iSeleCityRepository { get; set; }
        [Inject]
        private IFancyGenericRepository<Area> iSeleAreaRepository { get; set; }
        [Inject]
        private IFancyGenericRepository<AreaDaySetting> iSeleAreaDaySettingRepository { get; set; }
        #endregion

        // standard injections
        [Inject]
        private ILoggerManager Logger { get; set; }

        protected override void OnInitialized()
        {
            MigrationStati = new MigrationStatusClass();
            base.OnInitialized();
        }

        public async Task MigrateAllCustomers_Click()
        {
            MigrateStatusStr = (MigrateStatusStr == string.Empty) ? "Clicked" : string.Empty;

            await UpdateStati();
        }


        public async Task<bool> MigrateCity_Click()
        {
            #region LogicOfMigratiom
            /*
             * Cities have been migrated to and areas table
             * 
             * City Related Tables
             * QOnT                        iSele
             * =======================     ===================
             * CityTbl                      Cities & Areas will be the same ID and name
             * CityPrepDaysTbl              AreDaySettings
             * NextRoastDateByCity          no longer used, now this dqta sits in AreaTbl, as this is caluclated per day, this date will not be migrated.
             * 
             * FieldMapping
             * ================ 
             * 
             * CityTbl:
             * ID  => Cities.CityID = Cities.AreaID; Areas.AeriaID
             * City => Cities.CityName; Areas.AreaName; 
             *   
             *   Set. Notes to migrate or update
             *   --- not other data from CotyTbl
             * 
             * foreach CityPrepDay with CityID= CityTbl.ID
             * CityPrepDaysTbl:
             *   CityID  => Areas.AreaID
             *   PrepDAyOfWeekID => PreperationDayOfWeekID
             *   DeliveryDelayDays => DispatchDelayDays
             *   DeliveryOrder = > DeliveryOrder
             *   set EstimageDeiveryDelay = 0 - or can we do some logic here? this is used for thirdpartydeliveries
             *   Set. Notes to migrate or update   
             */
            #endregion
            bool success = false;

            QonTCities = QOnTCityTbl.GetAll();

            Logger.LogInfo("Started the city migration");



            // Need to o a migration before riunning as Changed the settings

            // Declare all the QOnT classes needed
            /*replace with SQL migration
                        CityTblDAL QonTCityTbl = new CityTblDAL();
                        CityPrepDaysTbl QOnTCityPrepDaysTbl = new CityPrepDaysTbl();
            */


            // get the data from the City table whcih is the parent table
            /*replace with SQL migration
                        List<CityTblData> QonTCities = QonTCityTbl.GetAll("ID");
            */


            // set migration status
            _MigrationStati = new MigrationStatusClass();
            _MigrationStati.SourceTable = "QOnT->WeekDaysTbl";
            _MigrationStati.SourceTable = "ISele->WeekDays";
            _MigrationStati.CurrentSourceRecorderNumber = 0;
            await UpdateStati();

            MigrateWeekDays migrateWeekDay = new MigrateWeekDays(
                QOnTWeekDaysTbl.GetAll().ToList(),
                iSeleWeekDay);

            Logger.LogInfo(" Migrationing WeekDays...");

            success = await migrateWeekDay.AddOrUpdateWeekDays();

            if (success)
                Logger.LogInfo("  WeekDays migration done.");
            else
                Logger.LogError("  There was a problem migrating WeekDays!");
            

            _MigrationStati.Clear();
            _MigrationStati.SourceTable = "QOnT->WeekDays, City & CityPrepDays";
            _MigrationStati.SourceTable = "ISele->Cities, Area & AreaDaySetting";
            _MigrationStati.CurrentSourceRecorderNumber = 0;
            _MigrationStati.TotalSourceRecorders = QonTCities.Count();


            Logger.LogInfo(" Migrationing QOnT->WeekDays, City & CityPrepDays TO ISele->Cities, Area & AreaDaySetting"); 
            MigrateCity cityMigration = new MigrateCity(Logger, iSeleCityRepository, iSeleAreaRepository, iSeleAreaDaySettingRepository);
            List<AreaDaySetting> areaDaySettings = new List<AreaDaySetting>();

            foreach (var city in QonTCities)
            {
                _MigrationStati.CurrentSourceRecorderNumber++;

                Logger.LogInfo($"Migrating city id: {city.Id}");
                // Get the day settings for this city now called area
                List<CityPrepDaysTbl> QOnTCityPrepDays = QOnTCityPrepDaysTbl.FindBy(cpd => cpd.CityId == city.Id).ToList();
                areaDaySettings.Clear();
                foreach (var CityPrepDay in QOnTCityPrepDays)
                {
                    Logger.LogDebug($"Migrating QOnTCityPrepDays id: {CityPrepDay.CityPrepDaysId}");
                    AreaDaySetting areaDaySetting = new AreaDaySetting
                    {
                        AreaDaySettingID = CityPrepDay.CityPrepDaysId,
                        AreaID = CityPrepDay.CityId,
                        PreperationDayOfWeekID = CityPrepDay.PrepDayOfWeekId,
                        DispatchDelayDays = CityPrepDay.DeliveryDelayDays,
                        DeliveryOrder = (short)CityPrepDay.DeliveryOrder,
                        EstimateDeliveryDelay = 0,
                        Notes = String.Format("Migrated from QOnT.City {0:d}", DateTime.UtcNow.Date)
                    };
                    areaDaySettings.Add(areaDaySetting);

                    //await 
                    cityMigration.AddOrUpdateAreaDays(CityPrepDay.CityPrepDaysId, areaDaySetting);
                }

                // Add area then areaday then city
                //await 
                Logger.LogDebug($"Migrating city id: {city.Id} to Areas");
                cityMigration.AddOrUpdateArea(city.Id, new Area
                {
                    AreaID = city.Id,
                    AreaName = city.City,
                    EstimatedDeliveryDelay = 0,
                    NextDispatchDay = 1,
                    NextManufacturingDay = 1,
                    AreaDaySettings = areaDaySettings,
                    Note = string.Format("Migrated from QOnT.City {0:d}", DateTime.UtcNow.Date)
                }); 

                Logger.LogDebug($"Migrating city id: {city.Id} to Cities");
                if (cityMigration.AddOrUpdateCity(city.Id, new City
                {
                    CityID = city.Id,
                    CityName = city.City,
                    AreaID = city.Id,
                    CountryCode = "ZAF",
                    Notes = String.Format("Migrated from QOnT.City {0:d}", DateTime.UtcNow.Date)
                }))
                {
                    _MigrationStati.TargetRecordsInserted++;
                }
                else
                {
                    _MigrationStati.TargetRecordsUpdated++;
                }

                // Get the day settings for this city now called area
                QOnTCityPrepDays.Clear();
                areaDaySettings.Clear();



                //foreach (var CityPrepDay in QOnTCityPrepDays)
                //{
                //    await cityMigration.AddOrUpdateAreaDays(city.ID, new AreaDaySetting
                //    {
                //        AreaDaySettingID = CityPrepDay.CityPrepDaysID,
                //        AreaID = CityPrepDay.CityID,
                //        PreperationDayOfWeekID = CityPrepDay.PrepDayOfWeekID,
                //        DispatchDelayDays = (short)CityPrepDay.DeliveryDelayDays,
                //        DeliveryOrder = (short)CityPrepDay.DeliveryOrder,
                //        EstimateDeliveryDelay = 0,
                //        Notes = String.Format("Migrated from QOnT.City {0:d}", DateTime.UtcNow.Date)
                //    });
                //}
                await UpdateStati();
            }
            /**/
            await UpdateStati();
            return success;
        }

        public async Task UpdateStati()
        {
            var MyTask = Task.Run(() => MigrationStati = _MigrationStati);
            await MyTask;
        }
    }
}
