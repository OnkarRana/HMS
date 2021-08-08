using HMS.IBL;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BL
{
    public class LeadRep : ILeadRep
    {
        private Data.HMSEntities db;
        public LeadRep() => db = new Data.HMSEntities();

        public DataTableResponse<LeadModel> Get()
        {
            {
               var record = (from l in db.leads join t in db.Tour_Mst on l.PlaingFor equals t.TourId
                              join c in db.customers on  l.CustId equals c.CustId
                             join k in (from kk in db.stringMaps where kk.optionType.Equals("Status") select kk) on l.statusId equals k.DisplayValue
                             join m in (from mk in db.stringMaps where mk.optionType.Equals("Rating") select mk) on l.statusId equals m.DisplayValue

                             select new LeadModel()
                                { leadId=l.leadId,
                                    CustId =c.fullname,
                                    Description = l.Description,
                                    PlaingFor = t.Name,
                                    Rating=m.DisplayName,statusId=k.DisplayName,PlaningOn=l.PlaningOn

                                }).AsNoTracking().ToList();

                return new DataTableResponse<LeadModel>
                {
                    RecordsTotal = record.Count(),
                    RecordsFiltered = 10,
                    Data = record.ToArray()
                };
            }
        }

        public EditLeadModelDto GetByID(int Id)
        {


            EditLeadModelDto model = new EditLeadModelDto() {
                editLead = (from l in db.leads
                            where l.leadId.Equals(Id)
                            select
                             new EditLeadModel()
                             {
                                 leadId = l.leadId,CustID=l.customer.CustId, NoOfPersons=l.NoOfPersons,PlaingFor=l.PlaingFor,PlaningOn=l.PlaningOn,statusId=(int)l.statusId,RatingId=(int)l.RatingId,Remarks=l.Remarks,Description=l.Description,
                                 Customerlist = (from c in db.customers select new DropListModel() { DId = c.CustId, DName = c.fullname + "" + c.Phone }).ToList(),
                                 Tourslist = (from t in db.Tour_Mst select new DropListModel() { DId = t.TourId, DName = t.Name }).ToList(),
                                 statusList = (from s in db.stringMaps where s.optionType.Equals("Status") select new DropListModel() { DId = (int)s.DisplayValue, DName = s.DisplayName }).ToList(),
                                 Ratinglist = (from r in db.stringMaps where r.optionType.Equals("Rating") select new DropListModel() { DId = (int)r.DisplayValue, DName = r.DisplayName }).ToList()

                             }).FirstOrDefault(),

            taskModel = (from t in db.Tasks                        
                         join  u in db.Users on t.createdby equals u.ID
                         where t.LeadID.Value.Equals(Id)
                         select new TaskModel()
                               {
                                   Id = t.taskId,
                                   comments = t.Comments,
                                   createdBy = u.UserName,
                                   createdOn = t.createdon

                               }).ToList()};

                    
            

            return model;
        }

        public string Save(EditLeadModel item)
        {
            string message = string.Empty;
            try
            {
                if (item.leadId != 0)
                {

                    var t = db.leads.Find(item.leadId);
                    if (t != null)
                    {
                        t.CustId = (int)item.CustID;t.Description = item.Description; t.Remarks = item.Remarks;
                        t.statusId = item.statusId; t.RatingId = item.RatingId;t.PlaingFor = item.PlaingFor;t.NoOfPersons = item.NoOfPersons;


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
                    Data.lead t = new Data.lead()
                    {
                        CustId = (int)item.CustID,Description = item.Description, Remarks = item.Remarks,
                         statusId = item.statusId,RatingId = item.RatingId,PlaingFor = item.PlaingFor,
                        NoOfPersons = item.NoOfPersons

                };
                    db.leads.Add(t);
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

        public bool LeadTask(CreateTaskModel item)
        {
            bool message = false;
            try
            {
                Data.Task _task = new Data.Task() {
                    Comments=item.comments,createdby=item.createdBy,createdon=DateTime.Now,LeadID=item.LeadId
                };
                db.Tasks.Add(_task);
                db.SaveChanges();
                message = true;
            }
            catch { }
            return message;
        }

        public IEnumerable<LeadModel> ChartData()
        {
            var record = (from l in db.leads
                          join t in db.Tour_Mst on l.PlaingFor equals t.TourId
                          join c in db.customers on l.CustId equals c.CustId
                          join k in (from kk in db.stringMaps where kk.optionType.Equals("Status") select kk) on l.statusId equals k.DisplayValue
                          join m in (from mk in db.stringMaps where mk.optionType.Equals("Rating") select mk) on l.statusId equals m.DisplayValue

                          select new LeadModel()
                          {
                              leadId = l.leadId,
                              CustId = c.fullname,
                              Description = l.Description,
                              PlaingFor = t.Name,
                              Rating = m.DisplayName,
                              statusId = k.DisplayName,
                              PlaningOn = l.PlaningOn

                          }).AsNoTracking().ToList();
            return record;
        }
        public IEnumerable<TaskModel> GetByIDTask (int Id)
        {
            return (from i in db.Tasks
                    join u in db.Users on i.createdby equals u.ID
                    where i.LeadID.Value.Equals(Id)


                    select new TaskModel() {
                        LeadId=(int)i.LeadID,comments=i.Comments,createdBy=u.UserName,createdOn=i.createdon
                    }).ToList();
        }
        public bool LeadTaskCreate (CreateTaskModel item)
        {
            bool a = false;
            var rec = db.leads.Where(x => x.leadId.Equals(item.LeadId)).FirstOrDefault();
            if (rec != null)
            {
                Data.Task t = new Data.Task()
                {
                    LeadID = item.LeadId,
                    Comments = item.comments,
                    createdon = DateTime.Now,
                    createdby = item.createdBy
                };
                db.Tasks.Add(t);
                db.SaveChanges();
                a = true;
            }

            return a;
        }
      public EditLeadModel CreateByID()
        {
            return (from l in db.leads
                          
                          select
                           new EditLeadModel()
                           {
                               leadId = 0,

                               Customerlist = (from c in db.customers select new DropListModel() { DId = c.CustId, DName = c.fullname + "" + c.Phone }).ToList(),
                               Tourslist = (from t in db.Tour_Mst select new DropListModel() { DId = t.TourId, DName = t.Name }).ToList(),
                               statusList = (from s in db.stringMaps where s.optionType.Equals("Status") select new DropListModel() { DId = (int)s.DisplayValue, DName = s.DisplayName }).ToList(),
                               Ratinglist = (from r in db.stringMaps where r.optionType.Equals("Rating") select new DropListModel() { DId = (int)r.DisplayValue, DName = r.DisplayName }).ToList()

                           }).FirstOrDefault();
        }

        public string Create(EditLeadModel item)
        {
            throw new NotImplementedException();
        }
    }
}
