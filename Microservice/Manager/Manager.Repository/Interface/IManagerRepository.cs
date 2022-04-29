using Manager.Model.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repository.Interface
{
    public interface IManagerRepository
    {
        Task<PostResponse> PostManagerDetails(PostRequest request);
        Task<GetDetailsByIdResponse> GetManagerDetailsById(int empId);
        Task<PutDetailsResponse> UpdateDetailsById(int empId, Model.Managers.Manager details);
    }
}
