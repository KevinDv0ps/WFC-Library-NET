using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;

namespace WcfLibrary.Application.Interfaces.InterfaceService
{
    public interface ILoanService
    {
        int CreateLoan(LoanCreateDTO loanDTO);
        IEnumerable<LoanDTO> GetAll();
        LoanDTO GetById(int id_loan);
        IEnumerable<LoanDTO> GetByUserId(int id_user);
        bool UpdateLoan(LoanUpdateDTO loanDTO);
        int ReturnBook(int id_loan);
        bool ExtendLoan(int id_loan);
    }
}
