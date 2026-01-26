using States;
using OpenAI;

namespace LLM {
    /// <summary>
    ///     interface (or abstract base class in C++) of LLM implementations from
    ///     OpenAI, Claude, or Azure OpenAI.
    /// </summary>
    public interface ILLMClient {
        // note: Adaptor: the implementations should adapt to the spec of this
        // interface, not other way around
        Task<string> makeRequest(List<Message> state);
    }

    // "wrapper classes" of the sdk provided classes (if they are provided)
    public class OpenAILLMClient : ILLMClient {
        //  a wrapper(adaptor) class around OpenAIClient 
        private readonly OpenAIClient client = new(
            Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );
        Task<string> makeRequest(List<Message> state) {
            // shall make calls to endpoints via client
            // might have to serialize `state`
        }
    }
    public class ClaudeLLMClient : ILLMClient {

    }
    public class AzureLLMClient : ILLMClient {

    }
}