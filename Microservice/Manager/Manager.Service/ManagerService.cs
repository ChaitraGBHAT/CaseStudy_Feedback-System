using Manager.Model.Managers;
using Manager.Repository.Interface;
using Manager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Service
{
    public class ManagerService: IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        /// <summary>
        /// Manager service
        /// </summary>
        /// <param name="ManagerRepository"></param>
        public ManagerService(IManagerRepository ManagerRepository)
        {
            _managerRepository = ManagerRepository;
        }

        public async Task<PostResponse> PostManagerDetails(PostRequest employeeRequest)
        {
            try
            {
                var response = await _managerRepository.PostManagerDetails(employeeRequest);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetDetailsByIdResponse> GetManagerDetailsById(int empId)
        {
            try
            {
                var response = await _managerRepository.GetManagerDetailsById(empId);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PutDetailsResponse> UpdateDetailsById(int empId, Model.Managers.Manager details)
        {
            try
            {
                var response = await _managerRepository.UpdateDetailsById(empId, details);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
