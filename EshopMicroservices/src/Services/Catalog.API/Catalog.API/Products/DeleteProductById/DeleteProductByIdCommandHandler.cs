using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using MediatR;
using System.Windows.Input;
using ICommand = BuildingBlocks.CQRS.ICommand;

namespace Catalog.API.Products.DeleteProductById
{
    public record DeleteProductByIdCommand(Guid Id) : ICommand;
    public class DeleteProductByIdCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductByIdCommand>
    {
        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = await session.Query<Product>().Where(obj => obj.Id == request.Id).FirstOrDefaultAsync();

            if (dataToDelete != null)
            {
                session.Delete<Product>(dataToDelete);
                await session.SaveChangesAsync();
            }

            return new Unit();
        }
    }
}
