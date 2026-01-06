using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Interfaces.InterfaceRepository
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAll();
        IEnumerable<Loan> GetByUserId(int id_user);
        Loan GetById(int id_loan);
        void CreateLoan(Loan loan);
        void UpdateLoan(Loan loan);
    }
}
