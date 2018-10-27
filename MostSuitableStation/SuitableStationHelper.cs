using System;
using System.Collections.Generic;
using System.Linq;
using MostSuitableStation.Model;
using MostSuitableStation.Utilities;

namespace MostSuitableStation
{
    public class SuitableStationHelper
    {
        private readonly List<Station> _stations;
        public SuitableStationHelper(List<Station> stations)
        {
            Ensure.ArgumentNotNull(stations, nameof(stations));
            _stations = stations;
        }

        public string MostSuitableStationFor(Point point)
        {
            Ensure.ArgumentNotNull(point, nameof(point));

            var bestStation = _stations.Select(s => new
                {
                    s.Coordinates,
                    s.Reach,
                    Power = CalculatePower(point, s.Coordinates, s.Reach)
                })
                .Where(s => s.Power > 0)
                .OrderByDescending(s => s.Power)
                .FirstOrDefault();

            return bestStation == null ? 
                    $"No link station within reach for point {point.X}, {point.Y}" :
                    $"Best link station for point {point.X}, {point.Y} is {bestStation.Coordinates.X}, {bestStation.Coordinates.Y} with power {bestStation.Power}";
        }

        private static double CalculatePower(Point point, Point station, int reach)
        {
            var distance = Math.Sqrt(Math.Pow(point.X - station.X, 2) + Math.Pow(point.Y - station.Y, 2));
            return distance > reach ? 0 : Math.Pow(reach - distance, 2);
        }
    }
}
