using Microsoft.EntityFrameworkCore;
using sigmaHashAlpha.Core.Repositories;
using sigmaHashAlpha.Data;
using sigmaHashAlpha.Models;

namespace sigmaHashAlpha.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImagesRepository
    {

        public ProductImageRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }

        public async Task<List<string>> ProdAllImages(string id)
        {
            //try
            //{
                List<string> paths = new List<string>();
                short i = 0;
                for(short k = 1; k <= 6; k++)
                {
                    string imgId = id + k.ToString();

                    ProductImage obj = await dbSet.FirstOrDefaultAsync(x=> x.ImagePath.Contains(imgId));
                    if (obj != null)
                        paths.Add(obj.ImagePath);
                }
                if(paths != null)
                    return paths;  
                else
                    return paths = new List<string>();
            //}
            //catch(Exception ex)
            //{
            //    _logger.LogError(ex, $"{typeof(ProductImage).ToString()} Repo ProdAllImages method error");
            //    return new List<string>();
            //}
        }

        public async Task<string> GetMainImage(string ProdId)
        {
            try
            {
                string imgId = ProdId + "1";
                ProductImage obj = await dbSet.FirstOrDefaultAsync(x => x.ImagePath == imgId);
                if(obj != null)
                {
                    return obj.ImagePath;
                }
                return null;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{typeof(ProductImage).ToString()} Repo, ProdAllImages method error");
                return null;
            }
        }

        public async Task<bool> UpsertProductImage(string id, string path)
        {
            try
            {
                ProductImage obj= new ProductImage();
                obj.ProductId = id; obj.ImagePath = path;

                var search = await dbSet.FirstOrDefaultAsync(x=> x.ImagePath == path);
                if (search == null)
                {
                    await Add(obj);
                }
                else
                {
                    Update(obj, obj);
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(ProductImage));
                return false;
            }

        }

        public async Task<bool> DeleteAllImages(string prodId)
        {
            try
            {
                List<ProductImage> list = await dbSet.Where(x=> x.ProductId == prodId).ToListAsync();

                foreach(ProductImage obj in list)
                {
                    dbSet.Remove(obj);
                }
                return true;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{typeof(ProductImage).ToString()} Repo, Delete method error");
                return false;
            }
        }

    }
}
