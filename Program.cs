// main entry point of the application

using chatSession;
using LLM;

namespace Program {
    public class Program {
        public static int Main() {
            string modelName = setupModel();
            if (modelName == "EOF") {
                Console.WriteLine("Entered EOF, program exit");
                return -1;
            }

            // choose a model (with switch pattern matching expression)
            ILLMClient LLMClient = modelName switch {
                "OpenAI" => new OpenAIClient(),
                "Claude" => new ClaudeAIClient(),
                "Azure"  => new AzureAIClient(),
                _ => throw new ArgumentException("bad LLM model name")
            };
            // start a session with the chosen model
            ChatSession session = new ChatSession(LLMClient);
            // initiate the actual chat
            while (true) {
                Console.WriteLine("Enter your prompt (or 'exit' to quit):");
                Console.Write("> ");
                string? userInput = Console.ReadLine();
                switch (userInput?.ToLower()) {
                    case null:
                        Console.WriteLine("Entered EOF, program exit");
                        return -1;
                    case "exit":
                        return 0;
                    default:
                        break;
                }
                // session.HandleUserInputAsync(userInput);
            }
        }
        static string setupModel() {
            // this function only belongs to the Program class, thus use static
            string? input;
            while (true) {
                Console.WriteLine(
                    "Enter a model name, one of (OpenAI, Claude,or Azure)");
                input = Console.ReadLine()?.Trim();
                string result = input ?? "EOF";
                switch (result) {
                    case "OpenAI": case "Claude":
                    case "Azure": case "EOF":
                        return result;
                    default:
                        Console.WriteLine("invalid model name, try again");
                        break;
                }
            }
        }
    }
}

