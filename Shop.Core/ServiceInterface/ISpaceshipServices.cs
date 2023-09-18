using Shop.Core.Domain;
using Shop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {

        Task<Spaceship> Create(SpaceshipDto dto);
        Task<Spaceship> GetAsync(Guid id);
    }
}
