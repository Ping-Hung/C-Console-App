// main entry point for the application, responsible for
// 1. running the agent loop
// 2. handling user input and send them to agents, where planning was done
// 3. present the plan to user and wait for more actions from user
class Program {
    static void Main(string[] args) {
        // 1. Running the agent loop
        while (true) {
            // 2. Handling user input
            Console.WriteLine("Enter your command (or type 'exit' to quit):");
            string? userInput = Console.ReadLine();

            if (userInput == null || userInput?.ToLower() == "exit") {
                // EOF or "exit" will exit app
                break;
            }
            // Send input to agents for planning
            string plan = ProcessInput(userInput ?? ""); // if userInput is null, send empty string
            // 3. Present the plan to the user
            Console.WriteLine($"Plan: {plan}");
        }
    }

    static string ProcessInput(string input) {
        // Placeholder for processing input and generating a plan
        return input != "" ? $"Processed input: {input}" : "No input provided.";
    }
}