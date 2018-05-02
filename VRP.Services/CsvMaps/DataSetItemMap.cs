using CsvHelper.Configuration;
using VRP.Dtos;
using VRP.Services.Converters;

namespace VRP.Services.CsvMaps {

    public sealed class DataSetItemMap : ClassMap<DataSetItemModel> {

        public DataSetItemMap() {
            Map(m => m.InsertDate).Ignore();
            Map(m => m.DeleteDate).Ignore();
            Map(m => m.DataSetId).Ignore();
            Map(m => m.DataSetType).Ignore();

            Map(m => m.Price).Name("price_doc").TypeConverter<DoubleTypeConverter>();
            Map(m => m.SaleDate).Name("timestamp").TypeConverter<DateTypeConverter>();
            Map(m => m.FullArea).Name("full_sq").TypeConverter<DoubleTypeConverter>();
            Map(m => m.LifeArea).Name("life_sq").TypeConverter<DoubleTypeConverter>();
            Map(m => m.Floor).Name("floor").TypeConverter<IntTypeConverter>();
            Map(m => m.MaxFloor).Name("max_floor").TypeConverter<IntTypeConverter>();
            Map(m => m.Material).Name("material").TypeConverter<IntTypeConverter>();
            Map(m => m.YearBuilt).Name("build_year").TypeConverter<IntTypeConverter>();
            Map(m => m.Rooms).Name("num_room").TypeConverter<IntTypeConverter>();
            Map(m => m.KitchenArea).Name("kitch_sq").TypeConverter<DoubleTypeConverter>();
            Map(m => m.State).Name("state").TypeConverter<IntTypeConverter>();
            Map(m => m.ProductType).Name("product_type");
            Map(m => m.District).Name("sub_area");

            Map(m => m.Population).Name("full_all").TypeConverter<IntTypeConverter>();
            Map(m => m.Male).Name("male_f").TypeConverter<IntTypeConverter>();
            Map(m => m.Female).Name("female_f").TypeConverter<IntTypeConverter>();
            Map(m => m.YoungAll).Name("young_all").TypeConverter<IntTypeConverter>();
            Map(m => m.YoungMale).Name("young_male").TypeConverter<IntTypeConverter>();
            Map(m => m.YoungFemale).Name("young_female").TypeConverter<IntTypeConverter>();
            Map(m => m.WorkAll).Name("work_all").TypeConverter<IntTypeConverter>();
            Map(m => m.WorkMale).Name("work_male").TypeConverter<IntTypeConverter>();
            Map(m => m.WorkFemale).Name("work_female").TypeConverter<IntTypeConverter>();
            Map(m => m.ElderAll).Name("ekder_all").TypeConverter<IntTypeConverter>();
            Map(m => m.ElderMale).Name("ekder_male").TypeConverter<IntTypeConverter>();
            Map(m => m.ElderFemale).Name("ekder_female").TypeConverter<IntTypeConverter>();

            Map(m => m.CarMetroMin).Name("metro_min_avto").TypeConverter<DoubleTypeConverter>();
            Map(m => m.CarMetroDistance).Name("metro_km_avto").TypeConverter<DoubleTypeConverter>();
            Map(m => m.TimeToMetro).Name("metro_min_walk").TypeConverter<DoubleTypeConverter>();
            Map(m => m.MetroDistance).Name("metro_km_walk").TypeConverter<DoubleTypeConverter>();
            Map(m => m.KindergartenDistance).Name("kindergarten_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.SchoolDistance).Name("school_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.ParkDistance).Name("park_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.GreenZoneDistance).Name("green_zone_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.IndustrialZoneDistance).Name("industrial_zone_km", "industrial_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.TrainStationDistance).Name("zd_vokzaly_avto_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.BusTerminalDistance).Name("bus_terminal_avto_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.BigMarketDistance).Name("big_market_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.MarketDistance).Name("market_shop_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.FitnessDistance).Name("fitness_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.SwimmingPoolDistance).Name("swim_pool_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.IcePalaceDistance).Name("ice_rink_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.StadiumDistance).Name("stadium_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.BasketballDistance).Name("basketball_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.HospiceDistance).Name("hospice_morgue_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.DetentionFacilityDistance).Name("detention_facility_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.PublicHealthcareDistance).Name("public_healthcare_km").TypeConverter<DoubleTypeConverter>();
            Map(m => m.UniversityDistance).Name("university_km").TypeConverter<DoubleTypeConverter>();
        }
    }
}
