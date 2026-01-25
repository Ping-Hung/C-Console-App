// main entry point of the application

using chatSession;

namespace Program {
    public class Program {
        public static int Main() {
            string modelName = setupModel();
            if (modelName == "EOF") {
                Console.WriteLine("Entered EOF, program exit");
                return -1;
            }
            // do some model configuration here
            while (true) {
                Console.WriteLine("Enter your command (or 'exit' to quit):");
                Console.Write("> ");
                string? userInput = Console.ReadLine();
                if (userInput == null) {
                    Console.WriteLine("Entered EOF, program exit");
                    return -1;
                } else if (userInput?.ToLower() == "exit") {
                    break;
                } else {
                    Console.WriteLine($"your plan: {userInput}");

                }
            }
            return 0;
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

