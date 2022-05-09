﻿using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Enitties
{
    public sealed class Product : Entity
    {

        #region Properties
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        #endregion

        #region Relations
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region Constructor
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        #endregion

        #region Methods
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        #endregion

        #region Validation
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length < 3,
                "Invalid description, too short, minimum 3 characters");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");

            DomainExceptionValidation.When(image.Length > 250,
                "Invalid image, too short, minimum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        #endregion



    }
}
