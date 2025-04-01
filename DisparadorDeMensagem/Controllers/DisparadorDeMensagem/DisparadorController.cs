using DisparadorDeMensagem.Dominio.Exemplo;
using Microsoft.AspNetCore.Mvc;

namespace DisparadorDeMensagem.Controllers.DisparadorDeMensagem
{
    [ApiController]
    [Route("Disparador")]
    public class DisparadorController : Controller
    {
        private readonly ExemploAPI _exemploApi;

        public DisparadorController()
        {
            _exemploApi = new ExemploAPI(); // Instancia ExemploAPI
        }

        [HttpGet]
        [Route("EnviarMensagem")]
        public async Task<IActionResult> SendMessage(string Numero, string Mensagem) // Retorna IActionResult
        {
            try
            {
                int resultado = await _exemploApi.SendWhatsAppMessage(Numero, Mensagem);

                if (resultado == 1) // Sucesso
                {
                    return Ok("Mensagem enviada com sucesso!");
                }
                else // Falha
                {
                    return BadRequest("Falha ao enviar mensagem.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log it, throw an exception).
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Erro interno do servidor."); // Retorna 500 para erro interno
            }
        }

    }
}
