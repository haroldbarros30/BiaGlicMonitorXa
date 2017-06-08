using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace BiaGlicMonitorXa.Services
{
	public interface IApiService
	{
        Task<Boolean> LoginAsync();
        Task<List<Usuario>> GetUsuariosAsync();
        Task<List<Medicao>> GetMedicaoAsync(string pUsuarioId);
        Task AddMedicao(Medicao pMedicao);
        Usuario GetUsuarioLogado();
        Task AddUsuarioAsync(Usuario pUsuario);
    }
}
