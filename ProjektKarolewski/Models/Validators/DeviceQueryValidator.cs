using FluentValidation;
using ProjektKarolewski.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models.Validators
{
    public class DeviceQueryValidator : AbstractValidator<DeviceQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15, 100, 1000};
        private string[] allowedSortByColumnNames = new[] { nameof(Device.Name), nameof(Device.Producer), nameof(Device.Comments)};
        public DeviceQueryValidator()
        {
            RuleFor(d => d.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(d => d.PageSize).Custom((value, context) =>
            {
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(", ", allowedPageSizes)}]");
                }
            });
            RuleFor(d => d.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(", ", allowedSortByColumnNames)}]");
        }
    }
}
