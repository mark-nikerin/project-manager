using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Common.ErrorResponses;
using ProjectManager.Common.Exceptions;
using ProjectManager.Services.Extensions;
using ProjectManager.Services.Interfaces.DTO.Iterations;
using ProjectManager.Services.Interfaces.Iterations;
using ProjectManager.Storage;
using ProjectManager.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace ProjectManager.Services.Iterations
{
    public class IterationsService : BaseService, IIterationsService
    {
        public IterationsService(ProjectManagerContext context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<IterationDTO>> GetIterations(int projectId)
        {
            var iterations = await _context.Iterations
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Select(x => x.ToDTO())
                .ToListAsync();

            return iterations;
        }

        public async Task<IterationDTO> GetIteration(int projectId, int iterationId)
        {
            var iteration = await _context.Iterations
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == iterationId)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            if (iteration == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Iteration with id={iterationId} not found");

            return iteration;
        }

        public async Task<IterationDTO> AddIteration(int projectId, IterationDTO model)
        {
            if (await IsAlreadyExistsAsync(model.Title, projectId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Iteration with title '{model.Title}' already exists in this project");

            var iteration = new Iteration
            {
                Title = model.Title,
                Description = model.Description,
                ProjectId = projectId,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            await _context.Iterations.AddAsync(iteration);
            await _context.SaveChangesAsync();

            var addedIteration = await _context.Iterations
                .AsNoTracking()
                .Where(x => x.ProjectId == iteration.ProjectId)
                .Where(x => x.Title == iteration.Title)
                .Select(x => x.ToDTO())
                .FirstOrDefaultAsync();

            return addedIteration;
        }

        public async Task<IterationDTO> UpdateIteration(int projectId, int iterationId, IterationDTO model)
        {
            var iteration = await _context.Iterations
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == iterationId)
                .FirstOrDefaultAsync();

            if (iteration == null)
                throw new NotFoundException(ErrorResponseCodes.InvalidOperation,
                    $"Iteration with id={iterationId} not found");

            if (await IsAlreadyExistsAsync(model.Title, projectId, iterationId))
                throw new BadRequestException(ErrorResponseCodes.InvalidOperation,
                    $"Iteration with title '{model.Title}' already exists in this project");

            iteration.Title = model.Title;
            iteration.Description = model.Description;
            iteration.StartDate = model.StartDate;
            iteration.EndDate = model.EndDate;

            _context.Iterations.Update(iteration);
            await _context.SaveChangesAsync();

            var result = iteration.ToDTO();
            return result;
        }

        public async Task DeleteIteration(int projectId, int iterationId)
        {
            var iteration = await _context.Iterations
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Id == iterationId)
                .FirstOrDefaultAsync();

            if (iteration != null)
            {
                _context.Iterations.Remove(iteration);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<bool> IsAlreadyExistsAsync(string title, int projectId, int? id = null)
        {
            var query = _context.Iterations
                .AsNoTracking()
                .Where(x => x.ProjectId == projectId)
                .Where(x => x.Title == title);

            query = id.HasValue
                ? query.Where(x => x.Id != id.Value)
                : query;

            return await query.AnyAsync();
        }
    }
}