using System;
using System.Collections.Generic;

namespace HipChat {
    public interface IHipChatClient : ISimpleHipchatMessageSender {
        /// <summary>
        /// If True, Sender and Message values are automatically truncated if they are too long.
        /// </summary>
        bool AutoTruncate { get; set; }

        /// <summary>
        /// Desired response format: json or xml. (default: json)
        /// </summary>
        HipChatClient.ApiResponseFormat Format { get; set; }

        /// <summary>
        /// Boolean flag of whether or not this message should trigger a notification for people in the room (based on their individual notification preferences). 0 = false, 1 = true. (default: 0)
        /// </summary>
        bool Notify { get; set; }

        /// <summary>
        /// The API authentication token - this is managed through the HipChat account admin panel.
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// The numeric id of the room to which to send a message
        /// </summary>
        int RoomId { // Convert to and from an integer to preserve API backward compatibility
            get; set; }

        /// <summary>
        /// The name of the room to which to send a message.
        /// </summary>
        string RoomName { get; set; }

        /// <summary>
        /// Name the message will appear be sent from. Must be less than 15 characters long. May contain letters, numbers, -, _, and spaces.
        /// </summary>
        string From { get; set; }

        /// <summary>
        /// Background color for message. 
        /// </summary>
        HipChatClient.BackgroundColor Color { get; set; }

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        void SendMessage(string message, int room, string from);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        void SendMessage(string message, string room, string from);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        void SendMessage(string message, int room, string from, bool notify);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        void SendMessage(string message, string room, string from, bool notify);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="room">The id of the room to send the message to - sets the RoomId property.</param>
        void SendMessage(string message, int room);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="room">The id of the room to send the message to - sets the RoomId property.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        void SendMessage(string message, int room, bool notify);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="from">The name of the sender - sets the From property.</param>
        void SendMessage(string message, string from);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="from">The name of the sender - sets the From property.</param>
        /// <param name="color">Background color to use with the message</param>
        void SendMessage(string message, string from, HipChatClient.BackgroundColor color);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="from">The name of the sender - sets the From property.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        void SendMessage(string message, string from, bool notify);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="from">The name of the sender - sets the From property.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        /// <param name="color">Background color to use with the message</param>
        void SendMessage(string message, string from, bool notify, HipChatClient.BackgroundColor color);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="color">Background color to use with the message</param>
        void SendMessage(string message, HipChatClient.BackgroundColor color);

        /// <summary>
        /// Sends a message to a chat room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        /// <param name="notify">If true, the message triggers a "ping" sound when it hits the room.</param>
        /// <param name="color">Background color to use with the message</param>
        void SendMessage(string message, HipChatClient.BackgroundColor color, bool notify);

        /// <summary>
        /// Sends a message to a room.
        /// </summary>
        /// <param name="message">The message to send - can contain some HTML and must be valid XHTML.</param>
        void SendMessage(string message);

        /// <summary>
        /// Returns the list of available rooms as XML/JSON 
        /// </summary>
        /// <returns>The raw JSON/XML API response (format is determined by Format property)</returns>
        string ListRooms();

        /// <summary>
        /// Returns the list of available rooms as native C# objects
        /// </summary>
        /// <returns>A List<> containing strongly-typed Entities.Room objects</returns>
        List<Entities.Room> ListRoomsAsNativeObjects();

        /// <summary>
        /// Yields each individual room as strongly-typed Entities.Room object
        /// </summary>
        /// <example>
        /// foreach ( Room room in client.YieldRooms() )
        /// {
        ///     // do something with room
        /// }
        /// </example>
        IEnumerable<Entities.Room> YieldRooms();

        /// <summary>
        /// Returns the history as native C# objects
        /// </summary>
        /// <returns>A List<> containing strongly-typed Entities.Message objects</returns>
        List<Entities.Message> ListHistoryAsNativeObjects(DateTime dt);

        List<Entities.Message> ListHistoryAsNativeObjects();

        /// <summary>
        /// Returns the chat history of a single room on a single day.
        /// </summary>
        /// <returns>The raw JSON/XML API response (format is determined by Format property)</returns>
        string RoomHistory(DateTime date);

        string RoomHistory();
    }

    public interface ISimpleHipchatMessageSender {
        void SendMessage(HipchatMessageParams msgParams);
    }

    public class HipchatMessageParams {
        public string Message;
        public string From;
        public string RoomName;
        public HipChatClient.BackgroundColor? BackgroundColor;
    }
}