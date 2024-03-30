using Joinlife.webui.Core;
using Joinlife.webui.Core.Repositories;
using Joinlife.webui.Core.Services;
using Joinlife.webui.Entities;
using Joinlife.webui.Mapping;
using Joinlife.webui.Models.OrganizerDtos;

namespace Joinlife.webui.Services
{
    public sealed class OrganizerService : IOrganizerService
    {
        private readonly IRepository<Organizer> _repository;
        private readonly IUnitOfWork _unitOfWork;
        OrganizerMapper organizerMapper = new OrganizerMapper();

        public OrganizerService(IRepository<Organizer> repository,
        IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateOrganizerInput input)
        {
            var entity = organizerMapper.CreateOrganizerInputToOrganizer(input);
            await _repository.CreateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var organizer = await _repository.GetAsync(x => x.Id == id);
            await _repository.DeleteAsync(organizer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<GetOrganizerResponse>> GetAllAsync()
        {
            var organizers = await _repository.GetAllAsync();
            return organizerMapper.OrganizerListToGetOrganizerResponseList(organizers);
        }

        public async Task<GetOrganizerByIdResponse> GetByIdAsync(Guid id)
        {
            var organizer = await _repository.GetAsync(x => x.Id == id);
            return organizerMapper.OrganizerToGetOrganizerByIdResponse(organizer);
        }

        public async Task UpdateAsync(UpdateOrganizerInput input)
        {
            var entity = organizerMapper.UpdateOrganizerInputToOrganizer(input);
            await _repository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}