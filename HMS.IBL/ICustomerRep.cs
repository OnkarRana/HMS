using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.IBL
{
    public interface ICustomerRep
    {
        DataTableResponse<CustomerModel> Get();
        IEnumerable<CustomerModel> GetAll();
        string Save(CustomeEditModel item);
        CustomeEditModel GetByID(int Id);
    }
}
