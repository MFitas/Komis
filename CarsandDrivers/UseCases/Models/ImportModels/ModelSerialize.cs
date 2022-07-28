using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CarsAndDrivers.UseCases.Models.ImportModels
{
    public class ModelSerialize
    {
        public List<string> CarModels { get; set; }
    }
}