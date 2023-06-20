using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASP.NET_Lab_4.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }
        [Display(Name = "Enter a name")]
        [StringLength(25)]
        [Required(ErrorMessage = "The length of the name is at least 5 characters")]
        public string name { get; set; }
        [Display(Name = "Enter the surname")]
        [StringLength(25)]
        [Required(ErrorMessage = "The length of the last name is at least 5 characters")]
        public string surname { get; set; }
        [Display(Name = "Enter the address")]
        [StringLength(35)]
        [Required(ErrorMessage = "The length of the address is at least 15 characters")]
        public string address { get; set; }
        [Display(Name = "Enter your phone number")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The length of the number is at least 10 characters")]
        public string phone { get; set; }
        [Display(Name = "Enter your mail")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "The length of the email is not less than 15 characters")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetail = new List<OrderDetail>();

    }


}
