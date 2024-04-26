using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOTracker.Application.Trackers.Commands
{
    public class SearchCommandValidator : AbstractValidator<SearchCommand>
    {
        public SearchCommandValidator()
        {
            RuleFor(s => s.Url).NotEmpty().WithMessage("Url must not be empty.");
            RuleFor(s => s.Keywords).NotEmpty().WithMessage("Keywords must not be empty.");
        }
    }
}
