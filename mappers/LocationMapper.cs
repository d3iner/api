using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.location;
using api.models;

namespace api.mappers
{
    public static class LocationMapper
    {
        public static LocationDto ToLocationDto(this Location location){
            return new  LocationDto{
                id = location.id,
                name = location.name,
            };
        }

        public static Location ToLocationFromCreateDto(this LocationCreateDto location){
            return new Location{
                name = location.name,
                
            };
        }
    }
}