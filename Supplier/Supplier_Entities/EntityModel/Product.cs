﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplier_Entities.EntityModel
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {

        }

        public Product(string ProductDescription, double Prize, int Cuantity, bool ActiveFlag, ProductType ProductType)
        {
            this.ProductDescription = ProductDescription;
            this.Prize = Prize;
            this.Cuantity = Cuantity;
            this.ActiveFlag = ActiveFlag;

            this.ProductType = ProductType;

            if (ProductType != null)
            {
                this.ProductTypeId = ProductType.ProductTypeId;
            }
            else
            {
                this.ProductTypeId = 0;
            }
        }

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public int ProductTypeId { get; set; }

        [MaxLength(500)]
        public string ProductDescription { get; set; }

        public double Prize { get; set; }

        public int Cuantity { get; set; }

        public bool ActiveFlag { get; set; }

        #endregion

        #region Foreing keys

        public ProductType ProductType { get; set; }

        #endregion
    }
}
