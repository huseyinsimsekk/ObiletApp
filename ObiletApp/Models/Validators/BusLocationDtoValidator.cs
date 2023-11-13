using FluentValidation;
using ObiletApp.Models.DTOs;

namespace ObiletApp.Models.Validators
{
    public class BusLocationDtoValidator : AbstractValidator<BusLocationDto>
    {
        public BusLocationDtoValidator()
        {
            RuleFor(x => x.DeparturaDate).NotNull().WithMessage("{PropertyName} null bırakılamaz")
                .NotEmpty().WithMessage("{PropertyName} boş bırakılamaz")
                .Must(IsValidDeparturaDate).WithMessage("Hareket Saati En Erken Bugun Seçilebilir");
            RuleFor(x => new { x.OrigionId, x.DestinationId }).Must(m => IsValidRoute(m.OrigionId, m.DestinationId));
        }

        private bool IsValidDeparturaDate(DateTime departuraDate)
        {
            if (departuraDate < DateTime.Today)
            {
                return false;
            }
            return true;
        }
        private bool IsValidRoute(int originId, int destinationid)
        {
            if (destinationid == originId)
            {
                return false;
            }
            return true;
        }
    }

}
