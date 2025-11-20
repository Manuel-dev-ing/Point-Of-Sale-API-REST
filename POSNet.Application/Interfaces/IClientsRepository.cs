using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSNet.Application.DTOs;
using POSNET.Domain.Entities;


namespace POSNet.Application.Interfaces
{
    public interface IClientsRepository
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente> GetClient(int id);
        Task<ClientDTO> GetClientAsync(int id);
        Task<List<ClientDTO>> GetClientsAsync();
        Task<int> getTotalClients();
        Task UpdateAsync(Cliente cliente);
    }
}
