using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    public GameObject DrBubblePrefab; // Prefab for the doctor's chat bubble
    public GameObject PatBubblePrefab; // Prefab for the patient's chat bubble
    public Transform chatPanel; // The panel or container where chat bubbles will be instantiated

    private Stack<GameObject> chat = new Stack<GameObject>();
    string DrChat = "ch7el ak tchouf";

    private void Start() {
        GameEvents.Instance.onChangeDetected += AddToChat;
    }
    
    // This function adds the chat to the conversation and handles reactions
    private void AddToChat(string patChat)
    {
        GameObject DrBubble = Instantiate(PatBubblePrefab, chatPanel); // Instantiate doctor bubble
        GameObject PatBubble = Instantiate(PatBubblePrefab, chatPanel); // Instantiate patient bubble

        loadChatInBubble(patChat, DrBubble, PatBubble); // Load chat in both bubbles
        
        // Add the instantiated bubbles to the stack
        chat.Push(DrBubble);
        chat.Push(PatBubble);
    }

    // This function loads chat into the respective bubbles (doctor and patient)
    private void loadChatInBubble(string patChat, GameObject Dr, GameObject Pat)
    {
        // Loading the doctor's chat into the doctor bubble
        WriteChat writeChat = Dr.GetComponent<WriteChat>();
        writeChat.loadChat(DrChat);

        // Loading the patient's chat into the patient bubble
        writeChat = Pat.GetComponent<WriteChat>();
        writeChat.loadChat(patChat);
    }
}
