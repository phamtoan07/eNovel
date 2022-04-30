using Novel.Data.Configuration;
using System.Collections.Generic;

namespace Novel.Data.Catalog
{
    public class CatalogSettings : ISettings
    {
        public CatalogSettings()
        {
            ObjectSortingEnumDisabled = new List<int>();
            ObjectSortingEnumDisplayOrder = new Dictionary<int, int>();
        }

        /// <summary>
        /// Gets or sets a value indicating details pages of unpublished Object details pages could be open
        /// </summary>
        public bool AllowViewUnpublishedObjectPage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating customers should see "discontinued" message when visibting details pages of unpublished object (if "AllowViewUnpublishedObjectPage" is "true)
        /// </summary>
        public bool DisplayDiscontinuedMessageForUnpublishedObjects { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display specification attribute on catalog pages
        /// </summary>
        public bool ShowSpecAttributeOnCatalogPages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to generate second picture on catalog pages
        /// </summary>
        public bool SecondPictureOnCatalogPages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether object sorting is enabled
        /// </summary>
        public bool AllowObjectSorting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to change object view mode
        /// </summary>
        public bool AllowObjectViewModeChanging { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to change object view mode
        /// </summary>
        public string DefaultViewMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a category details page should include objects from subcategories
        /// </summary>
        public bool ShowObjectsFromSubcategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a search box  should include objects from subcategories
        /// </summary>
        public bool ShowObjectsFromSubcategoriesInSearchBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether number of objects should be displayed beside each category
        /// </summary>
        public bool ShowCategoryObjectNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we include subcategories (when 'ShowCategoryObjectNumber' is 'true')
        /// </summary>
        public bool ShowCategoryObjectNumberIncludingSubcategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a 'Share button' is enabled
        /// </summary>
        public bool ShowShareButton { get; set; }

        /// <summary>
        /// Gets or sets a share code (e.g. AddThis button code)
        /// </summary>
        public string PageShareCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating object reviews must be approved
        /// </summary>
        public bool ObjectReviewsMustBeApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the default rating value of the object reviews
        /// </summary>
        public int DefaultObjectRatingValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users write object reviews.
        /// </summary>
        public bool AllowAnonymousUsersToReviewObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notification of a store owner about new object reviews is enabled
        /// </summary>
        public bool NotifyOwnerAboutNewObjectReviews { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product reviews will be filtered
        /// </summary>
        public bool ShowObjectReviewsPerObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether product 'Email a friend' feature is enabled
        /// </summary>
        public bool EmailAFriendEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'ask object question' feature is enabled
        /// </summary>
        public bool AskQuestionEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'contact us on the object page' feature is enabled
        /// </summary>
        public bool AskQuestionOnObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to allow anonymous users to email a friend.
        /// </summary>
        public bool AllowAnonymousUsersToEmailAFriend { get; set; }

        /// <summary>
        /// Gets or sets a number of "Recently viewed objects"
        /// </summary>
        public int RecentlyViewedObjectsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Recently viewed objects" feature is enabled
        /// </summary>
        public bool RecentlyViewedObjectEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Recommended objects" feature is enabled
        /// </summary>
        public bool RecommendedObjectsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Suggested objects" feature is enabled
        /// </summary>
        public bool SuggestedObjectsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of "Suggested objects"
        /// </summary>
        public int SuggestedObjectsNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "Personalized objects" feature is enabled
        /// </summary>
        public bool PersonalizedObjectsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a number of "Personalized objects"
        /// </summary>
        public int PersonalizedObjectsNumber { get; set; }

        /// <summary>
        /// Gets or sets a number of products on the "New objects" page
        /// </summary>
        public int NewObjectsNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether "New objects" page is enabled
        /// </summary>
        public bool NewObjectsEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether "New objects" is show on home page
        /// </summary>
        public bool NewObjectOnHomePage { get; set; }

        /// <summary>
        /// Gets or sets a number of products on the "New objects" on home page
        /// </summary>
        public int NewObjectsNumberOnHomePage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether autocomplete is enabled
        /// </summary>
        public bool ObjectSearchAutoCompleteEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether search by description is enabled
        /// </summary>
        public bool SearchByDescription { get; set; }

        /// <summary>
        /// Gets or sets a number of objects to return when using "autocomplete" feature
        /// </summary>
        public int ObjectSearchAutoCompleteNumberOfProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show product images in the auto complete search
        /// </summary>
        public bool ShowObjectImagesInSearchAutoComplete { get; set; }

        /// <summary>
        /// Gets or sets a minimum search term length
        /// </summary>
        public int ObjectSearchTermMinimumLength { get; set; }

        /// <summary>
        /// Gets or sets save search autocomplete
        /// </summary>
        public bool SaveSearchAutoComplete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show bestreadings on home page
        /// </summary>
        public bool ShowBestreadingsOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a number of BestReadings on home page
        /// </summary>
        public int NumberOfBestreadingsOnHomepage { get; set; }

        /// <summary>
        /// Gets or sets a number of time period for readings on home page
        /// </summary>
        public int PeriodBestReadings { get; set; }

        /// <summary>
        /// Gets or sets a number of review on object page
        /// </summary>
        public int NumberOfReview { get; set; }

        /// <summary>
        /// Gets or sets a number of products per page on the search objects page
        /// </summary>
        public int SearchPageObjectsPerPage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether customers are allowed to select page size on the search objects page
        /// </summary>
        public bool SearchPageAllowCustomersToSelectPageSize { get; set; }
        /// <summary>
        /// Gets or sets the available customer selectable page size options on the search objects page
        /// </summary>
        public string SearchPagePageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we should process attribute change using AJAX. It's used for dynamical attribute change, SKU/GTIN update of combinations, conditional attributes
        /// </summary>
        public bool AjaxProcessAttributeChange { get; set; }

        /// <summary>
        /// Gets or sets a number of object tags that appear in the tag cloud
        /// </summary>
        public int NumberOfObjectTags { get; set; }

        /// <summary>
        /// Gets or sets a number of objects per page on 'objects by tag' page
        /// </summary>
        public int ObjectsByTagPageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size for 'objects by tag'
        /// </summary>
        public bool ObjectsByTagAllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options for 'products by tag'
        /// </summary>
        public string ObjectsByTagPageSizeOptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore ACL rules (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreAcl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore load Filterable Specification Attribute Option (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreFilterableSpecAttributeOption { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether to ignore load Filterable available start and end date objects (side-wide). It can significantly improve performance when enabled.
        /// </summary>
        public bool IgnoreFilterableAvailableStartEndDateTime { get; set; }

        /// <summary>
        /// Gets or sets the default value to use for Category page size options (for new categories)
        /// </summary>
        public string DefaultCategoryPageSizeOptions { get; set; }
        /// <summary>
        /// Gets or sets the default value to use for Category page size (for new categories)
        /// </summary>
        public int DefaultCategoryPageSize { get; set; }
        /// <summary>
        /// Gets or sets a list of disabled values of ObjectSortingEnum
        /// </summary>
        public List<int> ObjectSortingEnumDisabled { get; set; }

        /// <summary>
        /// Gets or sets a display order of ObjectSortingEnum values 
        /// </summary>
        public Dictionary<int, int> ObjectSortingEnumDisplayOrder { get; set; }
    }
}
