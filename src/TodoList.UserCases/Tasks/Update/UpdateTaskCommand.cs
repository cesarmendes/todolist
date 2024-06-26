﻿using FluentResults;
using MediatR;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Update
{
    public record UpdateTaskCommand : IRequest<Result<Task>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
