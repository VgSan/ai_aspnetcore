﻿using AutoMapper;
using Aisys.Core;
using Aisys.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aisys.Application
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IMapper _mapper;
        IGenericRepository<Workflow> _workflowRepository;

        public WorkflowService(IMapper mapper,
            IGenericRepository<Workflow> workflowRepository)
        {
            _mapper = mapper;
            _workflowRepository = workflowRepository;
        }

        public async Task<WorkflowDto> GetWorkflow(int id)
        {
            Workflow workflow = await _workflowRepository.GetByIdAsync(id);
            var result = _mapper.Map<WorkflowDto>(workflow);
            return result;
        }

        public async Task CreateWorkflow(WorkflowInput input)
        {
            Workflow result = _mapper.Map<Workflow>(input);
            await _workflowRepository.Create(result);
        }

        public List<WorkflowDto> GetWorkflows()
        {
            List<Workflow> listOfWorkflow = _workflowRepository.GetAll().ToList();
            var result = _mapper.Map<List<WorkflowDto>>(listOfWorkflow);

            return result;
        }

        public async Task UpdateWorkflow(WorkflowDto input)
        {
            Workflow result = _mapper.Map<Workflow>(input);
            result.ModifiedDate = DateTime.Now;

            await _workflowRepository.Update(input.Id, result);
        }
        public async Task DeleteWorkflow(int id)
        {
            await _workflowRepository.Delete(id);
        }
    }
}
