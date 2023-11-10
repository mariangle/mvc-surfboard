using Lib.Models;

namespace Lib.Services
{
    public class SurfboardService : ISurfboardService
    {
        /// <summary>
        /// A private reference to the storage service from the DI container.
        /// </summary>
        private readonly IStorageService _storageService;

        /// <summary>
        /// Constructs a product service.
        /// </summary>
        /// <param name="storageService">A reference to the storage service from the DI container.</param>
        public SurfboardService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="sku">The unique sku reference.</param>
        /// <returns>A <see cref="ProductModel"/> type.</returns>
        public Surfboard? GetById(int id)
        {
            return _storageService.Surfboards.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>A <see cref="IList<ProductModel>"/> type.</returns>
        public IList<Surfboard> GetAll()
        {
            return _storageService.Surfboards.ToList();
        }

        public Surfboard? Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
