using DBStorage.GPS;
using Domain.GPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;

namespace Application.GPS
{
    public class GpsService : IGpsService
    {
        private IGpsRepository _repository;

        public GpsService(GpsRepository repository)
        {
            _repository = repository;
        }
    }
}
