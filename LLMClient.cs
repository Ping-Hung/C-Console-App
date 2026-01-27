using States;
using OpenAI;
using OpenAI.Responses;
using System.Text.Json;
using Microsoft.VisualBasic;

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
        // we are talking to the response endpoint:
        // https://platform.openai.com/docs/api-reference/responses/create
        private readonly ResponsesClient client = new(
            model: "gpt-5-nano-2025-08-07`",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        public async Task<string> makeRequest(List<Message> state) {
            // convert state to a parameter acceptable by CreateResponse and
            // determine how much should be passed as parameter
            
			var prompt = state[state.Count - 1];
            var context = state[state.Count - 2];   // this in general shall be a slice (subarray) of state

            // 2. call the end point.
            var response = await client.CreateResponse(
                userInputText: prompt.Content,
                previousResponseId: // some Response id,
            );

            // 3. Deserialize the response, and only return content[0].text
            // 4. Handle possible error on failed calls
            
            

        }
    }
    public class ClaudeLLMClient : ILLMClient {
        public ClaudeLLMClient() {
            throw new NotImplementedException();
        }
        public async Task<string> makeRequest(List<Message> state) {
            throw new NotImplementedException(); 
        }
    }
    public class AzureLLMClient : ILLMClient {
        public AzureLLMClient() {
            throw new NotImplementedException();
        }
        public async Task<string> makeRequest(List<Message> state) {
            throw new NotImplementedException(); 
        }
    }

    // helper class dedicated to serialize data using C# generics
    public class Serializer {
        static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        public static string Serialize<T>(T value) {
            return JsonSerializer.Serialize(value, options: options);
        }
    }

}
