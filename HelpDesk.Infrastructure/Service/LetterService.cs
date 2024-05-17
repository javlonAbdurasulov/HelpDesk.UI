using HelpDesk.Application.Services.Interfaces;
using HelpDesk.Domain;
using HelpDesk.Domain.DTO.Forma;
using HelpDesk.Domain.DTO.Letter;
using HelpDesk.Domain.Entity;
using HelpDesk.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Infrastructure.Service
{
	public class LetterService : ILetterService
	{
		public AppDbContext _db;
		public IFormService _formService;
		public LetterService(AppDbContext db, IFormService formService)
		{
			_db = db;
			_formService = formService;
		}

		//
		// Nado sozdat UserController potomushto Letter nelzya sozdat bez usera
		//

		public async Task<ResponseModel<Letter>> Create(LetterCreateDTO letterInCreateDto)
		{
			FormaCreateDTO formCreateDto= new FormaCreateDTO()
			{
				DateTime = DateTime.UtcNow,
				Description = letterInCreateDto.DescriptionForm,
				Kabinet = letterInCreateDto.KabinetForm,
				Korpus = letterInCreateDto.KorpusForm,
				Texnika = letterInCreateDto.TexnikaForm
			};
			var forma = await _formService.Create(formCreateDto);

            var newLetter = Letter.CreateLetter(letterInCreateDto.Title, 
				forma.Result.Id,letterInCreateDto.UserId);

			await _db.Letters.AddAsync(newLetter);
			await _db.SaveChangesAsync();

            return new ResponseModel<Letter>(newLetter);
        }

		public async Task<bool> Delete(int? Id)
		{
			var Letter = _db.Letters.FirstOrDefault(x => x.Id == Id);
			if (Letter == null)
			{
				return false;
			}
			int? DeleteformaId = Letter.FormaId;
			Letter.FormaId = null;
			var deleteFormaCheck = await _formService.Delete(DeleteformaId);
			if (!deleteFormaCheck)
			{
				//net takoy formi znachit pismo ne pravilno sozdavalas
				// napisat bi Log tut
				// a na udaleniye bez raznitsi vsyo ravno udalyayem je
			}
			Letter.UserId = null;
			
			_db.Letters.Remove(Letter);

			_db.SaveChanges();

			return true;
		}

		public async Task<IEnumerable<Letter>> GetAll()
		{
			return _db.Letters.ToList();
		}

		public async Task<ResponseModel<Letter>> GetById(int Id)
		{
            var letter = _db.Letters.FirstOrDefault(x => x.Id == Id);
            if (letter == null)
            {
                return new ResponseModel<Letter>(letter, System.Net.HttpStatusCode.NotFound);
            }

            return new ResponseModel<Letter>(letter);
        }

		public async Task<bool> Update(Letter obj)
		{
            var LetterForUpdate = _db.Letters.FirstOrDefault(x => x.Id == obj.Id);
            if (LetterForUpdate == null)
            {
                return false;
            }
            LetterForUpdate.Description = obj.Description;
            LetterForUpdate.Title = obj.Title;
            LetterForUpdate.Status = obj.Status;
			var updateFormaCheck = await _formService.Update(LetterForUpdate.Forma);
			if (!updateFormaCheck)
			{
				return false;
			}
            await _db.SaveChangesAsync();
            return true;
        }
	}
}
