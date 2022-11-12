﻿using LixiBanff.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LixiBanff.Domain.IServices
{
    public interface IPilaService
    {
        Task Create(Pila _obj);
        Task Save(Pila _obj);
        Task<bool> ValidateExistence(Pila _obj, string opcion);
        Task<List<Pila>> GetList();
        Task Delete(int identity_id);
    }
}