using States;
namespace LLM {
        public interface ILLMClient {
                // use interface so LLM implementations from OpenAI, Claude, or
                // Azure OpenAI could be "plugged in" easily
                Task<string> makeRequest(List<Message> state);
        }
}