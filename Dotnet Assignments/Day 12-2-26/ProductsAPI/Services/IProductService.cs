using ProductsAPI.DTOs;

namespace ProductsAPI.Services
{
    public interface IProductService
    {
        List<ProductReadDTO> GetAll();
        ProductReadDTO GetById(int id);

        ProductReadDTO Create(ProductCreateDTO dto);
        bool UpdatePut(int id, ProductUpdateDTO dto);
        bool UpdatePatch(int id, ProductUpdateDTO dto);
        bool Delete(ProductDeleteDTO dto);
    }
}
