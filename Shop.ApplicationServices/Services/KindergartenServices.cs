
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public  class KindergartenServices : IKindergartenServices
    {

        private readonly ShopContext _context;
     

        public KindergartenServices
            (
                ShopContext context
           
               
            )
        {
            _context = context;
            
           
        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
        {
            Kindergarten kindergarten = new();
            
            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher=dto.Teacher;
            kindergarten.ChildrenCount=dto.ChildrenCount;
            kindergarten.CreatedAt= DateTime.Now;
            kindergarten.ModifiedAt = DateTime.Now;
         
       
            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        //public async Task<Kindergarten> Update(KindergartenDto dto)
        //{


        //    var existingKindergarten = await _context.Kindergartens.FindAsync(dto.Id);

        //    if (existingKindergarten == null)
        //    {
        //        // Handle not found case, e.g., return null or throw an exception
        //        return null;
        //    }

        //    // Check for concurrency conflict by comparing ModifiedAt timestamps
        //    if (existingKindergarten.ModifiedAt > dto.ModifiedAt)
        //    {
        //        // Handle the concurrency conflict, e.g., return null or throw an exception
        //        return null;
        //    }

        //    // Update properties of the entity
        //    existingKindergarten.GroupName = dto.GroupName;
        //    existingKindergarten.KindergartenName = dto.KindergartenName;
        //    existingKindergarten.Teacher = dto.Teacher;
        //    existingKindergarten.ChildrenCount = dto.ChildrenCount;
        //    existingKindergarten.ModifiedAt = DateTime.Now;

        //    await _context.SaveChangesAsync();

        //    return existingKindergarten;
        //}



        //    Kindergarten kindergarten = new();

        //    kindergarten.Id = Guid.NewGuid();
        //    kindergarten.GroupName = dto.GroupName;
        //    kindergarten.KindergartenName = dto.KindergartenName;
        //    kindergarten.Teacher = dto.Teacher;
        //    kindergarten.ChildrenCount = dto.ChildrenCount;
        //    kindergarten.CreatedAt = dto.CreatedAt;
        //   kindergarten.ModifiedAt = DateTime.Now;



        //    _context.Kindergartens.Update(kindergarten);
        //    await _context.SaveChangesAsync();

        //    return kindergarten;
        //}







        public async Task<Kindergarten> Update(KindergartenDto dto)
        {
            var domain = new Kindergarten()
            {
                Id = dto.Id,
                GroupName = dto.GroupName,
                ChildrenCount = dto.ChildrenCount,
                KindergartenName = dto.KindergartenName,
                Teacher = dto.Teacher,


                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,



            };

            _context.Kindergartens.Update(domain);
            await _context.SaveChangesAsync();


            return domain;
        }


        public async Task<Kindergarten> GetAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


        public async Task<Kindergarten> Delete(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Kindergartens.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

       
    }
}

