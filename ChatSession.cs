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
                        this.llm = modelName switch {
                                "OpenAI" => new OpenAIClient(),
                                "Claude" => new ClaudeAIClient(),
                                "Azure" => new AzureAIClient(),
                                _ => throw new ArgumentException("bad LLM model name")
                        };
                }

                public async Task<string> HandleUserInputAsync(string userInput) {
                        state.messages.Add(new Message("user", userInput));
                        // maybe I'll need to serialize state.messages before
                        // returning
                        var reply = await llm.makeRequest(state.messages);
                        state.messages.Add(new Message("assistant", reply));
                        return reply;
                }
        }
}
