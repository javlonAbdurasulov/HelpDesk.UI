using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.Entity;
using HelpDesk.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infrastructure.Service
{
    public class FormService : IFormService
    {
        public AppDbContext _db;

        public FormService(AppDbContext Context)
        {
            _db = Context;
        }
        public async Task<ResponseModel<Forma>> Create(FormaCreateDTO obj)
        {
            var newForma = Forma.CreateForma(obj.Description, obj.Texnika, obj.Korpus, obj.Kabinet);

            await _db.Formas.AddAsync(newForma);
            await _db.SaveChangesAsync();

            return new ResponseModel<Forma>(newForma);
        }

        public async Task<bool> Delete(int Id)
        {
            var deleteForm = _db.Formas.FirstOrDefault(x => x.Id == Id);
            if (deleteForm == null)
            {
                return false;
            }
            var delete = _db.Formas.Remove(deleteForm);
            
            _db.SaveChanges();
            return true;
        }

        public async Task<ResponseModel<Forma>> GetById(int Id)
        {
            var forma = _db.Formas.FirstOrDefault(x => x.Id == Id);
            if (forma == null)
            {
                return new ResponseModel<Forma>(forma,System.Net.HttpStatusCode.NotFound);
            }

            return new ResponseModel<Forma>(forma);
        }

        public async Task<bool> Update(Forma obj)
        {
            var FormasForUpdate = _db.Formas.FirstOrDefault(x=>x.Id == obj.Id);
            if (FormasForUpdate == null)
            {
                return false;
            }
            FormasForUpdate.Description = obj.Description;
            FormasForUpdate.Korpus = obj.Korpus;
            FormasForUpdate.DateTime = DateTime.UtcNow;
            FormasForUpdate.Kabinet = obj.Kabinet;
            await _db.SaveChangesAsync();
            return true;
        }

    }
}
