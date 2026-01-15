using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary.Application.Interfaces.InterfaceRepository;
using WcfLibrary.Domain.Entities;
using WcfLibrary.Infrastructure.Data;


namespace WcfLibrary.Infrastructure.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext dataContextLibrary;
        public LoanRepository(LibraryDbContext context)
        {
            dataContextLibrary = context;
        }

        public void CreateLoan(Loan loan)
        {
            dataContextLibrary.Loans.Add(loan);
            dataContextLibrary.SaveChanges();
        }

        public IEnumerable<Loan> GetAll()
        {
            return dataContextLibrary.Loans
                .Include(b => b.book)
                .Include(u => u.user)
                .ToList();
        }

        public Loan GetById(int id_loan)
        {
            return dataContextLibrary.Loans
                .Include(b => b.book)
                .Include(u => u.user)
                .FirstOrDefault(i => i.id == id_loan);
        }

        public IEnumerable<Loan> GetByUserId(int id_user)
        {
            return dataContextLibrary.Loans
                .Include(b => b.book)
                .Include(u => u.user)
                .Where(a => a.id_user == id_user)
                .ToList();
        }

        public void UpdateLoan(Loan loan)
        {
            dataContextLibrary.Loans.AddOrUpdate(loan);
            dataContextLibrary.SaveChanges();
        }
    }
}
