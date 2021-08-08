using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class CustomerModel
    {

        [Display(Name = "ID")]
        public int CustId { get; set; }
        [Display(Name = "Client Name")]
        public string fullname { get; set; }
        [Display(Name = "Email")]
        public string EmailId { get; set; }
        [Display(Name = "Mobile")]
        public string Phone { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        [Display(Name = "Address")]
        public string Street { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int ModifiedBy { get; set; }

        

        public CustomerModel()
        {
        }
    }
    public class CustomeEditModel
    {
        [Display(Name = "ID")]
        public int CustId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Client Name")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Mobile")]
        public string Phone { get; set; }
        [Display(Name = "State")]
        public int stateID { get; set; }
        [Display(Name = "Address")]
        public string Street { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int ModifiedBy { get; set; }
        public ICollection <DropListModel> statelist { get; set; }
    }

    public class LeadModel
    {
        [Display(Name = "ID")]
        public int leadId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Client Name")]
        public string CustId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Plaing For")]
        public string PlaingFor { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Plaing On")]
        public DateTime ? PlaningOn { get; set; }
        [Display(Name = "No Of Persons")]
        public string NoOfPersons { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "status")]
       
        public string statusId { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Rating")]
        public string Rating { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int ModifiedBy { get; set; }

       
    }
    public class EditLeadModel
    {
        [Display(Name = "ID")]
        public int leadId { get; set; }
        [Display(Name = "Client Name")]
        public int CustID { get; set; }
        public string Description { get; set; }
        [Display(Name = "Plaing For")]
        public int? PlaingFor { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Plaing On")]
        public DateTime? PlaningOn { get; set; }
        [Display(Name = "No Of Persons")]
        public string NoOfPersons { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "status")]
        public int statusId { get; set; }
        [Display(Name = "Rating")]
        public int RatingId { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int ModifiedBy { get; set; }
        
        public ICollection<DropListModel> statusList { get; set; }

        public ICollection<DropListModel> Ratinglist { get; set; }

        public ICollection<DropListModel> Customerlist { get; set; }

        public ICollection<DropListModel> Tourslist { get; set; }
        public ICollection<TaskModel> taskList { get; set; }


    }

    public class EditLeadModelDto
    {
        public  EditLeadModel editLead { get; set; }
        public  List<TaskModel> taskModel { get; set; }
    }

    public class DropListModel
    {
       
       public int DId { get; set; }
       public string DName { get; set; }
    }
  
    public class TaskModel
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string comments { get; set; }
        public string createdBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? createdOn { get; set; }
    }
    public class CreateTaskModel
    {
       
        public int LeadId { get; set; }
        [Required]
        [Display(Name = "Remarks")]
        public string comments { get; set; }
        public int createdBy { get; set; }
    }

}
