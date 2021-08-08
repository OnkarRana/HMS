using System;
using System.Collections.Generic;
using HMS.IBL;
using HMS.Models;
using System.Linq;
using System.Data.Entity;

namespace HMS.BL
{
    public class TourRep : ITourRep
    {
        private Data.HMSEntities db;
        public TourRep() {

            db=new Data.HMSEntities();
            
        }

        public string SaveTour(TourModel item)
        {
            string message=string.Empty;
            try
            { 
                if (item.TourId !=0)
                {

                    var t = db.Tour_Mst.Find(item.TourId);
                    if (t != null)
                    {
                        t.Name = item.Name;
                        t.description = item.description;
                        t.Price = (decimal)item.Price;
                        t.ImageUrl = item.ImageUrl;
                        db.Entry(t).State = EntityState.Modified;
                        db.SaveChanges();
                         message = string.Format("Record is Updated With ID :{0}", t.TourId);
                    }
                    else
                    {
                        message = string.Format("Record doesnot exist");
                    }
                    
                }
                else
                {
                    Data.Tour_Mst t = new Data.Tour_Mst()
                    {
                        
                        Name = item.Name,
                        description = item.description,
                        Price = (decimal)item.Price,
                        ImageUrl = item.ImageUrl

                    };
                    db.Tour_Mst.Add(t);
                    db.SaveChanges();
                     message = string.Format("Record is Saved With ID :{0}", t.TourId);


                }
               
            }
            catch (Exception ex)
            {
                return message=ex.ToString();
            }
            return message;
        }

        public TourModel GetTourByID(int Id)
        {
            var tourModel = (from d in db.Tour_Mst where d.TourId.Equals(Id)
                             select new TourModel()
                             {
                                 TourId = d.TourId,
                                 Name = d.Name,
                                 description = d.description,
                                 Price = (decimal)d.Price,
                                 ImageUrl = d.ImageUrl
                             }).FirstOrDefault();

            return tourModel;
        }

        public IEnumerable<TourModel> TourList()
        {
            var tourModel = (from d in db.Tour_Mst
                            select new TourModel() {
                                TourId=d.TourId,Name=d.Name,description=d.description,Price=(decimal)d.Price,ImageUrl=d.ImageUrl
                            }).ToList();
            
            return tourModel;
        }

        
    }
}
