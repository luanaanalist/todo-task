
using FluentValidation;
using ToDoApp.Application.ViewModel;

namespace ToDoApp.Application.Validators
{
    public class TaskDtoValidator : AbstractValidator<ItemTaskVM>
    {
        public TaskDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
