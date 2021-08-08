using HMS.Models;
using System.Collections.Generic;

namespace HMS.IBL
{
    public interface ILeadRep
    {
        DataTableResponse<LeadModel> Get();
        string Save(EditLeadModel item);
        string Create(EditLeadModel item);
        EditLeadModelDto GetByID(int Id);
        EditLeadModel CreateByID();
        IEnumerable<TaskModel> GetByIDTask(int Id);
        bool LeadTaskCreate(CreateTaskModel item);
        IEnumerable<LeadModel> ChartData();
    }
}
