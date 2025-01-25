//using FluentValidation;

//namespace LMS.Identity.API.Application.Commands.UserLoginCommand
//{
//    public class ValidateUserValidator : AbstractValidator<UpsertUserCommand>
//    {
//        public ValidateUserValidator()
//        {
//            RuleFor(v => v.Name).NotEmpty();

//            RuleFor(v => v.Email)
//                .NotEmpty()
//                .MaximumLength(100)
//                .EmailAddress()
//                .WithMessage("Email must be a valid email address.");

//            RuleFor(v => v.Password).NotEmpty().MaximumLength(25);
//        }
//    }
//}
