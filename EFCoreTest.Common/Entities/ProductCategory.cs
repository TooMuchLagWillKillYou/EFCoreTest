using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest.Web
{
    /// <summary>
    /// High-level product categorization.
    /// </summary>
    [Table("ProductCategory", Schema = "SalesLT")]
    [Index(nameof(Name), Name = "AK_ProductCategory_Name", IsUnique = true)]
    [Index(nameof(Rowguid), Name = "AK_ProductCategory_rowguid", IsUnique = true)]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            InverseParentProductCategory = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        /// <summary>
        /// Primary key for ProductCategory records.
        /// </summary>
        [Key]
        [Column("ProductCategoryID")]
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        [Column("ParentProductCategoryID")]
        public int? ParentProductCategoryId { get; set; }
        /// <summary>
        /// Category description.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(ParentProductCategoryId))]
        [InverseProperty(nameof(ProductCategory.InverseParentProductCategory))]
        public virtual ProductCategory? ParentProductCategory { get; set; }
        [InverseProperty(nameof(ProductCategory.ParentProductCategory))]
        public virtual ICollection<ProductCategory> InverseParentProductCategory { get; set; }
        [InverseProperty(nameof(Product.ProductCategory))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
