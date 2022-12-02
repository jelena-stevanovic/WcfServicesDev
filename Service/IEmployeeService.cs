using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<EmployeeDto> GetAllEmployees();

        [OperationContract]
        void AddEmployee(EmployeeDto employee);

        [OperationContract]
        EmployeeDto GetEmployeeById(int id);

        [OperationContract]
        void UpdateEmployee(EmployeeDto employee);

        [OperationContract]
        void DeleteEmployee(int id);
    }

    [DataContract]
    public class EmployeeDto
    {
        [DataMember]
        public int EmployeeId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
