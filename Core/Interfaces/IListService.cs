using BienComun.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienComun.Core.Interfaces;

public interface IListService
{
    Task CreateListAsync(CreateListRequest request);
}
