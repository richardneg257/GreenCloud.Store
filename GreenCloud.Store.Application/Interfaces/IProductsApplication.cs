using GreenCloud.Store.Application.Dtos;

namespace GreenCloud.Store.Application.Interfaces
{
    public interface IProductsApplication
    {
        Task<List<ProductForListDto>> GetProducts();
        Task<ProductDetailDto> GetProduct(int id);
        Task InsertProduct(ProductForCreateDto productForCreateDto);
        Task UpdateProduct(int id, ProductForEditDto productForEditDto);
        Task DeleteProduct(int id);
    }
}
