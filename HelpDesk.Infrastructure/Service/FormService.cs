using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.Entity;
using HelpDesk.Infrastructure.Data;

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

        public Task<Forma> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Forma obj)
        {
            throw new NotImplementedException();
        }
    }
}
