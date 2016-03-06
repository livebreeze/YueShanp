﻿using System.Linq;

namespace YueShanp.Models.Interface
{
    interface IQuotedRepository
    {
        void Create(Quoted instance);

        void Update(Quoted instance);

        void Delete(Quoted instance);

        Quoted Get(int QuotedId);

        IQueryable<Quoted> GetAll();

        void SaveChanges();
    }
}