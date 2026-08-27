using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountApplication.Commands
{
    public class DeleteDiscountCommand : IRequest<bool>
    {
        public string ProductName { get; set; }

        public DeleteDiscountCommand(string productName)
        {
            ProductName = productName;
        }
    }
}
