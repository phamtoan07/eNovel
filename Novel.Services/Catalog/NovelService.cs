using MediatR;
using MongoDB.Driver;
using Newtonsoft.Json;
using Novel.Core;
using Novel.Core.Caching;
using Novel.Core.Caching.Constants;
using Novel.Data.Catalog;
using Novel.Data.DataHelper;
using Novel.Services.Events;
using Novel.Services.Security;
using Novel.Services.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novel.Services.Catalog
{
    public partial class NovelService : INovelService
    {
        #region Fields

        private readonly IRepository<NovelEntity> _novelRepository;
        private readonly IRepository<NovelEntityDeleted> _novelDeletedRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly IAclService _aclService;
        private readonly IMediator _mediator;
        private readonly IAuthorMappingService _authorMappingService;
        private readonly CatalogSettings _catalogSettings;

        #endregion
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public NovelService(ICacheManager cacheManager,
            IRepository<NovelEntity> novelRepository,
            IRepository<NovelEntityDeleted> novelDeletedRepository,
            IWorkContext workContext,
            IMediator mediator,
            IAclService aclService,
            IAuthorMappingService authorMappingService,
            CatalogSettings catalogSettings
            )
        {
            _cacheManager = cacheManager;
            _novelRepository = novelRepository;
            _novelDeletedRepository = novelDeletedRepository;
            _workContext = workContext;
            _mediator = mediator;
            _aclService = aclService;
            _authorMappingService = authorMappingService;
            _catalogSettings = catalogSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="novel">Novel</param>
        public virtual async Task DeleteNovel(NovelEntity novel)
        {
            if (novel == null)
                throw new ArgumentNullException("novel");

            //deleted product
            await _novelRepository.DeleteAsync(novel);

            //insert to deleted products
            var novelDeleted = JsonConvert.DeserializeObject<NovelEntityDeleted>(JsonConvert.SerializeObject(novel));
            novelDeleted.DeletedOnUtc = DateTime.UtcNow;
            await _novelDeletedRepository.InsertAsync(novelDeleted);

            //cache
            await _cacheManager.RemoveByPrefix(CacheKey.NOVELS_PATTERN_KEY);

            //event notification
            await _mediator.EntityDeleted(novel);
        }

        /// <summary>
        /// Gets all products displayed on the home page
        /// </summary>
        /// <returns>Products</returns>
        public virtual async Task<IList<NovelEntity>> GetAllNovelsDisplayedOnHomePage()
        {
            var builder = Builders<NovelEntity>.Filter;
            var filter = builder.Eq(x => x.ShowOnHomePage, true);
            //filter &= builder.Eq(x => x.ShowOnHomePage, true);
            var query = _novelRepository.Collection.Find(filter).SortBy(x => x.VolumeNum).ThenBy(x => x.Title);

            var novels = await query.ToListAsync();

            //ACL mapping
            novels = novels.Where(p => _aclService.Authorize(p) && _authorMappingService.Authorize(p)).ToList();

            //availability dates
            novels = novels.Where(p => p.IsAvailable()).ToList();
            return novels;
        }

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="novelId">Novel identifier</param>
        /// <param name="fromDB">get data from db (not from cache)</param>
        /// <returns>Product</returns>
        public virtual async Task<NovelEntity> GetNovelById(string novelId, bool fromDB = false)
        {
            if (string.IsNullOrEmpty(novelId))
                return null;

            if (fromDB)
                return await _novelRepository.GetByIdAsync(novelId);

            var key = string.Format(CacheKey.NOVELS_BY_ID_KEY, novelId);
            return await _cacheManager.GetAsync(key, () => _novelRepository.GetByIdAsync(novelId));
        }

        /// <summary>
        /// Get products by identifiers
        /// </summary>
        /// <param name="novelIds">Novel identifiers</param>
        /// <returns>Products</returns>
        public virtual async Task<IList<NovelEntity>> GetNovelsByIds(string[] novelIds, bool showHidden = false)
        {
            if (novelIds == null || novelIds.Length == 0)
                return new List<NovelEntity>();

            var builder = Builders<NovelEntity>.Filter;
            var filter = builder.Where(x => novelIds.Contains(x.Id));
            var novels = await _novelRepository.Collection.Find(filter).ToListAsync();

            //sort by passed identifiers
            var sortedNovels = new List<NovelEntity>();
            foreach (string id in novelIds)
            {
                var novel = novels.Find(x => x.Id == id);
                if (novel != null && (showHidden || (_aclService.Authorize(novel) && _authorMappingService.Authorize(novel) && (novel.IsAvailable()))))
                    sortedNovels.Add(novel);
            }

            return sortedNovels;
        }

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="novel">Product</param>
        public virtual async Task InsertNovel(NovelEntity novel)
        {
            if (novel == null)
                throw new ArgumentNullException("novel");

            //insert
            await _novelRepository.InsertAsync(novel);

            //clear cache
            await _cacheManager.RemoveByPrefix(CacheKey.NOVELS_PATTERN_KEY);

            //event notification
            await _mediator.EntityInserted(novel);
        }

        /// <summary>
        /// Updates the novel
        /// </summary>
        /// <param name="novel">Product</param>
        public virtual async Task UpdateNovel(NovelEntity novel)
        {
            if (novel == null)
                throw new ArgumentNullException("novel");
            var oldProduct = await _novelRepository.GetByIdAsync(novel.Id);
            //update
            var builder = Builders<NovelEntity>.Filter;
            var filter = builder.Eq(x => x.Id, novel.Id);
            var update = Builders<NovelEntity>.Update
                .Set(x => x.Title, novel.Title)
                .Set(x => x.VolumeNum, novel.VolumeNum)
                .Set(x => x.VolumeTile, novel.VolumeTile)
                .Set(x => x.ShortDesc, novel.ShortDesc)
                .Set(x => x.LongDesc, novel.LongDesc)
                .Set(x => x.PublishedDate, novel.PublishedDate)
                .Set(x => x.Status, novel.Status)
                .Set(x => x.IsFinished, novel.IsFinished)
                .Set(x => x.ShowOnHomePage, novel.ShowOnHomePage)
                .Set(x => x.AvgRate, novel.AvgRate)
                .Set(x => x.Icon, novel.Icon)
                .Set(x => x.LongDescImg, novel.LongDescImg)
                .Set(x => x.NovelTags, novel.NovelTags)
                .Set(x => x.NovelChapter, novel.NovelChapter)
                .Set(x => x.AvailableStartDateTimeUtc, novel.AvailableStartDateTimeUtc)
                .Set(x => x.AvailableEndDateTimeUtc, novel.AvailableEndDateTimeUtc)
                .Set(x => x.RequiredNovelIds, novel.RequiredNovelIds)
                .Set(x => x.SubjectToAcl, novel.SubjectToAcl)
                .Set(x => x.CustomerRoles, novel.CustomerRoles)
                .Set(x => x.LimitedToAuthor, novel.LimitedToAuthor)
                .Set(x => x.Authors, novel.Authors)
                .CurrentDate("UpdatedOnUtc");

            await _novelRepository.Collection.UpdateOneAsync(filter, update);

            //if (oldProduct.AdditionalShippingCharge != product.AdditionalShippingCharge ||
            //    oldProduct.IsFreeShipping != product.IsFreeShipping ||
            //    oldProduct.IsGiftCard != product.IsGiftCard ||
            //    oldProduct.IsShipEnabled != product.IsShipEnabled ||
            //    oldProduct.IsTaxExempt != product.IsTaxExempt ||
            //    oldProduct.IsRecurring != product.IsRecurring
            //    )
            //{

            //    await _mediator.Publish(new UpdateProductOnCartEvent(product));
            //}

            //cache
            await _cacheManager.RemoveAsync(string.Format(CacheKey.NOVELS_BY_ID_KEY, novel.Id));
            await _cacheManager.RemoveByPrefix(CacheKey.NOVELS_CUSTOMER_PERSONAL_PATTERN);
            await _cacheManager.RemoveByPrefix(CacheKey.NOVELS_CUSTOMER_ROLE_PATTERN);
            await _cacheManager.RemoveByPrefix(CacheKey.NOVELS_CUSTOMER_TAG_PATTERN);

            //event notification
            await _mediator.EntityUpdated(novel);
        }
        #endregion
    }
}
