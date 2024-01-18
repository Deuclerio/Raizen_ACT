using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;
using UPD8.Data.Domain.Interfaces.Repository;
using UPD8.Data.Domain.Interfaces.Services;

namespace UPD8.Data.Service.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly IPessoaRepository _iPessoaRepository;

        public PessoaService(IPessoaRepository iPessoaRepository)
        {
            _iPessoaRepository = iPessoaRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _iPessoaRepository.DeleteAsync(id);
        }

        public async Task<PessoaEntity?> GetAsync(int id)
        {
            return await _iPessoaRepository.GetAsync(id);
        }
        public async Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaEntity filter)
        {
            return await _iPessoaRepository.GetListAsync(filter).ToListAsync();
        }

        public async Task<IEnumerable<PessoaEntity>> GetListAsync()
        {
            return await _iPessoaRepository.GetListAsync();
        }

        public async Task InsertAsync(PessoaEntity dto)
        {
            await _iPessoaRepository.InsertAsync(dto);
        }

        public async Task UpdateAsync(PessoaEntity dto)
        {
            await _iPessoaRepository.UpdateAsync(dto);
        }
    }
}
