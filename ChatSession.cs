using States;
using LLM;

namespace chatSession {
        public interface IChatSession {
                Task<string> HandleUserInputAsync(string userInput);
        }
        public class ChatSession : IChatSession {
                private readonly ConversationState state;
                private readonly ILLMClient llm;

                public ChatSession(ConversationState state,  ILLMClient llm) {
                        this.state = state;
                        this.llm = llm;
                }

                public async Task<string> HandleUserInputAsync(string userInput) {
                        state.messages.Add(new Message("user", userInput));
                        // maybe I'll need to serialize state.messages 
                        var reply = await llm.makeRequest(state.messages);
                        state.messages.Add(new Message("assistant", reply));
                        return reply;
                }
        }
}
