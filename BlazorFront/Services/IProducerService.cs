using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerDto>> GetProducers();
        Task<IEnumerable<ProducerDto>> GetProducerById(int producerId);
        Task<ProducerDto> AddProducer(ProducerDto producer);
        Task DeleteProducer(int producerId);
        Task<ProducerDto> UpdateProducer(ProducerDto producer, int producerId);
    }
}
