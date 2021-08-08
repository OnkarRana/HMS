using System;
using System.Collections.Generic;
using HMS.IBL;
using HMS.Models;
using System.Linq;
using System.Data.Entity;

namespace HMS.BL
{
    public class CustomerRep : ICustomerRep
    {
        private Data.HMSEntities db;
        public CustomerRep()
        {

            db = new Data.HMSEntities();

        }

        public CustomeEditModel GetByID(int Id)
        {
            var model = (dynamic)null;
            if (!string.IsNullOrEmpty(Id.ToString()) && Id == 0)
            {
                model = new CustomeEditModel()
                {
                    CustId = 0,
                    statelist = (from s in db.state_mst select new DropListModel() { DId = s.stateId, DName = s.stateName }).ToList()
                };
            }
            else
            {


                model = (from c in db.customers
                         where c.CustId.Equals(Id)
                         select new CustomeEditModel()
                         {
                             CustId = c.CustId,
                             fullname=c.fullname,
                             EmailId = c.EmailId,
                             Phone = c.Phone,
                             stateID = (int)c.stateID,
                             Street = c.Street,
                             statelist = (from s in db.state_mst select new DropListModel() { DId = s.stateId, DName = s.stateName }).ToList()
                         }).FirstOrDefault();
            }

            return model;
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            IEnumerable<CustomerModel> model = (from c in db.customers

                                               select new CustomerModel()
                                               {
                                                   CustId = c.CustId,
                                                   EmailId = c.EmailId,
                                                   Phone = c.Phone,

                                                   Street = c.Street

                                               }).AsNoTracking().ToList();

            return model;
        }

        public string Save(CustomeEditModel item)
        {
            string message = string.Empty;
            try
            {
                if (item.CustId != 0)
                {

                    var t = db.customers.Find(item.CustId);
                    if (t != null)
                    {
                        t.fullname = item.fullname; t.EmailId = item.EmailId;
                        t.Phone = item.Phone;t.stateID = item.stateID;t.Street = item.Street;
                        
                        db.Entry(t).State = EntityState.Modified;
                        db.SaveChanges();
                        message = string.Format("Record is Updated With ID :{0}", t.CustId);
                    }
                    else
                    {
                        message = string.Format("Record doesnot exist");
                    }

                }
                else
                {
                   Data.customer  t = new Data.customer()
                    {
                        fullname = item.fullname,
                        EmailId = item.EmailId,
                        Phone = item.Phone,
                        stateID = item.stateID,
                        Street = item.Street
                    };
                    db.customers.Add(t);
                    db.SaveChanges();
                    message = string.Format("Record is Saved With ID :{0}", t.CustId);


                }

            }
            catch (Exception ex)
            {
                return message = ex.ToString();
            }
            return message;
        }

        public DataTableResponse<CustomerModel> Get()
        {
            var products = (from c in db.customers

                            select new CustomerModel()
                            {
                                CustId = c.CustId,
                                EmailId = c.EmailId,
                                Phone = c.Phone,
                                fullname=c.fullname,
                                Street = c.Street

                            }).AsNoTracking().ToList();

            return new DataTableResponse<CustomerModel>
            {
                RecordsTotal = products.Count(),
                RecordsFiltered = 10,
                Data = products.ToArray()
            };
        }

    }
}

