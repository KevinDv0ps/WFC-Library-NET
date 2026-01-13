using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Application.Interfaces.InterfaceService;
using WcfLibrary.Domain.Dtos.CreateDTO;
using WcfLibrary.Domain.Dtos.ResponseDTO;
using WcfLibrary.Domain.Dtos.UpdateDTO;
using WcfLibrary.Domain.Entities;

namespace WcfLibrary.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public LoanService(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }
        public int CreateLoan(LoanCreateDTO loanDTO)
        {
            var user = _userRepository.GetById(loanDTO.id_user);
            if (user == null) throw new Exception("User does not exist");

            var book = _bookRepository.GetById(loanDTO.id_book);
            if (book == null) throw new Exception("Book does not exist");

            if (!book.is_available) throw new Exception("Book is not available");

            var loan = new Loan
            {
                id_user = loanDTO.id_user,
                id_book = loanDTO.id_book,
                loan_date = DateTime.Now,
                due_date = DateTime.Now.AddDays(14),
                is_return = false,
                return_date = null,
            };

            _loanRepository.CreateLoan(loan);

            book.is_available = false;
            _bookRepository.UpdateBook(book);

            return loan.id;
        }

        public IEnumerable<LoanDTO> GetAll()
        {
            var loans = _loanRepository.GetAll();
            return loans.Select(loan => new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
                is_return = loan.is_return
            });
        }

        public LoanDTO GetById(int id_loan)
        {
            var loan =  _loanRepository.GetById(id_loan);
            return new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
            };
        }

        public IEnumerable<LoanDTO> GetByUserId(int id_user)
        {
            var loans = _loanRepository.GetByUserId(id_user);
            if (loans == null) return null;
            return loans.Select(loan => new LoanDTO
            {
                id_loan = loan.id,
                id_user = loan.id_user,
                id_book = loan.id_book,
                loan_date = loan.loan_date,
                due_date = loan.due_date,
                return_date = loan.return_date,
                is_return = loan.is_return
            });
        }

        public bool UpdateLoan(LoanUpdateDTO loanDTO)
        {
            var loan = _loanRepository.GetById(loanDTO.id);
            if (loan == null) throw new Exception("Loan does not exist");

            loan.id = loanDTO.id;
            loan.due_date = loanDTO.due_date;
            loan.return_date = loanDTO.return_date;

            _loanRepository.UpdateLoan(loan);
            return true;
        }

        public int ReturnBook(int id_loan)
        {
            var loan = _loanRepository.GetById(id_loan);
            if (loan == null) throw new Exception("Loan does not exist");

            if (loan.is_return) throw new Exception("Book already returned");
            loan.is_return = true;

            loan.return_date = DateTime.Now;
            var book = _bookRepository.GetById(loan.id_book);

            if (book == null) throw new Exception("Book does not exist");
            book.is_available = true;

            _loanRepository.UpdateLoan(loan);
            _bookRepository.UpdateBook(book);

            if (loan.due_date != loan.return_date)
            {
                if (loan.return_date > loan.due_date)
                {
                    var daysLate = (loan.return_date - loan.due_date).Value.Days;
                    var fineAmount = daysLate * 150; // $150 COP por dia de retraso

                    return fineAmount;
                }
                return 1;
            }
            return 0;
        }

        public bool ExtendLoan(int id_loan)
        {
            var loan = _loanRepository.GetById(id_loan);
            if (loan == null) throw new Exception("Loan does not exist");

            if (loan.is_return) throw new Exception("Book already returned");

            if (loan.due_date < DateTime.Now) throw new Exception("Cannot extend a loan that is already overdue");
            loan.due_date = loan.due_date.AddDays(7);

            _loanRepository.UpdateLoan(loan);
            return true;
        }
    }
}
