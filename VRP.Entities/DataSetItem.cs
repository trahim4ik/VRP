using System;
using VRP.Core.Enums;
using VRP.Core.Interfaces;

namespace VRP.Entities {
    public class DataSetItem : IId<long>, IEntity, IExpirable {

        #region Primary

        public long Id { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long DataSetId { get; set; }
        public DataSet DataSet { get; set; }
        public DataSetType DataSetType { get; set; }

        #endregion

        #region Primary Properties

        /// <summary>
        /// Sale price (this is the target variable)
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// Date of transaction
        /// </summary>
        public DateTime? SaleDate { get; set; }

        /// <summary>
        /// Total area in square meters, including loggias, balconies and other non-residential areas
        /// </summary>
        public double? FullArea { get; set; }

        /// <summary>
        /// Living area in square meters, excluding loggias, balconies and other non-residential areas
        /// </summary>
        public double? LifeArea { get; set; }

        /// <summary>
        /// For apartments, floor of the building
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        ///  Number of floors in the building
        /// </summary>
        public int? MaxFloor { get; set; }

        /// <summary>
        /// Wall material
        /// </summary>
        public int Material { get; set; }

        /// <summary>
        /// Year built
        /// </summary>
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Number of living rooms
        /// </summary>
        public int? Rooms { get; set; }

        /// <summary>
        /// Kitchen area
        /// </summary>
        public double? KitchenArea { get; set; }

        /// <summary>
        /// Apartment condition
        /// </summary>
        public int? State { get; set; }

        /// <summary>
        /// Owner-occupier purchase or investment
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Name of the district
        /// </summary>
        public string District { get; set; }

        #endregion

        #region Description of neighbourhood features

        /// <summary>
        /// Subarea population
        /// </summary>
        public int? Population { get; set; }

        /// <summary>
        /// Subarea male population
        /// </summary>
        public int? Male { get; set; }

        /// <summary>
        /// Subarea Female population
        /// </summary>
        public int? Female { get; set; }

        /// <summary>
        /// Population younger than working age
        /// </summary>
        public int? YoungAll { get; set; }

        /// <summary>
        /// Population males younger than working age
        /// </summary>
        public int? YoungMale { get; set; }

        /// <summary>
        /// Population males younger than working age
        /// </summary>
        public int? YoungFemale { get; set; }

        /// <summary>
        /// Working-age population
        /// </summary>
        public int? WorkAll { get; set; }

        /// <summary>
        /// Working-age population for male
        /// </summary>
        public int? WorkMale { get; set; }

        /// <summary>
        /// Working-age population for female
        /// </summary>
        public int? WorkFemale { get; set; }

        /// <summary>
        /// Retirement-age population for all
        /// </summary>
        public int? ElderAll { get; set; }

        /// <summary>
        /// Retirement-age population for male
        /// </summary>
        public int? ElderMale { get; set; }

        /// <summary>
        /// Retirement-age population for female
        /// </summary>
        public int? ElderFemale { get; set; }

        /// <summary>
        /// Time to subway by car, min.
        /// </summary>
        public double? CarMetroMin { get; set; }

        /// <summary>
        /// Distance to subway by car
        /// </summary>
        public double? CarMetroDistance { get; set; }

        /// <summary>
        /// Time to metro by foot
        /// </summary>
        public double? TimeToMetro { get; set; }

        /// <summary>
        /// Distance to the metro, km
        /// </summary>
        public double? MetroDistance { get; set; }

        /// <summary>
        /// Distance to kindergarten
        /// </summary>
        public double? KindergartenDistance { get; set; }

        /// <summary>
        /// Distance to high school
        /// </summary>
        public double? SchoolDistance { get; set; }

        /// <summary>
        /// Distance to park
        /// </summary>
        public double? ParkDistance { get; set; }

        /// <summary>
        /// Distance to green zone
        /// </summary>
        public double? GreenZoneDistance { get; set; }

        /// <summary>
        /// Distance to industrial zone
        /// </summary>
        public double? IndustrialZoneDistance { get; set; }

        /// <summary>
        /// Distance to train station(avto)
        /// </summary>
        public double? TrainStationDistance { get; set; }

        /// <summary>
        /// Distance to bus terminal (avto)
        /// </summary>
        public double? BusTerminalDistance { get; set; }

        /// <summary>
        /// Distance to grocery / wholesale markets
        /// </summary>
        public double? BigMarketDistance { get; set; }

        /// <summary>
        /// Distance to markets and department stores
        /// </summary>
        public double? MarketDistance { get; set; }

        /// <summary>
        /// Distance to fitness
        /// </summary>
        public double? FitnessDistance { get; set; }

        /// <summary>
        /// Distance to swimming pool
        /// </summary>
        public double? SwimmingPoolDistance { get; set; }

        /// <summary>
        /// Distance to ice palace
        /// </summary>
        public double? IcePalaceDistance { get; set; }

        /// <summary>
        /// Distance to stadium
        /// </summary>
        public double? StadiumDistance { get; set; }

        /// <summary>
        /// Distance to the basketball courts
        /// </summary>
        public double? BasketballDistance { get; set; }

        /// <summary>
        /// Distance to hospice/morgue
        /// </summary>
        public double? HospiceDistance { get; set; }

        /// <summary>
        /// Distance to detention facility
        /// </summary>
        public double? DetentionFacilityDistance { get; set; }


        /// <summary>
        /// Distance to public healthcare
        /// </summary>
        public double? PublicHealthcareDistance { get; set; }

        /// <summary>
        /// Distance to universities
        /// </summary>
        public double? UniversityDistance { get; set; }

        #endregion

    }
}
