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
		public async Task<ResponseModel<Letter>> Create(LetterCreateDTO letterInCreateDto)
		{
			FormaCreateDTO formCreateDto= new FormaCreateDTO()
			{
				DateTime = DateTime.Now,
				Description = letterInCreateDto.DescriptionForm,
				Kabinet = letterInCreateDto.KabinetForm,
				Korpus = letterInCreateDto.KorpusForm,
				Texnika = letterInCreateDto.TexnikaForm
			};
			var forma = await _formService.Create(formCreateDto);

            var newLetter = Letter.CreateLetter(letterInCreateDto.Status, 
				letterInCreateDto.Description, letterInCreateDto.Title, 
				letterInCreateDto.ActionType,forma.Result.Id);

			await _db.Letters.AddAsync(newLetter);
			await _db.SaveChangesAsync();

            return new ResponseModel<Letter>(newLetter);
        }

		public Task<bool> Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Letter>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Letter> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Letter obj)
		{
			throw new NotImplementedException();
		}
	}
}
