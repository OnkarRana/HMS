using HMS.Models;
using System.Collections.Generic;

namespace HMS.IBL
{
    public interface ITourRep
    {
        IEnumerable<TourModel> TourList();

        string SaveTour(TourModel item);
        TourModel GetTourByID(int Id);
    }
}
