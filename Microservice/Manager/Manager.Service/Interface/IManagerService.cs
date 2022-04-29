using Manager.Model.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service.Interface
{
    public interface IManagerService
    {
        Task<PostResponse> PostManagerDetails(PostRequest request);

        Task<GetDetailsByIdResponse> GetManagerDetailsById(int empId);

        Task<PutDetailsResponse> UpdateDetailsById(int empId, Model.Managers.Manager details);
    }
}
