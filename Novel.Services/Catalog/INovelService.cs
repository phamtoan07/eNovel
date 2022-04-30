using System.Collections.Generic;
using System.Threading.Tasks;
using Novel.Data.Catalog;

namespace Novel.Services.Catalog
{
    public partial interface INovelService
    {
        #region Novels

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="novel">Novel</param>
        Task DeleteNovel(NovelEntity novel);

        /// <summary>
        /// Gets all novels displayed on the home page
        /// </summary>
        /// <returns>Novels</returns>
        Task<IList<NovelEntity>> GetAllNovelsDisplayedOnHomePage();

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="novelId">Product identifier</param>
        /// <param name="fromDB">get data from db (not from cache)</param>
        /// <returns>Product</returns>
        Task<NovelEntity> GetNovelById(string novelId, bool fromDB = false);

        /// <summary>
        /// Gets novel from product or novel deleted
        /// </summary>
        /// <param name="novelId">Novel identifier</param>
        /// <returns>Novel</returns>

        Task<IList<NovelEntity>> GetNovelsByIds(string[] novelIds, bool showHidden = false);

        /// <summary>
        /// Inserts a novel
        /// </summary>
        /// <param name="novel">Novel</param>
        Task InsertNovel(NovelEntity novel);

        /// <summary>
        /// Updates the novel
        /// </summary>
        /// <param name="novel">Novel</param>
        Task UpdateNovel(NovelEntity novel);

        /// <summary>
        /// Set product as unpublished
        /// </summary>
        /// <param name="product"></param>
        Task UnpublishNovel(NovelEntity novel);

        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="filterableSpecificationAttributeOptionIds">The specification attribute option identifiers applied to loaded products (all pages)</param>
        /// <param name="loadFilterableSpecificationAttributeOptionIds">A value indicating whether we should load the specification attribute option identifiers applied to loaded products (all pages)</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="categoryIds">Category identifiers</param>
        /// <param name="manufacturerId">Manufacturer identifier; "" to load all records</param>
        /// <param name="storeId">Store identifier; "" to load all records</param>
        /// <param name="vendorId">Vendor identifier; "" to load all records</param>
        /// <param name="warehouseId">Warehouse identifier; "" to load all records</param>
        /// <param name="productType">Product type; "" to load all records</param>
        /// <param name="visibleIndividuallyOnly">A values indicating whether to load only products marked as "visible individually"; "false" to load all records; "true" to load "visible individually" only</param>
        /// <param name="featuredProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers). 0 to load featured products only, 1 to load not featured products only, null to load all products</param>
        /// <param name="priceMin">Minimum price; null to load all records</param>
        /// <param name="priceMax">Maximum price; null to load all records</param>
        /// <param name="productTag">Product tag name; "" to load all records</param>
        /// <param name="keywords">Keywords</param>
        /// <param name="searchDescriptions">A value indicating whether to search by a specified "keyword" in product descriptions</param>
        /// <param name="searchSku">A value indicating whether to search by a specified "keyword" in product SKU</param>
        /// <param name="searchProductTags">A value indicating whether to search by a specified "keyword" in product tags</param>
        /// <param name="languageId">Language identifier (search for text searching)</param>
        /// <param name="filteredSpecs">Filtered product specification identifiers</param>
        /// <param name="orderBy">Order by</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="overridePublished">
        /// null - process "Published" property according to "showHidden" parameter
        /// true - load only "Published" products
        /// false - load only "Unpublished" products
        /// </param>
        /// <returns>Products</returns>
        //Task<(IPagedList<Product> products, IList<string> filterableSpecificationAttributeOptionIds)> SearchProducts(
        //    bool loadFilterableSpecificationAttributeOptionIds = false,
        //    int pageIndex = 0,
        //    int pageSize = int.MaxValue,
        //    IList<string> categoryIds = null,
        //    string manufacturerId = "",
        //    string storeId = "",
        //    string vendorId = "",
        //    string warehouseId = "",
        //    ProductType? productType = null,
        //    bool visibleIndividuallyOnly = false,
        //    bool markedAsNewOnly = false,
        //    bool? featuredProducts = null,
        //    decimal? priceMin = null,
        //    decimal? priceMax = null,
        //    string productTag = "",
        //    string keywords = null,
        //    bool searchDescriptions = false,
        //    bool searchSku = true,
        //    bool searchProductTags = false,
        //    string languageId = "",
        //    IList<string> filteredSpecs = null,
        //    ProductSortingEnum orderBy = ProductSortingEnum.Position,
        //    bool showHidden = false,
        //    bool? overridePublished = null);

        /// <summary>
        /// Gets novels by novel attribute
        /// </summary>
        /// <param name="novelAttributeId">Novel attribute identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        //Task<IPagedList<NovelEntity>> GetProductsByProductAtributeId(string novelAttributeId,
        //    int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets associated products
        /// </summary>
        /// <param name="parentGroupedNovelId">Parent novel identifier (used with grouped novels)</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Novels</returns>
        Task<IList<NovelEntity>> GetAssociatedNovels(string parentGroupedNovelId, bool showHidden = false);

        /// <summary>
        /// Update novel associated 
        /// </summary>
        /// <param name="product">Product</param>
        Task UpdateAssociatedNovel(NovelEntity product);

        #endregion

        /*
        #region Related products

        /// <summary>
        /// Deletes a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        
        Task DeleteRelatedProduct(RelatedProduct relatedProduct);

        /// <summary>
        /// Inserts a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        Task InsertRelatedProduct(RelatedProduct relatedProduct);

        /// <summary>
        /// Updates a related product
        /// </summary>
        /// <param name="relatedProduct">Related product</param>
        Task UpdateRelatedProduct(RelatedProduct relatedProduct);

        #endregion

        #region Similar products

        /// <summary>
        /// Deletes a similar product
        /// </summary>
        /// <param name="similarProduct">Similar product</param>
        Task DeleteSimilarProduct(SimilarProduct similarProduct);

        /// <summary>
        /// Inserts a similar product
        /// </summary>
        /// <param name="similarProduct">Similar product</param>
        Task InsertSimilarProduct(SimilarProduct similarProduct);

        /// <summary>
        /// Updates a similar product
        /// </summary>
        /// <param name="similarProduct">Similar product</param>
        Task UpdateSimilarProduct(SimilarProduct similarProduct);

        #endregion
        */

        #region Novel pictures

        /// <summary>
        /// Deletes a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        //Task DeleteProductPicture(ProductPicture productPicture);

        /// <summary>
        /// Inserts a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        //Task InsertProductPicture(ProductPicture productPicture);

        /// <summary>
        /// Updates a product picture
        /// </summary>
        /// <param name="productPicture">Product picture</param>
        //Task UpdateProductPicture(ProductPicture productPicture);

        #endregion

    }
}
