namespace States {
        public record Message(string Role, string Content);
        public class ConversationState { 
                // chat history throughout one chat session
                public List<Message> messages { get; } = [];
        }
}