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
                                                "-Ayudalo a encontrar pistas para poder salir...";

        //Characters
        public const String JhonCharacter = "Jhon";
        public const String GhostCharacter = "Ghost";
        
        // Jhon's Keys
        public const string EmptyWardrobeKey = "EMPTY_WARDROBE";
        public const string FindObjectKey = "FIND_OBJECT";

        //Ghost Keys
        public const string KeyClueKey = "KEY_CLUE1";

        //Jhon's Dialogues
        private const String EmptyWardrobeText = "Parece que aquí no hay nada...";
        private const String FindObjectText = "Encontré una llave!!";

        //Ghost Dialogues
        private const String KeyClueText = "Si quieres salir de aquí debes encontrar la llave que abre la puerta del gran pasillo." +
                                            "-Ah! pero ten cuidado con los fantasmas. No todos son amigables como yo!" +
                                            "-Te voy a contar un secreto... " +
                                            "-Los fantasmas guardan en los armarios muchas cosas que se encuentran...";

        private Dictionary<String, String> jhonsDialogues = new();
        private Dictionary<String, String> ghostDialogues = new();
        private Dictionary<String, String> gameDialogues = new();

        public Dialogues() {
            SetJhonsDialogues();
            SetGhostDialogues();
            SetGameDialogues();
        }

        private void SetGameDialogues() {
            gameDialogues.Add(Key_GameInstructions, GameInstructions);
        }

        private void SetJhonsDialogues() {
            jhonsDialogues.Add(EmptyWardrobeKey, EmptyWardrobeText);
            jhonsDialogues.Add(FindObjectKey, FindObjectText);
            jhonsDialogues.Add(Key_RedKey, hasRedKey);
            jhonsDialogues.Add(Key_NoKey, hasNoKeys);
        }

        private void SetGhostDialogues() {
            ghostDialogues.Add(KeyClueKey, KeyClueText);
        }

        public string GetDialogue([CanBeNull] string character, string keyDialogue) {
            switch (character) {
                case JhonCharacter: return jhonsDialogues[keyDialogue];
                case GhostCharacter: return ghostDialogues[keyDialogue];
                default: return gameDialogues[keyDialogue]; 
            } 
        }
    }
}