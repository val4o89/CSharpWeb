namespace UnitOfWork.Contracts
{
    using System;

    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
