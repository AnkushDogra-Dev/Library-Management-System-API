//using LMS.Identity.API.Interfaces;
//using MediatR;

//namespace LMS.Identity.API.Application.Commands
//{
//    public record DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
//    {
//        private readonly IIdentity _repository;

//        private readonly IMediator _mediator;

//        public DeleteUserCommandHandler(IIdentity repository, IMediator mediator)
//        {
//            _repository = repository;
//            _mediator = mediator;
//        }

//        public async Task<string> Handle(
//            DeleteUserCommand request,
//            CancellationToken cancellationToken
//        )
//        {
//            var user = await _repository.GetByIdAsync(request.Id);
//            if (user is null)
//            {
//                throw new Exception("Constant.ProductNotFound");
//            }

//            await _repository.DeleteAsync(request.Id);

//            return "Constant.ProductDeleted";
//        }
//    }
//}
