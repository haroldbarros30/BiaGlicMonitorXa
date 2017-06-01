using System.Collections.Generic;
using System.Threading.Tasks;
using BiaGlicMonitorXa.Models;

namespace BiaGlicMonitorXa.Services
{
	public interface IApiService
	{
        Task<List<Usuario>> GetUsuariosAsync();
        Task<List<Medicao>> GetMedicaoAsync(string pUsuarioId);
        Task AddMedicao(Medicao pMedicao);
        Usuario GetUsuarioLogado();
    }
}
