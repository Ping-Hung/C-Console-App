using States;
using LLM;

namespace chatSession {
        public interface IChatSession {
                Task<string> HandleUserInputAsync(string userInput);
        }
        public class ChatSession : IChatSession {
                private readonly ConversationState state = new();
                private readonly ILLMClient llm; 

                public ChatSession(string modelName) {
                        // choose a model (with switch pattern matching expression)
                        llm = modelName switch {
                                "OpenAI" => new OpenAILLMClient(),
                                "Claude" => new ClaudeLLMClient(),
                                "Azure"  => new AzureLLMClient(),
                                _ => throw new ArgumentException("bad LLM model name")
                        };
                }

                public async Task<string> HandleUserInputAsync(string userInput) {
                        state.messages.Add(new Message("user", userInput));
                        var reply = await llm.makeRequest(state.messages);
                        state.messages.Add(new Message("assistant", reply));
                        return reply;
                }
        }
}
