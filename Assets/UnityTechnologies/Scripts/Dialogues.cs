using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace UnityTechnologies.Scripts
{
    public class Dialogues {
        //Game
        //Keys
        public const String Key_RedKey = "RED_KEY";
        public const String Key_NoKey = "NO_KEY";
        public const String Key_GameInstructions = "GAME_INSTRUCTIONS";
        //Dialogues  
        private const String hasRedKey = "Esta llave no entra en la cerradura... \nEs la llave incorrecta...";
        private const String hasNoKeys = "La puerta está bloqueada... \nNecesito conseguir una llave para abrirla...";
        private const String GameInstructions = "Jhon Lemon quiere escapar de esta Mansión Embrujada..." +
                                                "-Ayudalo a encontrar pistas para poder salir..." +
                                                "-Ten cuidado con los fantasmas. No todos son amigables.";

        //Characters
        public const String JhonCharacter = "Jhon";
        public const String GhostCharacter = "Ghost";
        
        // Jhon's Keys
        public const string EmptyWardrobeKey = "EMPTY_WARDROBE";
        public const string FindObjectKey = "FIND_OBJECT";

        //Ghost Keys
        public const string KeyClueKey1 = "KEY_CLUE1";
        public const string KeyClueKey2 = "KEY_CLUE2";

        //Jhon's Dialogues
        private const String EmptyWardrobeText = "Parece que aquí no hay nada...";
        private const String FindObjectText = "Encontré una llave!!";

        //Ghost Dialogues
        private const String KeyClueText1 = "Si quieres salir de aquí debes encontrar la llave que abre la puerta para salir.";
        private const String KeyClueText2 = "Sabes... Los fantasmas guardan las cosas que se encuentran en armarios...";

        private Dictionary<String, String> jhonsDialogues = new();
        private Dictionary<String, String> ghostDialogues = new();
        private Dictionary<String, String> gameDialogues = new();

        public Dialogues() {
            SetJhonsDialogues();
            SetGhostDialogues();
            SetGameDialogues();
        }

        private void SetGameDialogues() {
            gameDialogues.Add(Key_RedKey, hasRedKey);
            gameDialogues.Add(Key_NoKey, hasNoKeys);
            gameDialogues.Add(Key_GameInstructions, GameInstructions);
        }

        private void SetJhonsDialogues() {
            jhonsDialogues.Add(EmptyWardrobeKey, EmptyWardrobeText);
            jhonsDialogues.Add(FindObjectKey, FindObjectText);
        }

        private void SetGhostDialogues() {
            ghostDialogues.Add(KeyClueKey1, KeyClueText1);
            ghostDialogues.Add(KeyClueKey2, KeyClueText2);
        }

        public string GetDialogue([CanBeNull] string character, string keyDialogue) {
            switch (character) {
                case JhonCharacter: return jhonsDialogues[keyDialogue];
                case GhostCharacter: return ghostDialogues[keyDialogue];
                default: return gameDialogues[keyDialogue]; 
            } 
        }
        
        public string[] GetDialogues([CanBeNull] string character) {
            switch (character) {
                case JhonCharacter: return jhonsDialogues.Values.ToArray();
                case GhostCharacter: return ghostDialogues.Values.ToArray();
                default: return gameDialogues.Values.ToArray(); 
            } 
        }
    }
}