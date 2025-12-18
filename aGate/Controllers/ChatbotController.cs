using Microsoft.AspNetCore.Mvc;
using OpenAI;
using OpenAI.Chat; // ChatMessage, SystemChatMessage, UserChatMessage burada bulunur
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aGate.Controllers
{
    public class ChatbotController : Controller
    {
        private readonly OpenAIClient _client;

        public ChatbotController(IConfiguration config)
        {
            string apiKey = config["OpenAI:ApiKey"];
            // OpenAIClient ana istemcidir
            _client = new OpenAIClient(apiKey);
        }

        [HttpGet]
        public async Task<IActionResult> Ask(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
                return Content("Question is empty.");

            // 1. HATA DÜZELTMESİ: Modeli burada bir 'ChatClient' olarak alıyoruz.
            // OpenAIClient doğrudan chat yapmaz, bir ChatClient üretir.
            ChatClient chatClient = _client.GetChatClient("gpt-4o-mini");

            // 2. HATA DÜZELTMESİ: Mesaj listesi oluşturma yapısı.
            // 'Message.Create...' yerine 'new SystemChatMessage' vb. kullanılır.
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(
                    "You are the AI assistant of the aGate Campaign Management System. " +
                    "Give short, clear answers (max 2–3 sentences). " +
                    "Help with topics such as campaign creation, staff assignment, client management, and system usage. " +
                    "Do not generate long texts, essays, or unnecessary details. " +
                    "Your goal is to provide quick and useful guidance for the aGate system."
                ),
                new UserChatMessage(question)
            };
            // 3. HATA DÜZELTMESİ: Metot ismi 'CompleteChatAsync'tir.
            ChatCompletion completion = await chatClient.CompleteChatAsync(messages);

            // 4. Cevabı alma
            if (completion.Content != null && completion.Content.Count > 0)
            {
                string answer = completion.Content[0].Text;
                return Content(answer);
            }

            return Content("No response generated.");
        }
    }
}