using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyWeb.Models
{
    public class Category
    {
        //we now introduce something known as data annotation, for example to tell EF that Id is the primary key of the
        //table, we need to put[Key] on top of the field that we want to be the primary key.When the field name is Id
        //then entity framework assumes by default that it is the primary key and therefore Key annotation is not
        //reguired.However when any other name is used, then it must be indicated.
        //Required - data annotation that when the SQL Script will be generated, notnull will be imposed.It is placed on top of the field that is to be required.
        //More validation can be added to the fields in this model e.g.MaxLength and Range, e.t.c.
        //We then perform a check if the validations has been passed on the controller using ModelState.IsValid
        //To display custom error message, we use ErrorMessage inside the validation.

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="The display order must be in the range of 0 to 100")]
        public int DisplayOrder { get; set; }

    }
}
