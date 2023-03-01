using AutoMapper;
using GreenCloud.Store.Application.Dtos;
using GreenCloud.Store.Application.Interfaces;
using GreenCloud.Store.Entity;
using GreenCloud.Store.Repository.Interfaces;

namespace GreenCloud.Store.Application.Implementations
{
    public class ProductsApplication : IProductsApplication
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsApplication(IProductsRepository productsRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.mapper = mapper;
        }

        public async Task<List<ProductForListDto>> GetProducts()
        {
            var products = await productsRepository.GetProducts();
            
            var productsDto = mapper.Map<List<ProductForListDto>>(products);
            return productsDto;
        }

        public async Task<ProductDetailDto> GetProduct(int id)
        {
            var product = await productsRepository.GetProduct(id);

            var productDto = mapper.Map<ProductDetailDto>(product);
            return productDto;
        }

        public async Task InsertProduct(ProductForCreateDto productForCreateDto)
        {
            var productEntity = mapper.Map<Product>(productForCreateDto);

            await productsRepository.InsertProduct(productEntity);
        }

        public async Task UpdateProduct(int id, ProductForEditDto productForEditDto)
        {
            var productEntity = await productsRepository.GetProduct(id);

            mapper.Map(productForEditDto, productEntity);

            await productsRepository.UpdateProduct(productEntity);
        }

        public async Task DeleteProduct(int id)
        {
            var productEntity = await productsRepository.GetProduct(id);
            await productsRepository.DeleteProduct(productEntity);
        }
    }
}
