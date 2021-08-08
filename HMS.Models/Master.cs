using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class stringMapModel
    {
        public int Id { get; set; }
        public string optionType { get; set; }
        public string DisplayName { get; set; }
        public int DisplayValue { get; set; }

        public stringMapModel(int Id_, string optionType_, string DisplayName_, int DisplayValue_)
        {
            this.Id = Id_;
            this.optionType = optionType_;
            this.DisplayName = DisplayName_;
            this.DisplayValue = DisplayValue_;
        }
    }
    public class MenuModel
    {
        public int TourId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int MenuOrder { get; set; }

        public MenuModel(int TourId_, string MenuName_, string MenuUrl_, int MenuOrder_)
        {
            this.TourId = TourId_;
            this.MenuName = MenuName_;
            this.MenuUrl = MenuUrl_;
            this.MenuOrder = MenuOrder_;
        }
    }


    public class loginModel
    {
        public int UserId { get; set; }
        public string fullname { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public loginModel(int UserId_, string fullname_, string EmailId_, string Phone_, bool IsActive_)
        {
            this.UserId = UserId_;
            this.fullname = fullname_;
            this.EmailId = EmailId_;
            this.Phone = Phone_;
            this.IsActive = IsActive_;
        }
    }
    public class TourModel
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int MenuOrder { get; set; }
        public string description { get; set; }
        public decimal Price { get; set; }

        
    }

    public class StateModel
    {
        public int stateId { get; set; }
        public string stateName { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int ModifiedBy { get; set; }

        public StateModel(int stateId_, string stateName_, int createdBy_, DateTime createdOn_, int ModifiedBy_)
        {
            this.stateId = stateId_;
            this.stateName = stateName_;
            this.createdBy = createdBy_;
            this.createdOn = createdOn_;
            this.ModifiedBy = ModifiedBy_;
        }
    }
    public class DataTableResponse<T> where T : class
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public IEnumerable<T> Data { get; set; } 
        public string Error { get; set; }
    }
}
