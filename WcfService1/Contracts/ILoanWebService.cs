using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfService1.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILoanWebService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ILoanWebService
    {
        [OperationContract]
        int CreateLoan(LoanCreateDTO loanDTO);
        [OperationContract]
        IEnumerable<LoanDTO> GetAll();
        [OperationContract]
        LoanDTO GetById(int id_loan);
        [OperationContract]
        IEnumerable<LoanDTO> GetByUserId(int id_user);
        [OperationContract]
        bool UpdateLoan(LoanUpdateDTO loanDTO);
        [OperationContract]
        int ReturnBook(int id_loan);
        [OperationContract]
        bool ExtendLoan(int id_loan);
    }
}
