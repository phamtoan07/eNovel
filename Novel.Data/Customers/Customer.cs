using Novel.Data.Common;
using System;
using System.Collections.Generic;

namespace Novel.Data.Customers
{
    public partial class Customer : BaseEntity
    {
        private ICollection<CustomerRole> _customerRoles;
        private ICollection<Address> _addresses;
        private ICollection<string> _customerTags;

        /// <summary>
        /// Ctor
        /// </summary>
        public Customer()
        {
            CustomerGuid = Guid.NewGuid();
            PasswordFormat = PasswordFormat.Clear;
            Attributes = new List<CustomAttribute>();
        }

        /// <summary>
        /// Gets or sets the customer Guid
        /// </summary>
        public Guid CustomerGuid { get; set; }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password format
        /// </summary>
        public int PasswordFormatId { get; set; }
        /// <summary>
        /// Gets or sets the password format
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { PasswordFormatId = (int)value; }
        }
        /// <summary>
        /// Gets or sets the password salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the custom attributes (see "CustomerAttribute" entity for more info)
        /// </summary>
        public IList<CustomAttribute> Attributes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer account is system
        /// </summary>
        public bool IsSystemAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active by adding comments etc...
        /// </summary>
        public bool HasContributions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating number of failed login attempts (wrong password)
        /// </summary>
        public int FailedLoginAttempts { get; set; }

        /// <summary>
        /// Gets or sets the date and time until which a customer cannot login (locked out)
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }
        /// <summary>
        /// Gets or sets the customer system name
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last purchase
        /// </summary>
        public DateTime? LastPurchaseDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last update cart
        /// </summary>
        public DateTime? LastUpdateCartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last update wishlist
        /// </summary>
        public DateTime? LastUpdateWishListDateUtc { get; set; }

        /// <summary>
        /// Last date to change password
        /// </summary>
        public DateTime? PasswordChangeDateUtc { get; set; }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<CustomerRole> CustomerRoles
        {
            get { return _customerRoles ??= new List<CustomerRole>(); }
            protected set { _customerRoles = value; }
        }

        /// <summary>
        /// Gets or sets customer addresses
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ??= new List<Address>(); }
            protected set { _addresses = value; }
        }

        /// <summary>
        /// Gets or sets the customer tags
        /// </summary>
        public virtual ICollection<string> CustomerTags
        {
            get { return _customerTags ??= new List<string>(); }
            protected set { _customerTags = value; }
        }
        #endregion
    }
}
