using States;
namespace LLM {
        public interface ILLMClient {
                // use interface so LLM implementations from OpenAI, Claude, or
                // Azure OpenAI could be "plugged in" easily
                Task<string> makeRequest(List<Message> state);
        }

        // the following classes implements the "contract"/"blueprint" specified by ILLMClient
        public class OpenAIClient : ILLMClient {
                Task<string> makeRequest(List<Message> state) {
                        // make an api call to openai with state as parameter
                        // might have to serialize state first before passing,
                        // read their api specs
                }
        }
        public class ClaudeAIClient : ILLMClient {

        }
        public class AzureAIClient : ILLMClient {

        }
}